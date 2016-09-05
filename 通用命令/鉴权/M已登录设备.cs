using System;
using System.Collections.Generic;
using System.Net;

namespace 通用命令.鉴权
{
    public class M已登录设备
    {
        public IPAddress IP { get; set; }

        public int 端口号 { get; set; }

        public string 账号 { get; set; }

        public string 设备类型 { get; set; }

        public string 设备标识 { get; set; }

        public DateTime 登录时间 { get; set; }

        public string 备注 { get; set; }

    }

}
