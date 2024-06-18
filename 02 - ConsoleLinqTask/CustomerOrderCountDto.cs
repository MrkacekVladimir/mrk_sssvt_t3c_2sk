using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLinqTask
{
    public class CustomerOrderCountDto
    {
        public CustomerOrderCountDto(string customerName, int orderCount)
        {
            CustomerName = customerName;
            OrderCount = orderCount;
        }

        public string CustomerName { get; set; }
        public int OrderCount { get; set; }
    }
}
