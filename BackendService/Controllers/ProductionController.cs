using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using System.Web.Http;

using log4net;

using BackendService.Services;

namespace BackendService.Controllers
{

    public class ProductionController : ApiController
    {
        /// <summary>
        /// Uploads a new document to production.
        /// </summary>
        [HttpPost]
        [Route("Production/Document")]
        public async Task Document()
        {
            ILog log = LogManager.GetLogger(typeof(ProductionController));
            try
            {
                log.Info("Uploading file to production");

                if (!Request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }

                string root = HttpContext.Current.Server.MapPath("~/App_Data");
                var provider = new MultipartFormDataStreamProvider(root);
                var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
                foreach (var stream in filesReadToProvider.Contents)
                {
                    var fileBytes = await stream.ReadAsByteArrayAsync();
                    var filePath = stream.Headers.ContentDisposition.FileName.Trim('"','\\');
                    var extension = Path.GetExtension(filePath);
                    if (extension != ".doc" && extension != ".docx")
                    {
                        throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                    }

                    var documentService = new DocumentService();
                    await documentService.SaveAsync(fileBytes, filePath, fileBytes.Length);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
        }
    }
}
