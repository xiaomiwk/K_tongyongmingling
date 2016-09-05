using System;
using System.Collections.Generic;

namespace 通用命令.状态
{
    public class M业务概要
    {
        //类别, 属性, 当前值, 正常范围, 正常, 单位, 描述
        public string 类别 { get; set; }

        public string 属性 { get; set; }

        public string 当前值 { get; set; }

        public string 正常范围 { get; set; }

        public bool 正常 { get; set; }

        public string 单位 { get; set; }

        public string 描述 { get; set; }
    }

}
