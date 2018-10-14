using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using log4net;

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
            try
            {
                var service = new ProductService();
                var products = service.GetProducts();

                return products;
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets product information.
        /// </summary>
        /// <param name="id">Product ID.</param>
        /// <returns>Product information.</returns>
        public Product Get(int id)
        {
            try
            {
                var service = new ProductService();
                var product = service.GetProduct(id);

                return product;
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="parameters">New product information.</param>
        /// <returns>Product information.</returns>
        public Product Post([FromBody]ProductCreateParameters parameters)
        {
            try
            {
                var service = new ProductService();
                var newProduct = service.CreateProduct(parameters.Name);
                return newProduct;
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="id">Product ID.</param>
        /// <param name="parameters">Updated product information.</param>
        public void Put(int id, [FromBody]ProductCreateParameters parameters)
        {
            try
            {
                var service = new ProductService();
                service.UpdateProduct(id, parameters.Name);
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes a product.
        /// </summary>
        /// <param name="id">Product ID.</param>
        public void Delete(int id)
        {
            try
            {
                var service = new ProductService();
                service.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        private void LogError(Exception ex)
        {
            ILog log = LogManager.GetLogger(typeof(ProductsController));
            log.Error(ex);
        }
    }
}
