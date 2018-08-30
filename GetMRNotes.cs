
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace MRNotes
{
    public static class GetMRNotes
    {
        [FunctionName("GetMRNotes")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "MRNotes")]HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult(DataSource.Instance().GetNotes());
        }
    }
}
