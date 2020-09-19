﻿using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
   public  class Customer: EntityBase
    {
        [DataColum]

        public int CustomerId { get; set; }
        [DataColum]
        public string Name { get; set; }
        [DataColum]
        public string Address { get; set; }
        [DataColum]
        public string Email { get; set; }
        [DataColum]
        public string Phone { get; set; }
        [DataColum]
        public string UserName { get; set; }
        [DataColum]
        public string Password { get; set; }
        [DataColum]
        public int IsActive { get; set; }
    }
}
