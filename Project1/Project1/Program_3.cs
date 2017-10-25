using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project3
{
    class MainClass
    {
        Console.WriteLine("Your fibbonacci number:\n");
i       int number = Convert.ToInt32(Console.ReadLine());
        if (number > 48)
            {
                Console.WriteLine("Too long number");
                
            }
        else if (number< 1)
            {
                Console.WriteLine("Too small number\n");
            }
         else
            {
                int perv = 1;
                int vtor = 1;
                int sum = 0;

                int j = 2;
                while (j <= number)
                {
                    sum = perv + vtor;
                    perv = vtor;
                    vtor = sum;
                    j++;
                }
                Console.WriteLine("Под номером " + number + " в ряде Фибоначчи стоит число " + perv); 
            }
    }
}


