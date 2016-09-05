namespace 通用命令.迷你网管
{
    partial class F批量操作_FTP下载
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
            this.label1 = new System.Windows.Forms.Label();
            this.in远程文件或目录 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.in本地目录 = new System.Windows.Forms.TextBox();
            this.do下载 = new Utility.WindowsForm.U按钮();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.do选择目录 = new Utility.WindowsForm.U按钮();
            this.in端口号 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "远程文件或目录";
            // 
            // in远程文件或目录
            // 
            this.in远程文件或目录.Location = new System.Drawing.Point(188, 52);
            this.in远程文件或目录.Multiline = true;
            this.in远程文件或目录.Name = "in远程文件或目录";
            this.in远程文件或目录.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.in远程文件或目录.Size = new System.Drawing.Size(306, 168);
            this.in远程文件或目录.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "本地目录";
            // 
            // in本地目录
            // 
            this.in本地目录.Location = new System.Drawing.Point(188, 265);
            this.in本地目录.Name = "in本地目录";
            this.in本地目录.Size = new System.Drawing.Size(306, 23);
            this.in本地目录.TabIndex = 3;
            // 
            // do下载
            // 
            this.do下载.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do下载.FlatAppearance.BorderSize = 0;
            this.do下载.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do下载.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.do下载.Location = new System.Drawing.Point(188, 374);
            this.do下载.Name = "do下载";
            this.do下载.Size = new System.Drawing.Size(100, 26);
            this.do下载.TabIndex = 5;
            this.do下载.Text = "下载";
            this.do下载.UseVisualStyleBackColor = false;
            this.do下载.大小 = new System.Drawing.Size(100, 26);
            this.do下载.文字颜色 = System.Drawing.Color.WhiteSmoke;
            this.do下载.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(185, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(294, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "例: /my.exe  或者   /remotefolder/, 文件夹必须存在";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(185, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "例: c:\\downloads\\\r\n";
            // 
            // do选择目录
            // 
            this.do选择目录.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do选择目录.FlatAppearance.BorderSize = 0;
            this.do选择目录.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do选择目录.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.do选择目录.Location = new System.Drawing.Point(188, 317);
            this.do选择目录.Name = "do选择目录";
            this.do选择目录.Size = new System.Drawing.Size(100, 26);
            this.do选择目录.TabIndex = 6;
            this.do选择目录.Text = "选择目录";
            this.do选择目录.UseVisualStyleBackColor = false;
            this.do选择目录.大小 = new System.Drawing.Size(100, 26);
            this.do选择目录.文字颜色 = System.Drawing.Color.WhiteSmoke;
            this.do选择目录.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // in端口号
            // 
            this.in端口号.Location = new System.Drawing.Point(188, 14);
            this.in端口号.Name = "in端口号";
            this.in端口号.Size = new System.Drawing.Size(57, 23);
            this.in端口号.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "端口号";
            // 
            // F批量操作_FTP下载
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.in端口号);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.do选择目录);
            this.Controls.Add(this.do下载);
            this.Controls.Add(this.in本地目录);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.in远程文件或目录);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F批量操作_FTP下载";
            this.Size = new System.Drawing.Size(559, 414);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox in远程文件或目录;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox in本地目录;
        private Utility.WindowsForm.U按钮 do下载;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Utility.WindowsForm.U按钮 do选择目录;
        private System.Windows.Forms.TextBox in端口号;
        private System.Windows.Forms.Label label5;
    }
}
