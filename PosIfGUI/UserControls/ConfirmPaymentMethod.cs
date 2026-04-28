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
    public partial class ConfirmPaymentMethod : UserControl
    {
        public string total
        {
            get => label1.Text;
            set => label1.Text = value;
        }
        public string totalAmount
        {
            get => label2.Text;
            set => label2.Text = value;
        }
        public string price
        {
            get => label3.Text;
            set => label3.Text = value;
        }
        public string priceAmount
        {
            get => label4.Text;
            set => label4.Text = value;
        }
        public Image image
        {
            get => pictureBox1.Image;
            set => pictureBox1.Image = value;
        }

        public event EventHandler buttonClicked;
        public ConfirmPaymentMethod()
        {
            InitializeComponent();
            button1.Click += (s, e) =>
            {
                buttonClicked.Invoke(this, e);
            };
        }
    }
}
