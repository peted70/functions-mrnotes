
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace MRNotes
{
    public static class AddMRNoteToTable
    {
        private static TableStorageDataSource _dataSource;

        [FunctionName("AddMRNoteToTable")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "tableMRNotes")]HttpRequest req,
            [Table("mrnotes", Connection = "AzureWebJobsStorage")] CloudTable notesTable,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            if (_dataSource == null)
            {
                _dataSource = new TableStorageDataSource(notesTable);
            }

            string requestBody = new StreamReader(req.Body).ReadToEnd();
            var data = JsonConvert.DeserializeObject<MRNote>(requestBody, new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            });

            await _dataSource.AddNoteAsync(data);
            return new OkObjectResult(data);
        }
    }
}
