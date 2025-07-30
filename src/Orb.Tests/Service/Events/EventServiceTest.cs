using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Orb.Tests.Service.Events;

public class EventServiceTest : TestBase
{
    [Fact]
    public async Task Update_Works()
    {
        var event1 = await this.client.Events.Update(
            new()
            {
                EventID = "event_id",
                EventName = "event_name",
                Properties = new() { { "foo", JsonSerializer.SerializeToElement("bar") } },
                Timestamp = DateTime.Parse("2020-12-09T16:09:53Z"),
                CustomerID = "customer_id",
                ExternalCustomerID = "external_customer_id",
            }
        );
        event1.Validate();
    }

    [Fact]
    public async Task Deprecate_Works()
    {
        var response = await this.client.Events.Deprecate(new() { EventID = "event_id" });
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
                        Properties1 = new() { { "foo", JsonSerializer.SerializeToElement("bar") } },
                        Timestamp = DateTime.Parse("2020-12-09T16:09:53Z"),
                        CustomerID = "customer_id",
                        ExternalCustomerID = "external_customer_id",
                    },
                ],
                BackfillID = "backfill_id",
                Debug = true,
            }
        );
        response.Validate();
    }

    [Fact]
    public async Task Search_Works()
    {
        var response = await this.client.Events.Search(
            new()
            {
                EventIDs = ["string"],
                TimeframeEnd = DateTime.Parse("2019-12-27T18:11:19.117Z"),
                TimeframeStart = DateTime.Parse("2019-12-27T18:11:19.117Z"),
            }
        );
        response.Validate();
    }
}
