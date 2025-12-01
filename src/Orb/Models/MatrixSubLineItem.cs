using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<MatrixSubLineItem, MatrixSubLineItemFromRaw>))]
public sealed record class MatrixSubLineItem : ModelBase
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

    public required SubLineItemMatrixConfig MatrixConfig
    {
        get
        {
            return ModelBase.GetNotNullClass<SubLineItemMatrixConfig>(
                this.RawData,
                "matrix_config"
            );
        }
        init { ModelBase.Set(this._rawData, "matrix_config", value); }
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

    public required ApiEnum<string, MatrixSubLineItemType> Type
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, MatrixSubLineItemType>>(
                this.RawData,
                "type"
            );
        }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// The scaled quantity for this line item for specific pricing structures
    /// </summary>
    public double? ScaledQuantity
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "scaled_quantity"); }
        init { ModelBase.Set(this._rawData, "scaled_quantity", value); }
    }

    public override void Validate()
    {
        _ = this.Amount;
        this.Grouping?.Validate();
        this.MatrixConfig.Validate();
        _ = this.Name;
        _ = this.Quantity;
        this.Type.Validate();
        _ = this.ScaledQuantity;
    }

    public MatrixSubLineItem() { }

    public MatrixSubLineItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatrixSubLineItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static MatrixSubLineItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MatrixSubLineItemFromRaw : IFromRaw<MatrixSubLineItem>
{
    public MatrixSubLineItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MatrixSubLineItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MatrixSubLineItemTypeConverter))]
public enum MatrixSubLineItemType
{
    Matrix,
}

sealed class MatrixSubLineItemTypeConverter : JsonConverter<MatrixSubLineItemType>
{
    public override MatrixSubLineItemType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "matrix" => MatrixSubLineItemType.Matrix,
            _ => (MatrixSubLineItemType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MatrixSubLineItemType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MatrixSubLineItemType.Matrix => "matrix",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
