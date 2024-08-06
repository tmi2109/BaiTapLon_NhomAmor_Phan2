using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuaChonHoatDong_Activity_Selection
{
    class HoatDong
    {
        public int Start { get; set; }
        public int Finish { get; set; }
        public string TenHD { get; set; }
    }
    class CLTL_Activity_Selection
    {
        static void Main(string[] args)
        {
            HoatDong[] hd = new HoatDong[MAX];
            int n;
            do
            {
                Console.Write("Nhap so luong hoat dong: ");
                n = int.Parse(Console.ReadLine());
            } while (n <= 0 || n > MAX);

            for (int i = 0; i < n; i++)
            {
                hd[i] = new HoatDong();
                Console.Write($"Nhap ten hoat dong {i + 1}: ");
                hd[i].TenHD = Console.ReadLine();
                Console.Write("Nhap thoi gian bat dau & ket thuc cua hoat dong: ");
                string[] times = Console.ReadLine().Split(' ');
                hd[i].Start = int.Parse(times[0]);
                hd[i].Finish = int.Parse(times[1]);
            }

            ActivitySelection(hd, n);                   //Gọi phương thức ActivitySelection để chọn và in ra các hoạt động được chọn.
            Console.ReadKey();
        }

        const int MAX = 10;
        static void HoanVi(ref HoatDong a, ref HoatDong b)             
        {
            HoatDong t = a;
            a = b;
            b = t;
        }

        static void SapXepHoatDong(HoatDong[] hd, int n)                     // sắp xếp các hoạt động theo thời gian kết thúc tăng dần
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (hd[i].Finish > hd[j].Finish)
                    {
                        HoanVi(ref hd[i], ref hd[j]);
                    }
                }
            }
        }
        static void ActivitySelection(HoatDong[] hd, int n)             //Sắp xếp các hoạt động và chọn các hoạt động theo chiến lược tham lam
        {           
            SapXepHoatDong(hd, n);
            int i = 0;
            Console.WriteLine("Cac hoat dong duoc chon la:");           //In ra danh sách các hoạt động được chọn.
            Console.WriteLine(hd[i].TenHD);
            for (int j = 1; j < n; j++)
            {
                if (hd[j].Start >= hd[i].Finish)
                {
                    Console.WriteLine(hd[j].TenHD);
                    i = j;
                }
            }
        }
    }

}
