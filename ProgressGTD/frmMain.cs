using System;
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
        private ComponentResourceManager res = new ComponentResourceManager(typeof(frmMain));

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

            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            LoadLanguage(this);
            this.Text = res.GetString("Title");
            btnGO.Text = res.GetString("Go");
            lblMinutes.Text = res.GetString("Minutes");
            lblMinutes2.Text = res.GetString("Minutes");
        }

        #region Language
        public static void LoadLanguage(Form form)
        {
            if (form != null)
            {
                ComponentResourceManager resources = new ComponentResourceManager(form.GetType());
                resources.ApplyResources(form, "$this");
                Loading(form, resources);
            }
        }
        private static void Loading(Control control, ComponentResourceManager resources)
        {
            if (control is MenuStrip)
            {
                resources.ApplyResources(control, control.Name);
                MenuStrip ms = (MenuStrip)control;
                if (ms.Items.Count > 0)
                {
                    foreach (ToolStripMenuItem c in ms.Items)
                    {
                        Loading(c, resources);
                    }
                }
            }

            foreach (Control c in control.Controls)
            {
                resources.ApplyResources(c, c.Name);
                Loading(c, resources);
            }
        }
        private static void Loading(ToolStripMenuItem item, ComponentResourceManager resources)
        {
            if (item is ToolStripMenuItem)
            {
                resources.ApplyResources(item, item.Name);
                ToolStripMenuItem tsmi = (ToolStripMenuItem)item;
                if (tsmi.DropDownItems.Count > 0)
                {
                    foreach (ToolStripMenuItem c in tsmi.DropDownItems)
                    {
                        Loading(c, resources);
                    }
                }
            }
        }
        #endregion Language

        private void tmMain_Tick(object sender, EventArgs e)
        {
            if (TaskbarManager.IsPlatformSupported)
            {
                current++;

                pbMain.Maximum = max;
                pbMain.Value = current;

                if (cbxShow.Checked)
                {
                    TaskbarManager.Instance.SetProgressValue(current, max, this.Handle);
                }

                if (btnGO.Text == res.GetString("BreakWork"))
                {
                    // 工作用红色进度条
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Error);
                    this.Text = "[" + new TimeSpan(0, 0, max - current).ToString() + "]";
                    this.Icon = global::ProgressGTD.Properties.Resources.IconRed;
                }
                else
                {
                    // 休息用绿色进度条
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                    this.Text = "[" + new TimeSpan(0, 0, max - current).ToString() + "]";
                    this.Icon = global::ProgressGTD.Properties.Resources.IconGreen;
                }
            }

            if (current >= max)
            {
                tmMain.Stop();

                TaskbarManager.Instance.SetProgressValue(current, max, this.Handle);
                //TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Error);
                //MessageBox.Show(this, "TIME IS UP!");
                //TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);

                pbMain.Value = 0;

                if (btnGO.Text == res.GetString("BreakWork"))
                {
                    if (nudRest.Value >= 0.1m)
                    {
                        if (MessageBox.Show(res.GetString("RestConfirm"), res.GetString("Confirm"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                        {
                            StartRest();
                        }
                        else
                        {
                            Stop();
                        }
                    }
                    else
                    {
                        if (MessageBox.Show(res.GetString("NewWorkConfirm"), res.GetString("Confirm"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                        {
                            StartWork();
                        }
                        else
                        {
                            Stop();
                        }
                    }
                }
                else if (btnGO.Text == res.GetString("BreakRest") && MessageBox.Show(res.GetString("WorkConfirm"), "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                {
                    StartWork();
                }
                else
                {
                    Stop();
                }
            }
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            if (nudMain.Value < 0.1m)
            {
                MessageBox.Show(res.GetString("WorkTimeError"), res.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (btnGO.Text == res.GetString("Go") || (btnGO.Text == res.GetString("BreakRest") && pbMain.Value > 0 && MessageBox.Show(res.GetString("SureToWork"), res.GetString("Confirm"), MessageBoxButtons.OKCancel) == DialogResult.OK))
            {
                StartWork();
            }
            else if (btnGO.Text == res.GetString("BreakWork"))
            {
                if (nudRest.Value >= 0.1m)
                {

                    if (MessageBox.Show(res.GetString("SureToRest"), res.GetString("Confirm"), MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        StartRest();
                    }
                }
                else
                {
                    if (MessageBox.Show(res.GetString("NewWorkConfirm"), res.GetString("Confirm"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                    {
                        StartWork();
                    }
                }
            }
            else
            {
                this.Icon = global::ProgressGTD.Properties.Resources.IconNormal;
            }
        }

        private void StartWork()
        {
            current = 0;
            max = nudMain.Value >= 0.1m ? (int)(nudMain.Value * 60) : 0;

            btnGO.Text = res.GetString("BreakWork");

            tmMain.Start();

            if (cbxMinimize.Checked)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }
        private void StartRest()
        {
            current = 0;
            max = nudRest.Value >= 0.1m ? (int)(nudRest.Value * 60) : 0;

            btnGO.Text = res.GetString("BreakRest");

            tmMain.Start();

            if (cbxMinimize.Checked)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }
        private void Stop()
        {
            btnGO.Text = res.GetString("Go");
            this.Text = res.GetString("Title");
            this.Icon = global::ProgressGTD.Properties.Resources.IconNormal;

            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
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
