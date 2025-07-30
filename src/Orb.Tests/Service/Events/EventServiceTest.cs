using Json = System.Text.Json;
using System = System;
using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;

namespace Orb.Tests.Service.Events;

public class EventServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task Update_Works()
    {
        var event1 = await this.client.Events.Update(
            new()
            {
                EventID = "event_id",
                EventName = "event_name",
                Properties = new() { { "foo", Json::JsonSerializer.SerializeToElement("bar") } },
                Timestamp = System::DateTime.Parse("2020-12-09T16:09:53Z"),
                CustomerID = "customer_id",
                ExternalCustomerID = "external_customer_id",
            }
        );
        event1.Validate();
    }

    [Fact]
    public async Tasks::Task Deprecate_Works()
    {
        var response = await this.client.Events.Deprecate(new() { EventID = "event_id" });
        response.Validate();
    }

    [Fact]
    public async Tasks::Task Ingest_Works()
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
                        Properties1 = new()
                        {
                            { "foo", Json::JsonSerializer.SerializeToElement("bar") },
                        },
                        Timestamp = System::DateTime.Parse("2020-12-09T16:09:53Z"),
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
    public async Tasks::Task Search_Works()
    {
        var response = await this.client.Events.Search(
            new()
            {
                EventIDs = ["string"],
                TimeframeEnd = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                TimeframeStart = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
            }
        );
        response.Validate();
    }
}
