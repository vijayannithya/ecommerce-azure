using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.Options;
using System.Data.Common;
using System.Reflection;
using Swashbuckle.AspNetCore;
using Microsoft.AspNetCore.Cors.Infrastructure;



var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

    })
    .Build();

host.Run();
