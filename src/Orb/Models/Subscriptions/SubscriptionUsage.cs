using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Subscriptions;

[JsonConverter(typeof(SubscriptionUsageConverter))]
public record class SubscriptionUsage : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public SubscriptionUsage(UngroupedSubscriptionUsage value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionUsage(GroupedSubscriptionUsage value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SubscriptionUsage(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UngroupedSubscriptionUsage"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUngrouped(out var value)) {
    ///     // `value` is of type `UngroupedSubscriptionUsage`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUngrouped([NotNullWhen(true)] out UngroupedSubscriptionUsage? value)
    {
        value = this.Value as UngroupedSubscriptionUsage;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="GroupedSubscriptionUsage"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGrouped(out var value)) {
    ///     // `value` is of type `GroupedSubscriptionUsage`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGrouped([NotNullWhen(true)] out GroupedSubscriptionUsage? value)
    {
        value = this.Value as GroupedSubscriptionUsage;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (UngroupedSubscriptionUsage value) => {...},
    ///     (GroupedSubscriptionUsage value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<UngroupedSubscriptionUsage> ungrouped,
        System::Action<GroupedSubscriptionUsage> grouped
    )
    {
        switch (this.Value)
        {
            case UngroupedSubscriptionUsage value:
                ungrouped(value);
                break;
            case GroupedSubscriptionUsage value:
                grouped(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of SubscriptionUsage"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (UngroupedSubscriptionUsage value) => {...},
    ///     (GroupedSubscriptionUsage value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<UngroupedSubscriptionUsage, T> ungrouped,
        System::Func<GroupedSubscriptionUsage, T> grouped
    )
    {
        return this.Value switch
        {
            UngroupedSubscriptionUsage value => ungrouped(value),
            GroupedSubscriptionUsage value => grouped(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of SubscriptionUsage"
            ),
        };
    }

    public static implicit operator SubscriptionUsage(UngroupedSubscriptionUsage value) =>
        new(value);

    public static implicit operator SubscriptionUsage(GroupedSubscriptionUsage value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of SubscriptionUsage"
            );
        }
        this.Switch((ungrouped) => ungrouped.Validate(), (grouped) => grouped.Validate());
    }

    public virtual bool Equals(SubscriptionUsage? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            UngroupedSubscriptionUsage _ => 0,
            GroupedSubscriptionUsage _ => 1,
            _ => -1,
        };
    }
}

sealed class SubscriptionUsageConverter : JsonConverter<SubscriptionUsage>
{
    public override SubscriptionUsage? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<UngroupedSubscriptionUsage>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<GroupedSubscriptionUsage>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubscriptionUsage value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<UngroupedSubscriptionUsage, UngroupedSubscriptionUsageFromRaw>)
)]
public sealed record class UngroupedSubscriptionUsage : JsonModel
{
    public required IReadOnlyList<Data> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Data>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Data>>("data", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public UngroupedSubscriptionUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UngroupedSubscriptionUsage(UngroupedSubscriptionUsage ungroupedSubscriptionUsage)
        : base(ungroupedSubscriptionUsage) { }
#pragma warning restore CS8618

    public UngroupedSubscriptionUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UngroupedSubscriptionUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UngroupedSubscriptionUsageFromRaw.FromRawUnchecked"/>
    public static UngroupedSubscriptionUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UngroupedSubscriptionUsage(IReadOnlyList<Data> data)
        : this()
    {
        this.Data = data;
    }
}

class UngroupedSubscriptionUsageFromRaw : IFromRawJson<UngroupedSubscriptionUsage>
{
    /// <inheritdoc/>
    public UngroupedSubscriptionUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UngroupedSubscriptionUsage.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public required BillableMetric BillableMetric
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BillableMetric>("billable_metric");
        }
        init { this._rawData.Set("billable_metric", value); }
    }

    public required IReadOnlyList<DataUsage> Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DataUsage>>("usage");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DataUsage>>(
                "usage",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, DataViewMode> ViewMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataViewMode>>("view_mode");
        }
        init { this._rawData.Set("view_mode", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BillableMetric.Validate();
        foreach (var item in this.Usage)
        {
            item.Validate();
        }
        this.ViewMode.Validate();
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<BillableMetric, BillableMetricFromRaw>))]
public sealed record class BillableMetric : JsonModel
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

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public BillableMetric() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BillableMetric(BillableMetric billableMetric)
        : base(billableMetric) { }
