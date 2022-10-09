using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace TCC.Common.Extensions;

public static class JsonContentExtension
{
    public static StringContent ToJsonContent(this object obj)
    {
        var json = JsonSerializer.Serialize(obj);
        return new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
    }
}
