using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using MatrixSubLineItemProperties = Orb.Models.MatrixSubLineItemProperties;
using System = System;

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
                throw new System::ArgumentOutOfRangeException(
                    "amount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("amount");
        }
        set { this.Properties["amount"] = JsonSerializer.SerializeToElement(value); }
    }

    public required SubLineItemGrouping? Grouping
    {
        get
        {
            if (!this.Properties.TryGetValue("grouping", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "grouping",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<SubLineItemGrouping?>(element);
        }
        set { this.Properties["grouping"] = JsonSerializer.SerializeToElement(value); }
    }

    public required SubLineItemMatrixConfig MatrixConfig
    {
        get
        {
            if (!this.Properties.TryGetValue("matrix_config", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "matrix_config",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<SubLineItemMatrixConfig>(element)
                ?? throw new System::ArgumentNullException("matrix_config");
        }
        set { this.Properties["matrix_config"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("name");
        }
        set { this.Properties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    public required double Quantity
    {
        get
        {
            if (!this.Properties.TryGetValue("quantity", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "quantity",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<double>(element);
        }
        set { this.Properties["quantity"] = JsonSerializer.SerializeToElement(value); }
    }

    public required MatrixSubLineItemProperties::Type Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<MatrixSubLineItemProperties::Type>(element)
                ?? throw new System::ArgumentNullException("type");
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Amount;
        this.Grouping?.Validate();
        this.MatrixConfig.Validate();
        _ = this.Name;
        _ = this.Quantity;
        this.Type.Validate();
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
