using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using AlertCreateForSubscriptionParamsProperties = Orb.Models.Alerts.AlertCreateForSubscriptionParamsProperties;

namespace Orb.Models.Alerts;

/// <summary>
/// This endpoint is used to create alerts at the subscription level.
///
/// Subscription level alerts can be one of two types: `usage_exceeded` or `cost_exceeded`.
/// A `usage_exceeded` alert is scoped to a particular metric and is triggered when
/// the usage of that metric exceeds predefined thresholds during the current billing
/// cycle. A `cost_exceeded` alert is triggered when the total amount due during
/// the current billing cycle surpasses predefined thresholds. `cost_exceeded` alerts
/// do not include burndown of pre-purchase credits. Each subscription can have one
/// `cost_exceeded` alert and one `usage_exceeded` alert per metric that is a part
/// of the subscription. Alerts are triggered based on usage or cost conditions met
/// during the current billing cycle.
/// </summary>
public sealed record class AlertCreateForSubscriptionParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string SubscriptionID;

    /// <summary>
    /// The thresholds that define the values at which the alert will be triggered.
    /// </summary>
    public required List<Threshold> Thresholds
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("thresholds", out JsonElement element))
                throw new ArgumentOutOfRangeException("thresholds", "Missing required argument");

            return JsonSerializer.Deserialize<List<Threshold>>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("thresholds");
        }
        set
        {
            this.BodyProperties["thresholds"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The type of alert to create. This must be a valid alert type.
    /// </summary>
    public required ApiEnum<string, AlertCreateForSubscriptionParamsProperties::Type> Type
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("type", out JsonElement element))
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<
                ApiEnum<string, AlertCreateForSubscriptionParamsProperties::Type>
            >(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The metric to track usage for.
    /// </summary>
    public string? MetricID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("metric_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["metric_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/alerts/subscription_id/{0}", this.SubscriptionID)
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
