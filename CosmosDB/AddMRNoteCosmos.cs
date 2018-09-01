
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using MRNotes;
using Microsoft.Azure.Documents.Client;
using System.Threading.Tasks;

namespace mrnotes.CosmosDB
{
    public static class AddMRNoteCosmos
    {
        [FunctionName("AddMRNoteCosmos")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "MRNotesCosmos")]HttpRequest req,
        [CosmosDB(
            databaseName: "mrnotes",
            collectionName: "notes",
            ConnectionStringSetting = "CosmosDBConnection"
         )] IAsyncCollector<MRNote> collector,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = new StreamReader(req.Body).ReadToEnd();
            var data = JsonConvert.DeserializeObject<MRNote>(requestBody, new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            });

            await collector.AddAsync(data);
            return new OkObjectResult(data);
        }
    }
}
