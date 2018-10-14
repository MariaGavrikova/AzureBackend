using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdventureWorks;

namespace BackendService.Services
{
    public class ProductService
    {
        private readonly AdventureWorks.DbModel.Entities _entities =
            new AdventureWorks.DbModel.Entities();

        public ProductService()
        {
        }

        public ICollection<Product> GetProducts()
        {
            var query = from d in _entities.Products
                        select new BackendService.Services.Product
                        {
                            ProductID = d.ProductID,
                            Name = d.Name,
                        };

            return query.ToArray();
        }
    }
}
