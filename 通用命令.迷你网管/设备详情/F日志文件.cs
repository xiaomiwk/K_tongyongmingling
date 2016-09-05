using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility.WindowsForm;
using 通用命令.日志;
using 通用访问;

namespace 通用命令.迷你网管.设备详情
{
    public partial class F日志文件 : UserControl
    {
        private IT客户端 _IT客户端;

        private IB日志_C _IB日志;

        public F日志文件()
        {
            InitializeComponent();
        }

        public void 初始化(IT客户端 __IT客户端)
        {
            _IT客户端 = __IT客户端;
            _IB日志 = new B日志_C(_IT客户端);

            do刷新.PerformClick();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.do删除.Click += do删除_Click;
            this.do刷新.Click += do刷新_Click;
            this.do下载.Click += do下载_Click;
            this.do压缩.Click += do压缩_Click;
            this.in全选.CheckedChanged += in全选_CheckedChanged;
        }

        void in全选_CheckedChanged(object sender, EventArgs e)
        {
            var __全选 = this.in全选.Checked;
             for (var i = 0; i < this.out列表.Items.Count; i++)
             {
                 this.out列表.Items[i].Checked = __全选;
             }
        }

        void do压缩_Click(object sender, EventArgs e)
        {
            var __选中列表 = 获取选中();
            if (__选中列表.Count > 0)
            {
                _IB日志.压缩日志文件(__选中列表);
                do刷新.PerformClick();
            }
            else
            {
                new F对话框_确定("请选择文件!").ShowDialog();
            }
        }

        void do下载_Click(object sender, EventArgs e)
        {
            var __窗口 = new FolderBrowserDialog() {ShowNewFolderButton = true};
            if (__窗口.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var __选中列表 = 获取选中();
            if (__选中列表.Count == 0)
            {
                  new F对话框_确定("请选择文件!").ShowDialog();
                  return;
            }
            //限制界面
            var __等待面板 = new F等待();
            this.创建局部覆盖控件(__等待面板, null);

            //配置任务
            var __任务 = new Task(() =>
            {
                //执行后台任务
                if (__选中列表.Count > 0)
                {
                    _IB日志.导出日志文件(__选中列表, __窗口.SelectedPath);
                }
            });
            __任务.ContinueWith(task =>
            {
                //成功后提示, 并取消限制 
                __等待面板.隐藏();
                new F对话框_确定("下载完成").ShowDialog();
            },
                CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion,
                 TaskScheduler.FromCurrentSynchronizationContext());
            __任务.ContinueWith(task =>
            {
                //失败后提示, 并取消限制    
                __等待面板.隐藏();
                new F对话框_确定(task.Exception.GetBaseException().Message).ShowDialog();
                //App.主窗口.显示操作失败(E功能.短信, task.Exception.GetBaseException().Message);
                task.Exception.Handle(q => true);

            },
                CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted,
                 TaskScheduler.FromCurrentSynchronizationContext());

            //开始任务
            __任务.Start();
        }

        void do刷新_Click(object sender, EventArgs e)
        {
            this.out列表.Items.Clear();
            var __列表 = _IB日志.查询日志文件(null);
            __列表.ForEach(q => this.out列表.Items.Add(new ListViewItem(new string[]
            {
                q.路径, (q.大小 / 1024).ToString("g") , q.最后修改时间.ToString("yyyy-MM-dd HH:mm:ss")
            })));
        }

        void do删除_Click(object sender, EventArgs e)
        {
            var __选中列表 = 获取选中();
            if (__选中列表.Count > 0)
            {
                _IB日志.删除日志文件(__选中列表);
            }
            else
            {
                new F对话框_确定("请选择文件!").ShowDialog();
            }
        }

        private List<string> 获取选中()
        {
            if (this.out列表.CheckedItems.Count == 0)
            {
                return new List<string>();
            }
            var __选中列表 = new List<string>();
            for (int i = 0; i < this.out列表.CheckedItems.Count; i++)
            {
                var __temp = this.out列表.CheckedItems[i];
                __选中列表.Add(__temp.Text);
            }
            return __选中列表;
        }
    }
}
