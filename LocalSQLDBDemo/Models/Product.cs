
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LocalSQLDBDemo.Models;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }

    public int CategoryId { get; set; }

    // ��������, һ��һ
    public virtual Category Category { get; set; }
}

public class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; }

    // ��������, һ�Զ�
    public virtual ICollection<Product> Products 
    { get; private set; } = new ObservableCollection<Product>();
}