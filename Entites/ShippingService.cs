using Fawry_Task.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawry_Task.Entites
{
    public  class ShippingService
    {
        public void ship(List<IShippable> items, Customer customer)
        {
            double totalweight = 0;
            Console.WriteLine("** Shipment notice ** ");
            Dictionary<string,int> ItemCounts = new Dictionary<string, int>();
            Dictionary<string,double> ItemWeights = new Dictionary<string, double>();
            foreach(var item in items)
            {
                if(ItemCounts.ContainsKey(item.Getname()))
                {
                    ItemCounts[item.Getname()] ++;
                    ItemWeights[item.Getname()] += item.Getweight();
                }
                else
                {
                    ItemCounts[item.Getname()] = 1;
                    ItemWeights[item.Getname()] = item.Getweight();
                }
            }
            foreach (var itemName in ItemCounts.Keys)
            {
                Console.WriteLine($"{ItemCounts[itemName]}x {itemName}\t\t{ItemWeights[itemName]}g");
                totalweight += ItemWeights[itemName];
            }
            Console.WriteLine($"Total package weight is {totalweight/1000} Kg");
            Console.WriteLine();
        }
    }
}
