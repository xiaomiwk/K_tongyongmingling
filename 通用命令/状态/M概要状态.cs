using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace 通用命令.状态
{
    public class M概要状态
    {
        public DateTime 启动时间 { get; set; }

        public E健康状态 健康状态 { get; set; }

        public DateTime 状态开始时间 { get; set; }

        public int 未清除告警数量 { get; set; }

    }
}
