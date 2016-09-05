using Utility.WindowsForm;

namespace 通用命令.迷你网管.设备详情
{
    partial class F工程日志
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
            "10-10 10:10:10",
            "输入",
            "GIS服务器(g1)",
            "跟踪",
            "111",
            "72020200",
            "请求跟踪72020200, 等级:重要用户, 期限:2015-11-10"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "10-10 10:10:10",
            "输出",
            "基站(r1)",
            "GIS跟踪订购",
            "111",
            "72020200",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "10-10 10:10:10",
            "输出",
            "GIS服务器(g1)",
            "跟踪",
            "111",
            "72020200",
            "跟踪72020200成功"}, -1);
            this.in重要性 = new System.Windows.Forms.ComboBox();
            this.do开启 = new Utility.WindowsForm.U按钮();
            this.out列表 = new ListViewK();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.do导出 = new Utility.WindowsForm.U按钮();
            this.in关键字 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.in业务类型 = new System.Windows.Forms.ComboBox();
            this.do更新配置 = new Utility.WindowsForm.U按钮();
            this.do清空 = new Utility.WindowsForm.U按钮();
            this.SuspendLayout();
            // 
            // in重要性
            // 
            this.in重要性.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.in重要性.FormattingEnabled = true;
            this.in重要性.Location = new System.Drawing.Point(52, 1);
            this.in重要性.Name = "in重要性";
            this.in重要性.Size = new System.Drawing.Size(80, 25);
            this.in重要性.TabIndex = 16;
            // 
            // do开启
            // 
            this.do开启.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do开启.FlatAppearance.BorderSize = 0;
            this.do开启.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do开启.ForeColor = System.Drawing.Color.White;
            this.do开启.Location = new System.Drawing.Point(501, 0);
            this.do开启.Name = "do开启";
            this.do开启.Size = new System.Drawing.Size(90, 26);
            this.do开启.TabIndex = 18;
            this.do开启.Text = "开启";
            this.do开启.UseVisualStyleBackColor = false;
            this.do开启.大小 = new System.Drawing.Size(90, 26);
            this.do开启.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // out列表
            // 
            this.out列表.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.out列表.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader6,
            this.columnHeader8,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader9});
            this.out列表.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.out列表.Location = new System.Drawing.Point(0, 42);
            this.out列表.Margin = new System.Windows.Forms.Padding(0);
            this.out列表.Name = "out列表";
            this.out列表.Size = new System.Drawing.Size(955, 503);
            this.out列表.TabIndex = 19;
            this.out列表.UseCompatibleStateImageBehavior = false;
            this.out列表.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "时间";
            this.columnHeader3.Width = 110;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "方向";
            this.columnHeader5.Width = 41;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "重要性";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "边界";
            this.columnHeader6.Width = 167;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "业务类型";
            this.columnHeader8.Width = 84;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "业务标识";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "描述";
            this.columnHeader4.Width = 250;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "业务标签";
            this.columnHeader9.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "重要性";
            // 
            // do导出
            // 
            this.do导出.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do导出.FlatAppearance.BorderSize = 0;
            this.do导出.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do导出.ForeColor = System.Drawing.Color.White;
            this.do导出.Location = new System.Drawing.Point(789, 0);
            this.do导出.Name = "do导出";
            this.do导出.Size = new System.Drawing.Size(90, 26);
            this.do导出.TabIndex = 34;
            this.do导出.Text = "导出";
            this.do导出.UseVisualStyleBackColor = false;
            this.do导出.大小 = new System.Drawing.Size(90, 26);
            this.do导出.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // in关键字
            // 
            this.in关键字.Location = new System.Drawing.Point(376, 2);
            this.in关键字.Name = "in关键字";
            this.in关键字.Size = new System.Drawing.Size(100, 23);
            this.in关键字.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(326, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 37;
            this.label3.Text = "关键字";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(138, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 39;
            this.label4.Text = "业务类型";
            // 
            // in业务类型
            // 
            this.in业务类型.FormattingEnabled = true;
            this.in业务类型.Location = new System.Drawing.Point(200, 2);
            this.in业务类型.Name = "in业务类型";
            this.in业务类型.Size = new System.Drawing.Size(120, 25);
            this.in业务类型.TabIndex = 40;
            // 
            // do更新配置
            // 
            this.do更新配置.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do更新配置.FlatAppearance.BorderSize = 0;
            this.do更新配置.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do更新配置.ForeColor = System.Drawing.Color.White;
            this.do更新配置.Location = new System.Drawing.Point(597, 0);
            this.do更新配置.Name = "do更新配置";
            this.do更新配置.Size = new System.Drawing.Size(90, 26);
            this.do更新配置.TabIndex = 41;
            this.do更新配置.Text = "更新配置";
            this.do更新配置.UseVisualStyleBackColor = false;
            this.do更新配置.大小 = new System.Drawing.Size(90, 26);
            this.do更新配置.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // do清空
            // 
            this.do清空.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do清空.FlatAppearance.BorderSize = 0;
            this.do清空.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do清空.ForeColor = System.Drawing.Color.White;
            this.do清空.Location = new System.Drawing.Point(693, 0);
            this.do清空.Name = "do清空";
            this.do清空.Size = new System.Drawing.Size(90, 26);
            this.do清空.TabIndex = 42;
            this.do清空.Text = "清空";
            this.do清空.UseVisualStyleBackColor = false;
            this.do清空.大小 = new System.Drawing.Size(90, 26);
            this.do清空.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // F工程日志
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.do清空);
            this.Controls.Add(this.do更新配置);
            this.Controls.Add(this.in业务类型);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.in关键字);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.do导出);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.out列表);
            this.Controls.Add(this.do开启);
            this.Controls.Add(this.in重要性);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F工程日志";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(955, 545);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox in重要性;
        private Utility.WindowsForm.U按钮 do开启;
        private ListViewK out列表;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private Utility.WindowsForm.U按钮 do导出;
        private System.Windows.Forms.TextBox in关键字;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ComboBox in业务类型;
        private Utility.WindowsForm.U按钮 do更新配置;
        private Utility.WindowsForm.U按钮 do清空;


    }
}
