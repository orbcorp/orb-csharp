using BalanceTransactionCreateParamsProperties = Orb.Models.Customers.BalanceTransactions.BalanceTransactionCreateParamsProperties;
using Generic = System.Collections.Generic;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;
using Text = System.Text;

namespace Orb.Models.Customers.BalanceTransactions;

/// <summary>
/// Creates an immutable balance transaction that updates the customer's balance and
/// returns back the newly created transaction.
/// </summary>
public sealed record class BalanceTransactionCreateParams : Orb::ParamsBase
{
    public Generic::Dictionary<string, Json::JsonElement> BodyProperties { get; set; } = [];

    public required string CustomerID;

    public required string Amount
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("amount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "amount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("amount");
        }
        set { this.BodyProperties["amount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required BalanceTransactionCreateParamsProperties::Type Type
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return Json::JsonSerializer.Deserialize<BalanceTransactionCreateParamsProperties::Type>(
                    element
                ) ?? throw new System::ArgumentNullException("type");
        }
        set { this.BodyProperties["type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An optional description that can be specified around this entry.
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("description", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.BodyProperties["description"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/customers/{0}/balance_transactions", this.CustomerID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public Http::StringContent BodyContent()
    {
        return new(
            Json::JsonSerializer.Serialize(this.BodyProperties),
            Text::Encoding.UTF8,
            "application/json"
        );
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
