using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using INET;
using Utility.Windows;
using Utility.通用;
using 通用命令.FTP;
using 通用命令.名片;
using 通用命令.日志;
using 通用命令.点名;
using 通用命令.状态;
using 通用命令.系统;
using 通用命令.链路;
using 通用访问;

namespace 通用命令.服务端测试
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            H调试.初始化();
            H日志输出.设置(__日志 => H调试.记录(__日志.概要, __日志.等级, __日志.详细, __日志.方法, __日志.文件, __日志.行号), TraceEventType.Warning);
            var __服务端列表 = new List<IT服务端>();
            var __随机数 = new Random();
            for (int __端口 = 8001; __端口 <= 8001; __端口++)
            {
                #region 初始化环境
                IT服务端 __IT服务端 = FT通用访问工厂.创建服务端();
                __IT服务端.端口 = __端口;
                __服务端列表.Add(__IT服务端);
                #endregion

                #region 配置通用命令
                var __标识 = __端口.ToString();
                H容器.注入<IB名片_S, B名片_S>(true, true, __标识, __IT服务端);
                H容器.注入<IB系统_S, B系统_S>(true, true, __标识, __IT服务端);
                H容器.注入<IB状态_S, B状态_S>(true, true, __标识, __IT服务端);
                H容器.注入<IBFTP_S, BFTP_S>(true, true, __标识, __IT服务端);

                H容器.取出<IB名片_S>(__标识).初始化(
                    new M名片 { 名称 = "设备1", 描述 = "描述1", 版本号 = "1.0.0.0", 版本时间 = DateTime.Now.ToString() },
                    new List<M参数> { new M参数("IP列表", "192.168.1.1,202.195.114.1"), new M参数("系统", "Windows 7") });
                H容器.取出<IB状态_S>(__标识).初始化(null, DateTime.Now);
                H容器.取出<IBFTP_S>(__标识);
                H容器.取出<IB系统_S>(__标识).初始化(() =>
                {
                    Console.WriteLine("重启");
                }, () =>
                {
                    Console.WriteLine("关闭");
                }, () =>
                {
                    Console.WriteLine("查询版本记录");
                    return new List<M版本记录>
                {
                    new M版本记录{ 版本号 = "1.0.0.0", 修改记录 = "xxx", 标签 = new List<string>{ "a", "b"}}, 
                    new M版本记录{ 版本号 = "1.0.1.0", 修改记录 = "yyy", 标签 = new List<string>{ "a1", "b1"}}, 
                };
                });

                #endregion

                #region 交互
                //H容器.取出<IBFTP_S>(__标识).开启();
                H容器.取出<IB状态_S>(__标识).设置属性("类别1", "属性1", () => new M业务概要 { 类别 = "类别1", 属性 = "属性1", 当前值 = "1", 正常 = true });
                H容器.取出<IB状态_S>(__标识).设置属性("类别1", "属性2", () => new M业务概要 { 类别 = "类别1", 属性 = "属性2", 当前值 = "1", 正常 = false });
                Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < 100; i++)
                    {
                        if (i % 8 < 4)
                        {
                            H容器.取出<IB状态_S>(__标识).新增告警(new M上报告警
                            {
                                标识 = i.ToString(),
                                产生时间 = DateTime.Now,
                                来源设备类型 = "来源设备类型",
                                来源设备标识 = "来源设备标识",
                                重要性 = (通用命令.状态.E重要性)(i % 4),
                                类别 = "类别",
                                描述 = "描述",
                                原因 = "原因",
                                解决方案 = "解决方案"
                            });
                        }
                        else
                        {
                            H容器.取出<IB状态_S>(__标识).清除告警(new M上报清除
                            {
                                标识 = (i / 8 * 8 + (8 - i % 8)).ToString(),
                                来源设备类型 = "来源设备类型",
                                来源设备标识 = "来源设备标识",
                            });
                        }
                        Thread.Sleep(1000 * __随机数.Next(3,3));
                    }
                });

                #endregion

                //break;
            }
            __服务端列表.ForEach(q => q.开启());
            Console.WriteLine("启动完毕, 按回车键关闭");
            Console.ReadLine();
            Console.WriteLine("关闭中");
            __服务端列表.ForEach(q => q.关闭());
            Console.WriteLine("按回车键退出");
            Console.ReadLine();
        }

        private static void 参考(string __标识, IT服务端 __IT服务端)
        {
            H容器.注入<IB链路_S, B链路_S>(true, true, __标识, __IT服务端);
            H容器.注入<IB日志_S, B日志_S>(true, true, __标识, __IT服务端);
            H容器.注入<IB点名_S, B点名_S>(true, true, __标识, __IT服务端);

            H容器.取出<IB点名_S>(__标识).初始化();
            H容器.取出<IB链路_S>(__标识);
            H容器.取出<IB状态_S>(__标识).健康状态变化 += q => H容器.取出<IB点名_S>().发布事件(E事件.健康状态变化);
            H容器.取出<IB点名_S>(__标识).发布事件(E事件.启动完成);
            H日志.输出通知 += (__标题, __内容, __等级, __线程) =>
            {
                var __重要性 = 通用命令.日志.E重要性.一般;
                switch (__等级)
                {
                    case TraceEventType.Critical:
                    case TraceEventType.Error:
                        __重要性 = 通用命令.日志.E重要性.紧急;
                        break;
                    case TraceEventType.Warning:
                        __重要性 = 通用命令.日志.E重要性.紧急;
                        break;
                    case TraceEventType.Information:
                        __重要性 = 通用命令.日志.E重要性.次要;
                        break;
                }
                H容器.取出<IB日志_S>(__标识).新增开发日志(new 通用命令.日志.M上报开发日志
                {
                    标题 = __标题,
                    时间 = DateTime.Now,
                    内容 = __内容,
                    线程 = __线程,
                    重要性 = __重要性
                });
            };
            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    H容器.取出<IB日志_S>(__标识).新增工程日志(new 通用命令.日志.M上报工程日志
                    {
                        边界类型 = "对端设备类型" + i,
                        边界标识 = "对端设备名称" + i,
                        方向 = "输入",
                        描述 = "描述" + i,
                        时间 = DateTime.Now,
                        业务标签 = new List<string> { "标签" + i, "标签" + (i + 1), "标签" + (i + 1) },
                        业务标识 = "业务标识" + i,
                        业务类型 = "业务类型" + i,
                        重要性 = (通用命令.日志.E重要性)(i % 4)
                    });
                    if (i % 2 == 0)
                    {
                        H容器.取出<IB链路_S>(__标识)
                            .建立(new M链路
                            {
                                IP = IPAddress.Parse("192.168.1.1"),
                                端口号 = 11,
                                建立连接时间 = DateTime.Now,
                                设备标识 = "设备标识1",
                                设备类型 = "设备类型1"
                            });
                        H容器.取出<IB链路_S>(__标识)
                            .建立(new M链路
                            {
                                IP = IPAddress.Parse("192.168.1.2"),
                                端口号 = 12,
                                建立连接时间 = DateTime.Now,
                                设备标识 = "设备标识2",
                                设备类型 = "设备类型2",
                                账号 = "k"
                            });
                    }
                    else
                    {
                        H容器.取出<IB链路_S>(__标识).断开(new IPEndPoint(IPAddress.Parse("192.168.1.1"), 11));
                    }
                    Thread.Sleep(3000);
                }
            });

        }
    }
}
