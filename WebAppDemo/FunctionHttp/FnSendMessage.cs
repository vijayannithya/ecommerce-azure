using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus;
using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;
using System.Text;
using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace FunctionHttp
{
    public static class FnSendMessage
    {

        [Function("FnSendMessageToQueue")]
        public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req)
        {
            string name = req.Query["ProductName"];

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully."
                : $"Hi, The Product {name} has been added to Product Catalog. Happy Shopping!!";

            string conn = Environment.GetEnvironmentVariable("ServiceBusConnection");

            ServiceBusClient client = new ServiceBusClient(conn);

            var queueOrTopicName = "eservicebusqueue";

            var queueSender = client.CreateSender(queueOrTopicName);
            await queueSender.SendMessageAsync(new ServiceBusMessage(responseMessage));
            Console.WriteLine("Sucessfully Completed");

            return new OkObjectResult(responseMessage);

        }

    }
}
