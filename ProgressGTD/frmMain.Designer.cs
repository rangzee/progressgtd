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
            ((System.ComponentModel.ISupportInitialize)(this.nudMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMain
            // 
            this.pbMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbMain.Location = new System.Drawing.Point(0, 71);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(214, 11);
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
            this.nudMain.Location = new System.Drawing.Point(14, 12);
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
            this.label1.Location = new System.Drawing.Point(86, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Minute(s)";
            // 
            // btnGO
            // 
            this.btnGO.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGO.Location = new System.Drawing.Point(151, 9);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(49, 23);
            this.btnGO.TabIndex = 4;
            this.btnGO.Text = "GO";
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // cbxShow
            // 
            this.cbxShow.AutoSize = true;
            this.cbxShow.Location = new System.Drawing.Point(14, 39);
            this.cbxShow.Name = "cbxShow";
            this.cbxShow.Size = new System.Drawing.Size(168, 16);
            this.cbxShow.TabIndex = 5;
            this.cbxShow.Text = "Show progress in taskbar";
            this.cbxShow.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 82);
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
    }
}