#pragma warning restore CS8618

    public BillableMetric(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillableMetric(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BillableMetricFromRaw.FromRawUnchecked"/>
    public static BillableMetric FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BillableMetricFromRaw : IFromRawJson<BillableMetric>
{
    /// <inheritdoc/>
    public BillableMetric FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BillableMetric.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<DataUsage, DataUsageFromRaw>))]
public sealed record class DataUsage : JsonModel
{
    public required double Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("quantity");
        }
        init { this._rawData.Set("quantity", value); }
    }

    public required System::DateTimeOffset TimeframeEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("timeframe_end");
        }
        init { this._rawData.Set("timeframe_end", value); }
    }

    public required System::DateTimeOffset TimeframeStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("timeframe_start");
        }
        init { this._rawData.Set("timeframe_start", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Quantity;
        _ = this.TimeframeEnd;
        _ = this.TimeframeStart;
    }

    public DataUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataUsage(DataUsage dataUsage)
        : base(dataUsage) { }
#pragma warning restore CS8618

    public DataUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataUsageFromRaw.FromRawUnchecked"/>
    public static DataUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataUsageFromRaw : IFromRawJson<DataUsage>
{
    /// <inheritdoc/>
    public DataUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DataUsage.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DataViewModeConverter))]
public enum DataViewMode
{
    Periodic,
    Cumulative,
}

sealed class DataViewModeConverter : JsonConverter<DataViewMode>
{
    public override DataViewMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "periodic" => DataViewMode.Periodic,
            "cumulative" => DataViewMode.Cumulative,
            _ => (DataViewMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataViewMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataViewMode.Periodic => "periodic",
                DataViewMode.Cumulative => "cumulative",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<GroupedSubscriptionUsage, GroupedSubscriptionUsageFromRaw>)
)]
public sealed record class GroupedSubscriptionUsage : JsonModel
{
    public required IReadOnlyList<GroupedSubscriptionUsageData> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<GroupedSubscriptionUsageData>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<GroupedSubscriptionUsageData>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public PaginationMetadata? PaginationMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMetadata>("pagination_metadata");
        }
        init { this._rawData.Set("pagination_metadata", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.PaginationMetadata?.Validate();
    }

    public GroupedSubscriptionUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GroupedSubscriptionUsage(GroupedSubscriptionUsage groupedSubscriptionUsage)
        : base(groupedSubscriptionUsage) { }
#pragma warning restore CS8618

    public GroupedSubscriptionUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedSubscriptionUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GroupedSubscriptionUsageFromRaw.FromRawUnchecked"/>
    public static GroupedSubscriptionUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public GroupedSubscriptionUsage(IReadOnlyList<GroupedSubscriptionUsageData> data)
        : this()
    {
        this.Data = data;
    }
}

class GroupedSubscriptionUsageFromRaw : IFromRawJson<GroupedSubscriptionUsage>
{
    /// <inheritdoc/>
    public GroupedSubscriptionUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GroupedSubscriptionUsage.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<GroupedSubscriptionUsageData, GroupedSubscriptionUsageDataFromRaw>)
)]
public sealed record class GroupedSubscriptionUsageData : JsonModel
{
    public required GroupedSubscriptionUsageDataBillableMetric BillableMetric
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<GroupedSubscriptionUsageDataBillableMetric>(
                "billable_metric"
            );
        }
        init { this._rawData.Set("billable_metric", value); }
    }

    public required MetricGroup MetricGroup
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MetricGroup>("metric_group");
        }
        init { this._rawData.Set("metric_group", value); }
    }

    public required IReadOnlyList<GroupedSubscriptionUsageDataUsage> Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<GroupedSubscriptionUsageDataUsage>
            >("usage");
        }
        init
        {
            this._rawData.Set<ImmutableArray<GroupedSubscriptionUsageDataUsage>>(
                "usage",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, GroupedSubscriptionUsageDataViewMode> ViewMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, GroupedSubscriptionUsageDataViewMode>
            >("view_mode");
        }
        init { this._rawData.Set("view_mode", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.BillableMetric.Validate();
        this.MetricGroup.Validate();
        foreach (var item in this.Usage)
        {
            item.Validate();
        }
        this.ViewMode.Validate();
    }

    public GroupedSubscriptionUsageData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GroupedSubscriptionUsageData(GroupedSubscriptionUsageData groupedSubscriptionUsageData)
        : base(groupedSubscriptionUsageData) { }
#pragma warning restore CS8618

    public GroupedSubscriptionUsageData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedSubscriptionUsageData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GroupedSubscriptionUsageDataFromRaw.FromRawUnchecked"/>
    public static GroupedSubscriptionUsageData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GroupedSubscriptionUsageDataFromRaw : IFromRawJson<GroupedSubscriptionUsageData>
{
    /// <inheritdoc/>
    public GroupedSubscriptionUsageData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GroupedSubscriptionUsageData.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        GroupedSubscriptionUsageDataBillableMetric,
        GroupedSubscriptionUsageDataBillableMetricFromRaw
    >)
)]
public sealed record class GroupedSubscriptionUsageDataBillableMetric : JsonModel
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

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public GroupedSubscriptionUsageDataBillableMetric() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GroupedSubscriptionUsageDataBillableMetric(
        GroupedSubscriptionUsageDataBillableMetric groupedSubscriptionUsageDataBillableMetric
    )
        : base(groupedSubscriptionUsageDataBillableMetric) { }
