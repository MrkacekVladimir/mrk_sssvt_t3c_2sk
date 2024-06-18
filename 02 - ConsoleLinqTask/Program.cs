using System.Data;

namespace ConsoleLinqTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = Database.GetShop();
            shop.PrintInfo();

            //1. Příklad filtrování
            TaskOne(shop);

            //2. Příklad výběru prvku
            TaskTwo(shop);

            //3. Příklad výběru prvku podle maxima
            TaskThree(shop);

            //4. Příklad použití průměru
            TaskFour(shop);

            //5. Příklad maxima na čase
            TaskFive(shop);

            //6. Příklad filtrování, řazení, získání určitého počtu
            TaskSix(shop);

            //7. Příklad filtrování, řazení, výběru
            TaskSeven(shop);

            //8. Příklad projekce
            TaskEight(shop);

            //BONUS Příklad agregace
            TaskBonus(shop);

        }

        /// <summary>
        /// Vyfiltruje všechny klienty, kteří nemají VIP členství
        /// </summary>
        /// <param name="shop">Obchod ve kterém filtrujeme</param>
        /// <returns>Seznam zákazníků, kteří nejsou VIP</returns>
        static List<Customer> TaskOne(Shop shop)
        {
            return shop.Customers.Where(customer => customer.IsVip == false).ToList();
        }

        /// <summary>
        /// Vrátí první objednávku s cenou větší než 150 000
        /// </summary>
        /// <param name="shop">Obchod ve kterém filtrujeme</param>
        /// <returns>Objednávka s cenou větší než 150 000</returns>
        static Order? TaskTwo(Shop shop)
        {
            //return shop.Orders.Where(order => order.TotalPrice > 150_000).First();
            return shop.Orders.First(order => order.TotalPrice > 150_000);
        }

        /// <summary>
        /// Najde a vrátí objednávku s největší celkovou cenou
        /// </summary>
        /// <param name="shop">Obchod ve kterém filtrujeme</param>
        /// <returns>Objednávku s největší celkovou cenou</returns>
        static Order? TaskThree(Shop shop)
        {
            return shop.Orders.MaxBy(order => order.TotalPrice);
        }

        /// <summary>
        /// Vrátí průměrný počet objednávek na zákazníka
        /// </summary>
        /// <param name="shop">Obchod ve kterém filtrujeme</param>
        /// <returns>Průměrný počet objednávek na zákazníka</returns>
        static double TaskFour(Shop shop)
        {
            return shop.Customers.Average(customer => customer.Orders.Count);
        }

        /// <summary>
        /// Vrátí nejaktuálnější datum objednávky.
        /// </summary>
        /// <param name="shop">Obchod ve kterém filtrujeme</param>
        /// <returns>Nejaktuálnější datum poslední objednávky</returns>
        static DateTime TaskFive(Shop shop)
        {
            return shop.Orders.Max(order => order.CreatedOn);
        }

        /// <summary>
        /// Vrátí nejdražší 3 objednávky od klientů, kteří nejsou VIP
        /// </summary>
        /// <param name="shop">Obchod ve kterém filtrujeme</param>
        /// <returns>Seznam objednávek</returns>
        static List<Order> TaskSix(Shop shop)
        {
            return shop.Orders
                .Where(order => order.Customer.IsVip == false)
                .OrderByDescending(order => order.TotalPrice)
                .Take(3)
                .ToList();
        }

        /// <summary>
        /// Vrátí druhou nejdražší zaplacenou objednávku
        /// </summary>
        /// <param name="shop">Obchod ve kterém filtrujeme</param>
        /// <returns>Druhá nejdražší zaplacená objednávka</returns>
        static Order? TaskSeven(Shop shop)
        {
            return shop.Orders
                .Where(order => order.PaidOn.HasValue)
                .OrderByDescending(order => order.TotalPrice)
                .Skip(1)
                .First();

            /*
            return shop.Orders
                .Where(order => order.PaidOn.HasValue)
                .OrderByDescending(order => order.TotalPrice)
                .Take(2)
                .Last();

            */
        }

        /// <summary>
        /// Vrátí nový seznam objektů obsahující pouze název zákazníka a počet jeho objednávek
        /// </summary>
        /// <param name="shop">Obchod ve kterém filtrujeme</param>
        /// <returns>Seznam DTO objektů</returns>
        static List<CustomerOrderCountDto> TaskEight(Shop shop)
        {
            return shop.Customers
                .Select(customer => new CustomerOrderCountDto(customer.FullName, customer.Orders.Count))
                .ToList();
        }

        /// <summary>
        /// Získá součet celkových cen všech objednávek, kterou jsou v rámci zákazníkových objednávek na sudém místě
        /// </summary>
        /// <param name="shop">Obchod ve kterém filtrujeme</param>
        /// <returns>Součet cen</returns>
        static decimal TaskBonus(Shop shop)
        {
            return shop.Orders.Aggregate(0m, (accumulator, order) =>
            {
                int index = order.Customer.Orders.IndexOf(order);
                if ((index + 1) % 2 != 0)
                {
                    return accumulator;
                }
                else
                {
                    return accumulator + order.TotalPrice;
                }
            });
        }

    }
}