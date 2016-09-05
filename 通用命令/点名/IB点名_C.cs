using System;
using System.Collections.Generic;
using 通用访问;

namespace 通用命令.点名
{
    public interface IB点名_C
    {
        bool 支持发送点名 { get; }

        bool 支持点名响应 { get; }

        void 点名(M点名条件 条件);

        event Action<M点名事件> 设备事件上报;
    }

    public class B点名_C : IB点名_C
    {
        private IT客户端 _IT客户端;

        private string _对象名称 = "点名";

        public B点名_C(IT客户端 __IT客户端)
        {
            _IT客户端 = __IT客户端;
        }

        public bool 支持发送点名
        {
            get
            {
                try
                {
                    return bool.Parse(_IT客户端.查询属性值(_对象名称, "支持发送点名"));
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool 支持点名响应
        {
            get
            {
                try
                {
                    return bool.Parse(_IT客户端.查询属性值(_对象名称, "支持点名响应"));
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public void 点名(M点名条件 条件)
        {
            _IT客户端.执行方法(_对象名称, "点名", new Dictionary<string,string>{{"点名条件",HJSON.序列化(条件)}});
        }

        Action<M点名事件> _设备事件上报;

        public event Action<M点名事件> 设备事件上报
        {
            add
            {
                if (_设备事件上报 == null)
                {
                    _IT客户端.订阅事件(_对象名称, "设备事件上报", 处理设备事件上报);
                }
                _设备事件上报 += value;
            }
            remove
            {
                if (_设备事件上报 != null)
                {
                    _设备事件上报 -= value;
                    if (_设备事件上报 == null)
                    {
                        _IT客户端.注销事件(_对象名称, "设备事件上报", 处理设备事件上报);
                    }
                }
            }
        }

        private void 处理设备事件上报(Dictionary<string,string> __实参列表)
        {
            var __事件 = HJSON.反序列化<M点名事件>(__实参列表["事件"]);
            On设备事件上报(__事件);
        }

        protected virtual void On设备事件上报(M点名事件 __事件)
        {
            var handler = _设备事件上报;
            if (handler != null) handler(__事件);
        }


    }
}
