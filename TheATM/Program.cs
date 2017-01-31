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
                bool active = true;

                while (active)
                {
                    Console.WriteLine("1) Login");
                    Console.WriteLine("2) Create a username and password and setup initial account");
                    Console.WriteLine("3) Exit machine");
                    int initialChoice = int.Parse(Read("> "));

                    switch (initialChoice)
                    {
                        case 1:
                            string uName = Read("Enter your username: ");
                            string pWord = Read("Enter your password: ");

                            foreach (var user in db.Users)
                            {
                                if (uName == user.UserName && pWord == user.Password)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Welcome {user.FullName} \n");
                                    Console.WriteLine("What would you like to do? ");
                                    DoTransaction(db, user);
                                }
                                else
                                {
                                    Console.WriteLine("Sorry, that username is invalid. ");
                                }
                            }
                            db.SaveChanges();
                            break;
                        case 2:
                            CreateUser(db);
                            break;
                        case 3:
                            active = false;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private static void DoTransaction(ATMContext db, User user)
        {
            Transaction instance = new Transaction();

            var allTransactions = db.Transactions.Count();
            Console.WriteLine($"{allTransactions} transactions in DB");

            var accountInstance = user.Account;
            int action = 0;

            while (action != 4)
            {
                Console.WriteLine("1) Withdrawal");
                Console.WriteLine("2) Deposit");
                Console.WriteLine("3) View Balance");
                Console.WriteLine("4) Exit");
                action = int.Parse(Read("> "));

                switch (action)
                {
                    case 1:
                        instance.Credit = 0;
                        instance.Withdrawal();
                        instance.SubtractFromBalance(instance.Debit);
                        break;
                    case 2:
                        instance.Debit = 0;
                        instance.Deposit();
                        instance.AddToBalance(instance.Credit);
                        break;
                    case 3:
                        instance.Credit = 0;
                        instance.Debit = 0;
                        Console.WriteLine($"Available Balance: {instance.AvailableBalance}");
                        break;
                    case 4:
                        break;
                    default:
                        break;
                }

                Transaction myTransaction = new Transaction
                {
                    Account = accountInstance,
                    Debit = instance.Debit,
                    Credit = instance.Credit,
                    AvailableBalance = instance.AvailableBalance
                };

                db.Transactions.Add(myTransaction);
            }
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

            Account myAccount = new Account();

            db.Accounts.Add(myAccount);
            db.SaveChanges();

            User myUser = new User
            {
                UserName = username,
                Password = password,
                FullName = fullName,
                Address = address,
                Phone = phone,
                DateOfBirth = dob,
                UserCreated = usercreated,
                Account = myAccount
            };

            db.Users.Add(myUser);
            db.SaveChanges();
        }
    }
}
