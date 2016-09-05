using System;
using System.Net;

namespace 通用命令.链路
{
    public class M链路
    {
        public IPAddress IP { get; set; }

        public int 端口号 { get; set; }

        public string 设备类型 { get; set; }

        public string 设备标识 { get; set; }
        
        public string 账号 { get; set; }

        public DateTime 建立连接时间 { get; set; }

    }
}
