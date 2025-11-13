using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Alerts;

/// <summary>
/// [Alerts within Orb](/product-catalog/configuring-alerts) monitor spending, usage,
/// or credit balance and trigger webhooks when a threshold is exceeded.
///
/// <para>Alerts created through the API can be scoped to either customers or subscriptions.</para>
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
            if (!this._properties.TryGetValue("id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        init
        {
            this._properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The creation time of the resource in Orb.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            if (!this._properties.TryGetValue("created_at", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'created_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "created_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTimeOffset>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["created_at"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("customer", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CustomerMinified?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["customer"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("enabled", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'enabled' cannot be null",
                    new System::ArgumentOutOfRangeException("enabled", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["enabled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The metric the alert applies to.
    /// </summary>
    public required Metric? Metric
    {
        get
        {
            if (!this._properties.TryGetValue("metric", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Metric?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["metric"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The plan the alert applies to.
    /// </summary>
    public required Plan? Plan
    {
        get
        {
            if (!this._properties.TryGetValue("plan", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Plan?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["plan"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("subscription", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<SubscriptionMinified?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["subscription"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("thresholds", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Threshold>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["thresholds"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The type of alert. This must be a valid alert type.
    /// </summary>
    public required ApiEnum<string, AlertType> Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, AlertType>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The current status of the alert. This field is only present for credit balance alerts.
    /// </summary>
    public List<BalanceAlertStatus>? BalanceAlertStatus
    {
        get
        {
            if (!this._properties.TryGetValue("balance_alert_status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<BalanceAlertStatus>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["balance_alert_status"] = JsonSerializer.SerializeToElement(
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

    public Alert(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Alert(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Alert FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The metric the alert applies to.
/// </summary>
[JsonConverter(typeof(ModelConverter<Metric>))]
public sealed record class Metric : ModelBase, IFromRaw<Metric>
{
    public required string ID
    {
        get
        {
            if (!this._properties.TryGetValue("id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        init
        {
            this._properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
    }

    public Metric() { }

    public Metric(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Metric(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Metric FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public Metric(string id)
        : this()
    {
        this.ID = id;
    }
}

/// <summary>
/// The plan the alert applies to.
/// </summary>
[JsonConverter(typeof(ModelConverter<Plan>))]
public sealed record class Plan : ModelBase, IFromRaw<Plan>
{
    public required string? ID
    {
        get
        {
            if (!this._properties.TryGetValue("id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An optional user-defined ID for this plan resource, used throughout the system
    /// as an alias for this Plan. Use this field to identify a plan by an existing
    /// identifier in your system.
    /// </summary>
    public required string? ExternalPlanID
    {
        get
        {
            if (!this._properties.TryGetValue("external_plan_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_plan_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? Name
    {
        get
        {
            if (!this._properties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string PlanVersion
    {
        get
        {
            if (!this._properties.TryGetValue("plan_version", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'plan_version' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "plan_version",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'plan_version' cannot be null",
                    new System::ArgumentNullException("plan_version")
                );
        }
        init
        {
            this._properties["plan_version"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.ExternalPlanID;
        _ = this.Name;
        _ = this.PlanVersion;
    }

    public Plan() { }

    public Plan(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Plan(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Plan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The type of alert. This must be a valid alert type.
/// </summary>
[JsonConverter(typeof(AlertTypeConverter))]
public enum AlertType
{
    CreditBalanceDepleted,
    CreditBalanceDropped,
    CreditBalanceRecovered,
    UsageExceeded,
    CostExceeded,
}

sealed class AlertTypeConverter : JsonConverter<AlertType>
{
    public override AlertType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "credit_balance_depleted" => AlertType.CreditBalanceDepleted,
            "credit_balance_dropped" => AlertType.CreditBalanceDropped,
            "credit_balance_recovered" => AlertType.CreditBalanceRecovered,
            "usage_exceeded" => AlertType.UsageExceeded,
            "cost_exceeded" => AlertType.CostExceeded,
            _ => (AlertType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AlertType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AlertType.CreditBalanceDepleted => "credit_balance_depleted",
                AlertType.CreditBalanceDropped => "credit_balance_dropped",
                AlertType.CreditBalanceRecovered => "credit_balance_recovered",
                AlertType.UsageExceeded => "usage_exceeded",
                AlertType.CostExceeded => "cost_exceeded",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Alert status is used to determine if an alert is currently in-alert or not.
/// </summary>
[JsonConverter(typeof(ModelConverter<BalanceAlertStatus>))]
public sealed record class BalanceAlertStatus : ModelBase, IFromRaw<BalanceAlertStatus>
{
    /// <summary>
    /// Whether the alert is currently in-alert or not.
    /// </summary>
    public required bool InAlert
    {
        get
        {
            if (!this._properties.TryGetValue("in_alert", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'in_alert' cannot be null",
                    new System::ArgumentOutOfRangeException("in_alert", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["in_alert"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The value of the threshold that defines the alert status.
    /// </summary>
    public required double ThresholdValue
    {
        get
        {
            if (!this._properties.TryGetValue("threshold_value", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'threshold_value' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "threshold_value",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["threshold_value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.InAlert;
        _ = this.ThresholdValue;
    }

    public BalanceAlertStatus() { }

    public BalanceAlertStatus(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceAlertStatus(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BalanceAlertStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
