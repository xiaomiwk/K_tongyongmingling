using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 通用命令.名片
{
    public class M参数
    {
        public string 名称 { get; set; }
        public string 值 { get; set; }

        public M参数()
        {
        }

        public M参数(string __名称, string __值)
        {
            名称 = __名称;
            值 = __值;
        }
    }
}
