using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using AlertCreateForExternalCustomerParamsProperties = Orb.Models.Alerts.AlertCreateForExternalCustomerParamsProperties;
using System = System;

namespace Orb.Models.Alerts;

/// <summary>
///  This endpoint creates a new alert to monitor a customer's credit balance. There
/// are three types of alerts that can be scoped to  customers: `credit_balance_depleted`,
/// `credit_balance_dropped`, and `credit_balance_recovered`. Customers can have
/// a maximum  of one of each type of alert per [credit balance currency](/product-catalog/prepurchase).
/// `credit_balance_dropped` alerts require a list of thresholds to be provided while
/// `credit_balance_depleted`  and `credit_balance_recovered` alerts do not require thresholds.
/// </summary>
public sealed record class AlertCreateForExternalCustomerParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string ExternalCustomerID;

    /// <summary>
    /// The case sensitive currency or custom pricing unit to use for this alert.
    /// </summary>
    public required string Currency
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("currency", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "currency",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("currency");
        }
        set { this.BodyProperties["currency"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The type of alert to create. This must be a valid alert type.
    /// </summary>
    public required AlertCreateForExternalCustomerParamsProperties::Type Type
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("type", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<AlertCreateForExternalCustomerParamsProperties::Type>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("type");
        }
        set { this.BodyProperties["type"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The thresholds that define the values at which the alert will be triggered.
    /// </summary>
    public List<Threshold>? Thresholds
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("thresholds", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Threshold>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["thresholds"] = JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/alerts/external_customer_id/{0}", this.ExternalCustomerID)
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
