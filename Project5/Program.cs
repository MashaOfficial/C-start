using System;
using System.IO;
using System.Linq;
using System.Windows;

// Если честно, сумма произвольного кол-ва чисел не работает(до переделывания работала)

namespace Project5
{
    public struct Square
    {
        public int x1_1, x1_2, x3_1, x3_2; // square's coordinate
        public double d;
        public double square;
        public double perimetr;

        public void Function(int x1_1, int x1_2, int x3_1, int x3_2)
        {
            d = Math.Pow(((x3_1 - x1_1) * (x3_1 - x1_1) + (x3_2 - x1_2) * (x3_2 - x1_2)), 0.5);

            Console.WriteLine("Diagonal: " + d);

            square = d * d / 2;
            perimetr = 2 * d * Math.Pow(2, 0.5);

            Console.WriteLine("Square is {0}\nPerimetr is {1}", square, perimetr);

            StreamWriter sw = new StreamWriter(@"C:square.txt");
            sw.WriteLine("Diagonal is " + d);
            sw.WriteLine("Perimetr is " + perimetr);
            sw.WriteLine("Square is " + square);

            sw.Close();

        }
    }

	public struct Summ
	{

        public static int Summa(params string[] text)                            //(string list)
		{

            string list = String.Join(" ", text);

            list.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x)).ToList();
			
            int result = 0;
            
            for (int i = 0; i < list.Length; i++)
			{
                
                result =+ i; 
			}

            return result;
        }


		public static string Reverse(string s)
		{
			char[] arr = s.ToCharArray();
			Array.Reverse(arr);
			return new string(arr);
		}

	}

    class MainClass
    {
        public static void Main(string[] args)
        {
            Square s = new Square();
            Console.WriteLine("Here is a square. Enter coordinate of poin.\nNotice, x1_1 and x1_2 is coordinate at the top right\nx1_1: ");
            s.x1_1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("x1_2 :");
            s.x1_2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("x3_1 : ");
            s.x3_1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nx3_2:");
            s.x3_2 = Convert.ToInt32(Console.ReadLine());
            s.Function(s.x1_1, s.x1_2, s.x3_1, s.x3_2);

			Console.WriteLine("Введите числа через пробел и нажмите Enter:");
            Console.WriteLine(Summ.Summa(Console.ReadLine()));

            Console.WriteLine("Введите числа через пробел и нажмите Enter:");
            Console.WriteLine(Summ.Reverse(Console.ReadLine()));
        }
            
    }
	
}

  