﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiregister.Model
{
    public class registration
    {
       
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Phn { get; set; }
        public int Password{ get; set; }
    }
}
