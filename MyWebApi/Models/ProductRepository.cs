
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApi.Models
{
    public class ProductRepository : IProduct
    {
        private List<Product> listProducts = new List<Product>();
        public ProductRepository()
        {
            listProducts.Add(new Product { ID = "p1", Name = "Name 1", Price = 100 });
            listProducts.Add(new Product { ID = "p2", Name = "Name 2", Price = 200 });
            listProducts.Add(new Product { ID = "p3", Name = "Name 3", Price = 400 });
        }
        public Product Find(string id)
        {
            return listProducts.Single(p => p.ID.Equals(id));
        }

        public IEnumerable<Product> FindAll()
        {
            return listProducts;
        }
    }
}
