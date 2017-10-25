using System;
using System.Globalization;
using System.Text;


namespace Project8
{
    class MainClass
    {

		public static string ReverseString(string s)
		{
			char[] arr = s.ToCharArray();
			Array.Reverse(arr);
			return new string(arr);
		}

        public static void Task1(string string1,  string string2)
        {
		
            if (string1.Length < string2.Length)
				Console.WriteLine("Incorrect enter");
			else
			{
				if (string1.Contains(string2))
					Console.WriteLine("String  '{0}' contains string  '{1}', index is {2}", string1, string2, string1.IndexOf(string2));
				else
					Console.WriteLine("String  '{0}' not contains string  '{1}'", string1, string2);
			}

			if (ReverseString(string1).Contains(ReverseString(string2)))
				Console.WriteLine("\nIn reverse order\nString  '{0}' contains string  '{1}'   {2} ", string1, string2, string1.Length - ReverseString(string1).IndexOf(ReverseString(string2)));
			else
				Console.WriteLine("String  '{0}' not contains string  '{1}'", string1, string2);

         }

        public static void Task2(string s)
        {
            Console.WriteLine(s.Trim());
        }

        public static void Task3(string s)
        {
			string[] separators = { ",", ".", ":", " " };
            string[] words = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
			foreach (var word in words)
				Console.WriteLine(word);
		

		}

        public static void Task4()
        {
            Console.WriteLine("\nTask4\n");

            int a = 344567895;
			Console.WriteLine(a.ToString("0,0"));
			Console.WriteLine(String.Format(CultureInfo.InvariantCulture, "{0:0,0}", a));
			Console.WriteLine(String.Format(CultureInfo.CreateSpecificCulture("fr-FR"), "{0:0,0}", a));
			Console.WriteLine(String.Format("{0:0000000000000}", a));
			Console.WriteLine(a.ToString("(###) ###-####"));
			Console.WriteLine(String.Format("{0:(###) ###-####}", a));

			float b = 12.456f;
			Console.WriteLine(b.ToString("0.00", CultureInfo.CreateSpecificCulture("fr-FR")));
			Console.WriteLine(String.Format(CultureInfo.InvariantCulture, "{0:0.00}", b));
			Console.WriteLine(b.ToString("#0.##%", CultureInfo.InvariantCulture));
			Console.WriteLine(String.Format(CultureInfo.CreateSpecificCulture("fr-FR"), "{0:0.###E+0}", b));

			DateTime date1 = new DateTime(2011, 6, 10);
			Console.WriteLine("Today is " + date1.ToString("MMMM dd, yyyy"));
			DateTimeOffset date2 = new DateTimeOffset(2011, 6, 10, 15, 24, 16, TimeSpan.Zero);
			Console.WriteLine("The current date and time: {0:MM/dd/yy H:mm:ss zzz}", date2);
			DateTime date3 = new DateTime(2008, 8, 29, 19, 27, 15);

			Console.WriteLine(date1.ToString("d, M", CultureInfo.InvariantCulture));
			Console.WriteLine(date1.ToString("d MMMM", CultureInfo.CreateSpecificCulture("en-US")));
			Console.WriteLine(date1.ToString("d MMMM", CultureInfo.CreateSpecificCulture("es-MX"))); // Mexico



		}

        public static void Task5(string[] s1, string[] s2)
        {
			StringBuilder builder = new StringBuilder();
			foreach (string s in s1)
			{
				builder.Append(s);
				builder.Append(" ");
			}
			foreach (string s in s2)
			{
				builder.Append(s);
				builder.Append(" ");
			}
			Console.WriteLine(builder);
        }

        public static void Main(string[] args)
        {
			Console.WriteLine("Task 1\nEnter string : ");
			string string1 = Convert.ToString(Console.ReadLine());
			Console.WriteLine("\nEnter what string you are looking for :");
			string string2 = Convert.ToString(Console.ReadLine());  
            Task1(string1, string2);
			Console.WriteLine("\nTask2 ");
			Console.WriteLine("Enter your string with whitespaces :");
            string string3 = Convert.ToString(Console.ReadLine());
            Task2(string3);
            Console.WriteLine("\nTask3\nEnter text : ");
            string string4 = Convert.ToString(Console.ReadLine());
            Task3(string4);
            Task4();
            Console.WriteLine("\nTask5\nEnter first string :  ");
			string[] s1 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("Enter second string : ");
            string[] s2 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Task5(s1, s2);

		}
    }
}
