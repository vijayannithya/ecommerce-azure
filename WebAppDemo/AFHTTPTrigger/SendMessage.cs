using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus;
//using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using Microsoft.Azure.WebJobs;
using System.Text;


namespace AFHTTPTrigger
{
    public static class SendMessage
    {

        [FunctionName("SendMessage")]
        [return: ServiceBus("eservicebusqueue", Connection = "SBConnection")]
        public static async Task<string> Run(
            [Microsoft.Azure.Functions.Worker.HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("SendMessage function requested");
            string body = string.Empty;
            using (var reader = new StreamReader(req.Body, Encoding.UTF8))
            {
                body = await reader.ReadToEndAsync();
                log.LogInformation($"Message body : {body}");
            }
            log.LogInformation($"SendMessage processed.");
            return body;
        }


    }
}
