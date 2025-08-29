using System;
using System.Net.Http;
using System.Text.Json;

namespace Orb.Models.Customers.Credits;

/// <summary>
/// Returns a paginated list of unexpired, non-zero credit blocks for a customer.
///
/// If `include_all_blocks` is set to `true`, all credit blocks (including expired
/// and depleted blocks) will be included in the response.
///
/// Note that `currency` defaults to credits if not specified. To use a real world
/// currency, set `currency` to an ISO 4217 string.
/// </summary>
public sealed record class CreditListByExternalIDParams : ParamsBase
{
    public required string ExternalCustomerID;

    /// <summary>
    /// The ledger currency or custom pricing unit to use.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
    /// If set to True, all expired and depleted blocks, as well as active block will
    /// be returned.
    /// </summary>
    public bool? IncludeAllBlocks
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("include_all_blocks", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["include_all_blocks"] = JsonSerializer.SerializeToElement(
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

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/customers/external_customer_id/{0}/credits",
                    this.ExternalCustomerID
                )
        )
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
