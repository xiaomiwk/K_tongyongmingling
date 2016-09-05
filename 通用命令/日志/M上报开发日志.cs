using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 通用命令.日志
{
    public class M上报开发日志
    {
        public DateTime 时间 { get; set; }

        public E重要性 重要性 { get; set; }

        public string 线程 { get; set; }

        public string 标题 { get; set; }

        public string 内容 { get; set; }

    }
}
