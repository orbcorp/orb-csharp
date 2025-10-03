using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using MatrixSubLineItemProperties = Orb.Models.MatrixSubLineItemProperties;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<MatrixSubLineItem>))]
public sealed record class MatrixSubLineItem : ModelBase, IFromRaw<MatrixSubLineItem>
{
    /// <summary>
    /// The total amount for this sub line item.
    /// </summary>
    public required string Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new ArgumentOutOfRangeException("amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new ArgumentNullException("amount")
                );
        }
        set
        {
            this.Properties["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required SubLineItemGrouping? Grouping
    {
        get
        {
            if (!this.Properties.TryGetValue("grouping", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<SubLineItemGrouping?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["grouping"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required SubLineItemMatrixConfig MatrixConfig
    {
        get
        {
            if (!this.Properties.TryGetValue("matrix_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'matrix_config' cannot be null",
                    new ArgumentOutOfRangeException("matrix_config", "Missing required argument")
                );

            return JsonSerializer.Deserialize<SubLineItemMatrixConfig>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'matrix_config' cannot be null",
                    new ArgumentNullException("matrix_config")
                );
        }
        set
        {
            this.Properties["matrix_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentNullException("name")
                );
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required double Quantity
    {
        get
        {
            if (!this.Properties.TryGetValue("quantity", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'quantity' cannot be null",
                    new ArgumentOutOfRangeException("quantity", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, MatrixSubLineItemProperties::Type> Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, MatrixSubLineItemProperties::Type>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("scaled_quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["scaled_quantity"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatrixSubLineItem(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MatrixSubLineItem FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
