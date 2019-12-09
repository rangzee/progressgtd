namespace ProgressGTD
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pbMain = new System.Windows.Forms.ProgressBar();
            this.tmMain = new System.Windows.Forms.Timer(this.components);
            this.nudMain = new System.Windows.Forms.NumericUpDown();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.btnGO = new System.Windows.Forms.Button();
            this.cbxShow = new System.Windows.Forms.CheckBox();
            this.lblMinutes2 = new System.Windows.Forms.Label();
            this.nudRest = new System.Windows.Forms.NumericUpDown();
            this.lblWork = new System.Windows.Forms.Label();
            this.lblRest = new System.Windows.Forms.Label();
            this.cbxMinimize = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRest)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMain
            // 
            this.pbMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbMain.Location = new System.Drawing.Point(0, 155);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(196, 11);
            this.pbMain.TabIndex = 0;
            // 
            // tmMain
            // 
            this.tmMain.Interval = 1000;
            this.tmMain.Tick += new System.EventHandler(this.tmMain_Tick);
            // 
            // nudMain
            // 
            this.nudMain.DecimalPlaces = 1;
            this.nudMain.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudMain.Location = new System.Drawing.Point(44, 12);
            this.nudMain.Name = "nudMain";
            this.nudMain.Size = new System.Drawing.Size(66, 21);
            this.nudMain.TabIndex = 1;
            this.nudMain.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudMain.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudMain_KeyPress);
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Location = new System.Drawing.Point(116, 14);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(59, 12);
            this.lblMinutes.TabIndex = 2;
            this.lblMinutes.Text = "Minute(s)";
            // 
            // btnGO
            // 
            this.btnGO.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGO.Location = new System.Drawing.Point(14, 71);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(161, 23);
            this.btnGO.TabIndex = 3;
            this.btnGO.Text = "GO!";
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // cbxShow
            // 
            this.cbxShow.AutoSize = true;
            this.cbxShow.Location = new System.Drawing.Point(14, 105);
            this.cbxShow.Name = "cbxShow";
            this.cbxShow.Size = new System.Drawing.Size(168, 16);
            this.cbxShow.TabIndex = 4;
            this.cbxShow.Text = "Show progress in taskbar";
            this.cbxShow.UseVisualStyleBackColor = true;
            // 
            // lblMinutes2
            // 
            this.lblMinutes2.AutoSize = true;
            this.lblMinutes2.Location = new System.Drawing.Point(116, 44);
            this.lblMinutes2.Name = "lblMinutes2";
            this.lblMinutes2.Size = new System.Drawing.Size(59, 12);
            this.lblMinutes2.TabIndex = 7;
            this.lblMinutes2.Text = "Minute(s)";
            // 
            // nudRest
            // 
            this.nudRest.DecimalPlaces = 1;
            this.nudRest.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudRest.Location = new System.Drawing.Point(44, 39);
            this.nudRest.Name = "nudRest";
            this.nudRest.Size = new System.Drawing.Size(66, 21);
            this.nudRest.TabIndex = 2;
            this.nudRest.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblWork
            // 
            this.lblWork.AutoSize = true;
            this.lblWork.Location = new System.Drawing.Point(9, 14);
            this.lblWork.Name = "lblWork";
            this.lblWork.Size = new System.Drawing.Size(29, 12);
            this.lblWork.TabIndex = 8;
            this.lblWork.Text = "Work";
            // 
            // lblRest
            // 
            this.lblRest.AutoSize = true;
            this.lblRest.Location = new System.Drawing.Point(9, 44);
            this.lblRest.Name = "lblRest";
            this.lblRest.Size = new System.Drawing.Size(29, 12);
            this.lblRest.TabIndex = 9;
            this.lblRest.Text = "Rest";
            // 
            // cbxMinimize
            // 
            this.cbxMinimize.AutoSize = true;
            this.cbxMinimize.Location = new System.Drawing.Point(14, 129);
            this.cbxMinimize.Name = "cbxMinimize";
            this.cbxMinimize.Size = new System.Drawing.Size(138, 16);
            this.cbxMinimize.TabIndex = 5;
            this.cbxMinimize.Text = "Minimize to taskbar";
            this.cbxMinimize.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 166);
            this.Controls.Add(this.cbxMinimize);
            this.Controls.Add(this.lblRest);
            this.Controls.Add(this.lblWork);
            this.Controls.Add(this.lblMinutes2);
            this.Controls.Add(this.nudRest);
            this.Controls.Add(this.cbxShow);
            this.Controls.Add(this.btnGO);
            this.Controls.Add(this.lblMinutes);
            this.Controls.Add(this.nudMain);
            this.Controls.Add(this.pbMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Progress GTD";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbMain;
        private System.Windows.Forms.Timer tmMain;
        private System.Windows.Forms.NumericUpDown nudMain;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.CheckBox cbxShow;
        private System.Windows.Forms.Label lblMinutes2;
        private System.Windows.Forms.NumericUpDown nudRest;
        private System.Windows.Forms.Label lblWork;
        private System.Windows.Forms.Label lblRest;
        private System.Windows.Forms.CheckBox cbxMinimize;
    }
}

