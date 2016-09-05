using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 通用命令.状态;
using 通用访问;

namespace 通用命令.迷你网管.设备详情
{
    public partial class F告警 : UserControl
    {
        private IT客户端 _IT客户端;

        private IB状态_C _IB告警;

        public F告警()
        {
            InitializeComponent();
        }

        public void 初始化(IT客户端 __IT客户端)
        {
            _IT客户端 = __IT客户端;
            _IB告警 = new B状态_C(_IT客户端);
            _IB告警.新增了告警 += _IB告警_新增了告警;
            _IB告警.清除了告警 += _IB告警_清除了告警;
            do刷新未清除告警.PerformClick();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.out未清除告警.Items.Clear();
            this.out通知.Items.Clear();

            this.do清除通知.Click += do清除通知_Click;
            this.do刷新未清除告警.Click += do刷新未清除告警_Click;
        }

        void _IB告警_清除了告警(M上报清除 obj)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<M上报清除>(_IB告警_清除了告警), obj);
                return;
            }

            var __缓存 = new List<ListViewItem>(this.out未清除告警.Items.Cast<ListViewItem>());
            foreach (var __行 in __缓存)
            {
                var __绑定 = __行.Tag as M上报告警;
                if (__绑定 != null && __绑定.标识 == obj.标识 && __绑定.来源设备标识 == obj.来源设备标识 && __绑定.来源设备类型 == obj.来源设备类型)
                {
                    this.out未清除告警.Items.Remove(__行);
                    break;
                }
            }
        }

        private void _IB告警_新增了告警(M上报告警 k)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<M上报告警>(_IB告警_新增了告警), k);
                return;
            }

            if (k.重要性 == E重要性.一般)
            {
                this.out通知.Items.Add(new ListViewItem(new string[]
                {
                    k.标识, k.产生时间.ToString("MM-dd HH:mm:ss"), k.重要性.ToString(), k.类别, k.描述, k.原因, k.解决方案, k.来源设备类型, k.来源设备标识
                })).Tag = k;

            }
            else
            {
                this.out未清除告警.Items.Add(new ListViewItem(new string[]
                {
                    k.标识, k.产生时间.ToString("MM-dd HH:mm:ss"), k.重要性.ToString(), k.类别, k.描述, k.原因, k.解决方案, k.来源设备类型, k.来源设备标识
                })).Tag = k;
            }
        }

        void do刷新未清除告警_Click(object sender, EventArgs e)
        {
            this.out未清除告警.Items.Clear();
            var __列表 = _IB告警.查询未清除告警(null);
            __列表.ForEach(k =>
            {
                if (k.重要性 != E重要性.一般)
                {
                    this.out未清除告警.Items.Add(new ListViewItem(new string[]
                    {
                        k.标识, k.产生时间.ToString("MM-dd HH:mm:ss"), k.重要性.ToString(), k.类别, k.描述, k.原因, k.解决方案, k.来源设备类型, k.来源设备标识
                    })).Tag = k;
                }
            });

        }

        void do清除通知_Click(object sender, EventArgs e)
        {
            this.out通知.Items.Clear();
        }
    }
}
