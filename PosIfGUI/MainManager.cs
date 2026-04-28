//
// Copyright (c) 2025, 合同会社玉木栄三郎事務所.
// All rights reserved.
//

using System;
using System.Windows.Forms;
using PosIfGUI.Constants;
using PosIfGUI.UserControls;
using PosIfRegister;

namespace PosIfGUI
{

    public class MainManager
    {
        private readonly UITestToolForm form;

        // 共通パーツマネージャー
        public readonly CommonPartsManager commonPartsManager;

        // それぞれのマネージャー
        public readonly AeonCardManager aeonCardManager;
        public readonly CreditManager creditManager;

        public MainManager(UITestToolForm form)
        {
            this.form = form;
            this.commonPartsManager =new CommonPartsManager(form,this);
            this.aeonCardManager = new AeonCardManager(form, this);
            this.creditManager = new CreditManager(form, this);
        }

        //　決済方法全部表示
        public void ShowPaymentOptions()
        {
            PaymentScreen paymentScreen = new PaymentScreen();
            paymentScreen.Dock = DockStyle.Fill;
            paymentScreen.cashClicked += Cash_click;
            paymentScreen.creditClicked += Credit_click;
            paymentScreen.electronicMoneyClicked += ElectronicMoney_click;
            paymentScreen.aeonGiftClicked += AeonGift_click;
            paymentScreen.aeonCardClicked += AeonCard_click;
            paymentScreen.codeClicked += Code_click;
            paymentScreen.ginrenClicked += Ginren_click;
            paymentScreen.waonPointClicked += WaonPoint_click;
            paymentScreen.price = "¥" + form.currentTransactionAmount;
            form.AddToPOSView(paymentScreen);
            commonPartsManager.addBackAndCancel();
            form.PreviousScreenId = ScreenIdConstants.mainMenuScreenId;
            form.CurrentScreenId = ScreenIdConstants.paymentOptionsScreenId;
            form.CurrentPackageName = ScreenIdConstants.defaultPackageId;
        }
        private void Cash_click(object sender, EventArgs e)
        {
            MessageBox.Show("Cash");
        }

        //　クレジット決済開始
        async private void Credit_click(object sender, EventArgs e)
        {
            form.currentTransaction = "credit";
            //　決済タイプボタン押下
            await form.businessTask.RequestDisplayWithResult(
                            TradeTypeEnum.Check, "creditMethod", "", "click", form.CurrentPackageName);
            //　画面更新待ち
            await form.businessTask.waitScreenChangesTo(ScreenIdConstants.confirmPaymentScreenId);
            commonPartsManager.ShowPaymentMethodConfirmation("credit"); //　決済タイプ

        }
        private void ElectronicMoney_click(object sender, EventArgs e)
        {
            MessageBox.Show("Emoney");

        }

        //　イオンギフト決済開始
        async private void AeonGift_click(object sender, EventArgs e)
        {
            form.currentTransaction = "aeongift";
            //　決済タイプボタン押下
            await form.businessTask.RequestDisplayWithResult(
                            TradeTypeEnum.Check, "aeonGiftMethod", "", "click", form.CurrentPackageName);
            //　画面更新待ち
            await form.businessTask.waitScreenChangesTo(ScreenIdConstants.confirmPaymentScreenId);
            commonPartsManager.ShowPaymentMethodConfirmation("aeongift");//　決済タイプ
        }
        private void AeonCard_click(object sender, EventArgs e)
        {
            MessageBox.Show("AeonCard");
        }
        private void Code_click(object sender, EventArgs e)
        {
            MessageBox.Show("Code");

        }
        private void Ginren_click(object sender, EventArgs e)
        {
            MessageBox.Show("Ginren");

        }
        private void WaonPoint_click(object sender, EventArgs e)
        {
            MessageBox.Show("WaonPoint");

        }
    }
}
