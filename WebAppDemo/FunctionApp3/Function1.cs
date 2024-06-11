using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs;

namespace FunctionApp3
{
    public static class Function1
    {
        [Function("BindingToSender")]
        public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "GET", "POST", Route = null)] HttpRequest req)
        {
            string requestMsg = string.IsNullOrEmpty(req.Query["ProductName"]) ? "" : req.Query["ProductName"];

            requestMsg = "The Product " + requestMsg + " have been added to the Catalog.Enjoy Shopping!!";
                string conn = Environment.GetEnvironmentVariable("ServiceBusConnection");
            ServiceBusClient client = new ServiceBusClient(conn);

            ServiceBusSender sender = client.CreateSender("eservicebusqueue");
            await sender.SendMessageAsync(new ServiceBusMessage(requestMsg));


            return new OkObjectResult(requestMsg);
        }
    }
}
