using System;
using System.Diagnostics;
using System.Windows.Forms;
using INET;
using Utility.通用;

namespace 通用命令.迷你网管
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            H调试.初始化();
            H日志输出.设置(__日志 => H调试.记录(__日志.概要, __日志.等级, __日志.详细, __日志.方法, __日志.文件, __日志.行号), TraceEventType.Warning);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new F主窗口());
        }
    }
}
