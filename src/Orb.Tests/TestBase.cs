using System;
using Orb;

namespace Orb.Tests;

public class TestBase
{
    protected IOrbClient client;

    public TestBase()
    {
        client = new OrbClient()
        {
            BaseUrl = new Uri(
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010"
            ),
            APIKey = "My API Key",
        };
    }
}
