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
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "amount"); }
        init { JsonModel.Set(this._rawData, "amount", value); }
    }

    public required SubLineItemGrouping? Grouping
    {
        get { return JsonModel.GetNullableClass<SubLineItemGrouping>(this.RawData, "grouping"); }
        init { JsonModel.Set(this._rawData, "grouping", value); }
    }

    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    public required double Quantity
    {
        get { return JsonModel.GetNotNullStruct<double>(this.RawData, "quantity"); }
        init { JsonModel.Set(this._rawData, "quantity", value); }
    }

    public required ApiEnum<string, OtherSubLineItemType> Type
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, OtherSubLineItemType>>(
                this.RawData,
                "type"
            );
        }
        init { JsonModel.Set(this._rawData, "type", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OtherSubLineItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
