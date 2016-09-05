using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 通用命令.日志
{
    public class M过滤工程日志
    {
        public E重要性? 重要性 { get; set; }

        public string 方向 { get; set; }

        public string 边界类型 { get; set; }

        public string 边界标识 { get; set; }

        public List<string> 业务类型 { get; set; }

        public string 业务标识 { get; set; }

        public List<string> 业务标签 { get; set; }

        public List<string> 关键字 { get; set; }
    }
}
