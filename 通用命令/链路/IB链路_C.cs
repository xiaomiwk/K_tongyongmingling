using System;
using System.Collections.Generic;
using 通用访问;
using 通用访问.自定义序列化;

namespace 通用命令.链路
{
    /// <summary>
    /// 只负责互联, 不复杂内部鉴权逻辑
    /// </summary>
    public interface IB链路_C
    {
        List<M链路> 已连接设备 { get; }

        event Action<M链路> 已建立连接;

        event Action<M链路> 已断开连接;
    }

    public class B链路_C : IB链路_C
    {
        private IT客户端 _IT客户端;

        private string _对象名称 = "链路";

        public B链路_C(IT客户端 __IT客户端)
        {
            _IT客户端 = __IT客户端;
        }

        public List<M链路> 已连接设备
        {
            get { return HJSON.反序列化<List<M链路>>(_IT客户端.查询属性值(_对象名称, "已连接设备")); }
        }

        Action<M链路> _已建立连接;

        public event Action<M链路> 已建立连接
        {
            add
            {
                if (_已建立连接 == null)
                {
                    _IT客户端.订阅事件(_对象名称, "已建立连接", 处理已建立连接);
                }
                _已建立连接 += value;
            }
            remove
            {
                if (_已建立连接 != null)
                {
                    _已建立连接 -= value;
                    if (_已建立连接 == null)
                    {
                        _IT客户端.注销事件(_对象名称, "已建立连接", 处理已建立连接);
                    }
                }
            }
        }

        protected virtual void On已建立连接(M链路 obj)
        {
            var handler = _已建立连接;
            if (handler != null) handler(obj);
        }

        private void 处理已建立连接(Dictionary<string,string> __实参列表)
        {
            var __链路 = HJSON.反序列化<M链路>(__实参列表["事件参数"]);
            On已建立连接(__链路);
        }


        Action<M链路> _已断开连接;

        public event Action<M链路> 已断开连接
        {
            add
            {
                if (_已断开连接 == null)
                {
                    _IT客户端.订阅事件(_对象名称, "已断开连接", 处理已断开连接);
                }
                _已断开连接 += value;
            }
            remove
            {
                if (_已断开连接 != null)
                {
                    _已断开连接 -= value;
                    if (_已断开连接 == null)
                    {
                        _IT客户端.注销事件(_对象名称, "已断开连接", 处理已断开连接);
                    }
                }
            }
        }

        protected virtual void On已断开连接(M链路 obj)
        {
            var handler = _已断开连接;
            if (handler != null) handler(obj);
        }

        private void 处理已断开连接(Dictionary<string,string> __实参列表)
        {
            var __链路 = HJSON.反序列化<M链路>(__实参列表["事件参数"]);
            On已断开连接(__链路);
        }

    }
}
