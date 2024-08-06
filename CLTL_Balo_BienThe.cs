using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balo_BienThe
{
    class CLTL_Balo_BienThe
    {
        static void Main()
        {
            List<Item> items = new List<Item>
        {
            new Item { Weight = 10, Value = 60 },
            new Item { Weight = 20, Value = 100 },
            new Item { Weight = 30, Value = 120 }
        };

            int capacity = 50;

            Console.WriteLine("Gia tri va trong luong cua tung do vat:");
            foreach (var item in items)
            {
                Console.WriteLine("Do vat: Gia tri = {0}, Trong luong = {1}", item.Value, item.Weight);
            }

            Console.WriteLine("Gia tri toi da trong balo = " + FractionalKnapsackGreedy(items, capacity));
            Console.ReadKey();
        }
        class Item
        {
            public int Weight { get; set; }
            public int Value { get; set; }
            public double Ratio { get { return (double)Value / Weight; } }
        }

        static double FractionalKnapsackGreedy(List<Item> items, int capacity)
        {
            items.Sort((a, b) => b.Ratio.CompareTo(a.Ratio));

            double totalValue = 0.0;
            foreach (var item in items)
            {
                if (capacity == 0)
                {
                    break;
                }

                if (item.Weight <= capacity)
                {
                    totalValue += item.Value;
                    capacity -= item.Weight;
                }
                else
                {
                    totalValue += item.Ratio * capacity;
                    capacity = 0;
                }
            }

            return totalValue;
        }
    }
}
