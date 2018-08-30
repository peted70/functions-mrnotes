
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
    public static class DeleteMRNoteFromTable
    {
        private static TableStorageDataSource _dataSource;

        [FunctionName("DeleteMRNoteFromTable")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "MRNotes/{id}")]HttpRequest req,
            [Table("mrnotes", Connection = "AzureWebJobsStorage")] CloudTable notesTable,
            ILogger log,
            string id)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            if (_dataSource == null)
            {
                _dataSource = new TableStorageDataSource(notesTable);
            }

            var note = await _dataSource.DeleteNoteAsync(id);

            return new OkObjectResult(note);
        }
    }
}
