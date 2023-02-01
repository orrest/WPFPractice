namespace CustomizedEventDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            
            Customer customer = new Customer();
            Waiter waiter = new Waiter();

            customer.OrderEventHandler += waiter.Action;
            // 由事件拥有者的内部逻辑触发事件.
            customer.Action();
        }
    }

    /// <summary>
    /// 委托也是一个类型. 所以不要搞成内部类.
    /// </summary>
    /// <param name="c">Order事件所需要的顾客参数</param>
    /// <param name="e">Order事件所需要的点单信息参数</param>
    delegate void OrderEventHandler(Customer c, OrderEventArgs e);

    internal class OrderEventArgs: EventArgs
    {
        public string DishName { get; set; }
        public string Size { get; set; }
    }

    /// <summary>
    /// 事件的拥有者, 事件
    /// 
    /// 由事件拥有者的内部逻辑触发事件.
    /// </summary>
    internal class Customer
    {
        private OrderEventHandler orderEventHandler;

        public event OrderEventHandler OrderEventHandler
        {
            add { this.orderEventHandler += value; }
            remove { this.orderEventHandler -= value; }
        }

        private void WalkIn()
        {
            Console.WriteLine("Walk into the restaurant.");
        }

        private void SitDown()
        {
            Console.WriteLine("Sit down.");
        }

        private void ThinkToOrder()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Consider what to order...");
                Thread.Sleep(1000);
            }

            if (this.orderEventHandler != null)
            {
                var e = new OrderEventArgs();
                e.DishName = "Kongpao Chicken";
                e.Size = "large";
                this.orderEventHandler(this, e);
            }
        }

        public void Action()
        {
            WalkIn();
            SitDown();
            ThinkToOrder();
        }
    }

    class Waiter
    {
        internal void Action(Customer c, OrderEventArgs e)
        {
            Console.WriteLine($"Got your order: {e.DishName}");
        }
    }
}