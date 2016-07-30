namespace Client
{
    using System;
    using Client.Controllers;

    public class Program
    {
        public static void Main(string[] args)
        {
            Bootstrapper.Bootstrap();  //Init IoC DI SimpleInjector

            //Command
            var orderController = Bootstrapper.GetInstance<CommandExampleController>();

            var orderId = orderController.CreateOrder();

            orderController.ShipOrder(orderId);

            //Query
            var showUnshippedOrdersController = Bootstrapper.GetInstance<QueryExampleController>();

            showUnshippedOrdersController.ShowOrders(pageIndex: 0, pageSize: 10);

            Console.ReadLine();
        }
    }
}