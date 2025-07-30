using AlertCreateForCustomerParamsProperties = Orb.Models.Alerts.AlertCreateForCustomerParamsProperties;
using Generic = System.Collections.Generic;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;
using Text = System.Text;

namespace Orb.Models.Alerts;

/// <summary>
///  This endpoint creates a new alert to monitor a customer's credit balance. There
/// are three types of alerts that can be scoped to  customers: `credit_balance_depleted`,
/// `credit_balance_dropped`, and `credit_balance_recovered`. Customers can have
/// a maximum  of one of each type of alert per [credit balance currency](/product-catalog/prepurchase).
/// `credit_balance_dropped` alerts require a list of thresholds to be provided while
/// `credit_balance_depleted`  and `credit_balance_recovered` alerts do not require thresholds.
/// </summary>
public sealed record class AlertCreateForCustomerParams : Orb::ParamsBase
{
    public Generic::Dictionary<string, Json::JsonElement> BodyProperties { get; set; } = [];

    public required string CustomerID;

    /// <summary>
    /// The case sensitive currency or custom pricing unit to use for this alert.
    /// </summary>
    public required string Currency
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("currency", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "currency",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("currency");
        }
        set { this.BodyProperties["currency"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The type of alert to create. This must be a valid alert type.
    /// </summary>
    public required AlertCreateForCustomerParamsProperties::Type Type
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return Json::JsonSerializer.Deserialize<AlertCreateForCustomerParamsProperties::Type>(
                    element
                ) ?? throw new System::ArgumentNullException("type");
        }
        set { this.BodyProperties["type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The thresholds that define the values at which the alert will be triggered.
    /// </summary>
    public Generic::List<Threshold>? Thresholds
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("thresholds", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<Threshold>?>(element);
        }
        set { this.BodyProperties["thresholds"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/alerts/customer_id/{0}", this.CustomerID)
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
