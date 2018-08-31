
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;

namespace MRNotes
{
 
    public static class GetMRNotesFromTable
    {
        private static TableStorageDataSource _dataSource;

        [FunctionName("GetMRNotesFromTable")]
        public async static Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "tableMRNotes")]HttpRequest req,
            [Table("mrnotes", Connection = "AzureWebJobsStorage")] CloudTable notesTable,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            if (_dataSource == null)
            {
                _dataSource = new TableStorageDataSource(notesTable);
            }

            var notes = await _dataSource.GetNotesAsync();

            return new OkObjectResult(notes);
        }
    }
}
