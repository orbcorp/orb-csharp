using Orb = Orb;
using System = System;

namespace Orb.Tests;

public class TestBase
{
    protected Orb::IOrbClient client;

    public TestBase()
    {
        client = new Orb::OrbClient()
        {
            BaseUrl = new System::Uri(
                System::Environment.GetEnvironmentVariable("TEST_API_BASE_URL")
                    ?? "http://localhost:4010"
            ),
            APIKey = "My API Key",
        };
    }
}
