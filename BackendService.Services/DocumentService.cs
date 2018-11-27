using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace BackendService.Services
{
    public class DocumentService
    {
        private readonly Uri _blobUrl = new Uri($"https://{StorageAccount}.blob.core.windows.net/{Blob}");
        //private const string StorageAccount = "adventureworksrg1diag866";
        private const string StorageAccount = "adventureworksrg1diag867";
        //private const string AccessKey = "mvq1tXXtIxyA46z8xOHGrYIGz1uN2seB/jwgdoOwMPpPV8VyGSL0S92R1GsGTwsZx8JB7+SEqAumvmBPwEzJDw==";
        private const string AccessKey = "l9nckJx7Ki6+DihJMAr3Bp85EB8OHohxPet8W9gmt/xdczv+pQV35WCV1qB134aMNAeWIFHbzMk9Eh7901xbfQ==";
        private readonly string StorageConnectionString = 
            $"DefaultEndpointsProtocol=https;AccountName={StorageAccount};AccountKey={AccessKey};EndpointSuffix=core.windows.net";
        private const string Blob = "adventure-works-documents-blob";
        private const string Queue = "adventure-works-documents-queue";
        private CloudBlobClient _blobClient;
        private CloudQueueClient _queueClient;

        public DocumentService()
        {
            var creds = new StorageCredentials(StorageAccount, AccessKey);
            _blobClient = new CloudBlobClient(_blobUrl, creds);
            var storageAccount = CloudStorageAccount.Parse(StorageConnectionString);
            _queueClient = storageAccount.CreateCloudQueueClient();
        }

        public async Task SaveAsync(byte[] document, string fileName, long size)
        {
            var fileId = Guid.NewGuid().ToString();
            var container = _blobClient.GetContainerReference(Blob);
            var blob = container.GetBlockBlobReference(fileId);
            await blob.UploadFromByteArrayAsync(document, 0, document.Length);

            var queue = _queueClient.GetQueueReference(Queue);
            queue.CreateIfNotExists();

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"File name: {fileName}");
            stringBuilder.AppendLine($"Azure Blob file name: {fileId}");
            stringBuilder.AppendLine($"Size: {size/1024} KB");
            var message = new CloudQueueMessage(stringBuilder.ToString());
            await queue.AddMessageAsync(message);
        }
    }
}
