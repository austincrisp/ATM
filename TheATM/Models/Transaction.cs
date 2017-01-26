using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheATM.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public double Balance { get; set; }

        public virtual Account Account { get; set; }

        public string TransRead(string input)
        {
            Console.Write(input);
            return Console.ReadLine();
        }

        public double Withdrawal(double InitialBalance)
        {
            int choice = int.Parse(TransRead("> "));

            Console.WriteLine("1) $10");
            Console.WriteLine("2) $20");
            Console.WriteLine("3) $50");
            Console.WriteLine("4) $100");

            switch (choice)
            {
                case 1:
                    Balance -= 10;
                    break;
                case 2:
                    Balance -= 20;
                    break;
                case 3:
                    Balance -= 50;
                    break;
                case 4:
                    Balance -= 100;
                    break;
                default:
                    break;
            }
            return Balance;
        }

        public double Deposit(double InitialBalance)
        {
            Console.WriteLine("Enter the amount you want to deposit: ");
            double amount = double.Parse(TransRead("> "));

            InitialBalance += amount;

            return Balance;
        }
    }
}
