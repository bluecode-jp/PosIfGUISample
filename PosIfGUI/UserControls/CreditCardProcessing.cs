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
    public partial class CreditCardProcessing : UserControl
    {
        public string uriagesougaku
        {
            get => label2.Text;
            set => label2.Text = value;
        }
        public string kessaitaishoukingaku
        {
            get => label4.Text;
            set => label4.Text = value;
        }
        public string shiharaikingaku
        {
            get => label8.Text;
            set => label8.Text = value;
        }
        public string cardcompany
        {
            get => label12.Text;
            set => label12.Text = value;
        }
        public event EventHandler buttonClicked;
        public CreditCardProcessing()
        {
            InitializeComponent();
            button1.Click += (s, e) =>
            {
                buttonClicked.Invoke(this, e);
            };
        }
    }
}
