namespace ConsoleLinqTask
{
    public class Shop
    {
        public Shop(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public List<Customer> Customers { get; set; } = new();
        public List<Order> Orders { get; set; } = new();

        public override string ToString()
        {
            return $"Shop: {Name} | Customers: {Customers.Count} | Orders: {Orders.Count}";
        }
    }

    public static class ShopExtensions
    {
        public static void PrintInfo(this Shop shop)
        {
            Console.WriteLine(shop);
            shop.Customers.ForEach(customer =>
            {
                Console.WriteLine("-------------------");
                Console.WriteLine(customer);
                customer.Orders.ForEach(order => Console.WriteLine(order));
                Console.WriteLine("-------------------");
            });
        }
    }
}
