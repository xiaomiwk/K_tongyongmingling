using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 通用命令.远程升级
{
    public class M请求上传
    {
        public string 版本号 { get; set; }

        public List<string> 标签 { get; set; }

        public string 文件名 { get; set; }

        public bool 补丁 { get; set; }

        public string md5校验码 { get; set; }

        /// <summary>
        /// 单位KB
        /// </summary>
        public int 大小 { get; set; }
    }
}
