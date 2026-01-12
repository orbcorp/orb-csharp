using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(JsonModelConverter<MatrixSubLineItem, MatrixSubLineItemFromRaw>))]
public sealed record class MatrixSubLineItem : JsonModel
{
    /// <summary>
    /// The total amount for this sub line item.
    /// </summary>
    public required string Amount
    {
        get { return this._rawData.GetNotNullClass<string>("amount"); }
        init { this._rawData.Set("amount", value); }
    }

    public required SubLineItemGrouping? Grouping
    {
        get { return this._rawData.GetNullableClass<SubLineItemGrouping>("grouping"); }
        init { this._rawData.Set("grouping", value); }
    }

    public required SubLineItemMatrixConfig MatrixConfig
    {
        get { return this._rawData.GetNotNullClass<SubLineItemMatrixConfig>("matrix_config"); }
        init { this._rawData.Set("matrix_config", value); }
    }

    public required string Name
    {
        get { return this._rawData.GetNotNullClass<string>("name"); }
        init { this._rawData.Set("name", value); }
    }

    public required double Quantity
    {
        get { return this._rawData.GetNotNullStruct<double>("quantity"); }
        init { this._rawData.Set("quantity", value); }
    }

    public required ApiEnum<string, MatrixSubLineItemType> Type
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, MatrixSubLineItemType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The scaled quantity for this line item for specific pricing structures
    /// </summary>
    public double? ScaledQuantity
    {
        get { return this._rawData.GetNullableStruct<double>("scaled_quantity"); }
        init { this._rawData.Set("scaled_quantity", value); }
    }

    /// <inheritdoc/>
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

    public MatrixSubLineItem(MatrixSubLineItem matrixSubLineItem)
        : base(matrixSubLineItem) { }

    public MatrixSubLineItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatrixSubLineItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MatrixSubLineItemFromRaw.FromRawUnchecked"/>
    public static MatrixSubLineItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MatrixSubLineItemFromRaw : IFromRawJson<MatrixSubLineItem>
{
    /// <inheritdoc/>
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
