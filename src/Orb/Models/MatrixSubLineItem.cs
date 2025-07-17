using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using MatrixSubLineItemProperties = Orb.Models.MatrixSubLineItemProperties;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<MatrixSubLineItem>))]
public sealed record class MatrixSubLineItem : Orb::ModelBase, Orb::IFromRaw<MatrixSubLineItem>
{
    /// <summary>
    /// The total amount for this sub line item.
    /// </summary>
    public required string Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "amount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("amount");
        }
        set { this.Properties["amount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required SubLineItemGrouping? Grouping
    {
        get
        {
            if (!this.Properties.TryGetValue("grouping", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "grouping",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<SubLineItemGrouping?>(element);
        }
        set { this.Properties["grouping"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required SubLineItemMatrixConfig MatrixConfig
    {
        get
        {
            if (!this.Properties.TryGetValue("matrix_config", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "matrix_config",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<SubLineItemMatrixConfig>(element)
                ?? throw new System::ArgumentNullException("matrix_config");
        }
        set { this.Properties["matrix_config"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("name", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("name");
        }
        set { this.Properties["name"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required double Quantity
    {
        get
        {
            if (!this.Properties.TryGetValue("quantity", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "quantity",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<double>(element);
        }
        set { this.Properties["quantity"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required MatrixSubLineItemProperties::Type Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return Json::JsonSerializer.Deserialize<MatrixSubLineItemProperties::Type>(element)
                ?? throw new System::ArgumentNullException("type");
        }
        set { this.Properties["type"] = Json::JsonSerializer.SerializeToElement(value); }
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
    [CodeAnalysis::SetsRequiredMembers]
    MatrixSubLineItem(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MatrixSubLineItem FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
