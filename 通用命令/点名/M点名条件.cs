using System.Collections.Generic;
using 通用命令.名片;
using 通用命令.状态;

namespace 通用命令.点名
{
    public class M点名条件
    {
        public List<M参数> 参数列表 { get; set; }

        public E健康状态? 健康状态 { get; set; }
    }
}
