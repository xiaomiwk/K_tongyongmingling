using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 通用命令.链路;
using 通用访问;

namespace 通用命令.迷你网管.设备详情
{
    public partial class F已连接设备 : UserControl
    {
        private IT客户端 _IT客户端;

        private IB链路_C _IB链路;

        public F已连接设备(IT客户端 __IT客户端)
        {
            _IT客户端 = __IT客户端;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.do刷新.Click += do刷新_Click;

            this.do刷新.PerformClick();
        }

        void do刷新_Click(object sender, EventArgs e)
        {
            _IB链路 = new B链路_C(_IT客户端);
            var __设备列表 = _IB链路.已连接设备;
            this.out列表.Items.Clear();
            __设备列表.ForEach(k => this.out列表.Items.Add(new ListViewItem(new string[]
            {
                k.IP.ToString(), k.端口号.ToString(),k.账号,k.设备类型,k.设备标识,k.建立连接时间.ToString()
            })));
        }
    }
}
