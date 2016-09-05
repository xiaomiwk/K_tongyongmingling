using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 通用命令.远程升级
{
    public class M发送参数
    {
        public int 端口号 { get; set; }
        /// <summary>
        /// 单位KB
        /// </summary>
        public int 每包最大 { get; set; }
        /// <summary>
        /// 毫秒
        /// </summary>
        public int 每包间隔 { get; set; }
    }
}
