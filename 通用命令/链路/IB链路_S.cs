using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using 通用访问;
using 通用访问.DTO;

namespace 通用命令.链路
{
    /// <summary>
    /// 只负责互联, 不复杂内部鉴权逻辑
    /// </summary>
    public interface IB链路_S
    {
        List<M链路> 已连接设备 { get; }

        void 建立(M链路 __请求);

        void 断开(IPEndPoint __来源地址);

        event Action<M链路> 已建立连接;

        event Action<M链路> 已断开连接;
    }

    public class B链路_S : IB链路_S
    {
        private IT服务端 _IT服务端;

        private string _对象名称 = "链路";

        Dictionary<IPEndPoint, M链路> _登录缓存 = new Dictionary<IPEndPoint, M链路>();

        public B链路_S(IT服务端 __IT服务端)
        {
            _IT服务端 = __IT服务端;
            配置通用访问();
        }

        private void 配置通用访问()
        {
            var _对象 = new M对象(_对象名称, "通用服务");
            _对象.添加属性("已连接设备", () => HJSON.序列化(_登录缓存.Values.ToList()), E角色.客户, null);
            _对象.添加事件("已建立连接", E角色.客户, new List<M形参>
            {
                new M形参{ 名称 = "事件参数", 元数据 = new M元数据
                    { 
                        //IP, 端口号, 设备类型, 设备标识, 账号, 成功, 描述
                        结构 = E数据结构.对象, 子成员列表 = new List<M子成员>
                        {
                            new M子成员("IP", "string"),
                            new M子成员("端口号", "int"),
                            new M子成员("设备类型","string"),
                            new M子成员("设备标识", "string"),
                            new M子成员("账号", "string"),
                        }
                    }
                }
            });
            _对象.添加事件("已断开连接", E角色.客户, new List<M形参>
            {
                new M形参{ 名称 = "事件参数", 元数据 = new M元数据
                    { 
                        //IP, 端口号, 设备类型, 设备标识, 账号, 成功, 描述
                        结构 = E数据结构.对象, 子成员列表 = new List<M子成员>
                        {
                            new M子成员("IP", "string"),
                            new M子成员("端口号", "int"),
                            new M子成员("设备类型","string"),
                            new M子成员("设备标识", "string"),
                            new M子成员("账号", "string"),
                        }
                    }
                }
            });

            _IT服务端.添加对象(_对象名称, () => _对象);
        }

        public void 建立(M链路 __链路)
        {
            var __地址 = new IPEndPoint(__链路.IP, __链路.端口号);
            if (!_登录缓存.ContainsKey(__地址))
            {
                _登录缓存[__地址] = __链路;
                On已建立连接(__链路);
                _IT服务端.触发事件(_对象名称, "已建立连接",new Dictionary<string,string>{{"事件参数",HJSON.序列化(__链路)}} );
            }
        }

        public void 断开(IPEndPoint __来源地址)
        {
            if (_登录缓存.ContainsKey(__来源地址))
            {
                var __链路 = _登录缓存[__来源地址];
                On已断开连接(__链路);
                _IT服务端.触发事件(_对象名称, "已断开连接", new Dictionary<string,string>{{"事件参数", HJSON.序列化(__链路)}});
                _登录缓存.Remove(__来源地址);
            }
        }

        public List<M链路> 已连接设备
        {
            get { return new List<M链路>(_登录缓存.Values); }
        }

        public event Action<M链路> 已建立连接;

        public event Action<M链路> 已断开连接;

        protected virtual void On已断开连接(M链路 obj)
        {
            var handler = 已断开连接;
            if (handler != null) handler(obj);
        }

        protected virtual void On已建立连接(M链路 obj)
        {
            var handler = 已建立连接;
            if (handler != null) handler(obj);
        }
    }
}
