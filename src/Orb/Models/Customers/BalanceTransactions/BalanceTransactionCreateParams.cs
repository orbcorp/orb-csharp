using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using BalanceTransactionCreateParamsProperties = Orb.Models.Customers.BalanceTransactions.BalanceTransactionCreateParamsProperties;
using System = System;

namespace Orb.Models.Customers.BalanceTransactions;

/// <summary>
/// Creates an immutable balance transaction that updates the customer's balance and
/// returns back the newly created transaction.
/// </summary>
public sealed record class BalanceTransactionCreateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string CustomerID;

    public required string Amount
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("amount", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "amount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("amount");
        }
        set { this.BodyProperties["amount"] = JsonSerializer.SerializeToElement(value); }
    }

    public required BalanceTransactionCreateParamsProperties::Type Type
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("type", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<BalanceTransactionCreateParamsProperties::Type>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("type");
        }
        set { this.BodyProperties["type"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An optional description that can be specified around this entry.
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["description"] = JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/customers/{0}/balance_transactions", this.CustomerID)
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
