using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<TierSubLineItem, TierSubLineItemFromRaw>))]
public sealed record class TierSubLineItem : ModelBase
{
    /// <summary>
    /// The total amount for this sub line item.
    /// </summary>
    public required string Amount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "amount"); }
        init { ModelBase.Set(this._rawData, "amount", value); }
    }

    public required SubLineItemGrouping? Grouping
    {
        get { return ModelBase.GetNullableClass<SubLineItemGrouping>(this.RawData, "grouping"); }
        init { ModelBase.Set(this._rawData, "grouping", value); }
    }

    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    public required double Quantity
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "quantity"); }
        init { ModelBase.Set(this._rawData, "quantity", value); }
    }

    public required TierConfig TierConfig
    {
        get { return ModelBase.GetNotNullClass<TierConfig>(this.RawData, "tier_config"); }
        init { ModelBase.Set(this._rawData, "tier_config", value); }
    }

    public required ApiEnum<string, TierSubLineItemType> Type
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, TierSubLineItemType>>(
                this.RawData,
                "type"
            );
        }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Grouping?.Validate();
        _ = this.Name;
        _ = this.Quantity;
        this.TierConfig.Validate();
        this.Type.Validate();
    }

    public TierSubLineItem() { }

    public TierSubLineItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TierSubLineItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TierSubLineItemFromRaw.FromRawUnchecked"/>
    public static TierSubLineItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TierSubLineItemFromRaw : IFromRaw<TierSubLineItem>
{
    /// <inheritdoc/>
    public TierSubLineItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TierSubLineItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<TierConfig, TierConfigFromRaw>))]
public sealed record class TierConfig : ModelBase
{
    public required double FirstUnit
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "first_unit"); }
        init { ModelBase.Set(this._rawData, "first_unit", value); }
    }

    public required double? LastUnit
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "last_unit"); }
        init { ModelBase.Set(this._rawData, "last_unit", value); }
    }

    public required string UnitAmount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "unit_amount"); }
        init { ModelBase.Set(this._rawData, "unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FirstUnit;
        _ = this.LastUnit;
        _ = this.UnitAmount;
    }

    public TierConfig() { }

    public TierConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TierConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TierConfigFromRaw.FromRawUnchecked"/>
    public static TierConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TierConfigFromRaw : IFromRaw<TierConfig>
{
    /// <inheritdoc/>
    public TierConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TierConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TierSubLineItemTypeConverter))]
public enum TierSubLineItemType
{
    Tier,
}

sealed class TierSubLineItemTypeConverter : JsonConverter<TierSubLineItemType>
{
    public override TierSubLineItemType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tier" => TierSubLineItemType.Tier,
            _ => (TierSubLineItemType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TierSubLineItemType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TierSubLineItemType.Tier => "tier",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
