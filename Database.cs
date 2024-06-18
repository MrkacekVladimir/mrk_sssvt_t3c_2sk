namespace ConsoleLinqTask
{
    public static class Database
    {
        private static List<Shop> _shops = new List<Shop>();

        static Database()
        {
            Shop shop = new Shop("Alza");

            #region Customer One - VIP
            Customer customer1 = new Customer("Vladimir Client", true);
            Order customer1Order1 = new Order(DateTime.Now.AddDays(-10), null, 100_000, customer1);
            Order customer1Order2 = new Order(DateTime.Now.AddDays(-12), DateTime.Now.AddDays(-11), 500, customer1);
            Order customer1Order3 = new Order(DateTime.Now.AddDays(-17), null, 5_000, customer1);
            Order customer1Order4 = new Order(DateTime.Now.AddDays(-20), DateTime.Now.AddDays(-19), 5_000, customer1);
            Order customer1Order5 = new Order(DateTime.Now.AddDays(-26), null, 260_000, customer1);
            Order customer1Order6 = new Order(DateTime.Now.AddDays(-36), DateTime.Now.AddDays(-33), 6_300, customer1);
            shop.Orders.AddRange(customer1.Orders);
            #endregion


            #region Customer Two - NonVIP
            Customer customer2 = new Customer("Jarda Client", false);
            Order customer2Order1 = new Order(DateTime.Now.AddDays(-1), null, 500_666, customer2);
            Order customer2Order2 = new Order(DateTime.Now.AddDays(-6), DateTime.Now.AddDays(-5), 1234, customer2);
            Order customer2Order3 = new Order(DateTime.Now.AddDays(-9), null, 11_000, customer2);
            Order customer2Order4 = new Order(DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-9), 340, customer2);
            shop.Orders.AddRange(customer2.Orders);
            #endregion

            #region Customer Three - NonVIP
            Customer customer3 = new Customer("Marek Client", false);
            Order customer3Order1 = new Order(DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1), 200, customer3);
            Order customer3Order2 = new Order(DateTime.Now.AddDays(-4), DateTime.Now.AddDays(-4), 150, customer3);
            Order customer3Order3 = new Order(DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-8), 490, customer3);
            Order customer3Order4 = new Order(DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-9), 180, customer3);
            shop.Orders.AddRange(customer3.Orders);
            #endregion

            shop.Customers = new List<Customer> { customer1, customer2, customer3 };
            _shops.Add(shop);
        }

        public static Shop GetShop() => _shops.First();
    }
}
