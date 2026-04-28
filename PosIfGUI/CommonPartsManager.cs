using System;
using System.Linq;
using System.Windows.Forms;
using PosIfGUI.Constants;
using PosIfGUI.UserControls;
using PosIfRegister;

namespace PosIfGUI
{
    //　共通コンポネント用のマネージャー
    public class CommonPartsManager
    {
        private readonly UITestToolForm form;
        private readonly MainManager mainManager;
        public CommonPartsManager(UITestToolForm form, MainManager mainManager)
        {
            this.form = form;
            this.mainManager = mainManager;
        }

        public void ShowPaymentMethodConfirmation(string method)
        {
            // add switch for every payment type
            ConfirmPaymentMethod confirmMethod = new ConfirmPaymentMethod();
            confirmMethod.buttonClicked += async (s, e) =>
            {
                await form.businessTask.RequestDisplayWithResult(
                            TradeTypeEnum.Check, "btConfirm", "O K", "click", form.CurrentPackageName);
                ShowProcessingScreen(method);
            };
            switch (method)
            {
                case "credit":
                    confirmMethod.image = Properties.Resources.ic_credit_logo;
                    break;
                case "aeongift":
                    confirmMethod.image = Properties.Resources.ic_aeon_card;
                    break;
                default:
                    break;
            }
            confirmMethod.price = "決済対象金額";
            confirmMethod.priceAmount = "¥" + form.currentTransactionAmount;
            confirmMethod.total = "買上総額";
            confirmMethod.totalAmount = "¥" + form.currentTransactionAmount;
            confirmMethod.Dock = DockStyle.Fill;
            form.AddToPOSView(confirmMethod);
            addBackAndCancel();
            form.PreviousScreenId = ScreenIdConstants.paymentOptionsScreenId;
            form.CurrentScreenId = ScreenIdConstants.confirmPaymentScreenId;
            form.CurrentPackageName = ScreenIdConstants.defaultPackageId;
        }

        //　処理画面
        async private void ShowProcessingScreen(string method)
        {
            ProcessingScreen processingScreen = new ProcessingScreen();
            processingScreen.Dock = DockStyle.Fill;
            form.AddToPOSView(processingScreen);
            // switch here depending on the selected payment method
            switch (method)
            {
                case "credit":
                    await form.businessTask.waitScreenChangesTo(ScreenIdConstants.readCreditCardScreenId);
                    mainManager.creditManager.ShowReadCreditCard();
                    break;
                case "aeongift":
                    await form.businessTask.waitScreenChangesTo(ScreenIdConstants.readAeonGiftCardScreenId);
                    mainManager.aeonCardManager.ShowReadAeonCard();
                    break;
                default:
                    break;
            }

        }



        //バック押下イベント
        async private void BackClick(object sender, EventArgs e)
        {
            // check previous screen and switch display based on it
            await form.businessTask.RequestDisplayWithResult(
                               TradeTypeEnum.Check, "btnBackspace", "", "click", form.CurrentPackageName);
            Back();
        }
        //バック
        private void Back()
        {
            switch (form.PreviousScreenId)
            {
                case ScreenIdConstants.mainMenuScreenId:
                    form.DisplayDefaultStateText();
                    break;
                case ScreenIdConstants.paymentOptionsScreenId:
                    mainManager.ShowPaymentOptions();
                    break;
                case ScreenIdConstants.confirmPaymentScreenId:
                    mainManager.commonPartsManager.ShowPaymentMethodConfirmation(form.currentTransaction);
                    break;
                case ScreenIdConstants.readCreditCardScreenId:
                    mainManager.creditManager.ShowReadCreditCard();
                    break;
                case ScreenIdConstants.readAeonGiftCardScreenId:
                    mainManager.aeonCardManager.ShowReadAeonCard();
                    break;
                default:
                    break;
            }
        }
        //キャンセル押下
        async private void Cancel(object sender, EventArgs e)
        {
            string[] btnImgCancelIds = { ScreenIdConstants.paymentOptionsScreenId, ScreenIdConstants.confirmPaymentScreenId };
            string[] btnCancelIds = { ScreenIdConstants.readAeonGiftCardScreenId, ScreenIdConstants.readCreditCardScreenId, ScreenIdConstants.executeAeonGiftPaymentScreenId, ScreenIdConstants.executeSinglePaymentCreditCardPaymentScreenId };
            //cancel Buttons id differs depending on the screen
            if (btnImgCancelIds.Contains(form.CurrentScreenId))
            {
                await form.businessTask.RequestDisplayWithResult(
                              TradeTypeEnum.Check, "btnImgCancel", "", "click", form.CurrentPackageName);
            }
            else if (btnCancelIds.Contains(form.CurrentScreenId))
            {
                await form.businessTask.RequestDisplayWithResult(
                                 TradeTypeEnum.Check, "btnCancel", "中止", "click", form.CurrentPackageName);
            }
            // show cancel modal POS side
            ShowCancelModal();

        }

