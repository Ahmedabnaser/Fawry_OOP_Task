using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry_Task.Entites
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime?  ExpireDate { get; set; }
        public bool IsExpired => ExpireDate.HasValue && DateTime.Now > ExpireDate.Value;
        public Product(string name, decimal price, int quantity, DateTime? expireDate = null)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            ExpireDate = expireDate;
        }
    }
}
