using System;

namespace Project_3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter your Fibbonacci number:\n");
            int number = Convert.ToInt32(Console.ReadLine());
            int first = 0;
            int second = 1;
            int fibb = 0;
            int counter = 0;
            //Console.WriteLine("\n1\n1");
            Console.WriteLine("\n");

            while (counter < number && number > 2 && number < 40)
            {
                fibb = first + second;
                Console.WriteLine("{0}", fibb);
                // fibb = second;
                first = second;
                second = fibb; 
                counter++;


            }

            Console.WriteLine("\n" + fibb);
        }
    }
}
