using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Subscriptions;

[JsonConverter(typeof(SubscriptionUsageConverter))]
public record class SubscriptionUsage
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public SubscriptionUsage(UngroupedSubscriptionUsage value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public SubscriptionUsage(GroupedSubscriptionUsage value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public SubscriptionUsage(JsonElement json)
    {
        this._json = json;
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of SubscriptionUsage"
            );
        }
    }

    public virtual bool Equals(SubscriptionUsage? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
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
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<UngroupedSubscriptionUsage>(
                json,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<GroupedSubscriptionUsage>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        return new(json);
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
    typeof(ModelConverter<UngroupedSubscriptionUsage, UngroupedSubscriptionUsageFromRaw>)
)]
public sealed record class UngroupedSubscriptionUsage : ModelBase
{
    public required IReadOnlyList<Data> Data
    {
        get { return ModelBase.GetNotNullClass<List<Data>>(this.RawData, "data"); }
        init { ModelBase.Set(this._rawData, "data", value); }
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

    public UngroupedSubscriptionUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UngroupedSubscriptionUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
    public UngroupedSubscriptionUsage(List<Data> data)
        : this()
    {
        this.Data = data;
    }
}

class UngroupedSubscriptionUsageFromRaw : IFromRaw<UngroupedSubscriptionUsage>
{
    /// <inheritdoc/>
    public UngroupedSubscriptionUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UngroupedSubscriptionUsage.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Data, DataFromRaw>))]
public sealed record class Data : ModelBase
{
    public required BillableMetric BillableMetric
    {
        get { return ModelBase.GetNotNullClass<BillableMetric>(this.RawData, "billable_metric"); }
        init { ModelBase.Set(this._rawData, "billable_metric", value); }
    }

    public required IReadOnlyList<DataUsage> Usage
    {
        get { return ModelBase.GetNotNullClass<List<DataUsage>>(this.RawData, "usage"); }
        init { ModelBase.Set(this._rawData, "usage", value); }
    }

    public required ApiEnum<string, DataViewMode> ViewMode
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, DataViewMode>>(
                this.RawData,
                "view_mode"
            );
        }
        init { ModelBase.Set(this._rawData, "view_mode", value); }
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

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRaw<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<BillableMetric, BillableMetricFromRaw>))]
public sealed record class BillableMetric : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public BillableMetric() { }

    public BillableMetric(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillableMetric(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BillableMetricFromRaw.FromRawUnchecked"/>
    public static BillableMetric FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BillableMetricFromRaw : IFromRaw<BillableMetric>
{
    /// <inheritdoc/>
    public BillableMetric FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BillableMetric.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<DataUsage, DataUsageFromRaw>))]
