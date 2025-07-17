using AlertProperties = Orb.Models.Alerts.AlertProperties;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Alerts;

/// <summary>
/// [Alerts within Orb](/product-catalog/configuring-alerts) monitor spending, usage,
/// or credit balance and trigger webhooks when a threshold is exceeded.
///
/// Alerts created through the API can be scoped to either customers or subscriptions.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::ModelConverter<Alert>))]
public sealed record class Alert : Orb::ModelBase, Orb::IFromRaw<Alert>
{
    /// <summary>
    /// Also referred to as alert_id in this documentation.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("id", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("id");
        }
        set { this.Properties["id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The creation time of the resource in Orb.
    /// </summary>
    public required System::DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "created_at",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set { this.Properties["created_at"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The name of the currency the credit balance or invoice cost is denominated in.
    /// </summary>
    public required string? Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "currency",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["currency"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The customer the alert applies to.
    /// </summary>
    public required Models::CustomerMinified? Customer
    {
        get
        {
            if (!this.Properties.TryGetValue("customer", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "customer",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Models::CustomerMinified?>(element);
        }
        set { this.Properties["customer"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Whether the alert is enabled or disabled.
    /// </summary>
    public required bool Enabled
    {
        get
        {
            if (!this.Properties.TryGetValue("enabled", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "enabled",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<bool>(element);
        }
        set { this.Properties["enabled"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The metric the alert applies to.
    /// </summary>
    public required AlertProperties::Metric? Metric
    {
        get
        {
            if (!this.Properties.TryGetValue("metric", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "metric",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<AlertProperties::Metric?>(element);
        }
        set { this.Properties["metric"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The plan the alert applies to.
    /// </summary>
    public required AlertProperties::Plan? Plan
    {
        get
        {
            if (!this.Properties.TryGetValue("plan", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("plan", "Missing required argument");

            return Json::JsonSerializer.Deserialize<AlertProperties::Plan?>(element);
        }
        set { this.Properties["plan"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The subscription the alert applies to.
    /// </summary>
    public required Models::SubscriptionMinified? Subscription
    {
        get
        {
            if (!this.Properties.TryGetValue("subscription", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "subscription",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Models::SubscriptionMinified?>(element);
        }
        set { this.Properties["subscription"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The thresholds that define the conditions under which the alert will be triggered.
    /// </summary>
    public required Generic::List<Threshold>? Thresholds
    {
        get
        {
            if (!this.Properties.TryGetValue("thresholds", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "thresholds",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<Threshold>?>(element);
        }
        set { this.Properties["thresholds"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The type of alert. This must be a valid alert type.
    /// </summary>
    public required AlertProperties::Type Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return Json::JsonSerializer.Deserialize<AlertProperties::Type>(element)
                ?? throw new System::ArgumentNullException("type");
        }
        set { this.Properties["type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The current status of the alert. This field is only present for credit balance alerts.
    /// </summary>
    public Generic::List<AlertProperties::BalanceAlertStatus>? BalanceAlertStatus
    {
        get
        {
            if (!this.Properties.TryGetValue("balance_alert_status", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<AlertProperties::BalanceAlertStatus>?>(
                element
            );
        }
        set
        {
            this.Properties["balance_alert_status"] = Json::JsonSerializer.SerializeToElement(
                value
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
    [CodeAnalysis::SetsRequiredMembers]
    Alert(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Alert FromRawUnchecked(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        return new(properties);
    }
}
