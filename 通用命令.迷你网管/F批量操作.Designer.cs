namespace 通用命令.迷你网管
{
    partial class F批量操作
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
            this.label6 = new System.Windows.Forms.Label();
            this.out列表 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.doFTP上传 = new Utility.WindowsForm.U按钮();
            this.do重启 = new Utility.WindowsForm.U按钮();
            this.doFTP下载 = new Utility.WindowsForm.U按钮();
            this.in设备分组 = new System.Windows.Forms.ComboBox();
            this.in健康状态 = new System.Windows.Forms.ComboBox();
            this.in全选 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "设备分组";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(218, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "健康状态";
            // 
            // out列表
            // 
            this.out列表.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.out列表.CheckBoxes = true;
            this.out列表.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader9,
            this.columnHeader4,
            this.columnHeader10,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.out列表.Location = new System.Drawing.Point(3, 51);
            this.out列表.Name = "out列表";
            this.out列表.ShowItemToolTips = true;
            this.out列表.Size = new System.Drawing.Size(994, 411);
            this.out列表.TabIndex = 13;
            this.out列表.UseCompatibleStateImageBehavior = false;
            this.out列表.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "设备分组";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "设备标识";
            this.columnHeader3.Width = 106;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "IP";
            this.columnHeader9.Width = 113;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "版本号";
            this.columnHeader4.Width = 126;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "版本时间";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "健康状态";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "未清除告警";
            this.columnHeader6.Width = 76;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "启动时间";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "描述";
            this.columnHeader8.Width = 149;
            // 
            // doFTP上传
            // 
            this.doFTP上传.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.doFTP上传.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.doFTP上传.FlatAppearance.BorderSize = 0;
            this.doFTP上传.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.doFTP上传.ForeColor = System.Drawing.Color.White;
            this.doFTP上传.Location = new System.Drawing.Point(68, 472);
            this.doFTP上传.Name = "doFTP上传";
            this.doFTP上传.Size = new System.Drawing.Size(100, 26);
            this.doFTP上传.TabIndex = 19;
            this.doFTP上传.Text = "FTP上传";
            this.doFTP上传.UseVisualStyleBackColor = false;
            this.doFTP上传.大小 = new System.Drawing.Size(100, 26);
            this.doFTP上传.文字颜色 = System.Drawing.Color.White;
            this.doFTP上传.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // do重启
            // 
            this.do重启.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.do重启.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do重启.FlatAppearance.BorderSize = 0;
            this.do重启.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do重启.ForeColor = System.Drawing.Color.White;
            this.do重启.Location = new System.Drawing.Point(280, 472);
            this.do重启.Name = "do重启";
            this.do重启.Size = new System.Drawing.Size(100, 26);
            this.do重启.TabIndex = 21;
            this.do重启.Text = "重启";
            this.do重启.UseVisualStyleBackColor = false;
            this.do重启.大小 = new System.Drawing.Size(100, 26);
            this.do重启.文字颜色 = System.Drawing.Color.White;
            this.do重启.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // doFTP下载
            // 
            this.doFTP下载.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.doFTP下载.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.doFTP下载.FlatAppearance.BorderSize = 0;
            this.doFTP下载.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.doFTP下载.ForeColor = System.Drawing.Color.White;
            this.doFTP下载.Location = new System.Drawing.Point(174, 472);
            this.doFTP下载.Name = "doFTP下载";
            this.doFTP下载.Size = new System.Drawing.Size(100, 26);
            this.doFTP下载.TabIndex = 23;
            this.doFTP下载.Text = "FTP下载";
            this.doFTP下载.UseVisualStyleBackColor = false;
            this.doFTP下载.大小 = new System.Drawing.Size(100, 26);
            this.doFTP下载.文字颜色 = System.Drawing.Color.White;
            this.doFTP下载.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // in设备分组
            // 
            this.in设备分组.FormattingEnabled = true;
            this.in设备分组.Location = new System.Drawing.Point(65, 15);
            this.in设备分组.Name = "in设备分组";
            this.in设备分组.Size = new System.Drawing.Size(121, 25);
            this.in设备分组.TabIndex = 25;
            // 
            // in健康状态
            // 
            this.in健康状态.FormattingEnabled = true;
            this.in健康状态.Location = new System.Drawing.Point(280, 15);
            this.in健康状态.Name = "in健康状态";
            this.in健康状态.Size = new System.Drawing.Size(50, 25);
            this.in健康状态.TabIndex = 27;
            // 
            // in全选
            // 
            this.in全选.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.in全选.AutoSize = true;
            this.in全选.Location = new System.Drawing.Point(3, 476);
            this.in全选.Name = "in全选";
            this.in全选.Size = new System.Drawing.Size(51, 21);
            this.in全选.TabIndex = 53;
            this.in全选.Text = "全选";
            this.in全选.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(418, 476);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(419, 17);
            this.label3.TabIndex = 54;
            this.label3.Text = "提示: 批量FTP上传和下载, 使用统一端口号, 而且设备无需实现\"通用访问\"协议";
            // 
            // F批量操作
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.in全选);
            this.Controls.Add(this.in健康状态);
            this.Controls.Add(this.in设备分组);
            this.Controls.Add(this.doFTP下载);
            this.Controls.Add(this.do重启);
            this.Controls.Add(this.doFTP上传);
            this.Controls.Add(this.out列表);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F批量操作";
            this.Size = new System.Drawing.Size(1000, 501);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView out列表;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private Utility.WindowsForm.U按钮 doFTP上传;
        private Utility.WindowsForm.U按钮 do重启;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private Utility.WindowsForm.U按钮 doFTP下载;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ComboBox in设备分组;
        private System.Windows.Forms.ComboBox in健康状态;
        private System.Windows.Forms.CheckBox in全选;
        private System.Windows.Forms.Label label3;
    }
}
