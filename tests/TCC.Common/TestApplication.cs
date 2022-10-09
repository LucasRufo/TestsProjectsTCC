using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace TCC.Common;

public class TestApplication : WebApplicationFactory<Program>
{
    private readonly string _environment;

    public TestApplication(string environment = "Development")
    {
        _environment = environment;
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.UseEnvironment(_environment);

        return base.CreateHost(builder);
    }
}