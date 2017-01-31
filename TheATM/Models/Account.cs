using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheATM.Models
{
    public class Account
    {
        public int Id { get; set; }
        public double InitialBalance { get; set; }
        public int PinNo { get; set; }
        public string RoutingNo { get; set; }

        public static string GenerateRoutingNumber()
        {
            Random RoutingNo = new Random();

            return RoutingNo.Next(0, 100000000).ToString("D10");
        }
    }
}
