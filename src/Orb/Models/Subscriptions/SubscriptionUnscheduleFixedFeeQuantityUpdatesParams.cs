using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System = System;

namespace Orb.Models.Subscriptions;

/// <summary>
/// This endpoint can be used to clear scheduled updates to the quantity for a fixed fee.
///
/// If there are no updates scheduled, a request validation error will be returned
/// with a 400 status code.
/// </summary>
public sealed record class SubscriptionUnscheduleFixedFeeQuantityUpdatesParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string SubscriptionID;

    /// <summary>
    /// Price for which the updates should be cleared. Must be a fixed fee.
    /// </summary>
    public required string PriceID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("price_id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "price_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("price_id");
        }
        set { this.BodyProperties["price_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/subscriptions/{0}/unschedule_fixed_fee_quantity_updates",
                    this.SubscriptionID
                )
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public StringContent BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
