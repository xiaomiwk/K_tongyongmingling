using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 通用命令.远程升级
{
    public class M存储版本
    {
        public string 版本号 { get; set; }

        public List<string> 标签 { get; set; }

        public string 文件路径 { get; set; }

        public bool 补丁 { get; set; }

        public string md5校验码 { get; set; }
    }
}
