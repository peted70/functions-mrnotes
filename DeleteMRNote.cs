
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace MRNotes
{
    public static class DeleteMRNote
    {
        [FunctionName("DeleteMRNote")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "MRNotes/{id}")]HttpRequest req, ILogger log,
            string id)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var item = DataSource.Notes.SingleOrDefault(x => x.Id == id);

            if (item != null)
            {
                DataSource.Notes.Remove(item);
                return new OkObjectResult(item);
            }

            return new NotFoundObjectResult(id);
        }
    }
}
