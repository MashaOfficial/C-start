using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica
{
	class MainClass
	{
        enum embedded_system : long { Symbian=2, Embedded_Linux=3, Windows_CE=4, VxWorks, QNX };
		public struct Circle
		{
			public int x, y, r, l; // (x,y) is center of a circle and r is radius and l is length and square is s
			public float s;
			public const float p = 3.14f;
			public void Square()
			{
				s = p * r * r;
				l = (int)(2 * r * p);
				Console.WriteLine("Circle ({0};{1}) with radius {2} and length {3} has square = {4} ", x, y, r, l, s);
			}

		}

		static void Main(string[] args)
		{
			int num;
			Console.WriteLine("Enter your number: ");
			num = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("\nResult : " + (3 * num * num + 4 * num * num - 2 * num + 1));
			Console.WriteLine("Next task...\n ");

			//Console.WriteLine(embedded_system.Embedded_Linux);
			Console.WriteLine("The members of the embedded system enum are:");
            foreach (string s in Enum.GetNames(typeof(embedded_system)))
				Console.WriteLine(s);
			Console.WriteLine("\nNext task... \n");


			Circle circle = new Circle();
			circle.x = 0;
			circle.y = 0;
			Console.WriteLine("Enter your radius :\n");
			circle.r = Convert.ToInt32(Console.ReadLine());

			// circle.l = 2 * circle.r * 3;
			// Console.WriteLine("Circle's square is  ");
			circle.Square();





		}
	}
}
