using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using OtherSubLineItemProperties = Orb.Models.OtherSubLineItemProperties;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<OtherSubLineItem>))]
public sealed record class OtherSubLineItem : ModelBase, IFromRaw<OtherSubLineItem>
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

    public required ApiEnum<string, OtherSubLineItemProperties::Type> Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, OtherSubLineItemProperties::Type>>(
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

    public override void Validate()
    {
        _ = this.Amount;
        this.Grouping?.Validate();
        _ = this.Name;
        _ = this.Quantity;
        this.Type.Validate();
    }

    public OtherSubLineItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OtherSubLineItem(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static OtherSubLineItem FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
