using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Utility.WindowsForm;
using Utility.任务;
using 通用命令.状态;
using 通用命令.系统;
using 通用访问;

namespace 通用命令.迷你网管
{
    public partial class F批量操作 : UserControl
    {
        private List<M设备> _设备列表;
        public F批量操作(List<M设备> __设备列表)
        {
            _设备列表 = __设备列表;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.in设备分组.Items.Add("全部");
            this.in设备分组.Items.AddRange(_设备列表.Select(q => q.分组).Distinct().ToArray());
            this.in设备分组.SelectedIndex = 0;
            this.in设备分组.DropDownStyle = ComboBoxStyle.DropDownList;

            this.in健康状态.Items.AddRange(new object[] { "全部", "优", "良", "中", "差" });
            this.in健康状态.SelectedIndex = 0;
            this.in健康状态.DropDownStyle = ComboBoxStyle.DropDownList;

            this.in健康状态.SelectedIndexChanged += 过滤;
            this.in设备分组.SelectedIndexChanged += 过滤;

            this.doFTP上传.Click += doFTP上传_Click;
            this.doFTP下载.Click += doFTP下载_Click;
            this.do重启.Click += do重启_Click;
            this.in全选.CheckedChanged += in全选_CheckedChanged;

            this.过滤(null, null);
        }

        void in全选_CheckedChanged(object sender, EventArgs e)
        {
            var __全选 = this.in全选.Checked;
            for (var i = 0; i < this.out列表.Items.Count; i++)
            {
                this.out列表.Items[i].Checked = __全选;
            }
        }

        void 过滤(object sender, EventArgs e)
        {
            string __分组 = null;
            E健康状态? __健康 = null;
            if (this.in设备分组.SelectedIndex > 0)
            {
                __分组 = (string)this.in设备分组.SelectedItem;
            }
            if (this.in健康状态.SelectedIndex > 0)
            {
                __健康 = (E健康状态)Enum.Parse(typeof(E健康状态), (string)this.in健康状态.SelectedItem);
            }
            var __匹配列表 = _设备列表.Where(q =>
                (__分组 == null || q.分组 == __分组)
                && (!__健康.HasValue || (q.概要状态 != null && q.概要状态.健康状态 <= __健康)));
            this.out列表.Items.Clear();
            __匹配列表.ToList().ForEach(q =>
            {
                if (q.概要状态 == null)
                {
                    this.out列表.Items.Add(new ListViewItem(new string[]
                    {
                        q.分组, 
                        "", 
                        q.设备标识,
                        q.IP == null ? "" : q.IP.ToString(), 
                        "", 
                        "", 
                        "", 
                        "", 
                        "", 
                    }) { Tag = q });
                }
                else
                {
                    var __颜色 = Color.White;
                    switch (q.概要状态.健康状态)
                    {
                        case E健康状态.优:
                            __颜色 = Color.YellowGreen;
                            break;
                        case E健康状态.良:
                            __颜色 = Color.FromArgb(38, 164, 221);
                            break;
                        case E健康状态.中:
                            __颜色 = Color.Orange;
                            break;
                        case E健康状态.差:
                            __颜色 = Color.Red;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    this.out列表.Items.Add(new ListViewItem(new string[]
                    {
                        q.分组, 
                        q.设备标识,
                        q.IP == null ? "" : q.IP.ToString(), 
                        q.名片 == null ? "" : q.名片.版本号, 
                        q.名片 == null ? "" : q.名片.版本时间.ToString(), 
                        q.概要状态 == null ? "" : q.概要状态.健康状态.ToString(),
                        q.概要状态 == null ? "" : q.概要状态.未清除告警数量.ToString(),
                        q.名片 == null ? "" : q.名片.描述
                    }) { BackColor = __颜色, Tag = q });
                }
            });
        }

        void do重启_Click(object sender, EventArgs e)
        {
            var __选中列表 = 获取选中();
            if (__选中列表.Count == 0)
            {
                new F对话框_确定("请先选择设备!").ShowDialog();
                return;
            }
            var __失败列表 = new List<M设备>();
            __选中列表.ForEach(q =>
            {
                try
                {
                    if (q.访问入口.连接正常)
                    {
                        IB系统_C __IB系统 = new B系统_C(q.访问入口);
                        __IB系统.重启();
                    }
                    else
                    {
                        __失败列表.Add(q);
                    }
                }
                catch (Exception)
                {
                    __失败列表.Add(q);
                }
            });
            if (__失败列表.Count == 0)
            {
                new F对话框_确定(__选中列表.Count + "个设备全部重启!").ShowDialog();
            }
            else
            {
                new F对话框_确定((
                    __选中列表.Count - __失败列表.Count) + "个设备重启成功!"
                    + __失败列表.Count + "个设备重启失败!" + Environment.NewLine
                    + string.Join(Environment.NewLine, __失败列表.Select(q => string.Format("{0}({1})", q.设备标识, q.IP))))
                    .ShowDialog();
            }
        }

        void doFTP下载_Click(object sender, EventArgs e)
        {
            var __选中列表 = 获取选中();
            if (__选中列表.Count == 0)
            {
                new F对话框_确定("请先选择设备!").ShowDialog();
                return;
            }

            new F空窗口(new F批量操作_FTP下载(__选中列表), "批量下载") { 允许缩放 = false, 允许最大化 = false }.ShowDialog();
        }

        void doFTP上传_Click(object sender, EventArgs e)
        {
            var __选中列表 = 获取选中();
            if (__选中列表.Count == 0)
            {
                new F对话框_确定("请先选择设备!").ShowDialog();
                return;
            }

            new F空窗口(new F批量操作_FTP上传(__选中列表), "批量上传"){ 允许缩放 = false, 允许最大化 =false }.ShowDialog();
        }

        private List<M设备> 获取选中()
        {
            if (this.out列表.CheckedItems.Count == 0)
            {
                return new List<M设备>();
            }
            var __选中列表 = new List<M设备>();
            for (int i = 0; i < this.out列表.CheckedItems.Count; i++)
            {
                var __temp = this.out列表.CheckedItems[i].Tag as M设备;
                __选中列表.Add(__temp);
            }
            return __选中列表;
        }

    }
}
