using System;
using System.Collections.Generic;
using 通用访问;

namespace 通用命令.远程升级
{
    public interface IB远程升级_C
    {
        bool 支持 { get; }

        List<M存储版本> 查询();

        void 请求上传(M请求上传 请求, string 文件路径);

        void 结束上传();

        void 开始升级(string 版本号);

        void 删除版本(string 版本号);

        event Action<bool> 上传完成;

        event Action<M升级完成> 升级完成;

    }

    public class B远程升级_C : IB远程升级_C
    {
        private IT客户端 _IT客户端;

        private string _对象名称 = "远程升级";

        public B远程升级_C(IT客户端 __IT客户端)
        {
            _IT客户端 = __IT客户端;
        }

        public bool 支持
        {
            get
            {
                try
                {
                    return bool.Parse(_IT客户端.查询属性值(_对象名称, "支持"));
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        private string _文件路径;

        public B远程升级_C()
        {
            _IT客户端.订阅事件(_对象名称, "升级完成", 处理升级完毕);

        }

        public List<M存储版本> 查询()
        {
            return HJSON.反序列化<List<M存储版本>>(_IT客户端.查询属性值(_对象名称, "存储版本"));
        }

        public void 请求上传(M请求上传 请求, string 文件路径)
        {
            _文件路径 = 文件路径;
            _IT客户端.订阅事件(_对象名称, "准备好接收数据", 上传数据);
            try
            {
                _IT客户端.执行方法(_对象名称, "请求上传", new Dictionary<string,string>{{"版本",HJSON.序列化(请求)}});
            }
            catch (Exception)
            {
                _IT客户端.注销事件(_对象名称, "准备好接收数据", 上传数据);
            }
        }

        private void 上传数据(Dictionary<string,string> __实参列表)
        {
            try
            {
                var __发送参数 = HJSON.反序列化<M发送参数>(__实参列表["事件参数"]);
                //todo 建立连接,按参数发送数据

                On上传完成(true);
            }
            catch (Exception)
            {
                On上传完成(false);
            }
        }

        public void 结束上传()
        {
            _IT客户端.执行方法(_对象名称, "结束上传", null);
            _IT客户端.注销事件(_对象名称, "准备好接收数据", 上传数据);
        }

        public void 开始升级(string 版本号)
        {
            _IT客户端.执行方法(_对象名称, "开始升级", new Dictionary<string,string>{{"版本",版本号}});
        }

        private void 处理升级完毕(Dictionary<string,string> __实参列表)
        {
            var __升级完成 = HJSON.反序列化<M升级完成>(__实参列表["事件参数"]);

            On升级完成(__升级完成);
        }

        public void 删除版本(string 版本号)
        {
            _IT客户端.执行方法(_对象名称, "删除版本", new Dictionary<string,string>{{"版本",版本号}});
        }


        public event Action<M升级完成> 升级完成;

        protected virtual void On升级完成(M升级完成 obj)
        {
            var handler = 升级完成;
            if (handler != null) handler(obj);
        }


        public event Action<bool> 上传完成;

        protected virtual void On上传完成(bool obj)
        {
            var handler = 上传完成;
            if (handler != null) handler(obj);
        }
    }
}
