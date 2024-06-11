using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FuncAppMsgSBQueue
{
    public class HttpFuncTrigger
    {
        private readonly ILogger<HttpFuncTrigger> _logger;

        public HttpFuncTrigger(ILogger<HttpFuncTrigger> logger)
        {
            _logger = logger;
        }

        [Function("Function")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