        //キャンセルモーダル
        public void ShowCancelModal()
        {
            CancelModal cancelModal = new CancelModal();
            cancelModal.Dock = DockStyle.Fill;
            cancelModal.button1Clicked += CancelModalBack;
            cancelModal.button2Clicked += CancelModalOK;
            form.ClearPOSView();
            form.AddToPOSView(cancelModal);
        }

        //キャンセルモーダルバック押下
        async private void CancelModalBack(object sender, EventArgs e)
        {
            // show previous screen
            await form.businessTask.RequestDisplayWithResult(
                               TradeTypeEnum.Check, "btnBack", "", "click", form.CurrentPackageName);
            switch (form.CurrentScreenId)
            {
                case ScreenIdConstants.mainMenuScreenId:
                    form.DisplayDefaultStateText();
                    break;
                case ScreenIdConstants.paymentOptionsScreenId:
                    mainManager.ShowPaymentOptions();
                    break;
                case ScreenIdConstants.confirmPaymentScreenId:
                    mainManager.commonPartsManager.ShowPaymentMethodConfirmation(form.currentTransaction);
                    break;
                case ScreenIdConstants.readAeonGiftCardScreenId:
                    mainManager.aeonCardManager.ShowReadAeonCard();
                    break;
                default:
                    break;
            }
        }

        //キャンセルモーダルOK押下
        async private void CancelModalOK(object sender, EventArgs e)
        {
            await form.businessTask.RequestDisplayWithResult(
                                TradeTypeEnum.Check, "btnSubmit", "O K", "click", form.CurrentPackageName);
            form.DisplayDefaultStateText();
        }

        //　バックとキャンセルボタン表示
        public void addBackAndCancel()
        {
            BackAndCancelButtons backAndCancel = new BackAndCancelButtons();
            backAndCancel.button1Clicked += BackClick;
            backAndCancel.button2Clicked += Cancel;
            backAndCancel.Dock = DockStyle.Fill;
            form.AddToBackAndCancelButtonLayout(backAndCancel);
        }

        //前の取引が同じ内容の場合はのモーダル
        public void showPreviousTransactionSamePopup()
        {
            GenericPopupDoubleButton popup = new GenericPopupDoubleButton();
            popup.Title = "注意喚起ポップアップ";
            popup.ContentText = "前回の取引と同じ内容です。継続する場合はOKを押下してください。";
            popup.buttonClicked += BackButtonClickedSameTransactionPopup;
            popup.button2Clicked += OKButtonClickedSameTransactionPopup;
            popup.Dock = DockStyle.Fill;
            form.PreviousScreenId = form.CurrentScreenId;
            form.AddToPOSView(popup);
        }

        //前回取引のモーダルのバック押下
        async private void BackButtonClickedSameTransactionPopup(object sender, EventArgs e)
        {
            await form.businessTask.RequestDisplayWithResult(
                               TradeTypeEnum.Check, "btnBack", "", "click", form.CurrentPackageName);
            Back();
        }

