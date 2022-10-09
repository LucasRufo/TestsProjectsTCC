using TCC.Common;

namespace TCC.XUnit.Integration;

public abstract class BaseIntegrationTests : IDisposable
{
    protected HttpClient _client;

    protected BaseIntegrationTests()
    {
        var application = new TestApplication();
        _client = application.CreateClient();
    }

    public void Dispose() => _client.Dispose();
}
