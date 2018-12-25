using System;
using System.Collections.Generic;
using System.Linq;

namespace BackendService.Services
{
    public class ProductService
    {
        private readonly AdventureWorks.DbModel.Entities _entities;

        public ProductService(string connectionString)
        {
            _entities = new AdventureWorks.DbModel.Entities(connectionString);
        }

        public ICollection<Product> GetProducts()
        {
            var query = from d in _entities.Products
                        select new BackendService.Services.Product
                        {
                            ProductID = d.ProductID,
                            Name = d.Name,
                        };

            return query.Take(10).ToArray();
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

            var rowGuid = Guid.NewGuid();
            var queryResult = _entities.Products.Add(new AdventureWorks.DbModel.Product()
            {
                Name = name,
                ProductNumber = rowGuid.GetHashCode().ToString(),
                SellStartDate = DateTime.UtcNow.Date,
                ModifiedDate = DateTime.UtcNow.Date,
                SafetyStockLevel = 1,
                ReorderPoint = 1,
                rowguid = rowGuid
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

        public void UpdateProduct(int id, string name)
        {
            var queryResult = _entities.Products
                .FirstOrDefault(x => x.ProductID == id);
            if (queryResult == null)
            {
                throw new ApiException($"A product with ID={id} is not found");
            }

            queryResult.Name = name;
            _entities.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var queryResult = _entities.Products
                .FirstOrDefault(x => x.ProductID == id);
            if (queryResult == null)
            {
                throw new ApiException($"A product with ID={id} is not found");
            }

            _entities.Products.Remove(queryResult);
            _entities.SaveChanges();
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
