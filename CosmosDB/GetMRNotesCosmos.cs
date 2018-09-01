
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using MRNotes;
using System.Collections.Generic;

namespace mrnotes.CosmosDB
{
    public static class GetMRNotesCosmos
    {
        [FunctionName("GetMRNotesCosmos")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "cosmosmrnotes")]HttpRequest req,
        [CosmosDB(
        databaseName: "mrnotes",
        collectionName: "notes",
        ConnectionStringSetting = "CosmosDBConnection",
        SqlQuery = "SELECT * FROM c")]
        IEnumerable<MRNote> notes,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult(notes);
        }
    }
}
