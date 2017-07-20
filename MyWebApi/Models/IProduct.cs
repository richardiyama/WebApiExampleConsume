﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApi.Models
{
   public interface IProduct
    {
        IEnumerable<Product> FindAll();
        Product Find(string id);
    }
}