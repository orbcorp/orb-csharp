using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(JsonModelConverter<OtherSubLineItem, OtherSubLineItemFromRaw>))]
public sealed record class OtherSubLineItem : JsonModel
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

    public required ApiEnum<string, OtherSubLineItemType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, OtherSubLineItemType>>("type");
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
        this.Type.Validate();
    }

    public OtherSubLineItem() { }

    public OtherSubLineItem(OtherSubLineItem otherSubLineItem)
        : base(otherSubLineItem) { }

    public OtherSubLineItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OtherSubLineItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OtherSubLineItemFromRaw.FromRawUnchecked"/>
    public static OtherSubLineItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OtherSubLineItemFromRaw : IFromRawJson<OtherSubLineItem>
{
    /// <inheritdoc/>
    public OtherSubLineItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OtherSubLineItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(OtherSubLineItemTypeConverter))]
public enum OtherSubLineItemType
{
    Null,
}

sealed class OtherSubLineItemTypeConverter : JsonConverter<OtherSubLineItemType>
{
    public override OtherSubLineItemType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "'null'" => OtherSubLineItemType.Null,
            _ => (OtherSubLineItemType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OtherSubLineItemType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OtherSubLineItemType.Null => "'null'",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
