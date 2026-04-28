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
    public partial class ErrorPopup : UserControl
    {
        public string Title
        {
            get => label1.Text;
            set => label1.Text = value;
        }
        public string ContentText
        {
            get => label3.Text;
            set => label3.Text = value;
        }
        public string ButtonText
        {
            get => button1.Text;
            set => button1.Text = value;
        }
        public event EventHandler buttonClicked;
        public ErrorPopup()
        {
            InitializeComponent();
            button1.Click += (s, e) =>
            {
                buttonClicked.Invoke(this, e);
            };
        }
    }
}
