
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace MRNotes
{
    public static class DeleteMRNote
    {
        [FunctionName("DeleteMRNote")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "MRNotes/{id}")]HttpRequest req, ILogger log,
            string id)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var deleted = await DataSource.Instance().DeleteNoteAsync(id);

            if (deleted != null)
            {
                return new OkObjectResult(deleted);
            }

            return new NotFoundObjectResult(id);
        }
    }
}
