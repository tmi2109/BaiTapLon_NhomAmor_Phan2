using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    class Node : IComparable<Node>
    {
        public char ch;
        public int freq;
        public Node left;
        public Node right;

        public Node(char ch, int freq)
        {
            this.ch = ch;
            this.freq = freq;
            left = right = null;
        }

        public int CompareTo(Node other)
        {
            return this.freq - other.freq;
        }
    }
    class CLTL_Huffman
    {
        static List<Node> heap = new List<Node>();

        static void Insert(Node element)                    // Chèn một phần tử vào danh sách và sắp xếp lại
        {
            heap.Add(element);
            heap.Sort();
        }

        static Node DeleteMin()                         //Lấy và xóa phần tử có tần suất nhỏ nhất khỏi danh sách
        {
            Node minElement = heap[0];
            heap.RemoveAt(0);
            return minElement;
        }

        static void Print(Node temp, string code)           //In mã Huffman của các ký tự
        {
            if (temp.left == null && temp.right == null)
            {
                Console.WriteLine("Ky tu {0} ma {1}", temp.ch, code);
                return;
            }

            Print(temp.left, code + "0");
            Print(temp.right, code + "1");
        }

        static void Main()
        {
            Console.Write("Nhap so khong co ky tu: ");
            int n = int.Parse(Console.ReadLine());

            if (n == 0)
            {
                Console.WriteLine("Khong co ky tu de ma hoa");
                return;
            }

            Console.WriteLine("Nhap ky tu va tan suat:");
            for (int i = 0; i < n; i++)
            {
                char ch = Console.ReadLine()[0];
                int freq = int.Parse(Console.ReadLine());
                Node temp = new Node(ch, freq);
                Insert(temp);
            }

            if (n == 1)
            {
                Console.WriteLine("Ky tu {0} ma 0", heap[0].ch);
                return;
            }

            for (int i = 0; i < n - 1; i++)
            {
                Node left = DeleteMin();
                Node right = DeleteMin();
                Node temp = new Node('\0', left.freq + right.freq);
                temp.left = left;
                temp.right = right;
                Insert(temp);
            }

            Node tree = DeleteMin();
            Print(tree, "");

            Console.ReadKey();
        }
    }
}
