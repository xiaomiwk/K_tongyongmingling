using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Utility.通用;
using 通用命令.名片;
using 通用命令.状态;
using 通用访问;
using 通用访问.DTO;

namespace 通用命令.点名
{
    public interface IB点名_S
    {
        bool 支持发送点名 { get; }

        bool 支持点名响应 { get; }

        void 点名(M点名条件 条件);

        void 初始化(IPEndPoint __点名请求地址 = null, IPEndPoint __点名响应地址 = null);

        event Action<M点名事件> 设备事件上报;

        void 发布事件(E事件 __事件);
    }

    public class B点名_S : IB点名_S
    {
        private IT服务端 _IT服务端;

        private IB状态_S _IB状态 = H容器.取出<IB状态_S>();

        private IB名片_S _IB名片 = H容器.取出<IB名片_S>();

        private string _对象名称 = "点名";

        private IB组播点名 _IB组播点名 = new B组播点名();

        private IPEndPoint _请求地址;

        private IPEndPoint _响应地址;

        public B点名_S(IT服务端 __IT服务端)
        {
            _IT服务端 = __IT服务端;
            配置通用访问();
        }

        private void 配置通用访问()
        {
            var _对象 = new M对象(_对象名称, "通用服务");
            _对象.添加属性("支持发送点名", () => 支持发送点名.ToString(), E角色.客户, null);
            _对象.添加属性("支持点名响应", () => 支持点名响应.ToString(), E角色.客户, null);
            _对象.添加属性("点名请求地址", () => _请求地址.ToString(), E角色.客户, null);
            _对象.添加属性("事件上报地址", () => _响应地址.ToString(), E角色.客户, null);
            _对象.添加方法("点名", __实参列表 =>
            {
                var __条件 = HJSON.反序列化<M点名条件>(__实参列表["点名条件"]);
                点名(__条件);
                return "";
            }, E角色.客户, new List<M形参> { new M形参{ 名称 = "点名条件", 元数据 = new M元数据
            { 
                结构 = E数据结构.对象, 子成员列表 = new List<M子成员>
                {
                    new M子成员("参数列表", new M元数据{ 结构 = E数据结构.对象数组, 子成员列表 = new List<M子成员>
                    {
                        new M子成员("名称", "string"),
                        new M子成员("值", "int"),
                    }}),
                    new M子成员("状态概要", new M元数据{ 结构 = E数据结构.对象, 子成员列表 = new List<M子成员>
                    {
                        new M子成员("健康状态", "string"),
                        new M子成员("未清除告警数量", "int"),
                        new M子成员("启动时间", "string"),
                        new M子成员("状态开始时间", "string"),
                    }}),
                }
            } } }, null);

            _对象.添加事件("设备事件上报", E角色.客户, new List<M形参> { new M形参{ 名称 = "事件参数", 元数据 = new M元数据
            { 
                结构 = E数据结构.对象, 子成员列表 = new List<M子成员>
                {
                    new M子成员("地址", "string"),
                    new M子成员("类型", "string"),
                    new M子成员("参数", new M元数据
                    {
                         结构 = E数据结构.对象, 子成员列表 = new List<M子成员>
                         {
                            new M子成员("参数列表", new M元数据{ 结构 = E数据结构.对象数组, 子成员列表 = new List<M子成员>
                            {
                                new M子成员("名称", "string"),
                                new M子成员("值", "int"),
                            }}),
                            new M子成员("状态概要", new M元数据{ 结构 = E数据结构.对象, 子成员列表 = new List<M子成员>
                            {
                                new M子成员("健康状态", "string"),
                                new M子成员("未清除告警数量", "int"),
                                new M子成员("启动时间", "string"),
                                new M子成员("状态开始时间", "string"),
                            }}),
                         }
                    }),
                }
            } } });

            _IT服务端.添加对象(_对象名称, () => _对象);
        }

        public bool 支持发送点名 { get { return true; } }

        public bool 支持点名响应 { get { return true; } }

        public void 初始化(IPEndPoint __请求地址 = null, IPEndPoint __响应地址 = null)
        {
            _请求地址 = __请求地址 ?? new IPEndPoint(IPAddress.Parse("226.1.1.1"), 8888);
            _响应地址 = __响应地址 ?? new IPEndPoint(IPAddress.Parse("226.1.1.1"), 8889);

            _IB组播点名.收到事件 += On设备事件上报;
            _IB组播点名.初始化(处理被点名, __请求地址, __响应地址);
        }

        public void 点名(M点名条件 __条件)
        {
            _IB组播点名.点名(__条件);
        }

        public void 发布事件(E事件 __事件)
        {
            _IB组播点名.发布事件(__事件, new M点名事件参数 { 概要状态 = _IB状态.查询概要状态(), 名片 = _IB名片.名片 });
        }

        public event Action<M点名事件> 设备事件上报;

        protected virtual void On设备事件上报(M点名事件 __事件)
        {
            var handler = 设备事件上报;
            if (handler != null) handler(__事件);
            _IT服务端.触发事件(_对象名称, "设备事件上报", new Dictionary<string, string> { { "事件", __事件.ToString() } });
        }

        private M点名事件参数 处理被点名(M点名条件 __条件)
        {
            //TODO 检验
            return new M点名事件参数 { 概要状态 = _IB状态.查询概要状态(), 名片 = _IB名片.名片 };
        }
    }

}
