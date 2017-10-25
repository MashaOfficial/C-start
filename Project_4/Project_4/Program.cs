using System;


namespace Function{
	
    class MyExc : System.Exception
    {
        public void MyException()
        {
            Console.WriteLine("There can't be a zero");   
        }

    }

	public class Counter
	{
        public static double Count(double a)
		{
			double result = 0;

            if (a == 0) throw new MyExc();
			double b = Math.Pow(a, 0.5);
			result = 3 * (1 / (a * a)) + 4 / a - 2 * b + 1;
            return result;
		}

	}




	class MainClass
    {
        public static void Main(string[] args)
        {
            try
                {

				//double result = 0;
				Console.WriteLine("Ener x: ");
				double x = Convert.ToDouble(Console.ReadLine());
                if (x == 0) throw new DivideByZeroException();
                else if (x < 0) throw new MyExc();
                else
                {
                    double a = Counter.Count(x);
                    Console.WriteLine(a);
                }
                }
                
            catch (FormatException)
                {
                    Console.WriteLine("Format exception. Enter number, please ");
                }

            catch (MyExc)
            {
                Console.WriteLine("There can't be a negative");
            }
                
            catch (DivideByZeroException)
            {
                Console.WriteLine("Zero exception");
            }

            catch (Exception)
            {
                Console.WriteLine("Unknown exception");
            }
        }
	}
}
