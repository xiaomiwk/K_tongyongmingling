namespace 通用命令.迷你网管
{
    partial class F主窗口
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F主窗口));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.do读取默认配置 = new System.Windows.Forms.ToolStripMenuItem();
            this.do保存默认配置 = new System.Windows.Forms.ToolStripMenuItem();
            this.do编辑默认配置 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.do读取其他配置 = new System.Windows.Forms.ToolStripMenuItem();
            this.do另存配置 = new System.Windows.Forms.ToolStripMenuItem();
            this.u窗口背景1 = new Utility.WindowsForm.U窗口背景();
            this.do批量操作 = new Utility.WindowsForm.U按钮_轻();
            this.out设备列表 = new F设备列表();
            this.u窗体脚1 = new Utility.WindowsForm.U窗体脚();
            this.u窗体头1 = new Utility.WindowsForm.U窗体头();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.out标题 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.u窗口背景1.SuspendLayout();
            this.u窗体头1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.do读取默认配置,
            this.do保存默认配置,
            this.do编辑默认配置,
            this.toolStripSeparator1,
            this.do读取其他配置,
            this.do另存配置});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 120);
            // 
            // do读取默认配置
            // 
            this.do读取默认配置.Name = "do读取默认配置";
            this.do读取默认配置.Size = new System.Drawing.Size(146, 22);
            this.do读取默认配置.Text = "读取默认配置";
            // 
            // do保存默认配置
            // 
            this.do保存默认配置.Name = "do保存默认配置";
            this.do保存默认配置.Size = new System.Drawing.Size(146, 22);
            this.do保存默认配置.Text = "保存默认配置";
            // 
            // do编辑默认配置
            // 
            this.do编辑默认配置.Name = "do编辑默认配置";
            this.do编辑默认配置.Size = new System.Drawing.Size(146, 22);
            this.do编辑默认配置.Text = "编辑默认配置";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // do读取其他配置
            // 
            this.do读取其他配置.Name = "do读取其他配置";
            this.do读取其他配置.Size = new System.Drawing.Size(146, 22);
            this.do读取其他配置.Text = "从文件加载";
            // 
            // do另存配置
            // 
            this.do另存配置.Name = "do另存配置";
            this.do另存配置.Size = new System.Drawing.Size(146, 22);
            this.do另存配置.Text = "另存配置";
            // 
            // u窗口背景1
            // 
            this.u窗口背景1.Controls.Add(this.do批量操作);
            this.u窗口背景1.Controls.Add(this.out设备列表);
            this.u窗口背景1.Controls.Add(this.u窗体脚1);
            this.u窗口背景1.Controls.Add(this.u窗体头1);
            this.u窗口背景1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.u窗口背景1.Location = new System.Drawing.Point(0, 0);
            this.u窗口背景1.Margin = new System.Windows.Forms.Padding(0);
            this.u窗口背景1.Name = "u窗口背景1";
            this.u窗口背景1.Size = new System.Drawing.Size(1280, 702);
            this.u窗口背景1.TabIndex = 0;
            this.u窗口背景1.边框颜色 = System.Drawing.Color.Gainsboro;
            this.u窗口背景1.面板颜色 = System.Drawing.Color.Empty;
            // 
            // do批量操作
            // 
            this.do批量操作.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.do批量操作.BackColor = System.Drawing.Color.White;
            this.do批量操作.FlatAppearance.BorderSize = 0;
            this.do批量操作.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.do批量操作.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do批量操作.Location = new System.Drawing.Point(1178, 38);
            this.do批量操作.Name = "do批量操作";
            this.do批量操作.Size = new System.Drawing.Size(100, 26);
            this.do批量操作.TabIndex = 8;
            this.do批量操作.Text = "批量操作";
            this.do批量操作.UseVisualStyleBackColor = false;
            this.do批量操作.大小 = new System.Drawing.Size(100, 26);
            this.do批量操作.文字颜色 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(221)))));
            this.do批量操作.颜色 = System.Drawing.Color.White;
            // 
            // out设备列表
            // 
            this.out设备列表.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.out设备列表.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.out设备列表.Location = new System.Drawing.Point(18, 60);
            this.out设备列表.Name = "out设备列表";
            this.out设备列表.Size = new System.Drawing.Size(1246, 622);
            this.out设备列表.TabIndex = 7;
            this.out设备列表.精简 = false;
            // 
            // u窗体脚1
            // 
            this.u窗体脚1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.u窗体脚1.BackColor = System.Drawing.Color.White;
            this.u窗体脚1.Cursor = System.Windows.Forms.Cursors.PanSE;
            this.u窗体脚1.Location = new System.Drawing.Point(1246, 669);
            this.u窗体脚1.Name = "u窗体脚1";
            this.u窗体脚1.Size = new System.Drawing.Size(33, 32);
            this.u窗体脚1.TabIndex = 6;
            // 
            // u窗体头1
            // 
            this.u窗体头1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.u窗体头1.BackColor = System.Drawing.Color.White;
            this.u窗体头1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("u窗体头1.BackgroundImage")));
            this.u窗体头1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.u窗体头1.Controls.Add(this.pictureBox1);
            this.u窗体头1.Controls.Add(this.out标题);
            this.u窗体头1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.u窗体头1.Location = new System.Drawing.Point(1, 1);
            this.u窗体头1.Name = "u窗体头1";
            this.u窗体头1.Size = new System.Drawing.Size(1278, 47);
            this.u窗体头1.TabIndex = 4;
            this.u窗体头1.无背景图片 = false;
            this.u窗体头1.显示Logo = false;
            this.u窗体头1.显示最大化按钮 = true;
            this.u窗体头1.显示最小化按钮 = true;
            this.u窗体头1.显示标题 = false;
            this.u窗体头1.显示设置按钮 = true;
            this.u窗体头1.标题 = "标题";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::通用命令.迷你网管.Properties.Resources.K;
            this.pictureBox1.Location = new System.Drawing.Point(12, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // out标题
            // 
            this.out标题.AutoSize = true;
            this.out标题.BackColor = System.Drawing.Color.Transparent;
            this.out标题.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.out标题.Location = new System.Drawing.Point(38, 15);
            this.out标题.Name = "out标题";
            this.out标题.Size = new System.Drawing.Size(56, 17);
            this.out标题.TabIndex = 1;
            this.out标题.Text = "迷你网管";
            // 
            // F主窗口
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 702);
            this.Controls.Add(this.u窗口背景1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1920, 1050);
            this.Name = "F主窗口";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "迷你网管";
            this.contextMenuStrip1.ResumeLayout(false);
            this.u窗口背景1.ResumeLayout(false);
            this.u窗体头1.ResumeLayout(false);
            this.u窗体头1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Utility.WindowsForm.U窗口背景 u窗口背景1;
        private Utility.WindowsForm.U窗体头 u窗体头1;
        private System.Windows.Forms.Label out标题;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Utility.WindowsForm.U窗体脚 u窗体脚1;
        private F设备列表 out设备列表;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem do读取其他配置;
        private System.Windows.Forms.ToolStripMenuItem do另存配置;
        private System.Windows.Forms.ToolStripMenuItem do编辑默认配置;
        private System.Windows.Forms.ToolStripMenuItem do保存默认配置;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem do读取默认配置;
        private Utility.WindowsForm.U按钮_轻 do批量操作;
    }
}

