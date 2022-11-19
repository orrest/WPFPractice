using CrazyElephant.Models;
using System.Collections.Generic;
 
namespace CrazyElephant.Services
{
    public interface IDataService
    {
        List<Dish> GetDishes();
    }
}
