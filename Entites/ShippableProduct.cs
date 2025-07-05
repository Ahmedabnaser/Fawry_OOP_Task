using Fawry_Task.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry_Task.Entites
{
    internal class ShippableProduct:Product, IShippable
    {
        public double Weight { get;set; }

        public ShippableProduct(string name,decimal price,int quantity,double weight,DateTime? ExpireDate=null):base(name, price, quantity, ExpireDate)
        {
            Weight = weight;
        }

        public string Getname()
        {
            return Name;
        }

        public double Getweight()
        {
            return Weight;
        }
    }
}
