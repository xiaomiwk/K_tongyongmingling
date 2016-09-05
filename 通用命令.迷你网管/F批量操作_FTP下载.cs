using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Utility.WindowsForm;

namespace 通用命令.迷你网管
{
    public partial class F批量操作_FTP下载 : UserControl
    {
        private List<M设备> _设备列表;

        public F批量操作_FTP下载(List<M设备> __设备列表)
        {
            _设备列表 = __设备列表;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.in本地目录.Text = "d:\\";

            this.do下载.Click += do下载_Click;
            this.do选择目录.Click += do选择目录_Click;
        }

        void do选择目录_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog __窗口 = new FolderBrowserDialog() { ShowNewFolderButton = true };
            if (__窗口.ShowDialog() == DialogResult.OK)
            {
                this.in本地目录.Text = __窗口.SelectedPath + "\\";
            }
        }

        void do下载_Click(object sender, EventArgs e)
        {
            var __端口号 = int.Parse(this.in端口号.Text);
            var __等待面板 = new F等待();
            this.创建局部覆盖控件(__等待面板, null);
            Application.DoEvents();
            var __本地目录 = this.in本地目录.Text;
            if (!Directory.Exists(__本地目录))
            {
                try
                {
                    Directory.CreateDirectory(__本地目录);
                }
                catch (Exception)
                {
                    new F对话框_确定("文件不存在, 并且创建失败!").ShowDialog();
                    return;
                }
            }
            var __远程路径 = this.in远程文件或目录.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            var __失败列表 = new List<string>();
            _设备列表.ForEach(q =>
            {
                __远程路径.ForEach(k =>
                {
                    try
                    {
                        var __startinfo = new ProcessStartInfo("FlashFXP\\flashfxp.exe",
                            string.Format(" -c4 -download ftp://{0}:{1} -remotepath=\"{2}\" -localpath=\"{3}\"", q.IP, __端口号, k, __本地目录));
                        __startinfo.WindowStyle = ProcessWindowStyle.Hidden;
                        Process.Start(__startinfo).WaitForExit(2000);
                    }
                    catch (Exception)
                    {
                        __失败列表.Add(k);
                    }
                });

            });
            __等待面板.隐藏();
            if (__失败列表.Count == 0)
            {
                new F对话框_确定("全部完成!").ShowDialog();
            }
            else
            {
                new F对话框_确定((
                    __远程路径.Count - __失败列表.Count) + "个路径下载成功!"
                    + __失败列表.Count + "个路径下载失败!" + Environment.NewLine
                    + string.Join(Environment.NewLine, __失败列表))
                    .ShowDialog();
            }

        }
    }
}
