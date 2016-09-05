using 通用访问;

namespace 通用命令.系统
{
    public interface IB系统_C
    {
        void 重启();

        void 关闭();

        void 恢复出厂设置();

    }

    public class B系统_C : IB系统_C
    {
        private IT客户端 _IT客户端;

        private string _对象名称 = "系统";

        public B系统_C(IT客户端 __IT客户端)
        {
            _IT客户端 = __IT客户端;
        }

        public void 重启()
        {
            _IT客户端.执行方法(_对象名称, "重启", null);
        }

        public void 关闭()
        {
            _IT客户端.执行方法(_对象名称, "关闭", null);
        }

        public void 恢复出厂设置()
        {
            _IT客户端.执行方法(_对象名称, "恢复出厂设置", null);
        }
    }
}
