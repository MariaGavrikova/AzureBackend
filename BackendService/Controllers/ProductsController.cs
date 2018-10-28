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
            ILog log = LogManager.GetLogger(typeof(ProductsController));
            try
            {
                log.Info("Requested product list");

                var service = new ProductService();
                var products = service.GetProducts();
                
                return products;
            }
            catch (Exception ex)
            {
                log.Error(ex);
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
            ILog log = LogManager.GetLogger(typeof(ProductsController));
            try
            {
                var service = new ProductService();
                var product = service.GetProduct(id);

                return product;
            }
            catch (Exception ex)
            {
                log.Error(ex);
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
            ILog log = LogManager.GetLogger(typeof(ProductsController));
            try
            {
                var service = new ProductService();
                var newProduct = service.CreateProduct(parameters.Name);
                return newProduct;
            }
            catch (Exception ex)
            {
                log.Error(ex);
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
            ILog log = LogManager.GetLogger(typeof(ProductsController));
            try
            {
                var service = new ProductService();
                service.UpdateProduct(id, parameters.Name);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes a product.
        /// </summary>
        /// <param name="id">Product ID.</param>
        public void Delete(int id)
        {
            ILog log = LogManager.GetLogger(typeof(ProductsController));
            try
            {
                var service = new ProductService();
                service.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
        }
    }
}
