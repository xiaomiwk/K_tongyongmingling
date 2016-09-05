using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility.WindowsForm;

namespace 通用命令.迷你网管
{
    public partial class F设备列表 : UserControl
    {
        public List<M设备> 设备列表 { get; private set; }

        public F设备列表()
        {
            InitializeComponent();
        }

        void 设置界面(List<M设备> __设备列表)
        {
            this.out容器.Controls.Clear();
            if (__设备列表.Count == 0)
            {
                return;
            }

            this.SuspendLayout();
            var __分组 = __设备列表.GroupBy(k => k.分组, (key, group) => group).ToList();
            foreach (var __kv in __分组)
            {
                this.out容器.Controls.Add(new F设备列表_分组(__kv.ToList()) { Height = this.Height - 25 });
            }
            HandleSizeChanged(null, null);
            this.ResumeLayout();
        }

        public void 加载(List<M设备> __设备列表)
        {
            this.设备列表 = __设备列表;
            设置界面(__设备列表);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.SizeChanged += HandleSizeChanged;
            HandleSizeChanged(null, null);
        }

        void HandleSizeChanged(object sender, EventArgs e)
        {
            foreach (F设备列表_分组 __控件 in this.out容器.Controls)
            {
                __控件.Height = this.Height - 25;
                __控件.Width = __控件.获取所需宽度(__控件.Height);
            }
        }

        public bool 精简 { get; set; }
    }
}
