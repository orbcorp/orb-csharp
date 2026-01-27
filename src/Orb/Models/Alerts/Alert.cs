using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
[JsonConverter(typeof(JsonModelConverter<Alert, AlertFromRaw>))]
public sealed record class Alert : JsonModel
{
    /// <summary>
    /// Also referred to as alert_id in this documentation.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The creation time of the resource in Orb.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The name of the currency the credit balance or invoice cost is denominated in.
    /// </summary>
    public required string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// The customer the alert applies to.
    /// </summary>
    public required CustomerMinified? Customer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomerMinified>("customer");
        }
        init { this._rawData.Set("customer", value); }
    }

    /// <summary>
    /// Whether the alert is enabled or disabled.
    /// </summary>
    public required bool Enabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("enabled");
        }
        init { this._rawData.Set("enabled", value); }
    }

    /// <summary>
    /// The metric the alert applies to.
    /// </summary>
    public required Metric? Metric
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Metric>("metric");
        }
        init { this._rawData.Set("metric", value); }
    }

    /// <summary>
    /// The plan the alert applies to.
    /// </summary>
    public required Plan? Plan
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Plan>("plan");
        }
        init { this._rawData.Set("plan", value); }
    }

    /// <summary>
    /// The subscription the alert applies to.
    /// </summary>
    public required SubscriptionMinified? Subscription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubscriptionMinified>("subscription");
        }
        init { this._rawData.Set("subscription", value); }
    }

    /// <summary>
    /// The thresholds that define the conditions under which the alert will be triggered.
    /// </summary>
    public required IReadOnlyList<Threshold>? Thresholds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Threshold>>("thresholds");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Threshold>?>(
                "thresholds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AlertType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The current status of the alert. This field is only present for credit balance alerts.
    /// </summary>
    public IReadOnlyList<BalanceAlertStatus>? BalanceAlertStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BalanceAlertStatus>>(
                "balance_alert_status"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BalanceAlertStatus>?>(
                "balance_alert_status",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
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
    public Alert(Alert alert)
        : base(alert) { }
#pragma warning restore CS8618

    public Alert(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Alert(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AlertFromRaw.FromRawUnchecked"/>
    public static Alert FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AlertFromRaw : IFromRawJson<Alert>
{
    /// <inheritdoc/>
    public Alert FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Alert.FromRawUnchecked(rawData);
}

/// <summary>
/// The metric the alert applies to.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Metric, MetricFromRaw>))]
public sealed record class Metric : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
    }

    public Metric() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Metric(Metric metric)
        : base(metric) { }
#pragma warning restore CS8618

    public Metric(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Metric(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MetricFromRaw.FromRawUnchecked"/>
    public static Metric FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Metric(string id)
        : this()
    {
        this.ID = id;
    }
}

class MetricFromRaw : IFromRawJson<Metric>
{
    /// <inheritdoc/>
    public Metric FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Metric.FromRawUnchecked(rawData);
}

/// <summary>
/// The plan the alert applies to.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Plan, PlanFromRaw>))]
public sealed record class Plan : JsonModel
{
    public required string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_plan_id");
        }
        init { this._rawData.Set("external_plan_id", value); }
    }

    public required string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required string PlanVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("plan_version");
        }
        init { this._rawData.Set("plan_version", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ExternalPlanID;
        _ = this.Name;
        _ = this.PlanVersion;
    }

    public Plan() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Plan(Plan plan)
        : base(plan) { }
#pragma warning restore CS8618

    public Plan(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Plan(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanFromRaw.FromRawUnchecked"/>
    public static Plan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanFromRaw : IFromRawJson<Plan>
{
    /// <inheritdoc/>
    public Plan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Plan.FromRawUnchecked(rawData);
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
[JsonConverter(typeof(JsonModelConverter<BalanceAlertStatus, BalanceAlertStatusFromRaw>))]
public sealed record class BalanceAlertStatus : JsonModel
{
    /// <summary>
    /// Whether the alert is currently in-alert or not.
    /// </summary>
    public required bool InAlert
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("in_alert");
        }
        init { this._rawData.Set("in_alert", value); }
    }

    /// <summary>
    /// The value of the threshold that defines the alert status.
    /// </summary>
    public required double ThresholdValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("threshold_value");
        }
        init { this._rawData.Set("threshold_value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InAlert;
        _ = this.ThresholdValue;
    }

    public BalanceAlertStatus() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BalanceAlertStatus(BalanceAlertStatus balanceAlertStatus)
        : base(balanceAlertStatus) { }
#pragma warning restore CS8618

    public BalanceAlertStatus(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceAlertStatus(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BalanceAlertStatusFromRaw.FromRawUnchecked"/>
    public static BalanceAlertStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BalanceAlertStatusFromRaw : IFromRawJson<BalanceAlertStatus>
{
    /// <inheritdoc/>
    public BalanceAlertStatus FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BalanceAlertStatus.FromRawUnchecked(rawData);
}
