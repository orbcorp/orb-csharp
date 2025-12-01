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
        get
        {
            if (!this._rawData.TryGetValue("amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new System::ArgumentOutOfRangeException("amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new System::ArgumentNullException("amount")
                );
        }
        init
        {
            this._rawData["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required SubLineItemGrouping? Grouping
    {
        get
        {
            if (!this._rawData.TryGetValue("grouping", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<SubLineItemGrouping?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["grouping"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required SubLineItemMatrixConfig MatrixConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("matrix_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'matrix_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "matrix_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<SubLineItemMatrixConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'matrix_config' cannot be null",
                    new System::ArgumentNullException("matrix_config")
                );
        }
        init
        {
            this._rawData["matrix_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Name
    {
        get
        {
            if (!this._rawData.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        init
        {
            this._rawData["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required double Quantity
    {
        get
        {
            if (!this._rawData.TryGetValue("quantity", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'quantity' cannot be null",
                    new System::ArgumentOutOfRangeException("quantity", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, MatrixSubLineItemType> Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, MatrixSubLineItemType>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentNullException("type")
                );
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The scaled quantity for this line item for specific pricing structures
    /// </summary>
    public double? ScaledQuantity
    {
        get
        {
            if (!this._rawData.TryGetValue("scaled_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["scaled_quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
