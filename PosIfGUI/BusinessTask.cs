//
// Copyright (c) 2025, 合同会社玉木栄三郎事務所.
// All rights reserved.
//

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PosIfRegister;
using PosIfGUI.Constants;
using static PosIfRegister.PosIfCom;
using System.Linq;

namespace PosIfGUI

{
    public class BusinessTask
    {
        private UITestToolForm form;
        private static readonly SemaphoreSlim posCommLock = new SemaphoreSlim(1, 1);
        private static int _seqNoCounter = 1;

        private static int GeneratePosSeqNo()
        {
            // 0 ～ 1,073,741,823 の範囲で回す（POS側領域）
            if (_seqNoCounter >= 1073741823)
                _seqNoCounter = 1;
            return _seqNoCounter++;
        }

        // クラス内の共通 MessageJson（seqNo付き）を初期化して持っておく
        private MessageJson CreateMessageJson()
        {
            var msgJson = new MessageJson();
            msgJson.MsgJsonData.seqNo = GeneratePosSeqNo(); // ★ ここでPOS用 seqNo を設定
            return msgJson;
        }

        public BusinessTask(UITestToolForm form)
        {
            this.form = form;
        }

        // ACK 送信用の汎用関数
        private void SendAckForRaw(JObject original)
        {
            var ack = new JObject
            {
                ["transactionType"] = 10,
                ["seqNo"] = original["seqNo"],
                ["businessType"] = original["businessType"]
            };

            var dummy = new JObject();
            int bt = (int)(original["businessType"] ?? -1);

            switch (bt)
            {
                case 100:
                    form.posif.ConnectCheckModeSelf(ack, ref dummy);
                    break;
                case 102:
                    form.posif.ChangeOperationMode(ack, ref dummy);
                    break;
                case 110:
                    form.posif.RequestPayment_Alias(ack, ref dummy);
                    break;
                case 111:
                    form.posif.PaymentResultCheck_Alias(ack, ref dummy);
                    break;
                case 200:
                    form.posif.RequestDisplay_Alias(ack, ref dummy);
                    break;
            }

            Console.WriteLine($"[Send] ACK (bt:{bt}) : {ack}");
        }

        // 接続確認関数
        public async Task<bool> ConnectCheckModeSelfAsync(TradeTypeEnum nTradeType)
        {
            for (int retry = 0; retry < 3; retry++)
            {
                var MsgJson = CreateMessageJson();
                var send_json_obj = MsgJson.GetMsgObjConnectCheckModeSelf(nTradeType);

                ResultSelfModeEnum result;
                JObject recv = new JObject();

                await posCommLock.WaitAsync();
                try
                {
                    result = form.posif.ConnectCheckModeSelf(send_json_obj, ref recv);

                    if (result == ResultSelfModeEnum.Normal)
                    {
                        // 🔽 ACK 送信（ロック内で）
                        var ackJson = MsgJson.GetMsgObjConnectCheckModeSelf(TradeTypeEnum.Ack);
                        var dummy = new JObject();
                        form.posif.ConnectCheckModeSelf(ackJson, ref dummy);
                        Console.WriteLine($"[Send] ConnectCheck ACK: {ackJson}");
                        return true;
                    }
                }
                finally
                {
                    posCommLock.Release();
                }
            }

            return false;
        }

        // モード切替関数

        public async Task<JObject> ChangeOperationModeAsync(TradeTypeEnum nTradeType, int mode)
        {
            // テストツールでは簡易的に3回リトライとする
            for (int retry = 0; retry < 3; retry++)
            {
                var MsgJson = CreateMessageJson();
                var send_json_obj = MsgJson.GetMsgObjChangeOperationMode(nTradeType, mode);

                var recv = new JObject();
                ResultSelfModeEnum result;

                await posCommLock.WaitAsync();
                try
                {
                    result = form.posif.ChangeOperationMode(send_json_obj, ref recv);

                    if (result == ResultSelfModeEnum.Normal)
                    {
                        SendAckForRaw(recv);
                        return recv;
                    }
                }
                finally
                {
                    posCommLock.Release();
                }
            }

            return new JObject();
        }

