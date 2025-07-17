using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;

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
public sealed record class CreditListParams : Orb::ParamsBase
{
    public required string CustomerID;

    /// <summary>
    /// The ledger currency or custom pricing unit to use.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("currency", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.QueryProperties["currency"] = Json::JsonSerializer.SerializeToElement(value); }
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
    /// If set to True, all expired and depleted blocks, as well as active block will
    /// be returned.
    /// </summary>
    public bool? IncludeAllBlocks
    {
        get
        {
            if (
                !this.QueryProperties.TryGetValue(
                    "include_all_blocks",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<bool?>(element);
        }
        set
        {
            this.QueryProperties["include_all_blocks"] = Json::JsonSerializer.SerializeToElement(
                value
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
            if (!this.QueryProperties.TryGetValue("limit", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<long?>(element);
        }
        set { this.QueryProperties["limit"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/customers/{0}/credits", this.CustomerID)
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
