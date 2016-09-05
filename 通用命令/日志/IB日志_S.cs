using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Utility.存储;
using Utility.通用;
using 通用访问;
using 通用访问.DTO;

namespace 通用命令.日志
{
    public interface IB日志_S
    {
        [NoLog]
        void 新增工程日志(M上报工程日志 日志);

        [NoLog]
        void 新增开发日志(M上报开发日志 日志);

        /// <param name="日志文件查询">为null, 默认使用当前目录下的日志子目录</param>
        void 初始化(Func<M日志文件查询条件, List<M日志文件>> 日志文件查询 = null);

    }

    public class B日志_S : IB日志_S
    {
        private IT服务端 _IT服务端;

        private string _对象名称 = "日志";

        private Dictionary<IPEndPoint, M过滤工程日志> _工程日志过滤 = new Dictionary<IPEndPoint, M过滤工程日志>();

        private Dictionary<IPEndPoint, M过滤开发日志> _开发日志过滤 = new Dictionary<IPEndPoint, M过滤开发日志>();

        private Func<M日志文件查询条件, List<M日志文件>> _日志文件查询;

        public B日志_S(IT服务端 __IT服务端)
        {
            _IT服务端 = __IT服务端;
            配置通用访问();
            _IT服务端.客户端已断开 += _IT服务端_客户端已断开;
        }

        public void 初始化(Func<M日志文件查询条件, List<M日志文件>> __日志文件查询 = null)
        {
            _日志文件查询 = __日志文件查询;
        }

        void _IT服务端_客户端已断开(IPEndPoint __地址)
        {
            if (_工程日志过滤.ContainsKey(__地址))
            {
                _工程日志过滤.Remove(__地址);
            }
            if (_开发日志过滤.ContainsKey(__地址))
            {
                _开发日志过滤.Remove(__地址);
            }
        }

