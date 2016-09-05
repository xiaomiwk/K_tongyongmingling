using System;
using System.Collections.Generic;
using System.Net;

namespace 通用命令.点名
{
    public class M点名事件
    {
        public IPEndPoint 地址 { get; set; }

        public E事件 类型 { get; set; }

        public M点名事件参数 参数 { get; set; }

    }
}
