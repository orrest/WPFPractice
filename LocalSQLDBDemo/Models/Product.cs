
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LocalSQLDBDemo.Models;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }

    public int CategoryId { get; set; }

    // 导航属性, 一对一
    public virtual Category Category { get; set; }
}

public class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; }

    // 导航属性, 一对多
    public virtual ICollection<Product> Products 
    { get; private set; } = new ObservableCollection<Product>();
}