#pragma warning restore CS8618

    public GroupedSubscriptionUsageDataBillableMetric(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedSubscriptionUsageDataBillableMetric(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GroupedSubscriptionUsageDataBillableMetricFromRaw.FromRawUnchecked"/>
    public static GroupedSubscriptionUsageDataBillableMetric FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GroupedSubscriptionUsageDataBillableMetricFromRaw
    : IFromRawJson<GroupedSubscriptionUsageDataBillableMetric>
{
    /// <inheritdoc/>
    public GroupedSubscriptionUsageDataBillableMetric FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GroupedSubscriptionUsageDataBillableMetric.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<MetricGroup, MetricGroupFromRaw>))]
public sealed record class MetricGroup : JsonModel
{
    public required string PropertyKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("property_key");
        }
        init { this._rawData.Set("property_key", value); }
    }

    public required string PropertyValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("property_value");
        }
        init { this._rawData.Set("property_value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PropertyKey;
        _ = this.PropertyValue;
    }

    public MetricGroup() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MetricGroup(MetricGroup metricGroup)
        : base(metricGroup) { }
#pragma warning restore CS8618

    public MetricGroup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MetricGroup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MetricGroupFromRaw.FromRawUnchecked"/>
    public static MetricGroup FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetricGroupFromRaw : IFromRawJson<MetricGroup>
{
    /// <inheritdoc/>
    public MetricGroup FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MetricGroup.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        GroupedSubscriptionUsageDataUsage,
        GroupedSubscriptionUsageDataUsageFromRaw
    >)
)]
public sealed record class GroupedSubscriptionUsageDataUsage : JsonModel
{
    public required double Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("quantity");
        }
        init { this._rawData.Set("quantity", value); }
    }

    public required System::DateTimeOffset TimeframeEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("timeframe_end");
        }
        init { this._rawData.Set("timeframe_end", value); }
    }

    public required System::DateTimeOffset TimeframeStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("timeframe_start");
        }
        init { this._rawData.Set("timeframe_start", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Quantity;
        _ = this.TimeframeEnd;
        _ = this.TimeframeStart;
    }

    public GroupedSubscriptionUsageDataUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GroupedSubscriptionUsageDataUsage(
        GroupedSubscriptionUsageDataUsage groupedSubscriptionUsageDataUsage
    )
        : base(groupedSubscriptionUsageDataUsage) { }
#pragma warning restore CS8618

    public GroupedSubscriptionUsageDataUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedSubscriptionUsageDataUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GroupedSubscriptionUsageDataUsageFromRaw.FromRawUnchecked"/>
    public static GroupedSubscriptionUsageDataUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GroupedSubscriptionUsageDataUsageFromRaw : IFromRawJson<GroupedSubscriptionUsageDataUsage>
{
    /// <inheritdoc/>
    public GroupedSubscriptionUsageDataUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GroupedSubscriptionUsageDataUsage.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(GroupedSubscriptionUsageDataViewModeConverter))]
public enum GroupedSubscriptionUsageDataViewMode
{
    Periodic,
    Cumulative,
}

sealed class GroupedSubscriptionUsageDataViewModeConverter
    : JsonConverter<GroupedSubscriptionUsageDataViewMode>
{
    public override GroupedSubscriptionUsageDataViewMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "periodic" => GroupedSubscriptionUsageDataViewMode.Periodic,
            "cumulative" => GroupedSubscriptionUsageDataViewMode.Cumulative,
            _ => (GroupedSubscriptionUsageDataViewMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GroupedSubscriptionUsageDataViewMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GroupedSubscriptionUsageDataViewMode.Periodic => "periodic",
                GroupedSubscriptionUsageDataViewMode.Cumulative => "cumulative",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
