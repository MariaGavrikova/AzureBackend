using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace FileFunctions
{
    public static class QueueFileFunction
    {
        [FunctionName("QueueFileFunction")]
        public static void Run(
            [QueueTrigger("queue-file", Connection = "StorageAccountConnectionString")]
            string queueItem, 
            TraceWriter log)
        {
            log.Info($"C# Queue trigger function processed: {queueItem}");
        }
    }
}
