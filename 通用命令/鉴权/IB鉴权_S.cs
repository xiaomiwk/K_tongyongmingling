using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Utility.通用;
using 通用访问;
using 通用访问.DTO;

namespace 通用命令.鉴权
{
    /// <summary>
    /// 只负责互联, 不复杂内部鉴权逻辑
    /// </summary>
    public interface IB鉴权_S
    {
        List<M已登录设备> 已登录列表 { get; }

        void 登录(M登录请求 __请求, IPEndPoint __地址);

        void 注销(IPEndPoint __来源地址);

        List<M已登录设备> 查询(IPAddress __地址, int? __端口号, string __账号);

        void 初始化(Action<M登录请求, IPEndPoint> __登录验证);
    }

    public class B鉴权_S : IB鉴权_S
    {
        private IT服务端 _IT服务端 = H容器.取出<IT服务端>();

        private string _对象名称 = "鉴权";

        private Action<M登录请求, IPEndPoint> _登录验证;

        Dictionary<IPEndPoint, M已登录设备> _登录缓存 = new Dictionary<IPEndPoint, M已登录设备>();

        public B鉴权_S()
        {
            配置通用访问();
        }

        private void 配置通用访问()
        {
            var _对象 = new M对象(_对象名称, "通用服务");
            _对象.添加属性("已登录设备", () => HJSON.序列化(_登录缓存.Values.ToList()), E角色.客户, null);
            _对象.添加方法("登录", (__实参列表, __地址) =>
            {
                var __条件 = HJSON.反序列化<M登录请求>(__实参列表["请求参数"]);
                登录(__条件, __地址);
                return "";
            }, E角色.客户, new List<M形参> { new M形参{ 名称 = "请求参数", 元数据 = new M元数据
            { 
                //设备类型, 设备标识, 账号, 密码
                结构 = E数据结构.对象, 子成员列表 = new List<M子成员>
                {
                    new M子成员("设备类型", "string"),
                    new M子成员("设备标识", "string"),
                    new M子成员("账号", "string"),
                    new M子成员("密码", "string"),
                }
            } } }, null);
            _对象.添加方法("查询登录", (__实参列表, __地址) =>
            {
                IPAddress __IP = null;
                IPAddress.TryParse(__实参列表["IP"], out __IP);
                int? __端口号 = null;
                if (!string.IsNullOrEmpty(__实参列表["端口号"]))
                {
                    __端口号 = int.Parse(__实参列表["端口号"]);
                }
                var __结果 = 查询(__IP, __端口号, __实参列表["账号"]);
                return HJSON.序列化(__结果);
            }, E角色.客户, new List<M形参> { new M形参("IP", "string"), new M形参("端口号", new M元数据("int?"){ 描述 = "可为空"}) }, null);
            _对象.添加方法("注销", (__实参列表, __地址) =>
            {
                注销(__地址);
                return "";
            }, E角色.客户, null, null);

            _对象.添加事件("登录完毕", E角色.客户, new List<M形参>
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
                        new M子成员("成功", "string"),
                        new M子成员("描述","string"),
                    }
                }
                }
            });
            _对象.添加事件("注销完毕", E角色.客户, new List<M形参>
            {
                new M形参{ 名称 = "事件参数", 元数据 = new M元数据
                { 
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
            _对象.添加方法("修改密码", __实参列表 =>
            {
                var __旧密码 = __实参列表["旧密码"];
                var __新密码 = __实参列表["新密码"];
                修改密码(__旧密码, __新密码);
                return null;
            }, E角色.客户, new List<M形参> { new M形参("旧密码", "string"), new M形参("新密码", "string") });
            _对象.添加方法("增加账号", (__实参列表, __地址) =>
            {
                var __当前账号 = 查询账号(__地址);
                if (__当前账号 == null || __当前账号.账号 != "admin")
                {
                    throw new ApplicationException("无权限");
                }
                var __账号 = __实参列表["账号"];
                var __密码 = __实参列表["密码"];
                var __备注 = __实参列表["备注"];
                增加账号(__账号, __密码, __备注);
                return null;
            }, E角色.客户, new List<M形参> { new M形参("账号", "string"), new M形参("密码", "string"), new M形参("备注", "string") });
            _对象.添加方法("删除账号", (__实参列表, __地址) =>
            {
                var __当前账号 = 查询账号(__地址);
                if (__当前账号 == null || __当前账号.账号 != "admin")
                {
                    throw new ApplicationException("无权限");
                }
                var __账号 = __实参列表["账号"];
                删除账号(__账号);
                return null;
            }, E角色.客户, new List<M形参> { new M形参("账号", "string") });
            _对象.添加方法("修改账号", (__实参列表, __地址) =>
            {
                var __当前账号 = 查询账号(__地址);
                if (__当前账号 == null || __当前账号.账号 != "admin")
                {
                    throw new ApplicationException("无权限");
                }
                var __账号 = __实参列表["账号"];
                var __备注 = __实参列表["备注"];
                修改账号(__账号, __备注);
                return null;
            }, E角色.客户, new List<M形参> { new M形参("账号", "string"), new M形参("备注", "string") });
            _对象.添加方法("查询账号", (__实参列表, __地址) =>
            {
                var __当前账号 = 查询账号(__地址);
                if (__当前账号 == null || __当前账号.账号 != "admin")
                {
                    throw new ApplicationException("无权限");
                }
                var __账号 = __实参列表["账号"];
                var __备注 = __实参列表["备注"];
                return HJSON.序列化(查询账号(__账号, __备注));
            }, E角色.客户, new List<M形参> { new M形参("账号", "string"), new M形参("备注", "string") });


            _IT服务端.添加对象(_对象名称, () => _对象);
        }

        public void 登录(M登录请求 __请求, IPEndPoint __地址)
        {
            if (_登录验证 != null)
            {
                try
                {
                    _登录验证(__请求, __地址);
                }
                catch (Exception ex)
                {
                    _IT服务端.触发事件(_对象名称, "登录完毕", new Dictionary<string,string>{{"事件参数",HJSON.序列化(new M登录事件 { 成功 = false, 设备标识 = __请求.设备标识, 设备类型 = __请求.设备类型, 账号 = __请求.账号, 描述 = ex.Message })}});
                    throw;
                }
            }
            _登录缓存[__地址] = new M已登录设备 { IP = __地址.Address, 端口号 = __地址.Port, 登录时间 = DateTime.Now, 设备标识 = __请求.设备标识, 设备类型 = __请求.设备类型, 账号 = __请求.账号 };
            _IT服务端.触发事件(_对象名称, "登录完毕", new Dictionary<string,string>{{"事件参数",HJSON.序列化(new M登录事件 { 成功 = true, 设备标识 = __请求.设备标识, 设备类型 = __请求.设备类型, 账号 = __请求.账号 })}});
        }

        public void 注销(IPEndPoint __来源地址)
        {
            if (_登录缓存.ContainsKey(__来源地址))
            {
                var __已登录设备 = _登录缓存[__来源地址];
                _IT服务端.触发事件(_对象名称, "注销完毕", new Dictionary<string,string>{{"事件参数",HJSON.序列化(new 通用命令.鉴权.M注销事件 { 设备标识 = __已登录设备.设备标识, 设备类型 = __已登录设备.设备类型, 账号 = __已登录设备.账号 })}});
                _登录缓存.Remove(__来源地址);
            }
        }

        public List<M已登录设备> 已登录列表
        {
            get { return new List<M已登录设备>(_登录缓存.Values); }
        }

        public M已登录设备 查询(IPEndPoint __地址)
        {
            if (_登录缓存.ContainsKey(__地址))
            {
                return _登录缓存[__地址];
            }
            return null;
        }

        public void 初始化(Action<M登录请求, IPEndPoint> __登录验证)
        {
            _登录验证 = __登录验证;
        }


        public List<M已登录设备> 查询(IPAddress __地址, int? __端口号, string __账号)
        {
            var __结果 = new List<M已登录设备>();
            foreach (var __kv in _登录缓存)
            {
                if (( __地址 == null || Equals(__kv.Key.Address, __地址))
                    && (!__端口号.HasValue || __端口号.Value == __kv.Key.Port)
                    && (string.IsNullOrEmpty(__账号) || __账号 == __kv.Value.账号))
                {
                    __结果.Add(__kv.Value);
                }
            }
            return __结果;
        }

        public void 修改密码(string __旧密码, string __新密码)
        {
            throw new NotImplementedException();
        }

        public void 增加账号(string __账号, string __密码, string __备注)
        {
            throw new NotImplementedException();
        }

        public void 删除账号(string __账号)
        {
            throw new NotImplementedException();
        }

        public void 修改账号(string __账号, string __备注)
        {
            throw new NotImplementedException();
        }

        public M账号 查询账号(IPEndPoint __地址)
        {
            var __已登录设备 = 查询登录(__地址.Address, __地址.Port, null);
            if (__已登录设备.Count == 0)
            {
                return null;
            }
            return new M账号 { 账号 = __已登录设备[0].账号, 备注 = __已登录设备[0].备注 };
        }

        public List<M账号> 查询账号(string __账号, string __备注)
        {
            throw new NotImplementedException();
        }

        public List<M已登录设备> 查询登录(IPAddress __地址, int? __端口号, string __账号)
        {
            var __结果 = new List<M已登录设备>();
            foreach (var __kv in _登录缓存)
            {
                if ((__地址 == null || Equals(__kv.Key.Address, __地址))
                    && (!__端口号.HasValue || __端口号.Value == __kv.Key.Port)
                    && (string.IsNullOrEmpty(__账号) || __账号 == __kv.Value.账号))
                {
                    __结果.Add(__kv.Value);
                }
            }
            return __结果;
        }


    }
}
