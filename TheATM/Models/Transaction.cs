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
        public double AvailableBalance { get; set; }

        public virtual Account Account { get; set; }

        public string TransRead(string input)
        {
            Console.Write(input);
            return Console.ReadLine();
        }

        public double Withdrawal()
        {
            Console.WriteLine("How much would you like to withdraw? ");
            Console.WriteLine("1) $10");
            Console.WriteLine("2) $20");
            Console.WriteLine("3) $50");
            Console.WriteLine("4) $100");
            int choice = int.Parse(TransRead("> "));

            switch (choice)
            {
                case 1:
                    Debit -= 10;
                    break;
                case 2:
                    Debit -= 20;
                    break;
                case 3:
                    Debit -= 50;
                    break;
                case 4:
                    Debit -= 100;
                    break;
                default:
                    break;
            }

            return Debit;
        }

        public double Deposit()
        {
            Console.WriteLine("Enter the amount you want to deposit: ");
            double amount = double.Parse(TransRead("> "));

            Credit = amount;

            return Credit;
        }

        public double TotalBalance(double Credit)
        {
            if (Credit > 0)
            {
                AvailableBalance += Credit;
            }
            else if (Debit < AvailableBalance)
            {
                AvailableBalance -= Debit;
            }
            else
            {
                Console.WriteLine("The amount you have chosen to withdrawal will result in an overdraft and cannot take place. ");
                Console.WriteLine("We apologize for the inconvenience. ");
            }

            return AvailableBalance;
        }
    }
}
