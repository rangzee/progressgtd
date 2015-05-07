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
            this.label1 = new System.Windows.Forms.Label();
            this.btnGO = new System.Windows.Forms.Button();
            this.cbxShow = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudRest = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Minute(s)";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Minute(s)";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Work";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Rest";
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
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudRest);
            this.Controls.Add(this.cbxShow);
            this.Controls.Add(this.btnGO);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.CheckBox cbxShow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudRest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbxMinimize;
    }
}

