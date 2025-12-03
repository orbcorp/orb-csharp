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
[JsonConverter(typeof(ModelConverter<Alert, AlertFromRaw>))]
public sealed record class Alert : ModelBase
{
    /// <summary>
    /// Also referred to as alert_id in this documentation.
    /// </summary>
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// The creation time of the resource in Orb.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "created_at");
        }
        init { ModelBase.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// The name of the currency the credit balance or invoice cost is denominated in.
    /// </summary>
    public required string? Currency
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// The customer the alert applies to.
    /// </summary>
    public required CustomerMinified? Customer
    {
        get { return ModelBase.GetNullableClass<CustomerMinified>(this.RawData, "customer"); }
        init { ModelBase.Set(this._rawData, "customer", value); }
    }

    /// <summary>
    /// Whether the alert is enabled or disabled.
    /// </summary>
    public required bool Enabled
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "enabled"); }
        init { ModelBase.Set(this._rawData, "enabled", value); }
    }

    /// <summary>
    /// The metric the alert applies to.
    /// </summary>
    public required Metric? Metric
    {
        get { return ModelBase.GetNullableClass<Metric>(this.RawData, "metric"); }
        init { ModelBase.Set(this._rawData, "metric", value); }
    }

    /// <summary>
    /// The plan the alert applies to.
    /// </summary>
    public required Plan? Plan
    {
        get { return ModelBase.GetNullableClass<Plan>(this.RawData, "plan"); }
        init { ModelBase.Set(this._rawData, "plan", value); }
    }

    /// <summary>
    /// The subscription the alert applies to.
    /// </summary>
    public required SubscriptionMinified? Subscription
    {
        get
        {
            return ModelBase.GetNullableClass<SubscriptionMinified>(this.RawData, "subscription");
        }
        init { ModelBase.Set(this._rawData, "subscription", value); }
    }

    /// <summary>
    /// The thresholds that define the conditions under which the alert will be triggered.
    /// </summary>
    public required IReadOnlyList<Threshold>? Thresholds
    {
        get { return ModelBase.GetNullableClass<List<Threshold>>(this.RawData, "thresholds"); }
        init { ModelBase.Set(this._rawData, "thresholds", value); }
    }

    /// <summary>
    /// The type of alert. This must be a valid alert type.
    /// </summary>
    public required ApiEnum<string, AlertType> Type
    {
        get { return ModelBase.GetNotNullClass<ApiEnum<string, AlertType>>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// The current status of the alert. This field is only present for credit balance alerts.
    /// </summary>
    public IReadOnlyList<BalanceAlertStatus>? BalanceAlertStatus
    {
        get
        {
            return ModelBase.GetNullableClass<List<BalanceAlertStatus>>(
                this.RawData,
                "balance_alert_status"
            );
        }
        init { ModelBase.Set(this._rawData, "balance_alert_status", value); }
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

    public Alert(Alert alert)
        : base(alert) { }

    public Alert(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Alert(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AlertFromRaw.FromRawUnchecked"/>
    public static Alert FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AlertFromRaw : IFromRaw<Alert>
{
    /// <inheritdoc/>
    public Alert FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Alert.FromRawUnchecked(rawData);
}

/// <summary>
/// The metric the alert applies to.
/// </summary>
[JsonConverter(typeof(ModelConverter<Metric, MetricFromRaw>))]
public sealed record class Metric : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
    }

    public Metric() { }

    public Metric(Metric metric)
        : base(metric) { }

    public Metric(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Metric(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class MetricFromRaw : IFromRaw<Metric>
{
    /// <inheritdoc/>
    public Metric FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Metric.FromRawUnchecked(rawData);
}

/// <summary>
/// The plan the alert applies to.
/// </summary>
[JsonConverter(typeof(ModelConverter<Plan, PlanFromRaw>))]
public sealed record class Plan : ModelBase
{
    public required string? ID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// An optional user-defined ID for this plan resource, used throughout the system
    /// as an alias for this Plan. Use this field to identify a plan by an existing
    /// identifier in your system.
    /// </summary>
    public required string? ExternalPlanID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "external_plan_id"); }
        init { ModelBase.Set(this._rawData, "external_plan_id", value); }
    }

    public required string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    public required string PlanVersion
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "plan_version"); }
        init { ModelBase.Set(this._rawData, "plan_version", value); }
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

    public Plan(Plan plan)
        : base(plan) { }

    public Plan(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Plan(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlanFromRaw.FromRawUnchecked"/>
    public static Plan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlanFromRaw : IFromRaw<Plan>
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
[JsonConverter(typeof(ModelConverter<BalanceAlertStatus, BalanceAlertStatusFromRaw>))]
public sealed record class BalanceAlertStatus : ModelBase
{
    /// <summary>
    /// Whether the alert is currently in-alert or not.
    /// </summary>
    public required bool InAlert
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "in_alert"); }
        init { ModelBase.Set(this._rawData, "in_alert", value); }
    }

    /// <summary>
    /// The value of the threshold that defines the alert status.
    /// </summary>
    public required double ThresholdValue
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "threshold_value"); }
        init { ModelBase.Set(this._rawData, "threshold_value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InAlert;
        _ = this.ThresholdValue;
    }

    public BalanceAlertStatus() { }

    public BalanceAlertStatus(BalanceAlertStatus balanceAlertStatus)
        : base(balanceAlertStatus) { }

    public BalanceAlertStatus(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceAlertStatus(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class BalanceAlertStatusFromRaw : IFromRaw<BalanceAlertStatus>
{
    /// <inheritdoc/>
    public BalanceAlertStatus FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BalanceAlertStatus.FromRawUnchecked(rawData);
}
