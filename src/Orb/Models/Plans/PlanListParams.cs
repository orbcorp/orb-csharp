using System;
using System.Net.Http;
using System.Text.Json;
using PlanListParamsProperties = Orb.Models.Plans.PlanListParamsProperties;

namespace Orb.Models.Plans;

/// <summary>
/// This endpoint returns a list of all [plans](/core-concepts#plan-and-price) for
/// an account in a list format. The list of plans is ordered starting from the most
/// recently created plan. The response also includes [`pagination_metadata`](/api-reference/pagination),
/// which lets the caller retrieve the next page of results if they exist.
/// </summary>
public sealed record class PlanListParams : ParamsBase
{
    public DateTime? CreatedAtGt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("created_at[gt]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element);
        }
        set { this.QueryProperties["created_at[gt]"] = JsonSerializer.SerializeToElement(value); }
    }

    public DateTime? CreatedAtGte
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("created_at[gte]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element);
        }
        set { this.QueryProperties["created_at[gte]"] = JsonSerializer.SerializeToElement(value); }
    }

    public DateTime? CreatedAtLt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("created_at[lt]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element);
        }
        set { this.QueryProperties["created_at[lt]"] = JsonSerializer.SerializeToElement(value); }
    }

    public DateTime? CreatedAtLte
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("created_at[lte]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element);
        }
        set { this.QueryProperties["created_at[lte]"] = JsonSerializer.SerializeToElement(value); }
    }

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

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.QueryProperties["cursor"] = JsonSerializer.SerializeToElement(value); }
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

            return JsonSerializer.Deserialize<long?>(element);
        }
        set { this.QueryProperties["limit"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The plan status to filter to ('active', 'archived', or 'draft').
    /// </summary>
    public PlanListParamsProperties::Status? Status
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<PlanListParamsProperties::Status?>(element);
        }
        set { this.QueryProperties["status"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/plans")
        {
            Query = this.QueryString(client),
        }.Uri;
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