        private void 配置通用访问()
        {
            var _对象 = new M对象(_对象名称, "通用服务");
            _对象.添加方法("查询日志文件", __实参列表 =>
            {
                var __条件 = HJSON.反序列化<M日志文件查询条件>(__实参列表["过滤参数"]);
                return HJSON.序列化(查询日志文件列表(__条件));
            }, E角色.客户, new List<M形参>
            {
                new M形参
                {
                    名称 = "过滤参数",
                    元数据 = new M元数据
                    {
                        结构 = E数据结构.对象,
                        子成员列表 = new List<M子成员>
                        {
                            new M子成员("起始时间", new M元数据 {类型 = "string", 描述 = "可为空"}),
                            new M子成员("结束时间", new M元数据 {类型 = "string", 描述 = "可为空"}),
                        }
                    }
                }
            });

            _对象.添加方法("删除日志文件", __实参列表 =>
            {
                var __条件 = HJSON.反序列化<List<string>>(__实参列表["地址列表"]);
                return HJSON.序列化(删除日志文件列表(__条件));
            }, E角色.客户, new List<M形参>
            {
                new M形参("地址列表","string", E数据结构.单值数组)
            });

            _对象.添加方法("导出日志文件", __实参列表 =>
            {
                var __条件 = HJSON.反序列化<List<string>>(__实参列表["地址列表"]);
                return HJSON.序列化(导出日志文件列表(__条件));
            }, E角色.客户, new List<M形参>
            {
                new M形参("地址列表","string", E数据结构.单值数组)
            });

            _对象.添加方法("压缩日志文件", __实参列表 =>
            {
                var __条件 = HJSON.反序列化<List<string>>(__实参列表["地址列表"]);
                string __下载地址;
                压缩日志文件列表(__条件, out __下载地址);
                return __下载地址;
            }, E角色.客户, new List<M形参>
            {
                new M形参("地址列表","string", E数据结构.单值数组)
            });

            _对象.添加方法("过滤工程日志", 设置工程日志过滤, E角色.客户, new List<M形参>
            {
                new M形参
                {
                    名称 = "过滤参数",
                    元数据 = new M元数据
                    {
                        结构 = E数据结构.对象,
                        子成员列表 = new List<M子成员>
                        {
                            new M子成员("重要性", new M元数据 {类型 = "string", 描述 = "可为空"}),
                            new M子成员("方向", new M元数据 {类型 = "string", 描述 = "可为空"}),
                            new M子成员("对端设备类型", new M元数据 {类型 = "string", 描述 = "可为空"}),
                            new M子成员("对端设备标识", new M元数据 {类型 = "string", 描述 = "可为空"}),
                            new M子成员("业务类型", new M元数据 {类型 = "string", 结构 = E数据结构.单值数组, 描述 = "可为空"}),
                            new M子成员("业务标识", new M元数据 {类型 = "string", 描述 = "可为空"}),
                            new M子成员("业务标签", new M元数据 {类型 = "string", 结构 = E数据结构.单值数组, 描述 = "可为空"}),
                            new M子成员("关键字", new M元数据 {类型 = "string", 结构 = E数据结构.单值数组, 描述 = "可为空"}),
                        }
                    }
                }
            });
            _对象.添加方法("过滤开发日志", 设置开发日志过滤, E角色.客户, new List<M形参>
            {
                new M形参
                {
                    名称 = "过滤参数",
                    元数据 = new M元数据
                    {
                        结构 = E数据结构.对象,
                        子成员列表 = new List<M子成员>
                        {
                            new M子成员("重要性", new M元数据 {类型 = "string", 描述 = "可为空"}),
                            new M子成员("线程", new M元数据 {类型 = "string", 结构 = E数据结构.单值数组, 描述 = "可为空"}),
                            new M子成员("标题", new M元数据 {类型 = "string", 结构 = E数据结构.单值数组, 描述 = "可为空"}),
                            new M子成员("内容", new M元数据 {类型 = "string", 结构 = E数据结构.单值数组, 描述 = "可为空"}),
                        }
                    }
                }
            });

            _对象.添加事件("上报工程日志", E角色.客户, new List<M形参>
            {
                new M形参{ 
                    名称 = "事件参数", 
                    元数据 = new M元数据
                    { 
                        //时间, 重要性, 方向(输入/输出), 对端设备类型, 对端设备名称, 业务类型, 业务标识, 业务标签[], 描述
                        结构 = E数据结构.对象, 子成员列表 = new List<M子成员>
                        {
                            new M子成员("时间", "string"),
                            new M子成员("重要性", "string"),
                            new M子成员("方向","string"),
                            new M子成员("对端设备类型", "string"),
                            new M子成员("对端设备标识", "string"),
                            new M子成员("业务类型", "string"),
                            new M子成员("业务标识","string"),
                            new M子成员("业务标签", new M元数据{ 类型 = "string", 结构 = E数据结构.单值数组,  描述 = "可选"}),
                            new M子成员("描述","string"),
                        }
                    }
                }
            });
            _对象.添加事件("上报开发日志", E角色.客户, new List<M形参>
            {
                new M形参{ 名称 = "事件参数", 元数据 = new M元数据
                { 
                    //时间, 重要性, 模块, 函数, 线程, 描述, 文件及行号
                    结构 = E数据结构.对象, 子成员列表 = new List<M子成员>
                    {
                        new M子成员("时间", "string"),
                        new M子成员("重要性", "string"),
                        new M子成员("线程","string"),
                        new M子成员("标题", "string"),
                        new M子成员("内容", "string"),
                    }
                }
                }
            });
            //_对象.添加事件("日志压缩完毕", E角色.客户, new List<M形参>
            //{
            //    new M形参{ 名称 = "事件参数", 元数据 = new M元数据
            //    { 
            //        //时间, 重要性, 模块, 函数, 线程, 描述, 文件及行号
            //        结构 = E数据结构.行, 子成员列表 = new List<M子成员>
            //        {
            //            new M子成员("成功", "bool"),
            //            new M子成员("描述", "string"),
            //            new M子成员("相对路径","string"),
            //            new M子成员("下载地址", "string"),
            //        }
            //    }
            //    }
            //});
            _IT服务端.添加对象(_对象名称, () => _对象);
        }

        public void 新增工程日志(M上报工程日志 __日志)
        {
            var __缓存 = new Dictionary<IPEndPoint, M过滤工程日志>(_工程日志过滤);
            var __匹配 = new List<IPEndPoint>();
            foreach (var __kv in __缓存)
            {
                var __条件 = __kv.Value;
                if (!string.IsNullOrEmpty(__条件.边界类型) && __条件.边界类型 != __日志.边界类型)
                {
                    continue;
                }
                if (!string.IsNullOrEmpty(__条件.边界标识) && __条件.边界标识 != __日志.边界标识)
                {
                    continue;
                }
                if (!string.IsNullOrEmpty(__条件.方向) && __条件.方向 != __日志.方向)
                {
                    continue;
                }
                if (!string.IsNullOrEmpty(__条件.业务标识) && __条件.业务标识 != __日志.业务标识)
                {
                    continue;
                }
                if (__条件.重要性.HasValue && __条件.重要性 > __日志.重要性)
                {
                    continue;
                }
                if (__条件.关键字 != null && __条件.关键字.Count > 0 && (
                    __条件.关键字.All(q => !__日志.描述.Contains(q))
                    || __条件.关键字.All(q => !__日志.业务标识.Contains(q))
                    || __条件.关键字.All(q => !__日志.边界类型.Contains(q))
                    || __条件.关键字.All(q => !__日志.边界标识.Contains(q))
                    || (__日志.业务标签 != null && __日志.业务标签.Count > 0 && __条件.关键字.All(q => !__日志.业务标签.Contains(q)))
                    ))
                {
                    continue;
                }
                if (__条件.业务类型 != null && __条件.业务类型.Count > 0 && __条件.业务类型.All(q => __日志.业务类型 != q))
                {
                    continue;
                }
                if (__条件.业务标签 != null && __条件.业务标签.Count > 0 && __条件.业务标签.All(q => __日志.业务标签.Contains(q)))
                {
                    continue;
                }
                __匹配.Add(__kv.Key);
            }
            if (__匹配.Count > 0)
            {
                _IT服务端.触发事件(_对象名称, "上报工程日志", new Dictionary<string, string> { { "事件参数", HJSON.序列化(__日志) } }, __匹配);
            }
        }

