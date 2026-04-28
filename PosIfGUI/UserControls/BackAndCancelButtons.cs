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
    public partial class BackAndCancelButtons : UserControl
    {
        public event EventHandler button1Clicked;
        public event EventHandler button2Clicked;
        public BackAndCancelButtons()
        {
            InitializeComponent();
            button1.Click += (s, e) =>
            {
                button1Clicked.Invoke(this, e);
            };
            button2.Click += (s, e) =>
            {
                button2Clicked.Invoke(this, e);
            };
        }

    }
}
