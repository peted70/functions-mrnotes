
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
    public static class AddMRNote
    {
        [FunctionName("AddMRNote")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "MRNotes")]HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = new StreamReader(req.Body).ReadToEnd();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            DataSource.Notes.Add(data);

            return new OkObjectResult(data);
        }
    }
}
