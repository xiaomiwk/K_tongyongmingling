using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utility.WindowsForm;
using 通用命令.日志;
using 通用访问;

namespace 通用命令.迷你网管.设备详情
{
    public partial class F开发日志 : UserControl
    {
        private IT客户端 _IT客户端;
        private IB日志_C _IB日志;

        public F开发日志()
        {
            InitializeComponent();
        }

        public void 初始化(IT客户端 __IT客户端)
        {
            _IT客户端 = __IT客户端;
            _IB日志 = new B日志_C(_IT客户端);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.in重要性.Items.Add("全部");
            this.in重要性.Items.AddRange(Enum.GetNames(typeof (E重要性)));
            this.in重要性.SelectedIndex = 0;

            this.out列表.Items.Clear();
            this.do开启.Click += do开启_Click;
            this.do导出.Click += do导出_Click;
            this.do更新配置.Click += do更新配置_Click;
            this.do清空.Click += do清空_Click;
        }

        void do清空_Click(object sender, EventArgs e)
        {
            this.out列表.Items.Clear();
        }

        void do更新配置_Click(object sender, EventArgs e)
        {
            var __关键字 = string.IsNullOrEmpty(this.in关键字.Text.Trim()) ? new List<string>() : this.in关键字.Text.Trim().Split(' ').ToList();
            var __参数 = new M过滤开发日志
            {
                标题关键字 = __关键字, 内容关键字 = __关键字
            };
            if (this.in重要性.SelectedIndex != 0)
            {
                __参数.重要性 = (E重要性)Enum.Parse(typeof (E重要性), (string)this.in重要性.SelectedItem);
            }
            _IB日志.过滤开发日志(__参数);
        }

        void do导出_Click(object sender, EventArgs e)
        {
            if (this.out列表.Items.Count == 0)
            {
                new F对话框_确定("没有需要导出的内容").ShowDialog();
                return;
            }
            var __窗口 = new SaveFileDialog() { Filter = "json文件(*.json)|*.json" };
            if (__窗口.ShowDialog() == DialogResult.OK)
            {
                var __列表 = new List<object>();
                for (int i = 0; i < this.out列表.Items.Count; i++)
                {
                    var __行 = this.out列表.Items[i];
                    __列表.Add(new
                    {
                        时间 = __行.SubItems[0].Text,
                        重要性 = __行.SubItems[1].Text,
                        模块 = __行.SubItems[2].Text,
                        函数 = __行.SubItems[3].Text,
                        描述 = __行.SubItems[4].Text,
                        线程 = __行.SubItems[5].Text,
                        文件与行号 = __行.SubItems[6].Text,
                    });
                }

                File.WriteAllText(__窗口.FileName, Utility.存储.H序列化.ToJSON字符串(__列表), Encoding.UTF8);
            }
        }

        void do开启_Click(object sender, EventArgs e)
        {
            if (this.do开启.Text == "开启")
            {
                do更新配置.PerformClick();
                _IB日志.上报开发日志 += _IB日志_上报开发日志;
                this.do开启.Text = "关闭";
            }
            else
            {
                _IB日志.上报开发日志 -= _IB日志_上报开发日志;
                this.do开启.Text = "开启";
            }
        }

        void _IB日志_上报开发日志(M上报开发日志 __日志)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<M上报开发日志>(_IB日志_上报开发日志), __日志);
                return;
            }

            this.out列表.Items.Add(new ListViewItem(new string[]
            {
                __日志.时间.ToString("MM-dd HH:mm:ss"),
                __日志.重要性.ToString(), 
                __日志.线程,
                __日志.标题,
                __日志.内容,
            }));

            if (this.out列表.Items.Count > 5000)
            {
                this.out列表.Items.Clear();
            }
        }
    }
}
