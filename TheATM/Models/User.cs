﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheATM.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string DateOfBirth { get; set; }
        public DateTime UserCreated { get; set; }
    }
}
