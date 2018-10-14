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
                        select Map(d);

            return query.ToArray();
        }

        public Product GetProduct(int id)
        {
            var queryResult = _entities.Products
                .FirstOrDefault(x => x.ProductID == id);

            Product result = null;
            if (queryResult != null)
            {
                result = Map(queryResult);
            }

            return result;
        }

        public Product CreateProduct(string name)
        {
            Product result = null;

            var queryResult = _entities.Products.Add(new AdventureWorks.DbModel.Product()
            {
                Name = name,
                ProductNumber = Guid.NewGuid().GetHashCode().ToString(),
                SellStartDate = DateTime.UtcNow.Date,
                ModifiedDate = DateTime.UtcNow.Date,
                SafetyStockLevel = 1,
                ReorderPoint = 1
            });
            _entities.SaveChanges();

            var product = _entities.Products
                .FirstOrDefault(x => x.Name == name);
            if (product != null)
            {
                result = Map(product);
            }

            return result;
        }

        private Product Map(AdventureWorks.DbModel.Product d)
        {
            return new BackendService.Services.Product
            {
                ProductID = d.ProductID,
                Name = d.Name,
            };
        }
    }
}
