using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;

namespace Orb.Models.Subscriptions;

/// <summary>
/// This endpoint returns a [paginated](/api-reference/pagination) list of all plans
/// associated with a subscription along with their start and end dates. This list
/// contains the subscription's initial plan along with past and future plan changes.
/// </summary>
public sealed record class SubscriptionFetchScheduleParams : Orb::ParamsBase
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
            if (!this.QueryProperties.TryGetValue("cursor", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.QueryProperties["cursor"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The number of items to fetch. Defaults to 20.
    /// </summary>
    public long? Limit
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("limit", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<long?>(element);
        }
        set { this.QueryProperties["limit"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public System::DateTime? StartDateGt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("start_date[gt]", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.QueryProperties["start_date[gt]"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public System::DateTime? StartDateGte
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("start_date[gte]", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.QueryProperties["start_date[gte]"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public System::DateTime? StartDateLt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("start_date[lt]", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.QueryProperties["start_date[lt]"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public System::DateTime? StartDateLte
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("start_date[lte]", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.QueryProperties["start_date[lte]"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/schedule", this.SubscriptionID)
        )
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