        // 決済開始関数

        public async Task<bool> RequestPaymentAsync(
            TradeTypeEnum nTradeType,
            string totalAmount = "",
            bool printFlag = true,
            string salesNo = ""
        )
        {
            for (int retryCount = 0; retryCount < 2; retryCount++)
            {
                int seqNo = GeneratePosSeqNo();

                JObject dataList = new JObject
                {
                    ["totalAmount"] = totalAmount,
                    ["printFlag"] = printFlag,
                    ["salesNo"] = salesNo
                };

                JObject sendJson = new JObject
                {
                    ["transactionType"] = (int)nTradeType,
                    ["seqNo"] = seqNo,
                    ["dataList"] = dataList,
                    ["businessType"] = 110
                };

                Console.WriteLine($"[Send] PaymentRequest (seqNo: {seqNo}): {sendJson}");

                JObject recvJson = new JObject();
                ResultSelfModeEnum result;

                await posCommLock.WaitAsync();
                try
                {
                    result = form.posif.RequestPayment_Alias(sendJson, ref recvJson);
                    Console.WriteLine($"[Recv] PaymentResponse: {recvJson}");

                    if (result != ResultSelfModeEnum.Normal)
                        continue;  // ← 再送


                    string bizType = recvJson.Value<string>("businessType") ?? "";
                    string paymentResult = "";

                    if (recvJson.ContainsKey("dataList") &&
                        recvJson["dataList"] != null &&
                        recvJson["dataList"].Type == JTokenType.Object)
                    {
                        JObject dataListObj = (JObject)recvJson["dataList"];
                        if (dataListObj.ContainsKey("result"))
                        {
                            paymentResult = dataListObj["result"].ToString();
                        }
                    }

                    if (bizType == "110" && paymentResult == "1")
                    {
                        Console.WriteLine("[Warn] 決済開始拒否 → 111送ってリトライ");
                        await SendBusiness111ResponseAsync();
                        await Task.Delay(100);
                        continue;
                    }

                    form.HasEverStartedPayment = true;
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Error] RequestPayment 例外: {ex.Message}");
                }
                finally
                {
                    posCommLock.Release();
                }
            }

            Console.WriteLine("[Error] 2回試しても開始できず");
            return false;
        }

        // 画面情報取得用関数
        public async Task<string> RequestDisplayWithResult(
            TradeTypeEnum nTradeType,
            string viewId = "",
            string viewText = "",
            string action = "",
            string packageName = "",
            bool ignoreTimeout = false)
        {
            while (true)
            {
                await posCommLock.WaitAsync();

                int seqNo = GeneratePosSeqNo();

                try
                {
                    JObject dataList = new JObject
                    {
                        ["viewId"] = viewId,
                        ["viewText"] = viewText,
                        ["action"] = action,
                        ["packageName"] = packageName
                    };

                    if (ScreenIdConstants.TenkeyScreenIds.Contains(form.CurrentScreenId) && viewId == "btnSubmit")
                    {
                        dataList["viewId"] = "dummyButton_" + form.CurrentScreenId;
                        dataList["viewText"] = "";

                        if (!string.IsNullOrEmpty(form.TenkeyInputBuffer))
                        {
                            dataList["concatData"] = form.TenkeyInputBuffer;
                        }
                    }

                    JObject sendJson = new JObject
                    {
                        ["transactionType"] = (int)nTradeType,
                        ["seqNo"] = seqNo,
                        ["dataList"] = dataList,
                        ["businessType"] = 200
                    };

                    Console.WriteLine($"[Send] RequestDisplayWithResult: {sendJson}");


                    try
                    {
                        for (int attempt = 0; attempt < 2; attempt++)
                        {
                            var recvJson = new JObject();
                            var result = form.posif.RequestDisplay_Alias(sendJson, ref recvJson);

                            if (result == ResultSelfModeEnum.Normal || result == ResultSelfModeEnum.Exception)
                            {
                                SendAckForRaw(recvJson);

                                if (result == ResultSelfModeEnum.Normal)
                                {
                                    if (form.HasEverStartedPayment)
                                    {
                                        await SendBusiness111ResponseAsync();
                                    }

                                    return recvJson.ToString();
                                }
                                else
                                {
                                    return "";
                                }
                            }

                            if (attempt == 0 && !ignoreTimeout)
                                await Task.Delay(150);
                            else
                                break;
                        }
                    }
                    finally
                    { }
                }
                finally
                {
                    posCommLock.Release();
                }
            }
        }

