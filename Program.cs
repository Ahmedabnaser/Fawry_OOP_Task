using Fawry_Task.Entites;
using System.Collections.Concurrent;
using System.Threading.Channels;

namespace Fawry_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customer1 = new Customer("Ahmed",1700);
            var Cheese = new Product("cheese", 20, 2, new DateTime(2026,5,1));
            var tv = new ShippableProduct("Tv", 1300, 1, 1500,null);
            var egg=new Product("Egg", 10, 5, new DateTime(2028, 12, 1));
            var milk = new ShippableProduct("Milk", 10, 5, 2.5, new DateTime(2030, 12, 1));
            Cart cart = new Cart(); 
            cart.AddItem(Cheese, 2);
            cart.AddItem(tv, 1);
            cart.AddItem(egg, 5);
            cart.AddItem(milk, 3);
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.CheckOut(customer1, cart);
            
         

        }
    }
}
