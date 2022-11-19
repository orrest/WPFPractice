using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyElephant.Models
{
    /// <summary>
    /// 数据类不建议实现INotifyPropertyChanged,
    /// 由ViewModel负责NotificationObject.
    /// </summary>
    public class Dish
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Comment { get; set; }
        public double Score { get; set; }
    }
}
