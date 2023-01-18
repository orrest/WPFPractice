namespace LocalSQLDBDemo.Models;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }

    // foriegn key
    public int CategoryId { get; set; }
}

public class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
}