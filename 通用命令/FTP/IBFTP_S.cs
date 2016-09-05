using System;
using Utility.存储;
using Utility.扩展;
using Utility.通用;
using 通用访问;
using 通用访问.DTO;

namespace 通用命令.FTP
{
    public interface IBFTP_S
    {
        bool 支持 { get; }

        bool 运行中 { get; }

        int 端口号 { get; }

        void 开启();

        void 关闭();
    }

    public class BFTP_S : IBFTP_S
    {
        private IT服务端 _IT服务端;

        private string _对象名称 = "FTP";

        public bool 支持 { get; set; }

        public bool 运行中 { get; set; }

        public int 端口号 { get; set; }

        private FTPServer _FTP;

        public BFTP_S(IT服务端 __IT服务端)
        {
            端口号 = 2121;
            _IT服务端 = __IT服务端;
            支持 = true;
            配置通用访问();
        }

        private void 配置通用访问()
        {
            var _对象 = new M对象(_对象名称, "通用服务");
            _对象.添加属性("支持", () => 支持.ToString(), E角色.客户, null);
            _对象.添加属性("运行中", () => 运行中.ToString(), E角色.客户, null);
            _对象.添加属性("端口号", () => 端口号.ToString(), E角色.客户, null);
            _对象.添加属性("目录路径", () => H路径.程序目录, E角色.客户, null);
            _对象.添加属性("编码", () => "GB2312", E角色.客户, null);
            _对象.添加方法("开启", __实参列表 =>
            {
                开启();
                return "";
            }, E角色.客户, null, null);
            _对象.添加方法("关闭", __实参列表 =>
            {
                关闭();
                return "";
            }, E角色.客户, null, null);
            _IT服务端.添加对象(_对象名称, () => _对象);
        }

        public void 开启()
        {
            if (_FTP == null)
            {
                _FTP = new FTPServer
                {
                    DownloadSpeedLimit = -1,
                    UploadSpeedLimit = -1,
                    StartupDir = H路径.程序目录,
                    //UTF8 = true,
                    Port = 端口号
                };
                //_FTP.OnLogEvent += (m, n) => H调试.记录(n.ToString());
                //_FTP.AcceptedAdresses.Add(addr);
                //_FTP.BannedAdresses.Add(addr);

                try
                {
                    _FTP.Start();
                    运行中 = true;
                }
                catch (Exception ex)
                {
                    H日志.记录异常(ex);
                    运行中 = false;
                }
            }
        }

        public void 关闭()
        {
            if (_FTP != null)
            {
                运行中 = false;
                _FTP.Stop();
                _FTP = null;
            }
        }
    }

}
