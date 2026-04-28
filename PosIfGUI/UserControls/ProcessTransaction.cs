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
    public partial class ProcessTransaction : UserControl
    {
        public event EventHandler buttonClicked;

        public string text1
        {
            get => label1.Text;
            set => label1.Text = value;
        }
        public string text2
        {
            get => label2.Text;
            set => label2.Text = value;
        }
        public string text3
        {
            get => label3.Text;
            set => label3.Text = value;
        }
        public string text4
        {
            get => label4.Text;
            set => label4.Text = value;
        }

        public string text5
        {
            get => label5.Text;
            set => label5.Text = value;
        }
        public string text6
        {
            get => label6.Text;
            set => label6.Text = value;
        }
        public string text7
        {
            get => label7.Text;
            set => label7.Text = value;
        }
        public string text8
        {
            get => label8.Text;
            set => label8.Text = value;
        }
        public ProcessTransaction()
        {
            InitializeComponent();
            button1.Click += (s, e) =>
            {
                buttonClicked.Invoke(this, e);
            };
        }
    }
}
