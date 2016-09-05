using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;
using Utility.WindowsForm;
using Utility.存储;

namespace 通用命令.迷你网管
{
    public partial class F主窗口 : FormK
    {
        private List<M设备> _设备列表;

        public F主窗口()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.out标题.Text += " " + Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = this.out标题.Text;

            this.do读取默认配置.Click += do读取默认配置_Click;
            this.do保存默认配置.Click += do保存默认配置_Click;
            this.do编辑默认配置.Click += do编辑默认配置_Click;

            this.do读取其他配置.Click += do从文件加载_Click;
            this.do另存配置.Click += do另存配置_Click;
            this.do批量操作.Click += do批量操作_Click;

            this.u窗体头1.点击设置 += () => this.contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);

            this.do读取默认配置.PerformClick();
        }

        void do批量操作_Click(object sender, EventArgs e)
        {
            if (_设备列表.Count == 0)
            {
                new F对话框_确定("没有设备!").ShowDialog();
                return;
            }
            var __缓存 = new List<M设备>(_设备列表);
            new F空窗口(new F批量操作(__缓存), "批量操作").ShowDialog();
        }

        void do读取默认配置_Click(object sender, EventArgs e)
        {
            //限制界面
            var __等待面板 = new F等待();
            this.out设备列表.创建局部覆盖控件(__等待面板, null);

            List<M设备> __设备列表 = null;

            //配置任务
            var __任务 = new Task(() =>
            {
                //执行后台任务
                if (H路径.验证文件是否存在("设备列表.xml"))
                {
                    __设备列表 = 查询设备列表("设备列表.xml");
                }

                //__设备列表 = new List<M设备>();
                //for (int i = 0; i < 10; i++)
                //{
                //    var __每类数量 = 50;
                //    for (int j = 0; j < __每类数量; j++)
                //    {
                //        __设备列表.Add(new M设备
                //        {
                //            IP = IPAddress.Parse("127.0.0.1"),
                //            端口号 = 8001,
                //            //端口号 = 8000 + i + 1,
                //            分组 = string.Format("类型{0}", i + 1),
                //            设备标识 = string.Format("设备{0:D4}", i * __每类数量 + j + 1)
                //        });
                //    }
                //}
            });
            __任务.ContinueWith(task =>
            {
                //成功后提示, 并取消限制 
                __等待面板.隐藏();
                if (__设备列表.Count > 0)
                {
                    _设备列表 = __设备列表;
                    this.out设备列表.加载(__设备列表);
                    return;
                }
                new F对话框_确定("请配置设备列表").ShowDialog();
            },
                CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion,
                 TaskScheduler.FromCurrentSynchronizationContext());
            __任务.ContinueWith(task =>
            {
                //失败后提示, 并取消限制    
                __等待面板.隐藏();

                task.Exception.Handle(q => true);

                if (__设备列表 == null)
                {
                    new F对话框_确定("配置文件格式错误!").ShowDialog();
                    return;
                }
            },
                CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted,
                 TaskScheduler.FromCurrentSynchronizationContext());

            //开始任务
            __任务.Start();
        }

        private List<M设备> 查询设备列表(string __文件路径)
        {
            var __设备列表 = new List<M设备>();
            var __文件 = H路径.打开文件(__文件路径);
            var __XML文档 = XDocument.Load(__文件);
            __文件.Close();
            var __根节点 = __XML文档.Root;
            foreach (XElement __节点 in __根节点.XPathSelectElements("./设备"))
            {
                var __IP = IPAddress.Parse(__节点.Attribute("IP").Value);
                var __端口号 = int.Parse(__节点.Attribute("端口号").Value);
                var __设备 = new M设备
                {
                    分组 = __节点.Attribute("分类").Value,
                    设备标识 = __节点.Attribute("名称").Value,
                    IP = __IP,
                    端口号 = __端口号
                };
                __设备列表.Add(__设备);
            }
            return __设备列表;
        }

        void do保存默认配置_Click(object sender, EventArgs e)
        {
            var __XML = new XDocument(new XElement("列表"));
            _设备列表.ForEach(k =>
            {
                __XML.Root.Add(new XElement("设备"
                    , new XAttribute("分类", k.分组)
                    , new XAttribute("名称", k.设备标识)
                    , new XAttribute("IP", k.IP)
                    , new XAttribute("端口号", k.端口号)));
            });
            __XML.Save("设备列表.xml");
        }

        void do编辑默认配置_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", "设备列表.xml").WaitForExit();
            if (new F对话框_是否("需要重新加载吗?").ShowDialog() == DialogResult.Yes)
            {
                do读取其他配置.PerformClick();
            }
        }

        void do从文件加载_Click(object sender, EventArgs e)
        {
            var __窗口 = new OpenFileDialog() { Filter = "XML(.xml)|*.xml" };
            if (__窗口.ShowDialog() == DialogResult.OK)
            {
                var __文件 = __窗口.FileName;

                //限制界面
                var __等待面板 = new F等待();
                this.out设备列表.创建局部覆盖控件(__等待面板, null);

                List<M设备> __设备列表 = null;

                //配置任务
                var __任务 = new Task(() =>
                {
                    //执行后台任务
                    if (H路径.验证文件是否存在("设备列表.xml"))
                    {
                        __设备列表 = 查询设备列表(__文件);
                    }
                });
                __任务.ContinueWith(task =>
                {
                    //成功后提示, 并取消限制 
                    __等待面板.隐藏();
                    if (__设备列表.Count > 0)
                    {
                        _设备列表 = __设备列表;
                        this.out设备列表.加载(__设备列表);
                        return;
                    }
                },
                    CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion,
                     TaskScheduler.FromCurrentSynchronizationContext());
                __任务.ContinueWith(task =>
                {
                    //失败后提示, 并取消限制    
                    __等待面板.隐藏();

                    task.Exception.Handle(q => true);

                    if (__设备列表 == null)
                    {
                        new F对话框_确定("配置文件格式错误!").ShowDialog();
                        return;
                    }
                },
                    CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted,
                     TaskScheduler.FromCurrentSynchronizationContext());

                //开始任务
                __任务.Start();
            }
        }

        void do另存配置_Click(object sender, EventArgs e)
        {
            if (_设备列表 == null)
            {
                new F对话框_确定("无设备!").ShowDialog();
                return;
            }
            var __窗口 = new SaveFileDialog() { Filter = "XML(*.xml)|*.xml" };
            if (__窗口.ShowDialog() == DialogResult.OK)
            {
                var __XML = new XDocument(new XElement("列表"));
                _设备列表.ForEach(k =>
                {
                    __XML.Root.Add(new XElement("设备"
                        , new XAttribute("分类", k.分组)
                        , new XAttribute("名称", k.设备标识)
                        , new XAttribute("IP", k.IP)
                        , new XAttribute("端口号", k.端口号)));
                });
                __XML.Save(__窗口.FileName);
            }
        }
    }
}
