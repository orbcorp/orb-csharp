using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Orb.Tests.Services;

public class EventServiceTest : TestBase
{
    [Fact]
    public async Task Update_Works()
    {
        var event1 = await this.client.Events.Update(
            "event_id",
            new()
            {
                EventName = "event_name",
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),
            },
            TestContext.Current.CancellationToken
        );
        event1.Validate();
    }

    [Fact]
    public async Task Deprecate_Works()
    {
        var response = await this.client.Events.Deprecate(
            "event_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task Ingest_Works()
    {
        var response = await this.client.Events.Ingest(
            new()
            {
                Events =
                [
                    new()
                    {
                        EventName = "event_name",
                        IdempotencyKey = "idempotency_key",
                        Properties = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Timestamp = DateTimeOffset.Parse("2020-12-09T16:09:53Z"),
                        CustomerID = "customer_id",
                        ExternalCustomerID = "external_customer_id",
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task Search_Works()
    {
        var response = await this.client.Events.Search(
            new() { EventIDs = ["string"] },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
