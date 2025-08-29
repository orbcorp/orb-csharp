using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using AlertProperties = Orb.Models.Alerts.AlertProperties;

namespace Orb.Models.Alerts;

/// <summary>
/// [Alerts within Orb](/product-catalog/configuring-alerts) monitor spending, usage,
/// or credit balance and trigger webhooks when a threshold is exceeded.
///
/// Alerts created through the API can be scoped to either customers or subscriptions.
/// </summary>
[JsonConverter(typeof(ModelConverter<Alert>))]
public sealed record class Alert : ModelBase, IFromRaw<Alert>
{
    /// <summary>
    /// Also referred to as alert_id in this documentation.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("id");
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The creation time of the resource in Orb.
    /// </summary>
    public required DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new ArgumentOutOfRangeException("created_at", "Missing required argument");

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the currency the credit balance or invoice cost is denominated in.
    /// </summary>
    public required string? Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The customer the alert applies to.
    /// </summary>
    public required CustomerMinified? Customer
    {
        get
        {
            if (!this.Properties.TryGetValue("customer", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CustomerMinified?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["customer"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether the alert is enabled or disabled.
    /// </summary>
    public required bool Enabled
    {
        get
        {
            if (!this.Properties.TryGetValue("enabled", out JsonElement element))
                throw new ArgumentOutOfRangeException("enabled", "Missing required argument");

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["enabled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The metric the alert applies to.
    /// </summary>
    public required AlertProperties::Metric? Metric
    {
        get
        {
            if (!this.Properties.TryGetValue("metric", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<AlertProperties::Metric?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["metric"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The plan the alert applies to.
    /// </summary>
    public required AlertProperties::Plan? Plan
    {
        get
        {
            if (!this.Properties.TryGetValue("plan", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<AlertProperties::Plan?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["plan"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The subscription the alert applies to.
    /// </summary>
    public required SubscriptionMinified? Subscription
    {
        get
        {
            if (!this.Properties.TryGetValue("subscription", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<SubscriptionMinified?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["subscription"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The thresholds that define the conditions under which the alert will be triggered.
    /// </summary>
    public required List<Threshold>? Thresholds
    {
        get
        {
            if (!this.Properties.TryGetValue("thresholds", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Threshold>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["thresholds"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The type of alert. This must be a valid alert type.
    /// </summary>
    public required ApiEnum<string, AlertProperties::Type> Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<ApiEnum<string, AlertProperties::Type>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The current status of the alert. This field is only present for credit balance alerts.
    /// </summary>
    public List<AlertProperties::BalanceAlertStatus>? BalanceAlertStatus
    {
        get
        {
            if (!this.Properties.TryGetValue("balance_alert_status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AlertProperties::BalanceAlertStatus>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["balance_alert_status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Currency;
        this.Customer?.Validate();
        _ = this.Enabled;
        this.Metric?.Validate();
        this.Plan?.Validate();
        this.Subscription?.Validate();
        foreach (var item in this.Thresholds ?? [])
        {
            item.Validate();
        }
        this.Type.Validate();
        foreach (var item in this.BalanceAlertStatus ?? [])
        {
            item.Validate();
        }
    }

    public Alert() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Alert(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Alert FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
