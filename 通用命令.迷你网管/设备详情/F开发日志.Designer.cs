using Utility.WindowsForm;

namespace 通用命令.迷你网管.设备详情
{
    partial class F开发日志
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
            "错误",
            "输入数据(......)格式不正确",
            "接收报文",
            "Receive",
            "/../../...cs(66)",
            "1"}, -1);
            this.out列表 = new Utility.WindowsForm.ListViewK();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.in关键字 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.in重要性 = new System.Windows.Forms.ComboBox();
            this.do清空 = new Utility.WindowsForm.U按钮();
            this.do更新配置 = new Utility.WindowsForm.U按钮();
            this.do导出 = new Utility.WindowsForm.U按钮();
            this.do开启 = new Utility.WindowsForm.U按钮();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // out列表
            // 
            this.out列表.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.out列表.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader13,
            this.columnHeader11,
            this.columnHeader9});
            listViewItem1.StateImageIndex = 0;
            this.out列表.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.out列表.Location = new System.Drawing.Point(0, 42);
            this.out列表.Margin = new System.Windows.Forms.Padding(0);
            this.out列表.Name = "out列表";
            this.out列表.ShowItemToolTips = true;
            this.out列表.Size = new System.Drawing.Size(897, 508);
            this.out列表.TabIndex = 19;
            this.out列表.UseCompatibleStateImageBehavior = false;
            this.out列表.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "时间";
            this.columnHeader2.Width = 101;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "重要性";
            this.columnHeader4.Width = 52;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "标题";
            this.columnHeader11.Width = 250;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "内容";
            this.columnHeader9.Width = 400;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "线程";
            // 
            // in关键字
            // 
            this.in关键字.Location = new System.Drawing.Point(200, 2);
            this.in关键字.Name = "in关键字";
            this.in关键字.Size = new System.Drawing.Size(100, 23);
            this.in关键字.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 42;
            this.label1.Text = "重要性";
            // 
            // in重要性
            // 
            this.in重要性.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.in重要性.FormattingEnabled = true;
            this.in重要性.Location = new System.Drawing.Point(52, 1);
            this.in重要性.Name = "in重要性";
            this.in重要性.Size = new System.Drawing.Size(80, 25);
            this.in重要性.TabIndex = 41;
            // 
            // do清空
            // 
            this.do清空.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do清空.FlatAppearance.BorderSize = 0;
            this.do清空.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do清空.ForeColor = System.Drawing.Color.White;
            this.do清空.Location = new System.Drawing.Point(665, 0);
            this.do清空.Name = "do清空";
            this.do清空.Size = new System.Drawing.Size(90, 26);
            this.do清空.TabIndex = 52;
            this.do清空.Text = "清空";
            this.do清空.UseVisualStyleBackColor = false;
            this.do清空.大小 = new System.Drawing.Size(90, 26);
            this.do清空.文字颜色 = System.Drawing.Color.White;
            this.do清空.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // do更新配置
            // 
            this.do更新配置.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do更新配置.FlatAppearance.BorderSize = 0;
            this.do更新配置.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do更新配置.ForeColor = System.Drawing.Color.White;
            this.do更新配置.Location = new System.Drawing.Point(569, 0);
            this.do更新配置.Name = "do更新配置";
            this.do更新配置.Size = new System.Drawing.Size(90, 26);
            this.do更新配置.TabIndex = 51;
            this.do更新配置.Text = "更新配置";
            this.do更新配置.UseVisualStyleBackColor = false;
            this.do更新配置.大小 = new System.Drawing.Size(90, 26);
            this.do更新配置.文字颜色 = System.Drawing.Color.White;
            this.do更新配置.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // do导出
            // 
            this.do导出.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do导出.FlatAppearance.BorderSize = 0;
            this.do导出.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do导出.ForeColor = System.Drawing.Color.White;
            this.do导出.Location = new System.Drawing.Point(761, 0);
            this.do导出.Name = "do导出";
            this.do导出.Size = new System.Drawing.Size(90, 26);
            this.do导出.TabIndex = 50;
            this.do导出.Text = "导出";
            this.do导出.UseVisualStyleBackColor = false;
            this.do导出.大小 = new System.Drawing.Size(90, 26);
            this.do导出.文字颜色 = System.Drawing.Color.White;
            this.do导出.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // do开启
            // 
            this.do开启.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do开启.FlatAppearance.BorderSize = 0;
            this.do开启.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do开启.ForeColor = System.Drawing.Color.White;
            this.do开启.Location = new System.Drawing.Point(473, 0);
            this.do开启.Name = "do开启";
            this.do开启.Size = new System.Drawing.Size(90, 26);
            this.do开启.TabIndex = 49;
            this.do开启.Text = "开启";
            this.do开启.UseVisualStyleBackColor = false;
            this.do开启.大小 = new System.Drawing.Size(90, 26);
            this.do开启.文字颜色 = System.Drawing.Color.White;
            this.do开启.颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(150, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 45;
            this.label3.Text = "关键字";
            // 
            // F开发日志
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.do清空);
            this.Controls.Add(this.do更新配置);
            this.Controls.Add(this.do导出);
            this.Controls.Add(this.do开启);
            this.Controls.Add(this.in关键字);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.in重要性);
            this.Controls.Add(this.out列表);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "F开发日志";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(897, 550);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListViewK out列表;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.TextBox in关键字;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox in重要性;
        private Utility.WindowsForm.U按钮 do清空;
        private Utility.WindowsForm.U按钮 do更新配置;
        private Utility.WindowsForm.U按钮 do导出;
        private Utility.WindowsForm.U按钮 do开启;
        private System.Windows.Forms.Label label3;


    }
}
