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

        public Product GetProduct(int id)
        {
            var queryResult = _entities.Products
                .FirstOrDefault(x => x.ProductID == id);

            Product result = null;
            if (queryResult != null)
            {
                result = new BackendService.Services.Product
                {
                    ProductID = queryResult.ProductID,
                    Name = queryResult.Name,
                };
            }

            return result;
        }

        public void CreateProduct(string name)
        {
            var queryResult = _entities.Products.Add(new AdventureWorks.DbModel.Product()
            {
                Name = name
            });
            _entities.SaveChanges();
        }
    }
}
