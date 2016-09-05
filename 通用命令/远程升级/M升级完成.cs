using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 通用命令.远程升级
{
    public class M升级完成
    {
        public bool 成功 { get; set; }

        public string 描述 { get; set; }

        public bool 需要重启 { get; set; }
    }
}
