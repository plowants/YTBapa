namespace YTBapa.Common.Extension
{
    /// <summary>
    /// 数据返回
    /// </summary>
    public class Result<T>
    {
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess {
            get { return Status == 1; }
        }
        /// <summary>
        /// 错误编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 描述信息
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public T Data { get; set; }
    }
    /// <summary>
    /// 数据返回
    /// </summary>
    public class Result : Result<string>
    {
    }
}