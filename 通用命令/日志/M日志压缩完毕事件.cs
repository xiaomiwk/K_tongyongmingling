using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 通用命令.日志
{
    public class M日志压缩完毕事件
    {
        public bool 成功 { get; set; }
        public string 描述 { get; set; }
        public string 相对路径 { get; set; }
        public string 下载地址 { get; set; }
    }
}
