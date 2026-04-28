namespace PosIfGUI.UserControls
{
    partial class PaymentScreen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.code = new PosIfGUI.UserControls.Method();
            this.cash = new PosIfGUI.UserControls.Method();
            this.credit = new PosIfGUI.UserControls.Method();
            this.aeonCard = new PosIfGUI.UserControls.Method();
            this.electronicMoney = new PosIfGUI.UserControls.Method();
            this.aeonGift = new PosIfGUI.UserControls.Method();
            this.ginren = new PosIfGUI.UserControls.Method();
            this.waonPoint = new PosIfGUI.UserControls.Method();
            this.label1 = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.code, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cash, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.credit, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.aeonCard, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.electronicMoney, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.aeonGift, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.ginren, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.waonPoint, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.priceLabel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(630, 320);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // code
            // 
            this.code.BackColor = System.Drawing.SystemColors.Control;
            this.code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.code.Enabled = false;
            this.code.image = global::PosIfGUI.Properties.Resources.ic_qr_guide;
            this.code.Location = new System.Drawing.Point(160, 195);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(151, 122);
            this.code.TabIndex = 10;
            this.code.Title = "コード決済";
            // 
            // cash
            // 
            this.cash.BackColor = System.Drawing.SystemColors.Control;
            this.cash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cash.Enabled = false;
            this.cash.image = global::PosIfGUI.Properties.Resources.ic_cash;
            this.cash.Location = new System.Drawing.Point(3, 67);
            this.cash.Name = "cash";
            this.cash.Size = new System.Drawing.Size(151, 122);
            this.cash.TabIndex = 0;
            this.cash.Title = "現金";
            // 
            // credit
            // 
            this.credit.BackColor = System.Drawing.SystemColors.Control;
            this.credit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.credit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.credit.image = global::PosIfGUI.Properties.Resources.ic_credit_logo;
            this.credit.Location = new System.Drawing.Point(160, 67);
            this.credit.Name = "credit";
            this.credit.Size = new System.Drawing.Size(151, 122);
            this.credit.TabIndex = 1;
            this.credit.Title = "クレジット";
            // 
            // aeonCard
            // 
            this.aeonCard.BackColor = System.Drawing.SystemColors.Control;
            this.aeonCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.aeonCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aeonCard.Enabled = false;
            this.aeonCard.image = global::PosIfGUI.Properties.Resources.ic_aeonticket;
            this.aeonCard.Location = new System.Drawing.Point(3, 195);
            this.aeonCard.Name = "aeonCard";
            this.aeonCard.Size = new System.Drawing.Size(151, 122);
            this.aeonCard.TabIndex = 2;
            this.aeonCard.Title = "イオンカード";
            // 
            // electronicMoney
            // 
            this.electronicMoney.BackColor = System.Drawing.SystemColors.Control;
            this.electronicMoney.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.electronicMoney.Dock = System.Windows.Forms.DockStyle.Fill;
            this.electronicMoney.Enabled = false;
            this.electronicMoney.image = global::PosIfGUI.Properties.Resources.emoney;
            this.electronicMoney.Location = new System.Drawing.Point(317, 67);
            this.electronicMoney.Name = "electronicMoney";
            this.electronicMoney.Size = new System.Drawing.Size(151, 122);
            this.electronicMoney.TabIndex = 4;
            this.electronicMoney.Title = "電子マネー";
            // 
            // aeonGift
            // 
            this.aeonGift.BackColor = System.Drawing.SystemColors.Control;
            this.aeonGift.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.aeonGift.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aeonGift.image = global::PosIfGUI.Properties.Resources.ic_aeon_card;
            this.aeonGift.Location = new System.Drawing.Point(474, 67);
            this.aeonGift.Name = "aeonGift";
            this.aeonGift.Size = new System.Drawing.Size(153, 122);
            this.aeonGift.TabIndex = 5;
            this.aeonGift.Title = "イオンギフト";
            // 
            // ginren
            // 
            this.ginren.BackColor = System.Drawing.SystemColors.Control;
            this.ginren.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ginren.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ginren.Enabled = false;
            this.ginren.image = global::PosIfGUI.Properties.Resources.ic_union_pay_logo;
            this.ginren.Location = new System.Drawing.Point(317, 195);
            this.ginren.Name = "ginren";
            this.ginren.Size = new System.Drawing.Size(151, 122);
            this.ginren.TabIndex = 6;
            this.ginren.Title = "銀聯";
            // 
            // waonPoint
            // 
            this.waonPoint.BackColor = System.Drawing.SystemColors.Control;
            this.waonPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.waonPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.waonPoint.Enabled = false;
            this.waonPoint.image = global::PosIfGUI.Properties.Resources.ic_woan_dog;
            this.waonPoint.Location = new System.Drawing.Point(474, 195);
            this.waonPoint.Name = "waonPoint";
            this.waonPoint.Size = new System.Drawing.Size(153, 122);
            this.waonPoint.TabIndex = 7;
            this.waonPoint.Title = "WAONPOINT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 64);
            this.label1.TabIndex = 11;
            this.label1.Text = "買上総額";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.priceLabel.Location = new System.Drawing.Point(160, 0);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(151, 64);
            this.priceLabel.TabIndex = 12;
            this.priceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PaymentScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PaymentScreen";
            this.Size = new System.Drawing.Size(630, 320);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Method cash;
        private Method credit;
        private Method aeonCard;
        private Method electronicMoney;
        private Method aeonGift;
        private Method ginren;
        private Method waonPoint;
        private Method code;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label priceLabel;
    }
}
