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

    public bool TryPickUngrouped([NotNullWhen(true)] out UngroupedSubscriptionUsage? value)
    {
        value = this.Value as UngroupedSubscriptionUsage;
        return value != null;
    }

    public bool TryPickGrouped([NotNullWhen(true)] out GroupedSubscriptionUsage? value)
    {
        value = this.Value as GroupedSubscriptionUsage;
        return value != null;
    }

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

    public required IReadOnlyList<Usage> Usage
    {
        get { return ModelBase.GetNotNullClass<List<Usage>>(this.RawData, "usage"); }
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

    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRaw<Data>
{
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

    public static BillableMetric FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BillableMetricFromRaw : IFromRaw<BillableMetric>
{
    public BillableMetric FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BillableMetric.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Usage, UsageFromRaw>))]
public sealed record class Usage : ModelBase
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

    public override void Validate()
    {
        _ = this.Quantity;
        _ = this.TimeframeEnd;
        _ = this.TimeframeStart;
    }

    public Usage() { }

    public Usage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Usage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageFromRaw : IFromRaw<Usage>
{
    public Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Usage.FromRawUnchecked(rawData);
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
    public required IReadOnlyList<DataModel> Data
    {
        get { return ModelBase.GetNotNullClass<List<DataModel>>(this.RawData, "data"); }
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

    public static GroupedSubscriptionUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public GroupedSubscriptionUsage(List<DataModel> data)
        : this()
    {
        this.Data = data;
    }
}

class GroupedSubscriptionUsageFromRaw : IFromRaw<GroupedSubscriptionUsage>
{
    public GroupedSubscriptionUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GroupedSubscriptionUsage.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<DataModel, DataModelFromRaw>))]
public sealed record class DataModel : ModelBase
{
    public required DataModelBillableMetric BillableMetric
    {
        get
        {
            return ModelBase.GetNotNullClass<DataModelBillableMetric>(
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

    public required IReadOnlyList<UsageModel> Usage
    {
        get { return ModelBase.GetNotNullClass<List<UsageModel>>(this.RawData, "usage"); }
        init { ModelBase.Set(this._rawData, "usage", value); }
    }

    public required ApiEnum<string, DataModelViewMode> ViewMode
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, DataModelViewMode>>(
                this.RawData,
                "view_mode"
            );
        }
        init { ModelBase.Set(this._rawData, "view_mode", value); }
    }

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

    public DataModel() { }

    public DataModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static DataModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataModelFromRaw : IFromRaw<DataModel>
{
    public DataModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DataModel.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<DataModelBillableMetric, DataModelBillableMetricFromRaw>))]
public sealed record class DataModelBillableMetric : ModelBase
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

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public DataModelBillableMetric() { }

    public DataModelBillableMetric(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataModelBillableMetric(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static DataModelBillableMetric FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataModelBillableMetricFromRaw : IFromRaw<DataModelBillableMetric>
{
    public DataModelBillableMetric FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DataModelBillableMetric.FromRawUnchecked(rawData);
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

    public static MetricGroup FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetricGroupFromRaw : IFromRaw<MetricGroup>
{
    public MetricGroup FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MetricGroup.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<UsageModel, UsageModelFromRaw>))]
public sealed record class UsageModel : ModelBase
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

    public override void Validate()
    {
        _ = this.Quantity;
        _ = this.TimeframeEnd;
        _ = this.TimeframeStart;
    }

    public UsageModel() { }

    public UsageModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static UsageModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageModelFromRaw : IFromRaw<UsageModel>
{
    public UsageModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UsageModel.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DataModelViewModeConverter))]
public enum DataModelViewMode
{
    Periodic,
    Cumulative,
}

sealed class DataModelViewModeConverter : JsonConverter<DataModelViewMode>
{
    public override DataModelViewMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "periodic" => DataModelViewMode.Periodic,
            "cumulative" => DataModelViewMode.Cumulative,
            _ => (DataModelViewMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataModelViewMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataModelViewMode.Periodic => "periodic",
                DataModelViewMode.Cumulative => "cumulative",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
