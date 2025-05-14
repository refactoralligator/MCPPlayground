using MCPPlayground;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// Based on https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/#getting-started-building-an-mcp-server

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();

builder.Services.AddHttpClient();
builder.Services.AddSingleton<BreweriesService>();

await builder.Build().RunAsync();