        //前回取引のモーダルのOK押下
        async private void OKButtonClickedSameTransactionPopup(object sender, EventArgs e)
        {
            await form.businessTask.RequestDisplayWithResult(
                               TradeTypeEnum.Check, "btnSubmit", "O K", "click", form.CurrentPackageName);

            switch (form.currentTransaction)
            {
                case "credit":
                    mainManager.creditManager.ShowCreditCardOptions();
                    break;
                case "aeongift":
                    mainManager.aeonCardManager.ShowProcessAeonCard();
                    break;
                default:
                    break;
            }
        }

        //タイムアウトモーダル
        public void showTimeoutPopup()
        {
            GenericPopup popup = new GenericPopup();
            popup.Title = "タイムアウト";
            popup.ContentText = "カードを読み取っていただくようご案内ください。";
            popup.buttonClicked += dismissOkPopup;
            popup.Dock = DockStyle.Fill;
            form.PreviousScreenId = form.CurrentScreenId;
            form.AddToPOSView(popup);
        }

        //エラー発生時モーダル
        public void showErrorPopup()
        {
            ErrorPopup popup = new ErrorPopup();
            popup.Title = "読み取りエラー";
            popup.ContentText = "従業員を呼び出してください。";
            popup.ButtonText = "呼び出し";
            popup.buttonClicked += DismissAndWaitForClerk;
            popup.Dock = DockStyle.Fill;
            form.PreviousScreenId = form.CurrentScreenId;
            form.AddToPOSView(popup);
        }

        //従業員操作が必要時のモーダル
        async public void DismissAndWaitForClerk(object sender, EventArgs e)
        {
            // display waiting screen and await screen back to card read
            LabelControl waitingLabel = new LabelControl();
            waitingLabel.Dock = DockStyle.Fill;
            waitingLabel.Text = "ただいま従業員が確認のために参ります。\nしばらくお待ちください。";
            form.AddToPOSView(waitingLabel);
            // wait for A8700 screen to go back to card read after mode3
            // TO DO update depending on the previous screen
            await form.businessTask.waitScreenChangesTo(form.PreviousScreenId);
            //change screen back to readCard
            switch (form.currentTransaction)
            {
                case "aeongift":
                    mainManager.aeonCardManager.ShowReadAeonCard();
                    break;
                case "credit":
                    mainManager.creditManager.ShowReadCreditCard();
                    break;
                default:
                    break;
            }

        }

        //従業員操作が必要時のモーダル
        async private void dismissOkPopup(object sender, EventArgs e)
        {
            await form.businessTask.RequestDisplayWithResult(
                                TradeTypeEnum.Check, "btnSingleSubmit", "O K", "click", form.CurrentPackageName);
            Back();
        }

        //処理画面②
        async public void ShowProcessingScreen2()
        {
            ProcessingScreen processingScreen = new ProcessingScreen();
            processingScreen.Dock = DockStyle.Fill;
            form.AddToPOSView(processingScreen);
            await form.businessTask.waitScreenChangesTo(ScreenIdConstants.paymentSuccessful);
            showPaymentSuccessful();
        }
        //決済完了
        public void showPaymentSuccessful()
        {
            form.CurrentPackageName = ScreenIdConstants.defaultPackageId;
            PaymentSuccessful paymentSuccessful = new PaymentSuccessful();
            paymentSuccessful.Dock = DockStyle.Fill;
            paymentSuccessful.buttonClicked += async (sender, e) =>
            {
                await form.businessTask.RequestDisplayWithResult(
                           TradeTypeEnum.Check, "btnSubmit", "O K", "click", form.CurrentPackageName);
                // send back to main screen
                form.currentTransaction = "";
                form.DisplayDefaultStateText();
            };
            form.AddToPOSView(paymentSuccessful);
        }
    }
}
