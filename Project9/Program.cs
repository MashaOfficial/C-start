using System;
using System.Globalization;


namespace Project9
{

    public abstract class Account
    {
        protected int _id;
        static int counter = 0;

        protected decimal _sum;
        protected double _percentage;

        protected int _days = 1;

        public Account(decimal sum, double percentage, int days = 1)
        {
            _sum = sum;
            _percentage = percentage;
            _id = ++counter;
            _days = days;
        }


        public decimal CurrentSum
        {
            get { return _sum; }
        }

        public string Percentage
        {
            get { return Convert.ToString(_percentage); }
        }

        public int Id
        {
            get { return _id; }

        }


        protected internal virtual void Open()
        {
            Console.WriteLine("Открыт новый счет!Id счета: " + this._id, this._sum);
        }

        protected internal virtual void Close()
        {
            Console.WriteLine("Счет " + _id + " закрыт.  Итоговая сумма: " + CurrentSum);
        }

        public int IncrementDays
        {
            get { return _days; }
        }

        public int Days(int day)
        {
            this._days = day;
            return this._days;
        }

        protected virtual void Calculate() // count %
        {
            double increment = Convert.ToDouble(_sum) * _percentage / 100;
            //_sum = _sum + increment;
            Console.WriteLine("Начислены проценты в размере: " + increment);
        }

        public virtual void Put(decimal sum) // put money
        {
            _sum += sum;
            Console.WriteLine("На счет поступило " + sum);
        }

        public virtual decimal Withdraw(decimal sum) // recieve money
        {
            decimal result = 0;
            if (sum <= _sum)
            {
                _sum -= sum;
                result = sum;
                Console.WriteLine("Сумма " + sum + " снята со счета " + _id, sum);
            }
            else
            {
                Console.WriteLine("Недостаточно денег на счете " + _id);
            }
            return result;
        }

    }


    public class DemandAccount : Account, IAccount
    {
        public DemandAccount(decimal sum, double percentage) : base(sum, percentage)
        {
        }

        protected internal override void Open()
        {
            Console.WriteLine("Открыт новый счет до востребования! Id счета: " + this._id);
        }

        public void Count(int period)
        {
            this._days = period;
            double increment = Convert.ToDouble(_sum) * _percentage / 100;
            increment = increment * _days;
			Console.WriteLine("Начислены проценты в размере: " + increment);


        }
        public decimal AccountOperation
		{
            get { return _sum; }
            set
            {
                string [] transaction = new string[0];

                if (value < 0 && (0 > (value + _sum)))
                {
                    Console.WriteLine("Недостаточно денег на счете " + _id);
                }
                else
                    if (value < 0 && (0 < (value + _sum) || 0 == (value + _sum)))
                    {
                        decimal a = value;
                        decimal b = _sum;
                        _sum -= value;
                        Array.Resize(ref transaction, transaction.Length + 1);
                        transaction[transaction.Length - 1] = DateTime.Now + " Operation: " + Convert.ToString(a) + " - " + Convert.ToString(b) + " = " + Convert.ToString(_sum) ;
                    Console.WriteLine("Сумма " + Math.Abs(value) + " снята со счета " + _id, _sum);
                    }

                    else
                    {
    					decimal a = value;
    					decimal b = _sum; 
                        _sum += value;
                        Array.Resize(ref transaction, transaction.Length + 1);
                        transaction[transaction.Length - 1] = DateTime.Now + " Operation: " + Convert.ToString(a) + " + " + Convert.ToString(b) + " = " + Convert.ToString(_sum);                        
                        Console.WriteLine("На счет поступило " + value);
                    /*foreach (string i in transaction)
                    { Console.WriteLine(i); }*/
                    }
            }
		}

    }

   
    public class DepositAccount : Account, IAccount
    {
        public DepositAccount(decimal sum, double percentage) : base(sum, percentage)
        {
        }
        protected internal override void Open()
        {
            Console.WriteLine("Открыт новый депозитный счет!Id счета: " + this._id);
        }

        public override void Put(decimal sum)
        {
            if (_days % 30 == 0)
                base.Put(sum);
            else
                Console.WriteLine("На счет можно положить только после 30-ти дневного периода");
        }

        public override decimal Withdraw(decimal sum)
        {
            if (_days % 30 == 0)
                return base.Withdraw(sum);
            else
                Console.WriteLine("Вывести средства можно только после 30-ти дневного периода");
            return 0;
        }

        protected override void Calculate()
        {
            if (_days % 30 == 0)
                base.Calculate();
        }

