using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace BackendService.Services
{
    public class DocumentService
    {
        private readonly Uri _blobUrl = new Uri("https://adventureworksrg1diag866.blob.core.windows.net/adventure-works-documents-blob");
        private CloudBlobClient _blobClient;

        public DocumentService()
        {
            var creds = new StorageCredentials(
                "adventureworksrg1diag866",
                "mvq1tXXtIxyA46z8xOHGrYIGz1uN2seB/jwgdoOwMPpPV8VyGSL0S92R1GsGTwsZx8JB7+SEqAumvmBPwEzJDw==");
            _blobClient = new CloudBlobClient(_blobUrl, creds);
        }

        public async Task SaveAsync(Stream document)
        {
            var container = _blobClient.GetContainerReference("adventure-works-documents-blob");
            var blob = container.GetBlockBlobReference(Guid.NewGuid().ToString());
            await blob.UploadFromStreamAsync(document);
        }
    }
}
