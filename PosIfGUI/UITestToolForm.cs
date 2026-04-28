using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PosIfGUI.Constants;
using PosIfGUI.UserControls;

//using PosIfRegister;
//using static PosIfRegister.PosIfCom;
using PosIfRegister;
namespace PosIfGUI
{
    public partial class UITestToolForm : Form
    {

        public PosIfCom posif = new PosIfCom();

        // 現在の取引
        public string currentTransaction { get; set; } = "";
        public string SelectedPort { get; private set; }

        internal CancellationTokenSource currentLoopCts;
        public BusinessTask businessTask;
        public MainManager componentManager;
        public string currentTransactionAmount;
        public string CurrentPackageName { get; set; } = "jp.aeon.launcher2";
        public bool HasEverStartedPayment { get; set; } = false;
        public string TenkeyInputBuffer { get; set; } = "";
        // 現在表示している画面のSI（Screen ID）
        public string CurrentScreenId = "";
        //　前の画面のSI（Screen ID）
        public string PreviousScreenId = "";
        public UITestToolForm()
        {
            InitializeComponent();
            childLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.None; // Set to None
            childLayoutPanel2.CellPaint += ChildLayoutPanel2_CellPaint;
            var ports = System.IO.Ports.SerialPort.GetPortNames();
            if (ports.Length == 0)
            {
                MessageBox.Show("COMポートが見つかりませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            portComboBox.Items.AddRange(ports);
            Task task = this.UpdateTextBoxAsync();
            businessTask = new BusinessTask(this);
            componentManager = new MainManager(this);
        }

        private void ChildLayoutPanel2_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            // Define the specific cell to have no border (e.g., Column 1, Row 0)
            if (e.Column == 0 && e.Row == 1)
            {
                using (var pen = new Pen(Color.Gray, 1))
                {
                    //skip bottom border
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Right, e.CellBounds.Top);
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Left, e.CellBounds.Bottom);
                    e.Graphics.DrawLine(pen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                }

                return;
            }
            if (e.Column == 0 && e.Row == 2)
            {
                using (var pen = new Pen(Color.Gray, 1))
                {
                    // skip top border
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Left, e.CellBounds.Bottom);
                    e.Graphics.DrawLine(pen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }

                return;
            }

            // Draw the borders for all other cells
            // You can customize the pen color/thickness here
            using (var pen = new Pen(Color.Gray, 1))
            {
                Rectangle borderRect = e.CellBounds;
                borderRect.Width -= 1;
                borderRect.Height -= 1;
                e.Graphics.DrawRectangle(pen, borderRect);
            }
        }

        public void ClearRowControls(TableLayoutPanel panel, int targetRow)
        {
            List<Control> controlsToRemove = new List<Control>();

            foreach (Control control in panel.Controls)
            {
                int controlRow = panel.GetRow(control);
                if (controlRow == targetRow)
                {
                    controlsToRemove.Add(control);
                }
            }
            foreach (Control control in controlsToRemove)
            {
                panel.Controls.Remove(control);
                control.Dispose();
            }
        }

        // 起動時のテキスト表示
        public void DisplayDefaultStateText()
        {
            Label defaultLabel = new Label();
            defaultLabel.Location = new Point(13, 13);
            defaultLabel.AutoSize = true;
            defaultLabel.Dock = DockStyle.Fill;
            defaultLabel.Text = "買上総額を入力し、お会計ボタンを押下";
            defaultLabel.TextAlign = ContentAlignment.TopCenter;
            ClearRowControls(childLayoutPanel2, 1);
            ClearRowControls(childLayoutPanel2, 2);
            childLayoutPanel2.Controls.Add(defaultLabel);
            childLayoutPanel2.SetColumn(defaultLabel, 0);
            childLayoutPanel2.SetRow(defaultLabel, 1);
            childLayoutPanel2.PerformLayout();
        }

        //　ログ更新
        private async Task UpdateTextBoxAsync()
        {
            while (true)
            {
                // バッファーの更新をシミュレート
                await Task.Delay(100); // X秒待機

                // UIスレッドでTextBoxの内容を更新
                foreach (var v in this.posif.GetSendRecvDeque())
                {
                    this.sendBox.AppendText(v + Environment.NewLine);
                }
                this.posif.ClearSendRecvDeque();
                foreach (var v in this.posif.GetSendRecvDeque(isTargetSend: false))
                {
                    this.receiveBox.AppendText(v + Environment.NewLine);
                }
                this.posif.ClearSendRecvDeque(isTargetSend: false);
            }
        }


