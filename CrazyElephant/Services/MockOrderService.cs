using System.Collections.Generic;

namespace CrazyElephant.Services
{
    public class MockOrderService : IOrderService
    {
        public void PlaceOrder(List<string> dishes)
        {
            System.IO.File.WriteAllLinesAsync(
                @"D:\TempFile\order.txt", dishes.ToArray());
        }
    }
}
