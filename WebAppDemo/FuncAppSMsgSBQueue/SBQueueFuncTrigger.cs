using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FuncAppSMsgSBQueue
{
    public class SBQueueFuncTrigger
    {
        private readonly ILogger<SBQueueFuncTrigger> _logger;

        public SBQueueFuncTrigger(ILogger<SBQueueFuncTrigger> logger)
        {
            _logger = logger;
        }

        [Function(nameof(SBQueueFuncTrigger))]
        public async Task Run(
            [ServiceBusTrigger("myqueue", Connection = "")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {
            _logger.LogInformation("Message ID: {id}", message.MessageId);
            _logger.LogInformation("Message Body: {body}", message.Body);
            _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);

            // Complete the message
            await messageActions.CompleteMessageAsync(message);
        }
    }
}
