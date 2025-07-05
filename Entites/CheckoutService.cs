using Fawry_Task.Interface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Fawry_Task.Entites
{
    internal class CheckoutService
    {
        private decimal ShippingFees = 30;

        decimal TotalSumOfAllITems;
        public void CheckOut(Customer customer, Cart cart)
        {
            if (cart.IsEmpty())
            {
                throw new Exception("Cart is empty");
            }
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }
            foreach (var item in cart.GetAllItems())
            {
                TotalSumOfAllITems += item.TotalPrice;
            }
            List<IShippable> shipables = new();
            decimal subtotal = 0;
            decimal shipping = 0;
            
            foreach (var item in cart.GetAllItems())
            {

                if (item.Product.IsExpired)
                {
                    throw new Exception($"{item.Product.Name} is Expired ");
                }
                if (item.Product.Quantity < 0)
                {
                    throw new Exception($"{item.Product.Name} is out of stock plz check later");
                }
                subtotal += item.TotalPrice;

                if (item.Product is IShippable shippable)
                {
                    for (int i = 0; i < item.Quantity; i++)
                            shipables.Add(shippable);
                    shipping+=ShippingFees * item.Quantity;

                }
            }

            decimal total = subtotal + ShippingFees;
            if (customer.Balance < total)
            {
                throw new Exception($"Your balance is not enough to complete the transaction your balance is {customer.Balance} and the total is {total} ");
            }
            customer.Balance -= total;//reduce customer balance

            if (shipables.Any())
            {
                new ShippingService().ship(shipables,customer);
            }

            // then we print the recipet
            Console.WriteLine("** Checkout receipt ** ");
            foreach (var item in cart.GetAllItems())
            {
                Console.WriteLine($"{item.Quantity} x {item.Product.Name} {item.Product.Price} = {item.TotalPrice}");
            }
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"subtotal {subtotal}");
            Console.WriteLine($"Shipping {ShippingFees}");
            Console.WriteLine($"Amount {total}");
            Console.WriteLine($"The Remaning Balance is {customer.Balance} for Mr. {customer.Name}");

        }
    }
}
