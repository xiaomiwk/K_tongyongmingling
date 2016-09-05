using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using Utility.存储;
using Utility.通用;
using 通用命令.FTP;
using 通用访问;

namespace 通用命令.日志
{
    public interface IB日志_C
    {
        void 过滤工程日志(M过滤工程日志 过滤);

        void 过滤开发日志(M过滤开发日志 过滤);

        event Action<M上报工程日志> 上报工程日志;

        event Action<M上报开发日志> 上报开发日志;

        List<M日志文件> 查询日志文件(M日志文件查询条件 过滤);

        /// <returns>未删除列表</returns>
        List<string> 删除日志文件(List<string> 文件列表);

        /// <returns>下载地址</returns>
        string 压缩日志文件(List<string> 文件列表);

        /// <returns>ftp或http地址</returns>
        List<string> 导出日志文件(List<string> 文件列表);

        /// <returns>ftp或http地址</returns>
        void 导出日志文件(List<string> 文件列表, string 目录);
    }

    public class B日志_C : IB日志_C
    {
        private IT客户端 _IT客户端;

        private string _对象名称 = "日志";

        private M过滤工程日志 _过滤工程日志;

        private M过滤开发日志 _过滤开发日志;

        public B日志_C(IT客户端 __IT客户端)
        {
            _IT客户端 = __IT客户端;
            _IT客户端.已连接 += _IT客户端_已连接;
        }

        void _IT客户端_已连接()
        {
            if (_过滤工程日志 != null)
            {
                过滤工程日志(_过滤工程日志);
            }
            if (_过滤开发日志 != null)
            {
                过滤开发日志(_过滤开发日志);
            }
        }

        Action<M上报工程日志> _上报工程日志;

        public event Action<M上报工程日志> 上报工程日志
        {
            add
            {
                if (_上报工程日志 == null)
                {
                    _IT客户端.订阅事件(_对象名称, "上报工程日志", 处理工程日志);
                }
                _上报工程日志 += value;
            }
            remove
            {
                if (_上报工程日志 != null)
                {
                    _上报工程日志 -= value;
                    if (_上报工程日志 == null)
                    {
                        _IT客户端.注销事件(_对象名称, "上报工程日志", 处理工程日志);
                    }
                }
            }
        }

        protected virtual void On上报工程日志(M上报工程日志 obj)
        {
            var handler = _上报工程日志;
            if (handler != null) handler(obj);
        }
        private void 处理工程日志(Dictionary<string, string> __实参列表)
        {
            var __上报日志 = HJSON.反序列化<M上报工程日志>(__实参列表["事件参数"]);
            On上报工程日志(__上报日志);
        }

        Action<M上报开发日志> _上报开发日志;

        public event Action<M上报开发日志> 上报开发日志
        {
            add
            {
                if (_上报开发日志 == null)
                {
                    _IT客户端.订阅事件(_对象名称, "上报开发日志", 处理开发日志);
                }
                _上报开发日志 += value;
            }
            remove
            {
                if (_上报开发日志 != null)
                {
                    _上报开发日志 -= value;
                    if (_上报开发日志 == null)
                    {
                        _IT客户端.注销事件(_对象名称, "上报开发日志", 处理开发日志);
                    }
                }
            }
        }

        protected virtual void On上报开发日志(M上报开发日志 obj)
        {
            var handler = _上报开发日志;
            if (handler != null) handler(obj);
        }

        private void 处理开发日志(Dictionary<string, string> __实参列表)
        {
            var __上报日志 = HJSON.反序列化<M上报开发日志>(__实参列表["事件参数"]);
            On上报开发日志(__上报日志);
        }


        public void 过滤工程日志(M过滤工程日志 __过滤工程日志)
        {
            _过滤工程日志 = __过滤工程日志;
            _IT客户端.执行方法(_对象名称, "过滤工程日志", new Dictionary<string, string> { { "过滤参数", HJSON.序列化(__过滤工程日志) } });
        }

        public void 过滤开发日志(M过滤开发日志 __过滤开发日志)
        {
            _过滤开发日志 = __过滤开发日志;
            _IT客户端.执行方法(_对象名称, "过滤开发日志", new Dictionary<string, string> { { "过滤参数", HJSON.序列化(__过滤开发日志) } });
        }

        public List<M日志文件> 查询日志文件(M日志文件查询条件 过滤)
        {
            return HJSON.反序列化<List<M日志文件>>(_IT客户端.执行方法(_对象名称, "查询日志文件", new Dictionary<string, string> { { "过滤参数", HJSON.序列化(过滤) } }));
        }

        public List<string> 删除日志文件(List<string> 文件列表)
        {
            return HJSON.反序列化<List<string>>(_IT客户端.执行方法(_对象名称, "删除日志文件", new Dictionary<string, string> { { "地址列表", HJSON.序列化(文件列表) } }));
        }

        public string 压缩日志文件(List<string> 文件列表)
        {
            return HJSON.反序列化<string>(_IT客户端.执行方法(_对象名称, "压缩日志文件", new Dictionary<string, string> { { "地址列表", HJSON.序列化(文件列表) } }));
        }

        public List<string> 导出日志文件(List<string> 文件列表)
        {
            return HJSON.反序列化<List<string>>(_IT客户端.执行方法(_对象名称, "导出日志文件", new Dictionary<string, string> { { "地址列表", HJSON.序列化(文件列表) } }));
        }

        public void 导出日志文件(List<string> 文件列表, string 目录)
        {
            IBFTP_C __IBFTP = new BFTP_C(_IT客户端);
            if (!__IBFTP.运行中)
            {
                try
                {
                    __IBFTP.开启();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(string.Format("FTP开启失败, 无法下载:\r\n{0}", ex));
                }
            }

            var __结果 = 导出日志文件(文件列表);
            var __失败列表 = new List<string>();
            var __下载 = new WebClient();
            __结果.ForEach(q =>
            {
                try
                {
                    var __最终路径 = Path.Combine(目录, q);
                    var __最终目录 = Path.GetDirectoryName(__最终路径);
                    if (!Directory.Exists(__最终目录))
                    {
                        Directory.CreateDirectory(__最终目录);
                    }
                    if (H路径.验证文件是否存在("FlashFXP\\flashfxp.exe"))
                    {
                        var __远程路径 = q.Replace('\\', '/');
                        var __startinfo = new ProcessStartInfo("FlashFXP\\flashfxp.exe",
                            string.Format(" -c4 -download ftp://{0}:{1} -remotepath=\"{2}\" -localpath=\"{3}\"", _IT客户端.设备地址.Address, __IBFTP.端口号, __远程路径, __最终路径));
                        __startinfo.WindowStyle = ProcessWindowStyle.Hidden;
                        var __进程 = Process.Start(__startinfo);
                        __进程.WaitForExit(2000);
                        __进程.Dispose();
                    }
                    else
                    {
                        __下载.DownloadFile(string.Format("ftp://{0}:{1}/{2}", _IT客户端.设备地址.Address, __IBFTP.端口号, q), __最终路径);
                    }
                }
                catch (Exception ex)
                {
                    H调试.记录异常(ex);
                    __失败列表.Add(q);
                }
            });
            __下载.Dispose();
            if (__失败列表.Count > 0)
            {
                throw new ApplicationException(string.Format("下列文件下载失败:\r\n{0}", string.Join("\r\n", __失败列表)));
            }
        }
    }
}
