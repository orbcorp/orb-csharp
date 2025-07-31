using System.Net.Http;
using System.Text.Json;
using System = System;

namespace Orb.Models.Customers;

/// <summary>
/// This endpoint returns a list of all customers for an account. The list of customers
/// is ordered starting from the most recently created customer. This endpoint follows
/// Orb's [standardized pagination format](/api-reference/pagination).
///
/// See [Customer](/core-concepts##customer) for an overview of the customer model.
/// </summary>
public sealed record class CustomerListParams : ParamsBase
{
    public System::DateTime? CreatedAtGt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("created_at[gt]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.QueryProperties["created_at[gt]"] = JsonSerializer.SerializeToElement(value); }
    }

    public System::DateTime? CreatedAtGte
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("created_at[gte]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.QueryProperties["created_at[gte]"] = JsonSerializer.SerializeToElement(value); }
    }

    public System::DateTime? CreatedAtLt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("created_at[lt]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.QueryProperties["created_at[lt]"] = JsonSerializer.SerializeToElement(value); }
    }

    public System::DateTime? CreatedAtLte
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("created_at[lte]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
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

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
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

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set { this.QueryProperties["limit"] = JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/customers")
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
