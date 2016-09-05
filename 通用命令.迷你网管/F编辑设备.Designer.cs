namespace 通用命令.迷你网管
{
    partial class F编辑设备
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.do确定 = new Utility.WindowsForm.U按钮();
            this.label3 = new System.Windows.Forms.Label();
            this.in分类 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.in名称 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.in端口号 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.in当前IP = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // do确定
            // 
            this.do确定.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do确定.FlatAppearance.BorderSize = 0;
            this.do确定.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do确定.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.do确定.Location = new System.Drawing.Point(98, 153);
            this.do确定.Name = "do确定";
            this.do确定.Size = new System.Drawing.Size(100, 26);
            this.do确定.TabIndex = 1;
            this.do确定.Text = "确定";
            this.do确定.UseVisualStyleBackColor = false;
            this.do确定.大小 = new System.Drawing.Size(100, 26);
            this.do确定.文字颜色 = System.Drawing.Color.WhiteSmoke;
            this.do确定.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "分类:";
            // 
            // in分类
            // 
            this.in分类.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.in分类.Location = new System.Drawing.Point(77, 6);
            this.in分类.Name = "in分类";
            this.in分类.Size = new System.Drawing.Size(241, 23);
            this.in分类.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "名称:";
            // 
            // in名称
            // 
            this.in名称.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.in名称.Location = new System.Drawing.Point(77, 40);
            this.in名称.Name = "in名称";
            this.in名称.Size = new System.Drawing.Size(241, 23);
            this.in名称.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "端口号:";
            // 
            // in端口号
            // 
            this.in端口号.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.in端口号.Location = new System.Drawing.Point(77, 74);
            this.in端口号.Name = "in端口号";
            this.in端口号.Size = new System.Drawing.Size(241, 23);
            this.in端口号.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "当前IP:";
            // 
            // in当前IP
            // 
            this.in当前IP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.in当前IP.Location = new System.Drawing.Point(77, 108);
            this.in当前IP.Name = "in当前IP";
            this.in当前IP.Size = new System.Drawing.Size(241, 23);
            this.in当前IP.TabIndex = 12;
            // 
            // F编辑设备
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.in当前IP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.in端口号);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.in名称);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.in分类);
            this.Controls.Add(this.do确定);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F编辑设备";
            this.Size = new System.Drawing.Size(321, 198);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utility.WindowsForm.U按钮 do确定;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox in分类;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox in名称;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox in端口号;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox in当前IP;
    }
}
