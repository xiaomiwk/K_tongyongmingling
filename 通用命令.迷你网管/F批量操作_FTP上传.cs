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
    public partial class F批量操作_FTP上传 : UserControl
    {
        private List<M设备> _设备列表;

        public F批量操作_FTP上传(List<M设备> __设备列表)
        {
            _设备列表 = __设备列表;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.in远程目录.Text = "/";

            this.do上传.Click += do上传_Click;
            this.do选择目录.Click += do选择目录_Click;
            this.do选择文件.Click += do选择文件_Click;
        }

        void do选择文件_Click(object sender, EventArgs e)
        {
            OpenFileDialog __窗口 = new OpenFileDialog() { Multiselect = true };
            if (__窗口.ShowDialog() == DialogResult.OK)
            {
                this.in本地文件或目录.Text += string.Join(Environment.NewLine, __窗口.FileNames) + Environment.NewLine;
            }
        }

        void do选择目录_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog __窗口 = new FolderBrowserDialog() { ShowNewFolderButton = true };
            if (__窗口.ShowDialog() == DialogResult.OK)
            {
                this.in本地文件或目录.Text += __窗口.SelectedPath + "\\" + Environment.NewLine;
            }
        }

        void do上传_Click(object sender, EventArgs e)
        {
            var __端口号 = int.Parse(this.in端口号.Text);
            var __等待面板 = new F等待();
            this.创建局部覆盖控件(__等待面板, null);
            Application.DoEvents();
            var __远程目录 = this.in远程目录.Text;
            if (__远程目录 == "")
            {
                __远程目录 = "//";
            }
            var __本地路径 = this.in本地文件或目录.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            var __失败列表 = new List<string>();
            _设备列表.ForEach(q =>
            {
                __本地路径.ForEach(k =>
                {
                    try
                    {
                        var __startinfo = new ProcessStartInfo("FlashFXP\\flashfxp.exe",
                            string.Format(" -c4 -upload ftp://{0}:{1} -localpath=\"{3}\" -remotepath=\"{2}\"", q.IP, __端口号, __远程目录, k));
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
                    __本地路径.Count - __失败列表.Count) + "个路径上传成功!"
                    + __失败列表.Count + "个路径上传失败!" + Environment.NewLine
                    + string.Join(Environment.NewLine, __失败列表))
                    .ShowDialog();
            }

        }
    }
}
