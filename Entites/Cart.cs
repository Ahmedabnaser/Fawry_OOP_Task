using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Fawry_Task.Entites
{
    public class Cart
    {
        public List<CartItem> Items = new List<CartItem>();
        public void AddItem(Product product,int quantity)
        {
            if (quantity <= 0 || quantity > product.Quantity)
            {
                throw new Exception($"Invalid Quantity for product \"{product.Name}\" Only Avaliable : {product.Quantity} ");
            }
            Items.Add(new CartItem(product, quantity));
            product.Quantity -= quantity;
        }
        public List<CartItem> GetAllItems() => Items;
        public bool IsEmpty() => !Items.Any();
    }
}
