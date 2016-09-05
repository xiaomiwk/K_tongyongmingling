namespace 通用命令.迷你网管.设备详情
{
    partial class F已连接设备
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "202.202.202.202",
            "8888",
            "",
            "交换机",
            "S1"}, -1);
            this.out列表 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.do刷新 = new Utility.WindowsForm.U按钮();
            this.SuspendLayout();
            // 
            // out列表
            // 
            this.out列表.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.out列表.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader2});
            this.out列表.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.out列表.Location = new System.Drawing.Point(0, 0);
            this.out列表.Name = "out列表";
            this.out列表.Size = new System.Drawing.Size(736, 235);
            this.out列表.TabIndex = 13;
            this.out列表.UseCompatibleStateImageBehavior = false;
            this.out列表.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IP";
            this.columnHeader1.Width = 135;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "端口号";
            this.columnHeader3.Width = 64;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "账号";
            this.columnHeader5.Width = 97;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "设备类型";
            this.columnHeader6.Width = 117;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "设备标识";
            this.columnHeader7.Width = 149;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "建立连接时间";
            this.columnHeader2.Width = 130;
            // 
            // do刷新
            // 
            this.do刷新.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.do刷新.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do刷新.FlatAppearance.BorderSize = 0;
            this.do刷新.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do刷新.ForeColor = System.Drawing.Color.White;
            this.do刷新.Location = new System.Drawing.Point(0, 243);
            this.do刷新.Name = "do刷新";
            this.do刷新.Size = new System.Drawing.Size(100, 26);
            this.do刷新.TabIndex = 32;
            this.do刷新.Text = "刷新";
            this.do刷新.UseVisualStyleBackColor = false;
            this.do刷新.大小 = new System.Drawing.Size(100, 26);
            this.do刷新.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // F已连接设备
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.do刷新);
            this.Controls.Add(this.out列表);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F已连接设备";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(736, 274);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView out列表;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private Utility.WindowsForm.U按钮 do刷新;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}
