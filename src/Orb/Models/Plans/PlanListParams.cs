using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using PlanListParamsProperties = Orb.Models.Plans.PlanListParamsProperties;
using System = System;

namespace Orb.Models.Plans;

/// <summary>
/// This endpoint returns a list of all [plans](/core-concepts#plan-and-price) for
/// an account in a list format. The list of plans is ordered starting from the most
/// recently created plan. The response also includes [`pagination_metadata`](/api-reference/pagination),
/// which lets the caller retrieve the next page of results if they exist.
/// </summary>
public sealed record class PlanListParams : Orb::ParamsBase
{
    public System::DateTime? CreatedAtGt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("created_at[gt]", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.QueryProperties["created_at[gt]"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public System::DateTime? CreatedAtGte
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("created_at[gte]", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.QueryProperties["created_at[gte]"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public System::DateTime? CreatedAtLt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("created_at[lt]", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.QueryProperties["created_at[lt]"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public System::DateTime? CreatedAtLte
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("created_at[lte]", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.QueryProperties["created_at[lte]"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

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

    /// <summary>
    /// The plan status to filter to ('active', 'archived', or 'draft').
    /// </summary>
    public PlanListParamsProperties::Status? Status
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("status", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<PlanListParamsProperties::Status?>(element);
        }
        set { this.QueryProperties["status"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/plans")
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
