using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosIfGUI.UserControls
{
    public partial class CreditCardOptions : UserControl
    {
        public event EventHandler oneTimeClicked;
        public event EventHandler partitionClicked;
        public event EventHandler bonusClicked;
        public event EventHandler revolvingClicked;
        public event EventHandler bonusCombineClicked;
        public CreditCardOptions()
        {
            InitializeComponent();
            button1.Click += (s, e) =>
            {
                oneTimeClicked.Invoke(this, e);
            };
            button2.Click += (s, e) =>
            {
                partitionClicked.Invoke(this, e);
            };
            button3.Click += (s, e) =>
            {
                bonusClicked.Invoke(this, e);
            };
            button4.Click += (s, e) =>
            {
                revolvingClicked.Invoke(this, e);
            };
            button5.Click += (s, e) =>
            {
                bonusCombineClicked.Invoke(this, e);
            };
        }
    }
}
