
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Documents.Client;
using System;
using MRNotes;
using System.Linq;
using Microsoft.Azure.Documents.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace mrnotes.CosmosDB
{
    public static class DeleteMRNoteCosmos
    {
        [FunctionName("DeleteMRNoteCosmos")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "MRNotesCosmos/{id}")]HttpRequest req, 
                                        [CosmosDB(
                                            databaseName: "mrnotes",
                                            collectionName: "notes",
                                            ConnectionStringSetting = "CosmosDBConnection"
                                        )] DocumentClient client,
                                        ILogger log,
                                        string id)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            Uri collectionUri = UriFactory.CreateDocumentCollectionUri("mrnotes", "notes");
            var query = client.CreateDocumentQuery<MRNote>(collectionUri).Where(n => n.Id == id).AsDocumentQuery();

            var uri = UriFactory.CreateDocumentUri("mrnotes", "notes", id);

            await client.DeleteDocumentAsync(uri);

            return new OkObjectResult(id);
        }
    }
}