        public void 新增开发日志(M上报开发日志 __日志)
        {
            var __缓存 = new Dictionary<IPEndPoint, M过滤开发日志>(_开发日志过滤);
            var __匹配 = new List<IPEndPoint>();
            foreach (var __kv in __缓存)
            {
                var __条件 = __kv.Value;
                if (__条件.线程关键字 != null && __条件.线程关键字.Count > 0 && !string.IsNullOrEmpty(__日志.线程) && __条件.线程关键字.All(q => !__日志.线程.Contains(q)))
                {
                    continue;
                }
                if (__条件.标题关键字 != null && __条件.标题关键字.Count > 0 && !string.IsNullOrEmpty(__日志.标题) && __条件.标题关键字.All(q => !__日志.标题.Contains(q)))
                {
                    continue;
                }
                if (__条件.内容关键字 != null && __条件.内容关键字.Count > 0 && !string.IsNullOrEmpty(__日志.内容) && __条件.内容关键字.All(q => !__日志.内容.Contains(q)))
                {
                    continue;
                }
                if (__条件.重要性.HasValue && __条件.重要性 > __日志.重要性)
                {
                    continue;
                }
                __匹配.Add(__kv.Key);
            }
            if (__匹配.Count > 0)
            {
                _IT服务端.触发事件(_对象名称, "上报开发日志", new Dictionary<string,string>{{"事件参数",HJSON.序列化(__日志)}}, __匹配);
            }
        }

        private string 设置工程日志过滤(Dictionary<string,string> __实参列表, IPEndPoint __地址)
        {
            var __条件 = HJSON.反序列化<M过滤工程日志>(__实参列表["过滤参数"]);
            _工程日志过滤[__地址] = __条件;
            return "";
        }

        private string 设置开发日志过滤(Dictionary<string, string> __实参列表, IPEndPoint __地址)
        {
            var __条件 = HJSON.反序列化<M过滤开发日志>(__实参列表["过滤参数"]);
            _开发日志过滤[__地址] = __条件;
            return "";
        }

        private List<M日志文件> 查询日志文件列表(M日志文件查询条件 __条件)
        {
            if (_日志文件查询 == null)
            {
                var __日志路径 = H路径.验证目录是否存在("日志") ? "日志" : "";
                if (string.IsNullOrEmpty(__日志路径))
                {
                    __日志路径 = H路径.验证目录是否存在("log") ? "log" : "";
                }
                if (string.IsNullOrEmpty(__日志路径))
                {
                    __日志路径 = H路径.验证目录是否存在("logs") ? "logs" : "";
                }
                var __文件列表 = Directory.EnumerateFiles(Path.Combine(H路径.程序目录, __日志路径), "*.*", SearchOption.AllDirectories).ToList();
                //                        .Select(q => q.Replace(H路径.程序目录 + "\\", ""));
                var __结果 = new List<M日志文件>();
                __文件列表.ForEach(q =>
                {
                    var __文件 = new FileInfo(q);
                    __结果.Add(new M日志文件
                    {
                        路径 = q.Replace(H路径.程序目录 + "\\", ""),
                        大小 = __文件.Length, 
                        最后修改时间 = __文件.LastWriteTime
                    });
                });
                return __结果;
            }
            else
            {
                return _日志文件查询(__条件);
            }
        }

        private List<string> 导出日志文件列表(List<string> __日志文件列表)
        {
            return __日志文件列表;
        }

        private List<string> 删除日志文件列表(List<string> __日志文件列表)
        {
            var __未删除列表 = new List<string>();
            __日志文件列表.ForEach(q =>
            {
                try
                {
                    var __文件路径 = Path.Combine(H路径.程序目录, q);
                    File.Delete(__文件路径);
                }
                catch (Exception)
                {
                    __未删除列表.Add(q);
                }
            });
            return __未删除列表;
        }

        private void 压缩日志文件列表(List<string> __日志文件列表, out string __下载地址)
        {
            throw new NotImplementedException();
        }
    }
}
