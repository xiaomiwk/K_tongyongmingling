using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Utility.WindowsForm;
using Utility.存储;
using 通用命令.FTP;
using 通用命令.名片;
using 通用命令.状态;
using 通用命令.系统;
using 通用命令.迷你网管.设备详情;
using 通用访问;

namespace 通用命令.迷你网管
{
    public partial class F设备详情 : FormK
    {
        private F告警 _F告警;

        private IT客户端 _IT客户端;

        private string _标题;

        private IB状态_C _IB状态;

        private IB名片_C _IB名片;

        private IB系统_C _IB系统;

        public F设备详情(IT客户端 __IT客户端, string __标题 = "")
        {
            InitializeComponent();

            _IT客户端 = __IT客户端;
            _标题 = string.IsNullOrEmpty(__标题) ? __IT客户端.设备地址.ToString() : __标题;
            this.out标题.Text = _标题;
            this.Text = _标题;

            _F告警 = 加入控件<F告警>();
        }

        private T 加入控件<T>() where T : Control, new ()
        {
            var __控件 = new T
            {
                Location = new Point(15, 33),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                Height = this.out活动容器.Height - 33 - 15,
                Width = this.out活动容器.Width - 15 - 15,
            };
            this.out活动容器.Controls.Add(__控件);
            return __控件;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.do折叠.Click += (m, n) => this.splitContainer1.Panel1Collapsed = !this.splitContainer1.Panel1Collapsed;

            //this.do显示告警.Click += (m, n) => _F告警.BringToFront();
            this.doFTP.Click += doFTP_Click;
            this.do通用访问.Click += do通用访问_Click;
            this.do业务状态_刷新.Click += do业务状态_刷新_Click;
            this.do重启.Click += do重启_Click;

            _IT客户端.已断开 += _IT客户端_已断开;

            _IB名片 = new B名片_C(_IT客户端);
            this.out名片.Items.Add(new ListViewItem(new string[] { "名称", _IB名片.名片.名称 }));
            this.out名片.Items.Add(new ListViewItem(new string[] { "描述", _IB名片.名片.描述 }));
            this.out名片.Items.Add(new ListViewItem(new string[] { "版本号", _IB名片.名片.版本号 }));
            this.out名片.Items.Add(new ListViewItem(new string[] { "版本时间", _IB名片.名片.版本时间 }));
            _IB名片.参数列表.ForEach(k => this.out名片.Items.Add(new ListViewItem(new string[]
            {
                k.名称,k.值
            })));

            _IB状态 = new B状态_C(_IT客户端);
            _IB状态.健康状态变化 += 健康状态变化;

            _IB系统 = new B系统_C(_IT客户端); 

            _F告警.初始化(_IT客户端);

            this.out基本信息_启动时间.Text = _IB状态.启动时间.ToString();
            this.do业务状态_刷新.PerformClick();
            this.FormClosing += F设备详情_FormClosing;
        }

        void F设备详情_FormClosing(object sender, FormClosingEventArgs e)
        {
            _IB状态.健康状态变化 -= 健康状态变化;
            _IT客户端.已断开 -= _IT客户端_已断开;
        }

        void _IT客户端_已断开(bool obj)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<bool>(_IT客户端_已断开), obj);
                return;
            }
            this.out健康状态标题.BackColor = Color.Red;
            this.out健康状态.Text = "已断开";
            //new F对话框_确定("已断开连接").ShowDialog();
        }

        void 健康状态变化(M概要状态 __状态变化)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<M概要状态>(健康状态变化), __状态变化);
                return;
            }
            this.out健康状态.Text = __状态变化.健康状态.ToString();
            this.out开始时间.Text = __状态变化.状态开始时间.ToString();
            设置颜色(__状态变化.健康状态);
        }

        private void 设置颜色(E健康状态 __状态)
        {
            switch (__状态)
            {
                case E健康状态.优:
                    this.out健康状态标题.BackColor = Color.YellowGreen;
                    this.out健康状态.ForeColor = Color.YellowGreen;
                    break;
                case E健康状态.良:
                    this.out健康状态标题.BackColor = Color.FromArgb(38, 164, 221);
                    this.out健康状态.ForeColor = Color.FromArgb(38, 164, 221);
                    break;
                case E健康状态.中:
                    this.out健康状态标题.BackColor = Color.Orange;
                    this.out健康状态.ForeColor = Color.Orange;
                    break;
                case E健康状态.差:
                    this.out健康状态标题.BackColor = Color.Red;
                    this.out健康状态.ForeColor = Color.Red;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }

        void do重启_Click(object sender, EventArgs e)
        {
            _IB系统.重启();
        }

        void do业务状态_刷新_Click(object sender, EventArgs e)
        {
            var __概要状态 = _IB状态.查询概要状态();
            var __状态列表 = _IB状态.查询业务概要();
            __状态列表.Sort((m, n) => (m.类别 + m.属性).CompareTo(n.类别 + n.属性));
            this.out业务状态.Items.Clear();
            __状态列表.ForEach(k => this.out业务状态.Items.Add(new ListViewItem(new string[]
            {
                k.类别,k.属性,k.当前值,k.正常.ToString(),k.正常范围,k.单位, k.描述
            })));

            this.out健康状态.Text = __概要状态.健康状态.ToString();
            this.out开始时间.Text = __概要状态.状态开始时间.ToString();
            设置颜色(_IB状态.健康状态);
        }

        void do通用访问_Click(object sender, EventArgs e)
        {
            ProcessStartInfo __参数 = new ProcessStartInfo("通用访问.UI组件.exe",
                string.Format("{0} {1} {2} {3}", "对象列表", _IT客户端.设备地址.Address, _IT客户端.设备地址.Port, _标题));
            __参数.CreateNoWindow = false;
            __参数.WorkingDirectory = H路径.程序目录;
            __参数.WindowStyle = ProcessWindowStyle.Maximized;
            __参数.UseShellExecute = false;
            Process.Start(__参数);
        }

        void doFTP_Click(object sender, EventArgs e)
        {
            IBFTP_C __IBFTP = new BFTP_C(_IT客户端);
            if (!__IBFTP.运行中)
            {
                try
                {
                    __IBFTP.开启();
                }
                catch (Exception ex)
                {
                    new F对话框_确定("FTP开启失败!\r\n" + ex.Message).ShowDialog();
                    return;
                }
            }
            if (H路径.验证文件是否存在("FlashFXP\\flashfxp.exe"))
            {
                Process.Start("FlashFXP\\flashfxp.exe", string.Format("ftp://{0}:{1}", _IT客户端.设备地址.Address, __IBFTP.端口号));
                return;
            }
            Process.Start("explorer.exe", string.Format("ftp://{0}:{1}", _IT客户端.设备地址.Address, __IBFTP.端口号));
        }
    }
}
