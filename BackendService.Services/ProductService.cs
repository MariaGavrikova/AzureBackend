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
        private readonly DbModel.Entities _entities = new DbModel.Entities();

        public ProductService()
        {
        }

        public ICollection<Product> GetProducts()
        {
            var query = from d in _entities.Products
                        select new Department
                        {
                            Id = d.DepartmentID,
                            Name = d.Name,
                            GroupName = d.GroupName
                        };

            return query.ToArray();
        }
    }
}