public sealed record class DataUsage : ModelBase
{
    public required double Quantity
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "quantity"); }
        init { ModelBase.Set(this._rawData, "quantity", value); }
    }

    public required System::DateTimeOffset TimeframeEnd
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(
                this.RawData,
                "timeframe_end"
            );
        }
        init { ModelBase.Set(this._rawData, "timeframe_end", value); }
    }

    public required System::DateTimeOffset TimeframeStart
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(
                this.RawData,
                "timeframe_start"
            );
        }
        init { ModelBase.Set(this._rawData, "timeframe_start", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Quantity;
        _ = this.TimeframeEnd;
        _ = this.TimeframeStart;
    }

    public DataUsage() { }

    public DataUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataUsageFromRaw.FromRawUnchecked"/>
    public static DataUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataUsageFromRaw : IFromRaw<DataUsage>
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

[JsonConverter(typeof(ModelConverter<GroupedSubscriptionUsage, GroupedSubscriptionUsageFromRaw>))]
public sealed record class GroupedSubscriptionUsage : ModelBase
{
    public required IReadOnlyList<GroupedSubscriptionUsageData> Data
    {
        get
        {
            return ModelBase.GetNotNullClass<List<GroupedSubscriptionUsageData>>(
                this.RawData,
                "data"
            );
        }
        init { ModelBase.Set(this._rawData, "data", value); }
    }

    public PaginationMetadata? PaginationMetadata
    {
        get
        {
            return ModelBase.GetNullableClass<PaginationMetadata>(
                this.RawData,
                "pagination_metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "pagination_metadata", value); }
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

    public GroupedSubscriptionUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedSubscriptionUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
    public GroupedSubscriptionUsage(List<GroupedSubscriptionUsageData> data)
        : this()
    {
        this.Data = data;
    }
}

class GroupedSubscriptionUsageFromRaw : IFromRaw<GroupedSubscriptionUsage>
{
    /// <inheritdoc/>
    public GroupedSubscriptionUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GroupedSubscriptionUsage.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<GroupedSubscriptionUsageData, GroupedSubscriptionUsageDataFromRaw>)
)]
public sealed record class GroupedSubscriptionUsageData : ModelBase
{
    public required GroupedSubscriptionUsageDataBillableMetric BillableMetric
    {
        get
        {
            return ModelBase.GetNotNullClass<GroupedSubscriptionUsageDataBillableMetric>(
                this.RawData,
                "billable_metric"
            );
        }
        init { ModelBase.Set(this._rawData, "billable_metric", value); }
    }

    public required MetricGroup MetricGroup
    {
        get { return ModelBase.GetNotNullClass<MetricGroup>(this.RawData, "metric_group"); }
        init { ModelBase.Set(this._rawData, "metric_group", value); }
    }

    public required IReadOnlyList<GroupedSubscriptionUsageDataUsage> Usage
    {
        get
        {
            return ModelBase.GetNotNullClass<List<GroupedSubscriptionUsageDataUsage>>(
                this.RawData,
                "usage"
            );
        }
        init { ModelBase.Set(this._rawData, "usage", value); }
    }

    public required ApiEnum<string, GroupedSubscriptionUsageDataViewMode> ViewMode
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, GroupedSubscriptionUsageDataViewMode>>(
                this.RawData,
                "view_mode"
            );
        }
        init { ModelBase.Set(this._rawData, "view_mode", value); }
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

    public GroupedSubscriptionUsageData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedSubscriptionUsageData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class GroupedSubscriptionUsageDataFromRaw : IFromRaw<GroupedSubscriptionUsageData>
{
    /// <inheritdoc/>
    public GroupedSubscriptionUsageData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GroupedSubscriptionUsageData.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        GroupedSubscriptionUsageDataBillableMetric,
        GroupedSubscriptionUsageDataBillableMetricFromRaw
    >)
)]
public sealed record class GroupedSubscriptionUsageDataBillableMetric : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public GroupedSubscriptionUsageDataBillableMetric() { }

    public GroupedSubscriptionUsageDataBillableMetric(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedSubscriptionUsageDataBillableMetric(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
    : IFromRaw<GroupedSubscriptionUsageDataBillableMetric>
{
    /// <inheritdoc/>
    public GroupedSubscriptionUsageDataBillableMetric FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GroupedSubscriptionUsageDataBillableMetric.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<MetricGroup, MetricGroupFromRaw>))]
public sealed record class MetricGroup : ModelBase
{
    public required string PropertyKey
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "property_key"); }
        init { ModelBase.Set(this._rawData, "property_key", value); }
    }

    public required string PropertyValue
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "property_value"); }
        init { ModelBase.Set(this._rawData, "property_value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PropertyKey;
        _ = this.PropertyValue;
    }

    public MetricGroup() { }

    public MetricGroup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MetricGroup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MetricGroupFromRaw.FromRawUnchecked"/>
    public static MetricGroup FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetricGroupFromRaw : IFromRaw<MetricGroup>
{
    /// <inheritdoc/>
    public MetricGroup FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MetricGroup.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        GroupedSubscriptionUsageDataUsage,
        GroupedSubscriptionUsageDataUsageFromRaw
    >)
)]
public sealed record class GroupedSubscriptionUsageDataUsage : ModelBase
{
    public required double Quantity
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "quantity"); }
        init { ModelBase.Set(this._rawData, "quantity", value); }
    }

    public required System::DateTimeOffset TimeframeEnd
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(
                this.RawData,
                "timeframe_end"
            );
        }
        init { ModelBase.Set(this._rawData, "timeframe_end", value); }
    }

    public required System::DateTimeOffset TimeframeStart
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(
                this.RawData,
                "timeframe_start"
            );
        }
        init { ModelBase.Set(this._rawData, "timeframe_start", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Quantity;
        _ = this.TimeframeEnd;
        _ = this.TimeframeStart;
    }

    public GroupedSubscriptionUsageDataUsage() { }

    public GroupedSubscriptionUsageDataUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GroupedSubscriptionUsageDataUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class GroupedSubscriptionUsageDataUsageFromRaw : IFromRaw<GroupedSubscriptionUsageDataUsage>
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
