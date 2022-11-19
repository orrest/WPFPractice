namespace CrazyElephant.Models
{
    /// <summary>
    /// 不建议直接在主页面显示Model, 而是通过ViewModel再显示Model,
    /// ViewModel可以进行一个校验和过滤.
    /// </summary>
    public class Restaurant
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