        async public Task waitScreenChangesTo(string screenId)
        {
            string currentScreenId = "";
            string json = "";
            /*for (int i = 0; i < 10; i++)
            {
                if (!string.IsNullOrEmpty(json))
                {
                    var root = JObject.Parse(json);
                    var si = root?["dataList"]?["screenInfo"]?["SI"]?.ToString();

                    if (!string.IsNullOrEmpty(si))
                    {
                        currentScreenId = si;
                    }
                    else
                    {
                        Console.WriteLine($"⚠ 無効なSI: {si} → 再受信リトライ");
                    }
                }
                await Task.Delay(1000);
            }
            return;*/
            while (screenId != currentScreenId)
            {
                json = await RequestDisplayWithResult(
    TradeTypeEnum.Check, "", "", "screenRequest", "", ignoreTimeout: true);

                if (!string.IsNullOrEmpty(json))
                {
                    var root = JObject.Parse(json);
                    var si = root?["dataList"]?["screenInfo"]?["SI"]?.ToString();

                    if (!string.IsNullOrEmpty(si))
                    {
                        currentScreenId = si;
                    }
                    else
                    {
                        Console.WriteLine($"⚠ 無効なSI: {si} → 再受信リトライ");
                    }
                }
                await Task.Delay(500);
            }
            return;

        }

        async public Task<string> waitTillScreenChangesFromCurrent(string currentScreenId)
        {
            string arrivingScreenId = currentScreenId;
            string json = "";

            while (currentScreenId == arrivingScreenId || arrivingScreenId == ScreenIdConstants.loadingScreenId)
            {
                json = await RequestDisplayWithResult(
    TradeTypeEnum.Check, "", "", "screenRequest", "", ignoreTimeout: true);

                if (!string.IsNullOrEmpty(json))
                {
                    var root = JObject.Parse(json);
                    var si = root?["dataList"]?["screenInfo"]?["SI"]?.ToString();
                    JArray screenElements = root?["dataList"]?["screenInfo"]?["EL"] as JArray;
                    var screenElement=screenElements.Where(item => (string)item["VI"]=="tvTitle").Count()==1? screenElements.Where(item => (string)item["VI"] == "tvTitle").First(): null;
                    if (screenElement != null)
                    {
                        string title = (string)screenElement["VTX"];
                        bool popupIsError = title == "エラーポップアップ";
                        bool popupIsPreviousTransactionSame = title == "注意喚起ポップアップ";
                        bool popupIsTimeout = title== "タイムアウト";

                        if (popupIsTimeout)
                        {
                            arrivingScreenId = "timeout";
                            break;
                        }
                        if (popupIsError)
                        {
                            arrivingScreenId = "error";
                            break;
                        }
                        if (popupIsPreviousTransactionSame)
                        {
                            arrivingScreenId = "previous";
                            break;
                        }

                    }

                    if (!string.IsNullOrEmpty(si))
                    {
                        arrivingScreenId = si;
                    }
                    else
                    {
                        Console.WriteLine($"⚠ 無効なSI: {si} → 再受信リトライ");
                    }
                }
                await Task.Delay(500);
            }
            return arrivingScreenId;
        }

