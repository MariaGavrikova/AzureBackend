using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BackendService.Services;

namespace BackendService.Controllers
{
    public class ProductsController : ApiController
    {
        /// <summary>
        /// Gets a product list.
        /// </summary>
        /// <returns>A list of available products.</returns>
        public IEnumerable<Product> Get()
        {
            var service = new ProductService();
            var products = service.GetProducts();

            return products;
        }

        /// <summary>
        /// Gets product information.
        /// </summary>
        /// <param name="id">Product ID.</param>
        /// <returns>Product information.</returns>
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="value">Product information.</param>
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="id">Product ID.</param>
        /// <param name="value">Updated product information.</param>
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// Deletes a product.
        /// </summary>
        /// <param name="id">Product ID.</param>
        public void Delete(int id)
        {
        }
    }
}
