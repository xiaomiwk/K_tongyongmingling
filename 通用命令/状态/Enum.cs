namespace 通用命令.状态
{
    public enum E重要性
    {
        /// <summary>
        /// 正常通知
        /// </summary>
        一般,
        /// <summary>
        /// 非直接影响业务的使用, 不需要立即处理, 但还是需要排除告警
        /// </summary>
        次要,
        /// <summary>
        /// 严重的故障, 可能会影响业务, 需要用户处理
        /// </summary>
        重要,
        /// <summary>
        /// 系统级故障, 严重影响业务, 需要用户立即处理
        /// </summary>
        紧急,
    }

    public enum E健康状态
    {
        优,良,中,差,
    }


}
