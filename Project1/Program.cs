 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_1
{
	class MainClass
	{
		static void Main(string[] args)
		{
			// Console.WriteLine("Hello World!");
            Console.WriteLine("Hello stranger. How can  I call you?");
            string name = Console.ReadLine();
            Console.WriteLine("Hello, " + name + "!");
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine("New string");
			Console.ResetColor();
			Console.Beep();
			Console.WriteLine(Console.CapsLock);
			Console.WriteLine(Console.NumberLock);
		}
	}
}
