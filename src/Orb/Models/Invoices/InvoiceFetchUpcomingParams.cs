using System;
using System.Net.Http;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.Invoices;

/// <summary>
/// This endpoint can be used to fetch the upcoming [invoice](/core-concepts#invoice)
/// for the current billing period given a subscription.
/// </summary>
public sealed record class InvoiceFetchUpcomingParams : ParamsBase
{
    public required string SubscriptionID
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("subscription_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'subscription_id' cannot be null",
                    new ArgumentOutOfRangeException("subscription_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'subscription_id' cannot be null",
                    new ArgumentNullException("subscription_id")
                );
        }
        set
        {
            this.QueryProperties["subscription_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/invoices/upcoming")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
