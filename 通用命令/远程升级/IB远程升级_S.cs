using System;
using System.Collections.Generic;
using Utility.通用;
using 通用访问;
using 通用访问.DTO;

namespace 通用命令.远程升级
{
    public interface IB远程升级_S
    {
        bool 支持 { get; }

        int 默认端口号 { get; }

        List<M存储版本> 查询();

        void 请求上传(M请求上传 请求);

        void 结束上传();

        void 开始升级(string 版本号);

        void 删除版本(string 版本号);

    }

    public class B远程升级_S : IB远程升级_S
    {
        private IT服务端 _IT服务端 = H容器.取出<IT服务端>();

        private string _对象名称 = "远程升级";

        public B远程升级_S()
        {
            支持 = false;
            配置通用访问();
        }

        private void 配置通用访问()
        {
            var _对象 = new M对象(_对象名称, "通用服务");
            _对象.添加属性("支持", () => 支持.ToString(), E角色.客户, null);
            _对象.添加属性("默认端口号", () => 默认端口号.ToString(), E角色.客户, null);
            _对象.添加方法("请求上传", __实参列表 =>
            {
                var __版本 = HJSON.反序列化<M请求上传>(__实参列表["版本"]);
                请求上传(__版本);
                return null;
            }, E角色.客户, new List<M形参>
            {
                new M形参("版本", new M元数据{ 结构 = E数据结构.对象, 子成员列表 = new List<M子成员>
                {
                    new M子成员("版本号", "string"),
                    new M子成员("标签", "string", E数据结构.单值数组),
                    new M子成员("文件名", "string"),
                    new M子成员("补丁", "bool"),
                    new M子成员("md5校验码", "string"),
                    new M子成员("大小", new M元数据{ 类型 = "int", 描述 = "单位:KB"}),
                }})
            }, null);
            _对象.添加方法("结束上传", __实参列表 =>
            {
                结束上传();
                return null;
            }, E角色.客户);

            _对象.添加方法("开始升级", __实参列表 =>
            {
                var __版本 = __实参列表["版本号"];
                开始升级(__版本);
                return null;
            }, E角色.客户, new List<M形参>
            {
                new M形参("版本号",  "string")
            }, null);
            _对象.添加方法("删除版本", __实参列表 =>
            {
                var __版本 = __实参列表["版本号"];
                删除版本(__版本);
                return null;
            }, E角色.客户, new List<M形参>
            {
                new M形参("版本号",  "string")
            }, null);

            _对象.添加事件("准备好接收数据", E角色.客户, new List<M形参> {               
                new M形参("事件参数", new M元数据{ 结构 = E数据结构.对象, 子成员列表 = new List<M子成员>
                {
                    //端口号，每包最大(单位KB)，每包间隔（毫秒）
                    new M子成员("端口号", "int"),
                    new M子成员("每包最大", new M元数据{ 类型 = "int", 描述 = "单位:KB"}),
                    new M子成员("每包间隔", new M元数据{ 类型 = "int", 描述 = "单位:毫秒"}),
                }})
            });
            _对象.添加事件("升级完成", E角色.客户, new List<M形参> {               
                new M形参("事件参数", new M元数据{ 结构 = E数据结构.对象, 子成员列表 = new List<M子成员>
                {
                    //成功(true/false), 描述, 需要重启(true/false)
                    new M子成员("成功", "bool"),
                    new M子成员("描述", "string"),
                    new M子成员("需要重启", "bool"),
                }})
            });
            _IT服务端.添加对象(_对象名称, () => _对象);
        }

        public bool 支持 { get; set; }

        public int 默认端口号 { get; set; }

        public List<M存储版本> 查询()
        {
            throw new NotImplementedException();
        }

        public void 请求上传(M请求上传 请求)
        {
            throw new NotImplementedException();
        }

        public void 结束上传()
        {
            throw new NotImplementedException();
        }

        public void 开始升级(string 版本号)
        {
            throw new NotImplementedException();
        }

        public void 删除版本(string 版本号)
        {
            throw new NotImplementedException();
        }

    }
}
