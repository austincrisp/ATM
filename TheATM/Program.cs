using System;
using TheATM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheATM
{
    public class Program
    {
        static string Read(string input)
        {
            Console.Write(input);
            return Console.ReadLine();
        }

        static void Main(string[] args)
        {
            using (var db = new ATMContext())
            {
                Console.WriteLine("1) Login");
                Console.WriteLine("2) Create a username and password");
                int initChoice = int.Parse(Read("> "));

                switch (initChoice)
                {
                    case 1:
                        Read("Enter your username: ");
                        Read("Enter your password: ");
                        break;
                    case 2:
                        CreateUser(db);
                        break;
                    default:
                        break;
                }

                //DoTransaction(db);
            }
        }

        private static void DoTransaction(ATMContext db)
        {
            Transaction instance = new Transaction();

            var allTransactions = db.Transactions.Count();
            Console.WriteLine($"{allTransactions} transactions in DB");

            foreach (var account in db.Accounts)
            {
                Console.WriteLine($"{account.Id} - {account.User.FullName}");
                foreach (var availBalance in db.Transactions)
                {
                    Console.WriteLine($"-- {availBalance}");
                }
            }

            int action = int.Parse(Read("> "));

            Console.WriteLine("1) Withdrawal");
            Console.WriteLine("2) Deposit");
            Console.WriteLine("3) View Balance");

            switch (action)
            {
                case 1:
                    instance.Withdrawal();
                    break;
                case 2:
                    instance.Deposit();
                    break;
                case 3:
                    instance.TotalBalance(instance.Debit, instance.Credit);
                    break;
                default:
                    break;
            }

            db.Transactions.Add(instance);
            db.SaveChanges();
        }

        private static void CreateAccount(ATMContext db)
        {
            var allAccounts = db.Accounts.Count();
            Console.WriteLine($"{allAccounts} accounts in DB");

            foreach (var user in db.Users)
            {
                Console.WriteLine($"{user.Id} - {user.FullName}");
            }

            var userId = int.Parse(Read("User ID? "));
            var userInstance = db.Users.Where(u => u.Id == userId).First();

            double initialBalance = double.Parse(Read("Please enter the initial balance of this account: "));
            int pinNo = int.Parse(Read("Please enter a 4-digit pin number for this account: "));
            string routingNo = Account.GenerateRoutingNumber();
            Console.WriteLine($"Here is your routing number: {routingNo}");

            Account myAccount = new Account
            {
                User = userInstance,
                InitialBalance = initialBalance,
                PinNo = pinNo,
                RoutingNo = routingNo
            };

            db.Accounts.Add(myAccount);
            db.SaveChanges();
        }

        private static void CreateUser(ATMContext db)
        {
            var allUsers = db.Users.Count();
            Console.WriteLine($"{allUsers} users in DB");

            var username = Read("Enter a username: ");
            var password = Read("Enter a password: ");
            var fullName = Read("Enter your first and last name: ");
            var address = Read("Etner your address: ");
            var phone = Read("Enter your phone number: ");
            var dob = Read("Enter your date of birth: ");
            var usercreated = DateTime.Now;

            User myUser = new User
            {
                UserName = username,
                Password = password,
                FullName = fullName,
                Address = address,
                Phone = phone,
                DateOfBirth = dob,
                UserCreated = usercreated
            };

            db.Users.Add(myUser);
            db.SaveChanges();
        }
    }
}
