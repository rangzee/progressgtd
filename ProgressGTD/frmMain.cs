using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace ProgressGTD
{
    public partial class frmMain : Form
    {
        private int current = 0;
        private int max = 100;

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Left = 0;
            this.Top = Screen.FromControl(this).WorkingArea.Height - this.Height;

            this.nudMain.Select();

            // Initialize progress bar
            if (TaskbarManager.IsPlatformSupported)
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal, this.Handle);
                TaskbarManager.Instance.SetProgressValue(current, max, this.Handle);

                pbMain.Maximum = max;
                pbMain.Value = current;
            }

            // Stop progress bar
            //if (TaskbarManager.IsPlatformSupported)
            //{
            //    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
            //}
        }

        private void tmMain_Tick(object sender, EventArgs e)
        {
            if (TaskbarManager.IsPlatformSupported)
            {
                current++;

                pbMain.Maximum = max;
                pbMain.Value = current;

                if (cbxShow.Checked)
                {
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                    TaskbarManager.Instance.SetProgressValue(current, max, this.Handle);
                }
            }

            if (current >= max)
            {
                tmMain.Stop();

                if (cbxShow.Checked)
                {
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Error);
                    //MessageBox.Show(this, "TIME IS UP!");
                    //TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
                }

                pbMain.Value = 0;
            }
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            current = 0;
            max = (int)(nudMain.Value * 60);
            tmMain.Start();
        }
    }
}
