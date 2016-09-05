using System;
using System.Collections.Generic;
using 通用访问;
using 通用访问.DTO;

namespace 通用命令.系统
{
    public interface IB系统_S
    {
        Action 重启 { get; set; }

        Action 关闭 { get; set; }

        void 初始化(Action 重启, Action 关闭, Func<List<M版本记录>> 查询版本记录);
    }

    public class B系统_S : IB系统_S
    {
        private IT服务端 _IT服务端;

        private string _对象名称 = "系统";

        public Action 重启 { get; set; }

        public Action 关闭 { get; set; }

        public Func<List<M版本记录>> 查询版本记录 { get; set; }

        public B系统_S(IT服务端 __IT服务端)
        {
            _IT服务端 = __IT服务端;
            配置通用访问();
        }

        public void 初始化(Action __重启, Action __关闭, Func<List<M版本记录>> __查询版本记录)
        {
            重启 = __重启;
            关闭 = __关闭;
            查询版本记录 = __查询版本记录;
        }

        private void 配置通用访问()
        {
            var _对象 = new M对象(_对象名称, "通用服务");
            _对象.添加方法("重启", q =>
            {
                if (重启 != null)
                {
                    重启();
                    return "";
                }
                throw new ApplicationException("该功能不支持");
            }, E角色.客户);
            _对象.添加方法("关闭", q =>
            {
                if (关闭 != null)
                {
                    关闭();
                    return "";
                }
                throw new ApplicationException("该功能不支持");
            }, E角色.客户);
            _对象.添加方法("查询版本记录", q =>
            {
                if (查询版本记录 != null)
                {
                    return HJSON.序列化(查询版本记录());
                }
                throw new ApplicationException("该功能不支持");
            }, E角色.客户);
            _IT服务端.添加对象(_对象名称, () => _对象);
        }

    }
}
