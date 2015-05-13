﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
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

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Left = 0;
            this.Top = Screen.FromControl(this).WorkingArea.Height - this.Height;

            var interval = GetConfig("Interval");
            var intervalRest = GetConfig("IntervalRest");
            var showProgress = GetConfig("ShowProgress");
            var minimize = GetConfig("Minimize");

            this.nudMain.Text = interval;
            this.nudMain.Select(0, this.nudMain.Text.Length);
            this.nudRest.Text = intervalRest;
            this.cbxShow.Checked = showProgress.ToLower() == "true";
            this.cbxMinimize.Checked = minimize.ToLower() == "true";

            this.Show();
            this.btnGO.Focus();

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

                if (btnGO.Text == "Working... Break!")
                {
                    this.Text = "Working... [" + new TimeSpan(0, 0, max - current).ToString() + "]";
                }
                else
                {
                    this.Text = "Resting... [" + new TimeSpan(0, 0, max - current).ToString() + "]";
                }
            }

            if (current >= max)
            {
                tmMain.Stop();

                TaskbarManager.Instance.SetProgressValue(current, max, this.Handle);
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Error);
                //MessageBox.Show(this, "TIME IS UP!");
                //TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);

                pbMain.Value = 0;

                if (btnGO.Text == "Working... Break!" && MessageBox.Show("Time is up! Have a rest?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                {
                    current = 0;
                    max = (int)(nudRest.Value * 60);

                    btnGO.Text = "Resting... Go work!";

                    tmMain.Start();

                    if (cbxMinimize.Checked)
                    {
                        this.WindowState = FormWindowState.Minimized;
                    }
                }
                else if (btnGO.Text == "Resting... Go work!" && MessageBox.Show("Time is up! Begin to work now?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                {
                    current = 0;
                    max = (int)(nudMain.Value * 60);

                    btnGO.Text = "Working... Break!";

                    tmMain.Start();

                    if (cbxMinimize.Checked)
                    {
                        this.WindowState = FormWindowState.Minimized;
                    }
                }
                else
                {
                    btnGO.Text = "GO!";
                    this.Text = "Progress GTD";

                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
                }
            }
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            if (btnGO.Text == "GO!" || (btnGO.Text == "Resting... Go work!" && pbMain.Value > 0 && MessageBox.Show("Sure to work?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK))
            {
                current = 0;
                max = (int)(nudMain.Value * 60);

                btnGO.Text = "Working... Break!";
            }
            else if (btnGO.Text == "Working... Break!" && MessageBox.Show("Sure to break?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                current = 0;
                max = (int)(nudRest.Value * 60);

                btnGO.Text = "Resting... Go work!";
            }

            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);

            tmMain.Start();

            if (cbxMinimize.Checked)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        #region 读写配置文件
        /// <summary>
        /// 修改配置文件中某项的值
        /// </summary>
        /// <param name="key">appSettings的key</param>
        /// <param name="value">appSettings的Value</param>
        public static void SetConfig(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (config.AppSettings.Settings[key] != null)
                config.AppSettings.Settings[key].Value = value;
            else
                config.AppSettings.Settings.Add(key, value);

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// 读取配置文件某项的值
        /// </summary>
        /// <param name="key">appSettings的key</param>
        /// <returns>appSettings的Value</returns>
        public static string GetConfig(string key)
        {
            string _value = string.Empty;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] != null)
            {
                _value = config.AppSettings.Settings[key].Value;
            }
            return _value;
        }
        #endregion

        private void nudMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnGO.Focus();
                btnGO_Click(sender, e);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SetConfig("Interval", nudMain.Text);
            SetConfig("IntervalRest", nudRest.Text);
            SetConfig("ShowProgress", cbxShow.Checked.ToString());
            SetConfig("Minimize", cbxMinimize.Checked.ToString());
        }
    }
}
