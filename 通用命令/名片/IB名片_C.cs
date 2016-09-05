using System.Collections.Generic;
using 通用访问;

namespace 通用命令.名片
{
    public interface IB名片_C
    {
        M名片 名片 { get; }

        List<M参数> 参数列表 { get; }
    }

    public class B名片_C : IB名片_C
    {
        private IT客户端 _IT客户端;

        private string _对象名称 = "名片";

        private M名片 _名片;

        public M名片 名片 {
            get
            {
                return _名片 ?? (_名片 = HJSON.反序列化<M名片>(_IT客户端.执行方法(_对象名称, "查询", null)));
            }
        }

        private List<M参数> _参数列表;

        public List<M参数> 参数列表 {
            get
            {
                return _参数列表 ?? (_参数列表 = HJSON.反序列化<List<M参数>>(_IT客户端.执行方法(_对象名称, "查询参数", null)));
            }
        }

        public B名片_C(IT客户端 __IT客户端)
        {
            _IT客户端 = __IT客户端;
        }

    }
}
