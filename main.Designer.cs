using vmmsharp;

namespace Brookshook_DMA
{
    partial class main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblStatus = new Label();
            btnTryInitAgain = new Button();
            lblClient = new Label();
            label1 = new Label();
            cbEnemiesOnly = new CheckBox();
            cbVisibleOnly = new CheckBox();
            tbFov = new TrackBar();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            trackBar1 = new TrackBar();
            checkBox1 = new CheckBox();
            pictureBox1 = new PictureBox();
            cbMaps = new ComboBox();
            lblInfo = new Label();
            Arrow1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)tbFov).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Arrow1).BeginInit();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(10, 7);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(45, 15);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Status: ";
            // 
            // btnTryInitAgain
            // 
            btnTryInitAgain.BackColor = SystemColors.Control;
            btnTryInitAgain.ForeColor = SystemColors.ActiveCaptionText;
            btnTryInitAgain.Location = new Point(10, 24);
            btnTryInitAgain.Margin = new Padding(3, 2, 3, 2);
            btnTryInitAgain.Name = "btnTryInitAgain";
            btnTryInitAgain.Size = new Size(82, 22);
            btnTryInitAgain.TabIndex = 1;
            btnTryInitAgain.Text = "Try Again";
            btnTryInitAgain.UseVisualStyleBackColor = false;
            btnTryInitAgain.Visible = false;
            btnTryInitAgain.Click += btnTryInitAgain_Click;
            // 
            // lblClient
            // 
            lblClient.AutoSize = true;
            lblClient.Location = new Point(10, 483);
            lblClient.Name = "lblClient";
            lblClient.Size = new Size(0, 15);
            lblClient.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 140);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 3;
            label1.Text = "Aimbot Settings:";
            // 
            // cbEnemiesOnly
            // 
            cbEnemiesOnly.AutoSize = true;
            cbEnemiesOnly.Checked = true;
            cbEnemiesOnly.CheckState = CheckState.Checked;
            cbEnemiesOnly.Location = new Point(11, 179);
            cbEnemiesOnly.Margin = new Padding(3, 2, 3, 2);
            cbEnemiesOnly.Name = "cbEnemiesOnly";
            cbEnemiesOnly.Size = new Size(98, 19);
            cbEnemiesOnly.TabIndex = 4;
            cbEnemiesOnly.Text = "Enemies Only";
            cbEnemiesOnly.UseVisualStyleBackColor = true;
            // 
            // cbVisibleOnly
            // 
            cbVisibleOnly.AutoSize = true;
            cbVisibleOnly.Checked = true;
            cbVisibleOnly.CheckState = CheckState.Checked;
            cbVisibleOnly.Location = new Point(10, 202);
            cbVisibleOnly.Margin = new Padding(3, 2, 3, 2);
            cbVisibleOnly.Name = "cbVisibleOnly";
            cbVisibleOnly.Size = new Size(88, 19);
            cbVisibleOnly.TabIndex = 5;
            cbVisibleOnly.Text = "Visible Only";
            cbVisibleOnly.UseVisualStyleBackColor = true;
            // 
            // tbFov
            // 
            tbFov.Location = new Point(11, 245);
            tbFov.Margin = new Padding(3, 2, 3, 2);
            tbFov.Name = "tbFov";
            tbFov.Size = new Size(114, 45);
            tbFov.TabIndex = 6;
            tbFov.Value = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 228);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 7;
            label2.Text = "FOV:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 272);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 8;
            label3.Text = "Low";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(89, 272);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 9;
            label4.Text = "High";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(88, 344);
            label5.Name = "label5";
            label5.Size = new Size(33, 15);
            label5.TabIndex = 13;
            label5.Text = "High";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(10, 344);
            label6.Name = "label6";
            label6.Size = new Size(29, 15);
            label6.TabIndex = 12;
            label6.Text = "Low";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(10, 300);
            label7.Name = "label7";
            label7.Size = new Size(75, 15);
            label7.TabIndex = 11;
            label7.Text = "Smoothness:";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(10, 317);
            trackBar1.Margin = new Padding(3, 2, 3, 2);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(114, 45);
            trackBar1.TabIndex = 10;
            trackBar1.Value = 1;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(11, 157);
            checkBox1.Margin = new Padding(3, 2, 3, 2);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(66, 19);
            checkBox1.TabIndex = 14;
            checkBox1.Text = "Aimbot";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(526, 9);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(568, 485);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // cbMaps
            // 
            cbMaps.BackColor = SystemColors.Menu;
            cbMaps.DropDownStyle = ComboBoxStyle.Simple;
            cbMaps.ForeColor = SystemColors.MenuText;
            cbMaps.FormattingEnabled = true;
            cbMaps.Items.AddRange(new object[] { "Ancient", "Cache", "Dust2", "Inferno", "Mirage", "Nuke", "Overpass", "Train", "Vertigo" });
            cbMaps.Location = new Point(399, 12);
            cbMaps.Name = "cbMaps";
            cbMaps.Size = new Size(121, 165);
            cbMaps.Sorted = true;
            cbMaps.TabIndex = 16;
            cbMaps.SelectedIndexChanged += cbMaps_SelectedIndexChanged;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(260, 317);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(41, 15);
            lblInfo.TabIndex = 17;
            lblInfo.Text = "lblInfo";
            // 
            // Arrow1
            // 
            Arrow1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Arrow1.Parent = pictureBox1;
            Arrow1.Image = Properties.Resources.red_arrow_png_36960;
            Arrow1.Location = new Point(695, 309);
            Arrow1.Name = "Arrow1";
            Arrow1.Size = new Size(10, 10);
            Arrow1.SizeMode = PictureBoxSizeMode.StretchImage;
            Arrow1.TabIndex = 18;
            Arrow1.TabStop = false;
            Arrow1.BackColor = Color.Transparent;
            Arrow1.Visible = false;
            // 
            // main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1106, 509);
            Controls.Add(Arrow1);
            Controls.Add(lblInfo);
            Controls.Add(cbMaps);
            Controls.Add(pictureBox1);
            Controls.Add(checkBox1);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(trackBar1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(tbFov);
            Controls.Add(cbVisibleOnly);
            Controls.Add(cbEnemiesOnly);
            Controls.Add(label1);
            Controls.Add(lblClient);
            Controls.Add(btnTryInitAgain);
            Controls.Add(lblStatus);
            ForeColor = SystemColors.ActiveCaptionText;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MaximumSize = new Size(1122, 548);
            MinimumSize = new Size(1122, 548);
            Name = "main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BrooksHook csgo DMA Aimbot";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)tbFov).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Arrow1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStatus;
        private Button btnTryInitAgain;
        private Label lblClient;
        private Label label1;
        private CheckBox cbEnemiesOnly;
        private CheckBox cbVisibleOnly;
        private TrackBar tbFov;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TrackBar trackBar1;
        private CheckBox checkBox1;
        private PictureBox pictureBox1;
        private ComboBox cbMaps;
        private PictureBox Arrow1;
        private Label lblInfo;
    }
}