using System.Collections.Generic;
using System.Net;
using 通用访问;
using 通用访问.自定义序列化;

namespace 通用命令.鉴权
{
    public interface IB鉴权_C
    {
        List<M已登录设备> 已登录列表 { get; }

        void 登录(M登录请求 __请求);

        void 注销();

        List<M已登录设备> 查询(IPAddress __地址, int? __端口号, string __账号);
    }

    public class B鉴权_C : IB鉴权_C
    {
        private IT客户端 _IT客户端;

        private string _对象名称 = "鉴权";

        public B鉴权_C(IT客户端 __IT客户端)
        {
            _IT客户端 = __IT客户端;
        }

        public void 登录(M登录请求 __请求)
        {
            _IT客户端.执行方法(_对象名称, "登录", new Dictionary<string, string> { { "请求参数", HJSON.序列化(__请求) } });
        }

        public void 注销()
        {
            _IT客户端.执行方法(_对象名称, "注销", null);
        }

        public List<M已登录设备> 已登录列表
        {
            get { return HJSON.反序列化<List<M已登录设备>>(_IT客户端.查询属性值(_对象名称, "已登录列表")); }
        }

        //public M已登录设备 查询(IPEndPoint __地址)
        //{
        //    return HJSON.反序列化<M已登录设备>(_IT客户端.执行方法(_对象名称, "查询", new List<M实参>
        //    {
        //        new M实参 { 名称 = "IP", 值 = __地址.Address.ToString() },
        //        new M实参 { 名称 = "端口号", 值 = __地址.Port.ToString() },
        //    })); 
        //}

        public List<M已登录设备> 查询(IPAddress __地址, int? __端口号, string __账号)
        {
            return HJSON.反序列化<List<M已登录设备>>(_IT客户端.执行方法(_对象名称, "查询", new Dictionary<string, string> { { "IP", __地址.ToString() }, { "端口号", __端口号.ToString() }, { "账号", __账号 } }));
        }
    }
}
