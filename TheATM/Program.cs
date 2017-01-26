using System;
using TheATM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheATM
{
    class Program
    {
        /*
        static string Read(string input)
        {
            Console.Write(input);
            return Console.ReadLine();
        }
        */

        static void Main(string[] args)
        {
            /*
            using (var db = new ATMContext())
            {
            }
            */
        }

        /*
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
        */
    }
}
