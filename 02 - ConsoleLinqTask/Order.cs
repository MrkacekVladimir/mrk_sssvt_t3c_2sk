using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLinqTask
{
    public class Order
    {
        public Order(DateTime createdOn, DateTime? paidOn, decimal totalPrice, Customer customer)
        {
            CreatedOn = createdOn;
            PaidOn = paidOn;
            TotalPrice = totalPrice;
            Customer = customer;

            customer.Orders.Add(this);
        }

        public DateTime CreatedOn { get; set; }
        public DateTime? PaidOn { get; set; }
        public decimal TotalPrice { get; set; }
        public Customer Customer { get; private set; }

        public override string ToString()
        {
            int index = Customer.Orders.IndexOf(this);
            return $"Order ID: #{index + 1} | Total Price: {TotalPrice},- CZK | Created On: {CreatedOn.ToShortDateString()} | Paid On: {(PaidOn.HasValue ? PaidOn.Value.ToShortDateString() : "NOT PAID")}";
        }

    }
}
