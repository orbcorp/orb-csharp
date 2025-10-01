using System;
using System.Net.Http;
using System.Text.Json;
using Orb.Core;

namespace Orb.Models.Subscriptions;

/// <summary>
/// This endpoint returns a [paginated](/api-reference/pagination) list of all plans
/// associated with a subscription along with their start and end dates. This list
/// contains the subscription's initial plan along with past and future plan changes.
/// </summary>
public sealed record class SubscriptionFetchScheduleParams : ParamsBase
{
    public required string SubscriptionID;

    /// <summary>
    /// Cursor for pagination. This can be populated by the `next_cursor` value returned
    /// from the initial request.
    /// </summary>
    public string? Cursor
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("cursor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["cursor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of items to fetch. Defaults to 20.
    /// </summary>
    public long? Limit
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("limit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["limit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public DateTime? StartDateGt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("start_date[gt]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["start_date[gt]"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public DateTime? StartDateGte
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("start_date[gte]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["start_date[gte]"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public DateTime? StartDateLt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("start_date[lt]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["start_date[lt]"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public DateTime? StartDateLte
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("start_date[lte]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["start_date[lte]"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/schedule", this.SubscriptionID)
        )
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
