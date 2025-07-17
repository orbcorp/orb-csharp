using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;

namespace Orb.Models.Invoices;

/// <summary>
/// This endpoint can be used to fetch the upcoming [invoice](/core-concepts#invoice)
/// for the current billing period given a subscription.
/// </summary>
public sealed record class InvoiceFetchUpcomingParams : Orb::ParamsBase
{
    public required string SubscriptionID
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("subscription_id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "subscription_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("subscription_id");
        }
        set
        {
            this.QueryProperties["subscription_id"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/invoices/upcoming")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public void AddHeadersToRequest(Http::HttpRequestMessage request, Orb::IOrbClient client)
    {
        Orb::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            Orb::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
