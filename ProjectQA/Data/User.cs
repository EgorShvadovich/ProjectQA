﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQA.Data
{
    public class User
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Role { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
    }
}
