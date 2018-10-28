using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

using Swashbuckle.Application;
using Swashbuckle.Swagger;

namespace BackendService
{
    public class FileUploadOperation : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.operationId == "Production_Document")
            {
                operation.consumes.Add("application/form-data");
                operation.parameters = new[]
                {
                    new Parameter
                    {
                        name = "file",
                        @in = "formData",
                        required = true,
                        type = "file"
                    }
                };
            }
        }
    }
}