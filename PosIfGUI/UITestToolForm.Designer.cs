using PosIfRegister;

namespace PosIfGUI
{
    partial class UITestToolForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.portLabel = new System.Windows.Forms.Label();
            this.portConnection = new System.Windows.Forms.Button();
            this.connectionButton = new System.Windows.Forms.Button();
            this.connectionLabel = new System.Windows.Forms.Label();
            this.mode2Button = new System.Windows.Forms.Button();
            this.modeLabel = new System.Windows.Forms.Label();
            this.mode3Button = new System.Windows.Forms.Button();
            this.portComboBox = new System.Windows.Forms.ComboBox();
            this.saleButton = new System.Windows.Forms.Button();
            this.saleLabel = new System.Windows.Forms.Label();
            this.startSaleLabel = new System.Windows.Forms.Label();
            this.saleTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.childLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.sendLabel = new System.Windows.Forms.Label();
            this.sendBox = new System.Windows.Forms.TextBox();
            this.receiveLabel = new System.Windows.Forms.Label();
            this.receiveBox = new System.Windows.Forms.TextBox();
            this.posScreenLabel = new System.Windows.Forms.Label();
            this.parentLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.childLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2.SuspendLayout();
            this.childLayoutPanel.SuspendLayout();
            this.parentLayoutPanel.SuspendLayout();
            this.childLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // portLabel
            // 
            this.portLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(3, 0);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(96, 41);
            this.portLabel.TabIndex = 0;
            this.portLabel.Text = "ポート接続";
            this.portLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // portConnection
            // 
            this.portConnection.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.portConnection.Location = new System.Drawing.Point(105, 9);
            this.portConnection.Name = "portConnection";
            this.portConnection.Size = new System.Drawing.Size(127, 23);
            this.portConnection.TabIndex = 3;
            this.portConnection.Text = "ポート接続実行";
            this.portConnection.UseVisualStyleBackColor = true;
            this.portConnection.Click += new System.EventHandler(this.portConnection_Click);
            // 
            // connectionButton
            // 
            this.connectionButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.connectionButton.Location = new System.Drawing.Point(105, 49);
            this.connectionButton.Name = "connectionButton";
            this.connectionButton.Size = new System.Drawing.Size(127, 23);
            this.connectionButton.TabIndex = 5;
            this.connectionButton.Text = "接続確認実行";
            this.connectionButton.UseVisualStyleBackColor = true;
            this.connectionButton.Click += new System.EventHandler(this.connectionButton_Click);
            // 
            // connectionLabel
            // 
            this.connectionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectionLabel.AutoSize = true;
            this.connectionLabel.Location = new System.Drawing.Point(3, 41);
            this.connectionLabel.Name = "connectionLabel";
            this.connectionLabel.Size = new System.Drawing.Size(96, 39);
            this.connectionLabel.TabIndex = 4;
            this.connectionLabel.Text = "接続確認";
            this.connectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mode2Button
            // 
            this.mode2Button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.mode2Button.Location = new System.Drawing.Point(105, 89);
            this.mode2Button.Name = "mode2Button";
            this.mode2Button.Size = new System.Drawing.Size(127, 23);
            this.mode2Button.TabIndex = 7;
            this.mode2Button.Text = "ユーザー操作（モード2）";
            this.mode2Button.UseVisualStyleBackColor = true;
            this.mode2Button.Click += new System.EventHandler(this.mode2Button_Click);
            // 
            // modeLabel
            // 
            this.modeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modeLabel.AutoSize = true;
            this.modeLabel.Location = new System.Drawing.Point(3, 80);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(96, 41);
            this.modeLabel.TabIndex = 6;
            this.modeLabel.Text = "モード切替";
            this.modeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mode3Button
            // 
            this.mode3Button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.mode3Button.Location = new System.Drawing.Point(259, 89);
            this.mode3Button.Name = "mode3Button";
            this.mode3Button.Size = new System.Drawing.Size(156, 23);
            this.mode3Button.TabIndex = 8;
            this.mode3Button.Text = "係員操作（モード3）";
            this.mode3Button.UseVisualStyleBackColor = true;
            this.mode3Button.Click += new System.EventHandler(this.mode3Button_Click);
            // 
            // portComboBox
            // 
            this.portComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.portComboBox.FormattingEnabled = true;
            this.portComboBox.Location = new System.Drawing.Point(259, 10);
            this.portComboBox.Name = "portComboBox";
            this.portComboBox.Size = new System.Drawing.Size(156, 21);
            this.portComboBox.TabIndex = 9;
            // 
            // saleButton
            // 
            this.saleButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.saleButton.Location = new System.Drawing.Point(720, 49);
            this.saleButton.Name = "saleButton";
            this.saleButton.Size = new System.Drawing.Size(132, 23);
            this.saleButton.TabIndex = 15;
            this.saleButton.Text = "お会計ボタン押下";
            this.saleButton.UseVisualStyleBackColor = true;
            this.saleButton.Click += new System.EventHandler(this.saleButton_Click);
            // 
            // saleLabel
            // 
            this.saleLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.saleLabel.AutoSize = true;
            this.saleLabel.Location = new System.Drawing.Point(659, 14);
            this.saleLabel.Name = "saleLabel";
            this.saleLabel.Size = new System.Drawing.Size(55, 13);
            this.saleLabel.TabIndex = 14;
            this.saleLabel.Text = "買上総額";
            // 
            // startSaleLabel
            // 
            this.startSaleLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.startSaleLabel.AutoSize = true;
            this.startSaleLabel.Location = new System.Drawing.Point(659, 54);
            this.startSaleLabel.Name = "startSaleLabel";
            this.startSaleLabel.Size = new System.Drawing.Size(55, 13);
            this.startSaleLabel.TabIndex = 16;
            this.startSaleLabel.Text = "決済開始";
            // 
            // saleTextBox
            // 
            this.saleTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.saleTextBox.Location = new System.Drawing.Point(720, 10);
            this.saleTextBox.Name = "saleTextBox";
            this.saleTextBox.Size = new System.Drawing.Size(132, 20);
            this.saleTextBox.TabIndex = 17;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Controls.Add(this.portLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.connectionLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.saleButton, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.startSaleLabel, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.modeLabel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.portConnection, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.connectionButton, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.mode2Button, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.mode3Button, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.portComboBox, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.saleTextBox, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.saleLabel, 3, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(24, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.8843F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.2314F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1027, 121);
            this.tableLayoutPanel2.TabIndex = 20;
            // 
            // childLayoutPanel
            // 
            this.childLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.childLayoutPanel.ColumnCount = 1;
            this.childLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.childLayoutPanel.Controls.Add(this.sendLabel, 0, 0);
            this.childLayoutPanel.Controls.Add(this.sendBox, 0, 1);
            this.childLayoutPanel.Controls.Add(this.receiveLabel, 0, 2);
            this.childLayoutPanel.Controls.Add(this.receiveBox, 0, 3);
            this.childLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.childLayoutPanel.Name = "childLayoutPanel";
            this.childLayoutPanel.RowCount = 4;
            this.childLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.childLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.childLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.childLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.childLayoutPanel.Size = new System.Drawing.Size(507, 406);
            this.childLayoutPanel.TabIndex = 19;
            // 
            // sendLabel
            // 
            this.sendLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sendLabel.AutoSize = true;
            this.sendLabel.Location = new System.Drawing.Point(3, 7);
            this.sendLabel.Name = "sendLabel";
            this.sendLabel.Size = new System.Drawing.Size(49, 13);
            this.sendLabel.TabIndex = 10;
            this.sendLabel.Text = "送信ログ";
            // 
            // sendBox
            // 
            this.sendBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sendBox.Location = new System.Drawing.Point(3, 23);
            this.sendBox.Multiline = true;
            this.sendBox.Name = "sendBox";
            this.sendBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sendBox.Size = new System.Drawing.Size(501, 176);
            this.sendBox.TabIndex = 12;
            // 
            // receiveLabel
            // 
            this.receiveLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.receiveLabel.AutoSize = true;
            this.receiveLabel.Location = new System.Drawing.Point(3, 209);
            this.receiveLabel.Name = "receiveLabel";
            this.receiveLabel.Size = new System.Drawing.Size(49, 13);
            this.receiveLabel.TabIndex = 11;
            this.receiveLabel.Text = "受信ログ";
            // 
            // receiveBox
            // 
            this.receiveBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.receiveBox.Location = new System.Drawing.Point(3, 225);
            this.receiveBox.Multiline = true;
            this.receiveBox.Name = "receiveBox";
            this.receiveBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.receiveBox.Size = new System.Drawing.Size(501, 178);
            this.receiveBox.TabIndex = 13;
            // 
            // posScreenLabel
            // 
            this.posScreenLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.posScreenLabel.Location = new System.Drawing.Point(4, 3);
            this.posScreenLabel.Name = "posScreenLabel";
            this.posScreenLabel.Size = new System.Drawing.Size(500, 16);
            this.posScreenLabel.TabIndex = 18;
            this.posScreenLabel.Text = "POS画面（A8700）";
            this.posScreenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // parentLayoutPanel
            // 
            this.parentLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parentLayoutPanel.ColumnCount = 2;
            this.parentLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.parentLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.parentLayoutPanel.Controls.Add(this.childLayoutPanel2, 1, 0);
            this.parentLayoutPanel.Controls.Add(this.childLayoutPanel, 0, 0);
            this.parentLayoutPanel.Location = new System.Drawing.Point(24, 155);
            this.parentLayoutPanel.Name = "parentLayoutPanel";
            this.parentLayoutPanel.RowCount = 1;
            this.parentLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.parentLayoutPanel.Size = new System.Drawing.Size(1027, 412);
            this.parentLayoutPanel.TabIndex = 21;
            // 
            // childLayoutPanel2
            // 
            this.childLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.childLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.childLayoutPanel2.ColumnCount = 1;
            this.childLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.childLayoutPanel2.Controls.Add(this.posScreenLabel, 0, 0);
            this.childLayoutPanel2.Location = new System.Drawing.Point(516, 3);
            this.childLayoutPanel2.Name = "childLayoutPanel2";
            this.childLayoutPanel2.RowCount = 3;
            this.childLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.childLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.childLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.childLayoutPanel2.Size = new System.Drawing.Size(508, 406);
            this.childLayoutPanel2.TabIndex = 23;
            // 
            // UITestToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 601);
            this.Controls.Add(this.parentLayoutPanel);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "UITestToolForm";
            this.Text = "PosIfUIテストツール";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.childLayoutPanel.ResumeLayout(false);
            this.childLayoutPanel.PerformLayout();
            this.parentLayoutPanel.ResumeLayout(false);
            this.childLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Button portConnection;
        private System.Windows.Forms.Button connectionButton;
        private System.Windows.Forms.Label connectionLabel;
        private System.Windows.Forms.Button mode2Button;
        private System.Windows.Forms.Label modeLabel;
        private System.Windows.Forms.Button mode3Button;
        private System.Windows.Forms.ComboBox portComboBox;
        private System.Windows.Forms.Button saleButton;
        private System.Windows.Forms.Label saleLabel;
        private System.Windows.Forms.Label startSaleLabel;
        private System.Windows.Forms.TextBox saleTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel childLayoutPanel;
        private System.Windows.Forms.Label sendLabel;
        private System.Windows.Forms.TextBox sendBox;
        private System.Windows.Forms.Label receiveLabel;
        private System.Windows.Forms.TextBox receiveBox;
        private System.Windows.Forms.Label posScreenLabel;
        private System.Windows.Forms.TableLayoutPanel parentLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel childLayoutPanel2;
    }
}

