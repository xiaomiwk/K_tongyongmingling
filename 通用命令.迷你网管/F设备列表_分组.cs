using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility.WindowsForm;
using Utility.通用;
using 通用命令.名片;
using 通用命令.状态;
using 通用访问;

namespace 通用命令.迷你网管
{
    public partial class F设备列表_分组 : UserControl
    {
        private List<M设备> _设备列表;

        public F设备列表_分组(List<M设备> __设备列表)
        {
            _设备列表 = __设备列表;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.out标题.Text = _设备列表[0].分组;
            this.out容器.Controls.Clear();
            _设备列表.ForEach(__设备 =>
            {
                var __按钮 = new U按钮
                {
                    大小 = new Size(170, 26),
                    Tag = __设备,
                    ContextMenuStrip = this.contextMenuStrip1,
                    Text = __设备.设备标识,
                    颜色 = Color.Gray
                };
                __按钮.Click += 设备_Click;
                var __提示 = new StringBuilder();
                __提示
                    .AppendFormat("IP:  {0}", __设备.IP).AppendLine()
                    .AppendFormat("端口号:  {0}", __设备.端口号).AppendLine();
                this.toolTip1.SetToolTip(__按钮, __提示.ToString());
                this.out容器.Controls.Add(__按钮);

                __设备.访问入口 = FT通用访问工厂.创建客户端();
                __设备.访问入口.自动重连 = true;
                __设备.访问入口.已连接 += () => 访问入口_已连接(__设备, __按钮);
                __设备.访问入口.已断开 += q => 访问入口_已断开(__设备, __按钮);

                ThreadPool.QueueUserWorkItem((arg =>
                {
                    __设备.访问入口.连接(new IPEndPoint(__设备.IP, __设备.端口号));
                }));
            });
            this.do编辑设备.Click += do编辑设备_Click;
        }

        void 访问入口_已断开(M设备 __设备, U按钮 __按钮)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<M设备, U按钮>(访问入口_已断开), __设备, __按钮);
                return;
            }
            __按钮.颜色 = Color.Gray;
        }

        void 访问入口_已连接(M设备 __设备, U按钮 __按钮)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<M设备, U按钮>(访问入口_已连接), __设备, __按钮);
                return;
            }
            if (__设备.名片 == null)
            {
                var __IB名片 = new B名片_C(__设备.访问入口);
                var __IB状态 = new B状态_C(__设备.访问入口);
                __IB状态.健康状态变化 += q => _IB状态_健康状态变化(__设备, __按钮, q);

                var __任务 = new Task(() =>
                {
                    Let.Us.Retry(10000, 100, null, null).Do(() =>
                    {
                        __设备.名片 = __IB名片.名片;
                        __设备.概要状态 = __IB状态.查询概要状态();
                    });
                });
                __任务.ContinueWith(task =>
                {
                    var __提示 = new StringBuilder();
                    __提示
                        .AppendFormat("IP:  {0}", __设备.IP).AppendLine()
                        .AppendFormat("端口号:  {0}", __设备.端口号).AppendLine()
                        .AppendFormat("版本号:  {0}", __设备.名片 == null ? "" : __设备.名片.版本号).AppendLine()
                        .AppendFormat("版本时间:  {0}", __设备.名片 == null ? "" : __设备.名片.版本时间).AppendLine();
                    this.toolTip1.SetToolTip(__按钮, __提示.ToString());
                    _IB状态_健康状态变化(__设备, __按钮, __设备.概要状态);
                },
                    CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion,
                     TaskScheduler.FromCurrentSynchronizationContext());
                __任务.ContinueWith(task =>
                {
                    task.Exception.Handle(q => true);
                },
                    CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted,
                     TaskScheduler.FromCurrentSynchronizationContext());

                __任务.Start();
            }
        }

        void _IB状态_健康状态变化(M设备 __设备, U按钮 __按钮, M概要状态 __概要状态)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<M设备, U按钮, M概要状态>(_IB状态_健康状态变化), __设备, __按钮, __概要状态);
                return;
            }
            __设备.概要状态 = __概要状态;
            __按钮.Text = string.Format("{0}({1})", __设备.设备标识, __设备.概要状态.未清除告警数量);
            switch (__概要状态.健康状态)
            {
                case E健康状态.优:
                    __按钮.颜色 = Color.YellowGreen;
                    break;
                case E健康状态.良:
                    __按钮.颜色 = Color.FromArgb(38, 164, 221);
                    break;
                case E健康状态.中:
                    __按钮.颜色 = Color.Orange;
                    break;
                case E健康状态.差:
                    __按钮.颜色 = Color.Red;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        void do编辑设备_Click(object sender, EventArgs e)
        {
            var __菜单 = this.contextMenuStrip1;
            var __按钮 = __菜单.SourceControl as U按钮;
            var __设备 = __按钮.Tag as M设备;

            var __选择IP = new F编辑设备(__设备);
            if (new F空窗口(__选择IP, "编辑设备").ShowDialog() != DialogResult.OK)
            {
                return;
            }
            __按钮.Text = __设备.设备标识;
            var __提示 = new StringBuilder();
            __提示
                .AppendFormat("IP:  {0}", __设备.IP).AppendLine()
                .AppendFormat("端口号:  {0}", __设备.端口号).AppendLine()
                .AppendFormat("版本:  {0}", __设备.名片 == null ? "" : __设备.名片.版本号);
            this.toolTip1.SetToolTip(__按钮, __提示.ToString());

        }

        void 设备_Click(object sender, EventArgs e)
        {
            var __设备 = (sender as U按钮).Tag as M设备;

            if (__设备.IP == null)
            {
                MessageBox.Show("请未配置IP");
                return;
            }

            new F设备详情(__设备.访问入口, __设备.设备标识) { WindowState = FormWindowState.Maximized }.ShowDialog();
        }

        public int 获取所需宽度(int __高度)
        {
            var __栏目高度 = __高度 - 64;
            var __每列数量 = __栏目高度 / (26 + 6);
            var __所需列数 = _设备列表.Count / __每列数量 + (_设备列表.Count % __每列数量 == 0 ? 0 : 1);
            return 49 + (170 + 6) * __所需列数;
        }
    }
}
