using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using 通用命令.名片;
using 通用命令.状态;
using 通用访问;

namespace 通用命令.迷你网管
{
    public class M设备
    {
        public string 分组 { get; set; }

        public string 设备标识 { get; set; }

        public IPAddress IP { get; set; }

        public int 端口号 { get; set; }

        public M名片 名片 { get; set; }

        public M概要状态 概要状态 { get; set; }

        public IT客户端 访问入口 { get; set; }
    }
}
