using System;
using System.Linq;

namespace Project7
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			DateTime date1, date2;
			Console.WriteLine("Введите первую дату в формате: 01.12.2000 01:00:00 ");
            date1 = DateTime.Parse(Console.ReadLine());
			Console.WriteLine("Первая дата: {0}", date1);
			Console.WriteLine("Введите вторую дату в формате: 01.12.2000 01:00:00 ");
            date2 = DateTime.Parse(Console.ReadLine());
           
			Console.WriteLine("Вторая дата: {0}", date2);
		
            int year1= date1.Year;
            int year2 = date2.Year;
            int month1 = date1.Month;
            int month2 = date2.Month;
            int day1 = date1.Day;
            int day2 = date2.Day;
            TimeSpan time = date2.TimeOfDay.Subtract(date1.TimeOfDay);

            int year = Math.Abs(year2 - year1);
            int month = Math.Abs(month1 - month2);
            int day = Math.Abs(day1 - day2);
            Console.WriteLine("\nYear " + year + "\nMonth " + month + "\nDay " + day + "\n" + time);

        }
    }
}
