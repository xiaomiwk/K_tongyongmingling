using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 通用命令.系统
{
    public class M版本记录
    {
        //版本号, 标签[], 修改记录
        public string 版本号 { get; set; }
        public List<string> 标签 { get; set; }
        public string 修改记录 { get; set; }
    }
}
