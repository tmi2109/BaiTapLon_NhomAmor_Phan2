using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balo
{
    class CLTL_Balo
    {
        static void Main()
        {
            int[] values = { 60, 100, 120 };
            int[] weights = { 10, 20, 30 };
            int capacity = 50;
            int n = values.Length;

            Console.WriteLine("Gia tri va trong luong cua tung do vat:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Do vat {0}: Gia tri = {1}, Trong luong = {2}", i + 1, values[i], weights[i]);
            }

            Console.WriteLine("Gia tri toi da trong balo = " + KnapsackDP(weights, values, capacity, n));
            Console.ReadKey();
        }

        static int KnapsackDP(int[] weights, int[] values, int capacity, int n)
        {
            int[,] K = new int[n + 1, capacity + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int w = 0; w <= capacity; w++)
                {
                    if (i == 0 || w == 0)
                    {
                        K[i, w] = 0;
                    }
                    else if (weights[i - 1] <= w)
                    {
                        K[i, w] = Math.Max(values[i - 1] + K[i - 1, w - weights[i - 1]], K[i - 1, w]);
                    }
                    else
                    {
                        K[i, w] = K[i - 1, w];
                    }
                }
            }

            return K[n, capacity];
        }
    }
}
