using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry_Task.Entites
{
    public class ExpirableProduct:Product
    {

        public ExpirableProduct(string name, decimal price, int quantity, DateTime expireDate)
            : base(name, price, quantity)
        {
            ExpireDate = expireDate;
        }
    }
}