        public void Count(int period)
        {
			this._days = period;
            if (_days % 30 == 0)
            {
                double increment = (Convert.ToDouble(_sum) * _percentage / 100) * period;
                Console.WriteLine("Начислены проценты в размере: " + increment + " ( " + period + " ) ");
            }            
            else
                Console.WriteLine("Не прошел 30-тидневный срок!");

		}

		public decimal AccountOperation
        {
            get { return _sum; }
            set
            {   if(_days % 30 == 0)
                {
                string[] transaction = new string[0];

                    if (value < 0 && (0 > (value + _sum)))
                    {
                        Console.WriteLine("Недостаточно денег на счете " + _id);
                    }
                    else
                        if (value < 0 && (0 < (value + _sum) || 0 == (value + _sum)))
                    {
                        decimal a = value;
                        decimal b = _sum;
                        _sum -= value;
                        Array.Resize(ref transaction, transaction.Length + 1);
                        transaction[transaction.Length - 1] = DateTime.Now + " Operation: " + Convert.ToString(a) + " - " + Convert.ToString(b) + " = " + Convert.ToString(_sum);
                        Console.WriteLine("Сумма " + value + " снята со счета " + _id, _sum);
                    }

                    else
                    {
                        decimal a = value;
                        decimal b = _sum;
                        _sum += value;
                        Array.Resize(ref transaction, transaction.Length + 1);
                        transaction[transaction.Length - 1] = DateTime.Now + " Operation: " + Convert.ToString(a) + " + " + Convert.ToString(b) + " = " + Convert.ToString(_sum);
                        Console.WriteLine("На счет поступило " + value);
                        /*foreach (string i in transaction)
                        { Console.WriteLine(i); }*/
                    }      
            } else {Console.WriteLine("Не прошел 30-тидневный срок!"); }
            }
        }

    }

    public class AnotherDepositAccount : DepositAccount, IAccount
    {
        public AnotherDepositAccount(decimal sum, double percentage) : base(sum, percentage)
        {

        }

        protected internal override void Open()
        {
            Console.WriteLine("Открыт новый депозитный счет на год!Id счета: " + this._id);
        }

        public override void Put(decimal sum)
        {
            if (_days % 365 == 0)
                base.Put(sum);
            else
                Console.WriteLine("На счет можно положить только после 365-ти дневного периода");
        }

        public override decimal Withdraw(decimal sum)
        {
            if (_days % 365 == 0)
                return base.Withdraw(sum);
            else
                Console.WriteLine("Вывести средства можно только после 365-ти дневного периода");
            return 0;
        }

        protected override void Calculate()
        {
            if (_days % 365 == 0)
                base.Calculate();
        }

        public new void Count(int period)
        {
            //Console.WriteLine("Начислены проценты: ");
			this._days = period;
			if (_days > 365)
			{
				double increment = (Convert.ToDouble(_sum) * _percentage / 100) * period;
				Console.WriteLine("Начислены проценты в размере: " + increment + " ( " + period + " ) ");
			}
			else
				Console.WriteLine("Не прошел 365-тидневный срок!");
           }

    }

    public interface IAccount
    {

        void Count(int period);

    }


    class MainClass
    {
        public static void Main()
        {
            DemandAccount myaccount_1 = new DemandAccount(60000, 0.001);
            DepositAccount myaccount_2 = new DepositAccount(40000, 0.002);
            AnotherDepositAccount myaccount_3 = new AnotherDepositAccount(900000, 0.03);
            //myaccount_1.Open();
            /*myaccount_1.Count(30);
            myaccount_1.Count(100);

            myaccount_2.Count(20);
            myaccount_2.Count(90);

            myaccount_3.Count(700);
            myaccount_3.Count(69);


			int mai_period = 90;

            var _array = new[] { new DepositAccount(900000, 0.0002), new AnotherDepositAccount(60000, 0.001) };

            foreach(var i in _array)
            {
                i.Count(mai_period);

            }*/

            /*myaccount_1.CurrentSum.ToString();
            myaccount_1.Percentage.ToString();
            myaccount_1.Withdraw(5000);
            myaccount_2.Open();
            myaccount_2.CurrentSum.ToString();
            myaccount_2.Close();
            myaccount_3.Open();
            myaccount_3.IncrementDays.ToString();
            myaccount_3.Put(40000);*/

            Console.WriteLine(myaccount_1.AccountOperation.ToString());
            myaccount_1.AccountOperation = +6000;
            myaccount_1.AccountOperation = -90000;
            myaccount_1.AccountOperation = +86000;
            Console.WriteLine(myaccount_1.AccountOperation.ToString());
			myaccount_1.AccountOperation = -9030;
			myaccount_1.AccountOperation = +11800;
			Console.WriteLine(myaccount_1.AccountOperation.ToString());

		}

    }
}
