using System.Collections.Generic;

namespace CrazyElephant.Services
{
    public interface IOrderService
    {
        void PlaceOrder(List<string> dishes);
    }
}
