using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace 通用命令.迷你网管
{
    public partial class F编辑设备 : UserControl
    {
        private M设备 _设备;

        public F编辑设备(M设备 __设备)
        {
            InitializeComponent();
            _设备 = __设备;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.in当前IP.Text =_设备.IP == null ? "" : _设备.IP.ToString();
            this.in端口号.Text = _设备.端口号.ToString();
            this.in分类.Text = _设备.分组;
            this.in名称.Text = _设备.设备标识;

            this.do确定.Click += do确定_Click;
        }

        void do确定_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.in当前IP.Text))
            {
                try
                {
                    _设备.IP = IPAddress.Parse(this.in当前IP.Text.Trim());
                    _设备.分组 = this.in分类.Text.Trim();
                    _设备.端口号 = int.Parse(this.in端口号.Text.Trim());
                    _设备.设备标识 = this.in名称.Text.Trim();
                }
                catch (Exception)
                {
                    MessageBox.Show("请输入正确的参数");
                    this.in当前IP.Focus();
                    return;
                }
                this.ParentForm.DialogResult = DialogResult.OK;
                this.ParentForm.Close();
                return;
            }
            this.ParentForm.DialogResult = DialogResult.OK;
            this.ParentForm.Close();
        }
    }
}
