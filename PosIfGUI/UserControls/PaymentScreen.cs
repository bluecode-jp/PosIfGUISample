using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosIfGUI.UserControls
{
    public partial class PaymentScreen : UserControl
    {
        public event EventHandler cashClicked;
        public event EventHandler creditClicked;
        public event EventHandler electronicMoneyClicked;
        public event EventHandler aeonGiftClicked;
        public event EventHandler aeonCardClicked;
        public event EventHandler codeClicked;
        public event EventHandler ginrenClicked;
        public event EventHandler waonPointClicked;


        public string price
        {
            get => priceLabel.Text;
            set => priceLabel.Text = value;
        }
        public PaymentScreen()
        {
            InitializeComponent();
            cash.Click += (s, e) =>
            {
                cashClicked.Invoke(this, e);
            };
            credit.Click += (s, e) =>
            {
                creditClicked.Invoke(this, e);
            };
            electronicMoney.Click += (s, e) =>
            {
                electronicMoneyClicked.Invoke(this, e);
            };
            aeonGift.Click += (s, e) =>
            {
                aeonGiftClicked.Invoke(this, e);
            };
            aeonCard.Click += (s, e) =>
            {
                aeonCardClicked.Invoke(this, e);
            };
            code.Click += (s, e) =>
            {
                codeClicked.Invoke(this, e);
            };
            ginren.Click += (s, e) =>
            {
                ginrenClicked.Invoke(this, e);
            };
            waonPoint.Click += (s, e) =>
            {
                waonPointClicked.Invoke(this, e);
            };
        }
    }
}