        //　POSの中身を空にする
        public void ClearPOSView()
        {
            ClearRowControls(childLayoutPanel2, 1);
            ClearRowControls(childLayoutPanel2, 2);
        }


        //　バックとキャンセルボタンにレイアウト追加
        public void AddToBackAndCancelButtonLayout(Control item)
        {
            RemoveBackAndCancelButton();
            childLayoutPanel2.Controls.Add(item);
            childLayoutPanel2.SetColumn(item, 0);
            childLayoutPanel2.SetRow(item, 1);
            childLayoutPanel2.PerformLayout();
        }

        //　ボタンを削除
        public void RemoveBackAndCancelButton()
        {
            ClearRowControls(childLayoutPanel2, 1);
        }

        //　POS画面にコンポネント追加
        public void AddToPOSView(Control item)
        {
            ClearPOSView();
            childLayoutPanel2.Controls.Add(item);
            childLayoutPanel2.SetColumn(item, 0);
            childLayoutPanel2.SetRow(item, 2);
            childLayoutPanel2.PerformLayout();
        }

        private void portConnection_Click(object sender, EventArgs e)
        {
            SelectedPort = portComboBox.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(SelectedPort))
            {
                posif.SerialPortName = SelectedPort;
                posif.SerialPortBaudRate = 115200;
                posif.SendTimeOut = 20;
                posif.LogLevel = 91;
                // Openして成功チェック！
                if (!posif.Open())
                {
                    MessageBox.Show("POS通信ポートを開けませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Environment.Exit(0);
                    return;
                }
                DisplayDefaultStateText();
            }
            else
            {
                MessageBox.Show("ポートを選択してください。");
            }
        }

        //　接続確認
        async private void connectionButton_Click(object sender, EventArgs e)
        {
            await businessTask.ConnectCheckModeSelfAsync(TradeTypeEnum.Check);
        }


        //　mode２切り替え
        async private void mode2Button_Click(object sender, EventArgs e)
        {
            currentLoopCts?.Cancel();
            currentLoopCts = new CancellationTokenSource();
            var token = currentLoopCts.Token;

            mode2Button.Enabled = false;
            var originalText = mode2Button.Text;
            mode2Button.Text = "切替中...";

            try
            {
                // 🔁 モード切替要求（非同期＆結果あり）
                var resultJson = await businessTask.ChangeOperationModeAsync(TradeTypeEnum.Check, 2);

                await Task.Delay(100);
                var result = resultJson["dataList"]?["result"]?.ToString();

                if (result == "0")
                {
                    await Task.Delay(100);
                    MessageBox.Show("モード切り替えが完了しました。", "モード切替", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("モード切り替えに失敗しました。", "モード切替", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            finally
            {
                mode2Button.Text = originalText;
                mode2Button.Enabled = true;
            }
        }

        //mode3切り替え
        async private void mode3Button_Click(object sender, EventArgs e)
        {
            currentLoopCts?.Cancel();
            currentLoopCts = new CancellationTokenSource();
            var token = currentLoopCts.Token;

            // 🔁 非同期モード切替（結果付き）
            var resultJson = await businessTask.ChangeOperationModeAsync(TradeTypeEnum.Check, 3);
            var result = resultJson["dataList"]?["result"]?.ToString();

            if (result == "0")
            {
                await Task.Delay(100);
                MessageBox.Show("モード切り替えが完了しました。", "モード切替", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("モード切り替えに失敗しました。", "モード切替", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // 決済開始
        async private void saleButton_Click(object sender, EventArgs e)
        {
            saleButton.Enabled = false;
            var originalText = saleButton.Text;
            saleButton.Text = "処理中...";

            try
            {
                if (!decimal.TryParse(saleTextBox.Text, out var amount) || amount <= 0)
                {
                    MessageBox.Show("有効な金額を入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string amountText = saleTextBox.Text;
                saleTextBox.Clear();
                // salesNo は簡易的にランダム生成
                string salesNo = new Random().Next(0, 1073741824).ToString();
                // 決済開始要求
                bool saleOk = await businessTask.RequestPaymentAsync(
                    TradeTypeEnum.Sale, amountText, true, salesNo);
                if (!saleOk)
                {
                    MessageBox.Show("決済要求に失敗しました（POS未応答）。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                currentTransactionAmount = amountText;
                // Show POS UI Inside Forms
                await Task.Delay(100);
                componentManager.ShowPaymentOptions();

            }
            finally
            {
                saleButton.Enabled = true;
                saleButton.Text = originalText;
            }
        }
    }
}
