using System.Collections.Generic;
using 通用访问;
using 通用访问.DTO;

namespace 通用命令.名片
{
    public interface IB名片_S
    {
        M名片 名片 { get; }

        List<M参数> 参数列表 { get; }

        void 初始化(M名片 名片, List<M参数> 属性列表);

    }

    public class B名片_S : IB名片_S
    {
        private IT服务端 _IT服务端;

        private string _对象名称 = "名片";

        public B名片_S(IT服务端 __IT服务端)
        {
            _IT服务端 = __IT服务端;
            配置通用访问();
        }

        private void 配置通用访问()
        {
            var _对象 = new M对象(_对象名称, "通用服务");
            _对象.添加属性("名称", () => 名片.名称, E角色.客户);
            _对象.添加属性("描述", () => 名片.描述, E角色.客户);
            _对象.添加属性("版本号", () => 名片.版本号, E角色.客户);
            _对象.添加属性("版本时间", () => 名片.版本时间, E角色.客户);
            _对象.添加方法("查询", __实参列表 => HJSON.序列化(名片), E角色.客户, null, null);
            _对象.添加方法("查询参数", __实参列表 => HJSON.序列化(参数列表), E角色.客户, null, null);

            _IT服务端.添加对象(_对象名称, () => _对象);
        }

        public M名片 名片 { get; set; }

        public List<M参数> 参数列表 { get; set; }

        public void 初始化(M名片 __名片, List<M参数> __参数)
        {
            名片 = __名片;
            参数列表 = __参数;
        }

    }

}