        /*async public Task<ScreenState> waitScreenChangesToOrException(string screenId, string exceptionId)
        {
            string currentScreenId = "";
            string json = "";
            for (int i = 0; i < 10; i++)
            {
                if (!string.IsNullOrEmpty(json))
                {
                    var root = JObject.Parse(json);
                    var si = root?["dataList"]?["screenInfo"]?["SI"]?.ToString();

                    if (!string.IsNullOrEmpty(si))
                    {
                        currentScreenId = si;
                    }
                    else
                    {
                        Console.WriteLine($"⚠ 無効なSI: {si} → 再受信リトライ");
                    }
                }
                await Task.Delay(1000);
            }
            return;
            while (screenId != currentScreenId || exceptionId != currentScreenId)
            {
                json = await RequestDisplayWithResult(
    TradeTypeEnum.Check, "", "", "screenRequest", "", ignoreTimeout: true);

                if (!string.IsNullOrEmpty(json))
                {
                    var root = JObject.Parse(json);
                    var si = root?["dataList"]?["screenInfo"]?["SI"]?.ToString();

                    if (!string.IsNullOrEmpty(si))
                    {
                        currentScreenId = si;
                    }
                    else
                    {
                        Console.WriteLine($"⚠ 無効なSI: {si} → 再受信リトライ");
                    }
                }
                await Task.Delay(500);
            }
            if (screenId == currentScreenId)
            {
                return ScreenState.Success;
            }
            if (screenId == exceptionId)
                return ScreenState.Unexpected;
            return ScreenState.Error;
        }*/

        // 現金決済画面用の画面情報取得用関数
        public async Task<string> RequestDisplayWithResult(
            TradeTypeEnum nTradeType,
            JObject customDataList,
            int businessType = 200)
        {
            while (true)
            {
                await posCommLock.WaitAsync();

                int seqNo = GeneratePosSeqNo();

                try
                {
                    JObject sendJson = new JObject
                    {
                        ["transactionType"] = (int)nTradeType,
                        ["seqNo"] = seqNo,
                        ["dataList"] = customDataList,
                        ["businessType"] = businessType
                    };

                    Console.WriteLine($"[Send] RequestDisplayWithResult (custom): {sendJson}");

                    try
                    {
                        for (int attempt = 0; attempt < 2; attempt++)
                        {
                            var recvJson = new JObject();
                            var result = form.posif.RequestDisplay_Alias(sendJson, ref recvJson);

                            if (result == ResultSelfModeEnum.Normal || result == ResultSelfModeEnum.Exception)
                            {
                                SendAckForRaw(recvJson);

                                if (result == ResultSelfModeEnum.Normal)
                                {
                                    if (form.HasEverStartedPayment)
                                    {
                                        await SendBusiness111ResponseAsync();
                                    }

                                    return recvJson.ToString();
                                }
                                else
                                {
                                    return "";
                                }
                            }

                            if (attempt == 0)
                                await Task.Delay(150);
                            else
                                break;
                        }
                    }
                    finally
                    { }
                }
                finally
                {
                    posCommLock.Release();
                }
            }
        }

        // 決済結果確認用関数
        public async Task SendBusiness111ResponseAsync()
        {
            int seqNo = GeneratePosSeqNo();

            JObject request = new JObject
            {
                ["transactionType"] = 0,
                ["seqNo"] = seqNo,
                ["dataList"] = null,
                ["businessType"] = 111
            };

            JObject response = new JObject();

            try
            {
                await Task.Run(() =>
                {
                    var result = form.posif.PaymentResultCheck_Alias(request, ref response);

                    if (result == ResultSelfModeEnum.Normal)
                    {
                        Console.WriteLine($"[SendBusiness111Response] Response: {response}");

                        SendAckForRaw(response);  // 応答にACK送信

                        string concat = "";
                        if (response.ContainsKey("dataList") &&
                            response["dataList"] is JObject dataList &&
                            dataList.ContainsKey("concatData"))
                        {
                            concat = dataList["concatData"].ToString();
                        }

                        if (concat.StartsWith("2,N101") || concat.StartsWith("0,N001"))
                        {
                            Console.WriteLine("[INFO] POS業務終了 → hasEverStartedPayment = false");
                            form.HasEverStartedPayment = false;
                        }
                        else if (concat != "")
                        {
                            Console.WriteLine("[INFO] POS業務継続中 → hasEverStartedPayment 維持");
                        }
                    }
                    else
                    {
                        Console.WriteLine("[Warn] SendBusiness111Response: 通信失敗");
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error] SendBusiness111Response 例外: {ex.Message}");
            }
        }

    }
}
