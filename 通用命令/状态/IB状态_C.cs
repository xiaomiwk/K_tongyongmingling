using System;
using System.Collections.Generic;
using 通用访问;

namespace 通用命令.状态
{
    public interface IB状态_C
    {
        M概要状态 查询概要状态();

        List<M业务概要> 查询业务概要(string 类别 = "", string 属性 = "");

        int 未清除告警数量 { get; }

        DateTime 启动时间 { get; }

        E健康状态 健康状态 { get; }

        DateTime 状态开始时间 { get; }

        List<M上报告警> 查询未清除告警(M查询条件 查询条件);

        event Action<M上报告警> 新增了告警;

        event Action<M上报清除> 清除了告警;

        event Action<M概要状态> 健康状态变化;

    }

    public class B状态_C : IB状态_C
    {
        private IT客户端 _IT客户端;

        private string _对象名称 = "状态";

        public B状态_C(IT客户端 __IT客户端)
        {
            _IT客户端 = __IT客户端;
        }

        public M概要状态 查询概要状态()
        {
            return HJSON.反序列化<M概要状态>(_IT客户端.执行方法(_对象名称, "查询概要状态", null));
        }

        public List<M业务概要> 查询业务概要(string 类别 = "", string 属性 = "")
        {
            return HJSON.反序列化<List<M业务概要>>(_IT客户端.执行方法(_对象名称, "查询业务概要", new Dictionary<string,string>{{"类别",类别},{"属性",属性}}));
        }

        public int 未清除告警数量
        {
            get
            {
                try
                {
                    return int.Parse(_IT客户端.查询属性值(_对象名称, "未清除告警数量"));
                }
                catch (Exception)
                {
                    return int.MinValue;
                }
            }
        }

        public DateTime 启动时间
        {
            get
            {
                return DateTime.Parse(_IT客户端.查询属性值(_对象名称, "启动时间"));
            }
        }

        public E健康状态 健康状态
        {
            get { return (E健康状态)Enum.Parse(typeof(E健康状态), _IT客户端.查询属性值(_对象名称, "健康状态")); }
        }

        public DateTime 状态开始时间
        {
            get
            {
                return DateTime.Parse(_IT客户端.查询属性值(_对象名称, "状态开始时间"));
            }
        }

        public List<M上报告警> 查询未清除告警(M查询条件 查询条件)
        {
            var __返回值 = _IT客户端.执行方法(_对象名称, "查询未清除告警", new Dictionary<string,string>{{"条件",查询条件 == null ? "" : HJSON.序列化(查询条件)}});
            return HJSON.反序列化<List<M上报告警>>(__返回值);
        }

        private Action<M上报告警> _新增了告警;

        public event Action<M上报告警> 新增了告警
        {
            add
            {
                if (_新增了告警 == null)
                {
                    _IT客户端.订阅事件(_对象名称, "上报告警", 处理告警);
                }
                _新增了告警 += value;
            }
            remove
            {
                if (_新增了告警 != null)
                {
                    _新增了告警 -= value;
                    if (_新增了告警 == null)
                    {
                        _IT客户端.注销事件(_对象名称, "上报告警", 处理告警);
                    }
                }
            }
        }

        private void 处理告警(Dictionary<string,string> __实参列表)
        {
            var __上报告警 = HJSON.反序列化<M上报告警>(__实参列表["事件参数"]);
            On新增了告警(__上报告警);
        }

        protected virtual void On新增了告警(M上报告警 obj)
        {
            var handler = _新增了告警;
            if (handler != null) handler(obj);
        }

        private Action<M上报清除> _清除了告警;

        public event Action<M上报清除> 清除了告警
        {
            add
            {
                if (_清除了告警 == null)
                {
                    _IT客户端.订阅事件(_对象名称, "上报清除", 处理清除);
                }
                _清除了告警 += value;
            }
            remove
            {
                if (_清除了告警 == null)
                {
                    return;
                }
                _清除了告警 -= value;
                if (_清除了告警 == null)
                {
                    _IT客户端.注销事件(_对象名称, "上报清除", 处理清除);
                }
            }
        }

        private void 处理清除(Dictionary<string,string> __实参列表)
        {
            var __上报告警 = HJSON.反序列化<M上报清除>(__实参列表["事件参数"]);
            On清除了告警(__上报告警);
        }

        protected virtual void On清除了告警(M上报清除 obj)
        {
            var handler = _清除了告警;
            if (handler != null) handler(obj);
        }


        private Action<M概要状态> _健康状态变化;

        public event Action<M概要状态> 健康状态变化
        {
            add
            {
                if (_健康状态变化 == null)
                {
                    _IT客户端.订阅事件(_对象名称, "健康状态变化", 处理健康状态变化);
                }
                _健康状态变化 += value;
            }
            remove
            {
                if (_健康状态变化 == null)
                {
                    return;
                }
                _健康状态变化 -= value;
                if (_健康状态变化 == null)
                {
                    _IT客户端.注销事件(_对象名称, "健康状态变化", 处理健康状态变化);
                }
            }
        }

        private void 处理健康状态变化(Dictionary<string,string> __实参列表)
        {
            var __事件参数 = HJSON.反序列化<M概要状态>(__实参列表["事件参数"]);
            On健康状态变化(__事件参数);
        }

        protected virtual void On健康状态变化(M概要状态 obj)
        {
            var handler = _健康状态变化;
            if (handler != null) handler(obj);
        }

    }
}
