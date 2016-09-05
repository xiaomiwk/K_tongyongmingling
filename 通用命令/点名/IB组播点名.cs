using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Utility.通用;
using 通用访问;

namespace 通用命令.点名
{
    public interface IB组播点名
    {
        void 初始化(Func<M点名条件, M点名事件参数> __处理被点名, IPEndPoint __请求地址 = null, IPEndPoint __响应地址 = null);

        void 点名(M点名条件 __条件);

        void 发布事件(E事件 __事件, M点名事件参数 __参数);

        event Action<M点名事件> 收到事件;

        event Action<IPEndPoint> 设备被点名;
    }

    public class B组播点名 : IB组播点名
    {
        private IPEndPoint _请求地址;

        private IPEndPoint _响应地址;

        private Func<M点名条件, M点名事件参数> _处理被点名;

        public void 初始化(Func<M点名条件, M点名事件参数> __处理被点名, IPEndPoint __请求地址 = null, IPEndPoint __响应地址 = null)
        {
            _处理被点名 = __处理被点名;
            _请求地址 = __请求地址 ?? new IPEndPoint(IPAddress.Parse("226.1.1.1"), 8888);
            _响应地址 = __响应地址 ?? new IPEndPoint(IPAddress.Parse("226.1.1.1"), 8889);
            响应被点名();
            处理事件();
        }

        public void 点名(M点名条件 __条件)
        {
            var __udp = new UdpClient(0);
            var __内容 = Encoding.UTF8.GetBytes(HJSON.序列化(__条件));
            __udp.Send(__内容, __内容.Length, _请求地址);
        }

        public void 发布事件(E事件 __事件, M点名事件参数 __参数)
        {
            var __udp = new UdpClient(0);
            var __点名事件 = new M点名事件 { 地址 = (IPEndPoint)__udp.Client.LocalEndPoint, 参数 = __参数, 类型 = __事件 };
            var __内容 = Encoding.UTF8.GetBytes(HJSON.序列化(__点名事件));
            __udp.Send(__内容, __内容.Length, _响应地址);
        }

        private void 处理事件()
        {
            var __udp = new UdpClient(_响应地址.Port);
            __udp.JoinMulticastGroup(_响应地址.Address, 64);
            new Thread(() =>
            {
                IPEndPoint __远端 = null;
                var __响应列表 = new List<IPEndPoint>();
                while (true)
                {
                    var __接收数据 = __udp.Receive(ref __远端);
                    if (__响应列表.Contains(__远端))
                    {
                        continue;
                    }
                    __响应列表.Add(__远端);
                    var __接收信息 = Encoding.UTF8.GetString(__接收数据);
                    try
                    {
                        var __点名 = HJSON.反序列化<M点名事件>(__接收信息);
                        On收到事件(__点名);
                    }
                    catch (Exception ex)
                    {
                        H调试.记录异常(ex);
                    }
                }
            }) { IsBackground = true }.Start();
        }

        private void 响应被点名()
        {
            new Thread(() =>
            {
                var __udp = new UdpClient(_请求地址.Port);
                __udp.JoinMulticastGroup(_请求地址.Address, 64);
                IPEndPoint __远端 = null;

                while (true)
                {
                    var __接收数据 = __udp.Receive(ref __远端);
                    var __接收信息 = Encoding.UTF8.GetString(__接收数据);

                    try
                    {
                        var __点名条件 = HJSON.反序列化<M点名条件>(__接收信息);
                        var __事件参数 = _处理被点名 == null ? null : _处理被点名(__点名条件);
                        if (__事件参数 != null)
                        {
                            发布事件(E事件.点名响应, __事件参数);
                            On设备被点名(__远端);
                        }
                    }
                    catch (Exception ex)
                    {
                        H调试.记录异常(ex);
                    }
                }
            }) { IsBackground = true }.Start();
        }

        public event Action<M点名事件> 收到事件;

        protected virtual void On收到事件(M点名事件 obj)
        {
            var handler = 收到事件;
            if (handler != null) handler(obj);
        }

        public event Action<IPEndPoint> 设备被点名;

        protected virtual void On设备被点名(IPEndPoint obj)
        {
            var handler = 设备被点名;
            if (handler != null) handler(obj);
        }
    }
}
