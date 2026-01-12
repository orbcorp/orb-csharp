using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(JsonModelConverter<TierSubLineItem, TierSubLineItemFromRaw>))]
public sealed record class TierSubLineItem : JsonModel
{
    /// <summary>
    /// The total amount for this sub line item.
    /// </summary>
    public required string Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    public required SubLineItemGrouping? Grouping
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SubLineItemGrouping>("grouping");
        }
        init { this._rawData.Set("grouping", value); }
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

    public required double Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("quantity");
        }
        init { this._rawData.Set("quantity", value); }
    }

    public required TierConfig TierConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TierConfig>("tier_config");
        }
        init { this._rawData.Set("tier_config", value); }
    }

    public required ApiEnum<string, TierSubLineItemType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TierSubLineItemType>>("type");
        }
        init { this._rawData.Set("type", value); }
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

    public TierSubLineItem(TierSubLineItem tierSubLineItem)
        : base(tierSubLineItem) { }

    public TierSubLineItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TierSubLineItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TierSubLineItemFromRaw.FromRawUnchecked"/>
    public static TierSubLineItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TierSubLineItemFromRaw : IFromRawJson<TierSubLineItem>
{
    /// <inheritdoc/>
    public TierSubLineItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TierSubLineItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TierConfig, TierConfigFromRaw>))]
public sealed record class TierConfig : JsonModel
{
    public required double FirstUnit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("first_unit");
        }
        init { this._rawData.Set("first_unit", value); }
    }

    public required double? LastUnit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("last_unit");
        }
        init { this._rawData.Set("last_unit", value); }
    }

    public required string UnitAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unit_amount");
        }
        init { this._rawData.Set("unit_amount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FirstUnit;
        _ = this.LastUnit;
        _ = this.UnitAmount;
    }

    public TierConfig() { }

    public TierConfig(TierConfig tierConfig)
        : base(tierConfig) { }

    public TierConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TierConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TierConfigFromRaw.FromRawUnchecked"/>
    public static TierConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TierConfigFromRaw : IFromRawJson<TierConfig>
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
