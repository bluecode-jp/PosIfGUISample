using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosIfGUI.UserControls
{
    public partial class Method : UserControl
    {

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Title
        {
            get => label1.Text;
            set => label1.Text = value;
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image image
        {
            get => pictureBox1.Image;
            set => pictureBox1.Image = value;
        }
        public Method()
        {
            InitializeComponent();
            WireAllControls(this);
            this.EnabledChanged += new System.EventHandler(this.MyUserControl_EnabledChanged);
        }
        private void MyUserControl_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Enabled)
            {
                // color white
                tableLayoutPanel1.BackColor = Color.White;
            }
            else
            {
                // color disabled
                tableLayoutPanel1.BackColor = Color.LightGray;
            }
        }
        private void ChildControls_Click(object sender, EventArgs e)
        {
            // This raises the main UserControl's Click event in its parent container (e.g., the Form)
            this.InvokeOnClick(this, EventArgs.Empty);
        }
        private void WireAllControls(Control parentControl)
        {
            foreach (Control ctl in parentControl.Controls)
            {
                ctl.Click += ChildControls_Click;
                // If the control has children, recurse
                if (ctl.HasChildren)
                {
                    WireAllControls(ctl);
                }
            }
        }
    }
}
