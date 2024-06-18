using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLinqTask
{
    public class Customer
    {
        public Customer(string fullName, bool isVip = false)
        {
            FullName = fullName;
            IsVip = isVip;
        }

        public string FullName { get; set; }
        public bool IsVip { get; set; }
        public List<Order> Orders { get; set; } = new();

        public override string ToString()
        {
            return $"Customer: {FullName} | VIP: {(IsVip ? "YES" : "NO")} | Orders count: {Orders.Count}";
        }
    }
}
