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

    /// <summary>
    /// The property keys to group cost alerts by. Only present for cost alerts with
    /// grouping enabled.
    /// </summary>
    public IReadOnlyList<string>? GroupingKeys
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("grouping_keys");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "grouping_keys",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Minified license type for alert serialization.
    /// </summary>
    public LicenseType? LicenseType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<LicenseType>("license_type");
        }
        init { this._rawData.Set("license_type", value); }
    }

    /// <summary>
    /// Filters scoping which prices are included in grouped cost alert evaluation.
    /// </summary>
    public IReadOnlyList<AlertPriceFilter>? PriceFilters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AlertPriceFilter>>(
                "price_filters"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<AlertPriceFilter>?>(
                "price_filters",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Per-group threshold overrides. Each override maps a specific combination of
    /// grouping_keys values to a replacement threshold list. Only present for grouped
    /// cost alerts that have at least one override.
    /// </summary>
    public IReadOnlyList<AlertThresholdOverride>? ThresholdOverrides
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AlertThresholdOverride>>(
                "threshold_overrides"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<AlertThresholdOverride>?>(
                "threshold_overrides",
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
        _ = this.GroupingKeys;
        this.LicenseType?.Validate();
        foreach (var item in this.PriceFilters ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.ThresholdOverrides ?? [])
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
    LicenseBalanceThresholdReached,
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
            "license_balance_threshold_reached" => AlertType.LicenseBalanceThresholdReached,
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
                AlertType.LicenseBalanceThresholdReached => "license_balance_threshold_reached",
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

/// <summary>
/// Minified license type for alert serialization.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<LicenseType, LicenseTypeFromRaw>))]
public sealed record class LicenseType : JsonModel
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

    public LicenseType() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LicenseType(LicenseType licenseType)
        : base(licenseType) { }
#pragma warning restore CS8618

    public LicenseType(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LicenseType(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LicenseTypeFromRaw.FromRawUnchecked"/>
    public static LicenseType FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public LicenseType(string id)
        : this()
    {
        this.ID = id;
    }
}

class LicenseTypeFromRaw : IFromRawJson<LicenseType>
{
    /// <inheritdoc/>
    public LicenseType FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LicenseType.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<AlertPriceFilter, AlertPriceFilterFromRaw>))]
public sealed record class AlertPriceFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, AlertPriceFilterField> Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AlertPriceFilterField>>("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, AlertPriceFilterOperator> Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AlertPriceFilterOperator>>(
                "operator"
            );
        }
        init { this._rawData.Set("operator", value); }
    }

    /// <summary>
    /// The IDs or values that match this filter.
    /// </summary>
    public required IReadOnlyList<string> Values
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("values");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "values",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Field.Validate();
        this.Operator.Validate();
        _ = this.Values;
    }

    public AlertPriceFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AlertPriceFilter(AlertPriceFilter alertPriceFilter)
        : base(alertPriceFilter) { }
#pragma warning restore CS8618

    public AlertPriceFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AlertPriceFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AlertPriceFilterFromRaw.FromRawUnchecked"/>
    public static AlertPriceFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AlertPriceFilterFromRaw : IFromRawJson<AlertPriceFilter>
{
    /// <inheritdoc/>
    public AlertPriceFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AlertPriceFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(AlertPriceFilterFieldConverter))]
public enum AlertPriceFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class AlertPriceFilterFieldConverter : JsonConverter<AlertPriceFilterField>
{
    public override AlertPriceFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => AlertPriceFilterField.PriceID,
            "item_id" => AlertPriceFilterField.ItemID,
            "price_type" => AlertPriceFilterField.PriceType,
            "currency" => AlertPriceFilterField.Currency,
            "pricing_unit_id" => AlertPriceFilterField.PricingUnitID,
            _ => (AlertPriceFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AlertPriceFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AlertPriceFilterField.PriceID => "price_id",
                AlertPriceFilterField.ItemID => "item_id",
                AlertPriceFilterField.PriceType => "price_type",
                AlertPriceFilterField.Currency => "currency",
                AlertPriceFilterField.PricingUnitID => "pricing_unit_id",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Should prices that match the filter be included or excluded.
/// </summary>
[JsonConverter(typeof(AlertPriceFilterOperatorConverter))]
public enum AlertPriceFilterOperator
{
    Includes,
    Excludes,
}

sealed class AlertPriceFilterOperatorConverter : JsonConverter<AlertPriceFilterOperator>
{
    public override AlertPriceFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => AlertPriceFilterOperator.Includes,
            "excludes" => AlertPriceFilterOperator.Excludes,
            _ => (AlertPriceFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AlertPriceFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AlertPriceFilterOperator.Includes => "includes",
                AlertPriceFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A per-group threshold override on a grouped cost alert.
///
/// <para>An empty `thresholds` list means the group is silenced (never fires). A
/// non-empty list fully replaces the default thresholds for that group.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AlertThresholdOverride, AlertThresholdOverrideFromRaw>))]
public sealed record class AlertThresholdOverride : JsonModel
{
    /// <summary>
    /// The values of the grouping keys that identify this group. The list length
    /// matches the alert's grouping_keys.
    /// </summary>
    public required IReadOnlyList<string> GroupValues
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("group_values");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "group_values",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The thresholds applied to this group. An empty list means the group is silenced.
    /// </summary>
    public required IReadOnlyList<Threshold> Thresholds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Threshold>>("thresholds");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Threshold>>(
                "thresholds",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.GroupValues;
        foreach (var item in this.Thresholds)
        {
            item.Validate();
        }
    }

    public AlertThresholdOverride() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AlertThresholdOverride(AlertThresholdOverride alertThresholdOverride)
        : base(alertThresholdOverride) { }
#pragma warning restore CS8618

    public AlertThresholdOverride(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AlertThresholdOverride(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AlertThresholdOverrideFromRaw.FromRawUnchecked"/>
    public static AlertThresholdOverride FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AlertThresholdOverrideFromRaw : IFromRawJson<AlertThresholdOverride>
{
    /// <inheritdoc/>
    public AlertThresholdOverride FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AlertThresholdOverride.FromRawUnchecked(rawData);
}
