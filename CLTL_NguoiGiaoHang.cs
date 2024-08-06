using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDuong_NguoiGiaoHang
{
    class CLTL_NguoiGiaoHang
    {
        static int[,] matrix = new int[10, 10];
        static bool[] thanhPhoDaTham = new bool[10];
        static int n, chiPhi = 0;

        static void Main()
        {
            TravellingSalesmanProblem();
            Console.WriteLine("\n\nDuong di:");
            ChiPhiToiThieu(0);
            Console.WriteLine("\n\nChi phi toi thieu {0}", chiPhi);

            Console.ReadKey();
        }

        static void TravellingSalesmanProblem()
        {
            Console.Write("Nhap so thanh pho: ");
            n = int.Parse(Console.ReadLine());

            Console.WriteLine("\nNhap ma tran:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\nNhap {0} phan tu dong [{1}]:", n, i + 1);
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
                thanhPhoDaTham[i] = false;
            }

            Console.WriteLine("\n\nDanh sach:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < n; j++)
                {
                    Console.Write("\t{0}", matrix[i, j]);
                }
            }
        }

        static int Least(int c)
        {
            int nc = int.MaxValue;
            int min = int.MaxValue, kmin = 0;

            for (int i = 0; i < n; i++)
            {
                if (matrix[c, i] != 0 && !thanhPhoDaTham[i])
                {
                    if (matrix[c, i] + matrix[i, c] < min)
                    {
                        min = matrix[i, 0] + matrix[c, i];
                        kmin = matrix[c, i];
                        nc = i;
                    }
                }
            }

            if (min != int.MaxValue)
            {
                chiPhi += kmin;
            }

            return nc;
        }

        static void ChiPhiToiThieu(int city)
        {
            thanhPhoDaTham[city] = true;
            Console.Write("{0}--->", city + 1);

            int ncity = Least(city);

            if (ncity == int.MaxValue)
            {
                ncity = 0;
                Console.Write("{0}", ncity + 1);
                chiPhi += matrix[city, ncity];
                return;
            }

            ChiPhiToiThieu(ncity);
        }
    }
}
