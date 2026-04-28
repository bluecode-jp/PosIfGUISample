using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using PosIfGUI.Constants;
using PosIfGUI.UserControls;
using PosIfRegister;

namespace PosIfGUI
{
    public class CreditManager
    {
        private readonly UITestToolForm form;
        private readonly MainManager mainManager;
        public CreditManager(UITestToolForm form, MainManager mainManager)
        {
            this.form = form;
            this.mainManager = mainManager;
        }

        async public void ShowReadCreditCard()
        {
            PaymentRead read = new PaymentRead();
            read.image = Properties.Resources.credit_guide_animation;
            read.Dock = DockStyle.Fill;
            form.AddToPOSView(read);
            form.PreviousScreenId = ScreenIdConstants.confirmPaymentScreenId;
            form.CurrentScreenId = ScreenIdConstants.readCreditCardScreenId;
            form.CurrentPackageName = ScreenIdConstants.creditCardPackageName;
            mainManager.commonPartsManager.addBackAndCancel();

            // 画面切り替え待ち
            string newScreen = await form.businessTask.waitTillScreenChangesFromCurrent(form.CurrentScreenId);
            // ケース複数
            // 1-カード読み取り成功
            // 2-前回と同じ取引
            // 3-カード読み取りエラー
            // 4-タイムアウト
            // 更新後の画面により、Windows側で更新
            switch (newScreen)
            {
                case ScreenIdConstants.creditCardPaymentOptionsScreenId:
                    ShowCreditCardOptions();
                    break;
                case "error":
                    mainManager.commonPartsManager.showErrorPopup();
                    break;
                case "timeout":
                    mainManager.commonPartsManager.showTimeoutPopup();
                    break;
                case "previous":
                    mainManager.commonPartsManager.showPreviousTransactionSamePopup();
                    break;
                default:
                    break;
            }
        }

        public void ShowCreditCardOptions()
        {
            CreditCardOptions options = new CreditCardOptions();
            options.Dock = DockStyle.Fill;
            options.oneTimeClicked += async (sender, e) =>
            {
                await form.businessTask.RequestDisplayWithResult(
                           TradeTypeEnum.Check, "btn_category_1", "一括払い", "click", form.CurrentPackageName);
                var json = await form.businessTask.RequestDisplayWithResult(TradeTypeEnum.Check, "", "", "screenRequest", "");
                var root = JObject.Parse(json);
                var elem = root?["dataList"]?["screenInfo"]?["EL"];
                JArray screenElements = root?["dataList"]?["screenInfo"]?["EL"] as JArray;
                var cardCompanyJObject = screenElements.Where(item => (string)item["VI"] == "pitCardCompany_val").Count() == 1 ? screenElements.Where(item => (string)item["VI"] == "pitCardCompany_val").First() : null;
                var cardCompany = "";
                if (cardCompanyJObject != null)
                    cardCompany = (string)cardCompanyJObject["VTX"];
                ShowCreditCardProcess(cardCompany);
            };
            form.CurrentPackageName = ScreenIdConstants.creditCardPackageName;
            form.PreviousScreenId = ScreenIdConstants.readCreditCardScreenId;
            form.CurrentScreenId = ScreenIdConstants.creditCardPaymentOptionsScreenId;
            form.AddToPOSView(options);
            mainManager.commonPartsManager.addBackAndCancel();
        }
        public void ShowCreditCardProcess(string company = "")
        {
            CreditCardProcessing screen = new CreditCardProcessing();
            screen.Dock = DockStyle.Fill;
            screen.uriagesougaku = "¥" + form.currentTransactionAmount;
            screen.kessaitaishoukingaku = "¥" + form.currentTransactionAmount;
            screen.shiharaikingaku = "¥" + form.currentTransactionAmount;
            screen.cardcompany = company;

            screen.buttonClicked += async (sender, e) => {
                await form.businessTask.RequestDisplayWithResult(
                            TradeTypeEnum.Check, "btnSubmit", "実 行", "click", form.CurrentPackageName);
                await form.businessTask.SendBusiness111ResponseAsync();
                mainManager.commonPartsManager.ShowProcessingScreen2();
            };
            form.AddToPOSView(screen);
            form.PreviousScreenId = ScreenIdConstants.creditCardPaymentOptionsScreenId;
            form.CurrentScreenId = ScreenIdConstants.executeSinglePaymentCreditCardPaymentScreenId;
            mainManager.commonPartsManager.addBackAndCancel();
        }
    }
}
