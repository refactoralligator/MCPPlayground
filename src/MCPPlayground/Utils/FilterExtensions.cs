using System.Reflection;
using System.Web;
using MCPPlayground.Utils;

namespace MCPPlayground.Extensions;

public static class FilterExtensions
{
    public static string ToQueryString<T>(this T filter)
    {
        var query = HttpUtility.ParseQueryString(string.Empty);

        foreach(PropertyInfo prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            var value = prop.GetValue(filter);

            if (value is not null)
            {
                var attribute = prop.GetCustomAttribute<QueryNameAttribute>();
                var key = attribute?.Name ?? prop.Name;

                query[key] = value.ToString();
            }
        }

        return query.ToString()!;
    }
}
