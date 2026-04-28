using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PosIfGUI.Constants;
using PosIfGUI.UserControls;
using PosIfRegister;

namespace PosIfGUI
{
    public class AeonCardManager
    {
        private readonly UITestToolForm form;
        private readonly MainManager mainManager;
        public AeonCardManager(UITestToolForm form, MainManager mainManager)
        {
            this.form = form;
            this.mainManager = mainManager;
        }

        async public void ShowReadAeonCard()
        {
            PaymentRead read = new PaymentRead();
            read.image = Properties.Resources.ic_aeon_card;
            read.Dock = DockStyle.Fill;
            form.AddToPOSView(read);
            form.PreviousScreenId = ScreenIdConstants.confirmPaymentScreenId;
            form.CurrentScreenId = ScreenIdConstants.readAeonGiftCardScreenId;
            form.CurrentPackageName = ScreenIdConstants.aeonGiftPackageName;
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
                case ScreenIdConstants.executeAeonGiftPaymentScreenId:
                    ShowProcessAeonCard();
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

        public void ShowProcessAeonCard()
        {
            ProcessTransaction processTransaction = new ProcessTransaction();
            processTransaction.Dock = DockStyle.Fill;
            processTransaction.text1 = "買上総額";
            processTransaction.text2 = "¥" + form.currentTransactionAmount;
            processTransaction.text3 = "決済対象金額";
            processTransaction.text4 = "¥" + form.currentTransactionAmount;
            processTransaction.text5 = "カード会社";
            processTransaction.text6 = "ギフトカード";
            processTransaction.text7 = "取扱金額";
            processTransaction.text8 = "¥" + form.currentTransactionAmount;
            processTransaction.buttonClicked += async (sender, e) =>
            {
                await form.businessTask.RequestDisplayWithResult(
                            TradeTypeEnum.Check, "btnSubmit", "実 行", "click", form.CurrentPackageName);
                await form.businessTask.SendBusiness111ResponseAsync();
                mainManager.commonPartsManager.ShowProcessingScreen2();
            };
            form.CurrentPackageName = ScreenIdConstants.aeonGiftPackageName;
            form.PreviousScreenId = ScreenIdConstants.readAeonGiftCardScreenId;
            form.CurrentScreenId = ScreenIdConstants.executeAeonGiftPaymentScreenId;
            form.AddToPOSView(processTransaction);
            mainManager.commonPartsManager.addBackAndCancel();
        }
    }
}
