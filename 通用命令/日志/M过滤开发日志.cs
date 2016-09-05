using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 通用命令.日志
{
    public class M过滤开发日志
    {
        public E重要性? 重要性 { get; set; }

        public List<string> 线程关键字 { get; set; }

        public List<string> 标题关键字 { get; set; }

        public List<string> 内容关键字 { get; set; }
    }
}
