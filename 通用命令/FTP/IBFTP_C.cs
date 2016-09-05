using System;
using System.Collections.Generic;
using 通用访问;

namespace 通用命令.FTP
{
    public interface IBFTP_C
    {
        bool 支持 { get; }

        bool 运行中 { get; }

        int 端口号 { get; }

        string 目录路径 { get; }

        string 编码 { get; }

        void 开启();

        void 关闭();
    }

    public class BFTP_C : IBFTP_C
    {
        private IT客户端 _IT客户端;

        private string _对象名称 = "FTP";

        public BFTP_C(IT客户端 __IT客户端)
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

        public bool 运行中
        {
            get
            {
                try
                {
                    return bool.Parse(_IT客户端.查询属性值(_对象名称, "运行中"));
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public int 端口号
        {
            get
            {
                try
                {
                    return int.Parse(_IT客户端.查询属性值(_对象名称, "端口号"));
                }
                catch (Exception)
                {
                    return int.MinValue;
                }
            }
        }

        public string 目录路径
        {
            get
            {
                try
                {
                    return _IT客户端.查询属性值(_对象名称, "目录路径");
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public string 编码
        {
            get
            {
                try
                {
                    return _IT客户端.查询属性值(_对象名称, "编码");
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public void 开启()
        {
            _IT客户端.执行方法(_对象名称, "开启", null);
        }

        public void 关闭()
        {
            _IT客户端.执行方法(_对象名称, "关闭", null);
        }

    }

}
