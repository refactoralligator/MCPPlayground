using System.ComponentModel;
using ModelContextProtocol.Server;

namespace MCPPlayground;

[McpServerToolType]
public static class EchoTool
{
    [McpServerTool, Description("Message to client")]
    public static string Echo(string message) => $"Yo from c#: {message}";
}
