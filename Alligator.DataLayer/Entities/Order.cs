﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.DataLayer.Entities
{
   public  class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        //public int ClientId { get; set; }
        public Client Client { get; set; }
        public string Address { get; set; }






    }
}
