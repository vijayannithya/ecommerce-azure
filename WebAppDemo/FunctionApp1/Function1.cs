using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Azure.Messaging.ServiceBus;
namespace FunctionApp1
{
    public class Function1
    {
        public static class SendMessage
        {
            [FunctionName("SenderFunction")]
            public static async Task<IActionResult> Run(
             [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
             ILogger log)
            {
                log.LogInformation("C# HTTP trigger function processed a request.");

                string name = req.Query["name"];
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);
                name = name ?? data?.name;
                // Read the connection string from configurations
                string connectionstring = Environment.GetEnvironmentVariable("SBConnection");

                // Initialize Service bus connection 
                ServiceBusClient serviceBusClient = new ServiceBusClient(connectionstring);

                // Initialize a sender object with queue name
                var sender = serviceBusClient.CreateSender("eservicebusqueue");

                // Create message for service bus 
                ServiceBusMessage message = new ServiceBusMessage(requestBody);

                // Send the Message 
                await sender.SendMessageAsync(message);

                string responseMessage = string.IsNullOrEmpty(name)
                    ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                    : $"Hello, {name}. This HTTP triggered function executed successfully.";

                return new OkObjectResult(responseMessage);
            }

        }
    }
}
