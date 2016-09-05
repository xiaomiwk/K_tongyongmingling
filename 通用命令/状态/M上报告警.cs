using System;

namespace 通用命令.状态
{
    public class M上报告警
    {        //标识, 来源设备类型, 来源设备标识, 产生时间, 类别, 重要性, 描述, 原因, 解决方案
        public string 标识 { get; set; }

        public string 来源设备类型 { get; set; }

        public string 来源设备标识 { get; set; }

        public DateTime 产生时间 { get; set; }

        public string 类别 { get; set; }

        public E重要性 重要性 { get; set; }

        public string 描述 { get; set; }

        public string 原因 { get; set; }

        public string 解决方案 { get; set; }

    }
}
