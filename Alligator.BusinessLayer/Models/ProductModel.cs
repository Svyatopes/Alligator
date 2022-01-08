﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alligator.BusinessLayer.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryModel Category { get; set; }
    }
}