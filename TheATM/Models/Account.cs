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
        public int AccountNo { get; set; }
        public int RoutingNo { get; set; }
        public User User { get; set; }
    }
}
