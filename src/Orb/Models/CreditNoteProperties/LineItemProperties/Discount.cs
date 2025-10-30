using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.CreditNoteProperties.LineItemProperties.DiscountProperties;

namespace Orb.Models.CreditNoteProperties.LineItemProperties;

[JsonConverter(
    typeof(ModelConverter<global::Orb.Models.CreditNoteProperties.LineItemProperties.Discount>)
)]
public sealed record class Discount
    : ModelBase,
        IFromRaw<global::Orb.Models.CreditNoteProperties.LineItemProperties.Discount>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentNullException("id")
                );
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string AmountApplied
    {
        get
        {
            if (!this.Properties.TryGetValue("amount_applied", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount_applied' cannot be null",
                    new ArgumentOutOfRangeException("amount_applied", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'amount_applied' cannot be null",
                    new ArgumentNullException("amount_applied")
                );
        }
        set
        {
            this.Properties["amount_applied"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required List<string> AppliesToPriceIDs
    {
        get
        {
            if (!this.Properties.TryGetValue("applies_to_price_ids", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'applies_to_price_ids' cannot be null",
                    new ArgumentOutOfRangeException(
                        "applies_to_price_ids",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'applies_to_price_ids' cannot be null",
                    new ArgumentNullException("applies_to_price_ids")
                );
        }
        set
        {
            this.Properties["applies_to_price_ids"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, DiscountType> DiscountType
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'discount_type' cannot be null",
                    new ArgumentOutOfRangeException("discount_type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, DiscountType>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["discount_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required double PercentageDiscount
    {
        get
        {
            if (!this.Properties.TryGetValue("percentage_discount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'percentage_discount' cannot be null",
                    new ArgumentOutOfRangeException(
                        "percentage_discount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["percentage_discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? AmountDiscount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount_discount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["amount_discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Reason
    {
        get
        {
            if (!this.Properties.TryGetValue("reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["reason"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.AmountApplied;
        foreach (var item in this.AppliesToPriceIDs)
        {
            _ = item;
        }
        this.DiscountType.Validate();
        _ = this.PercentageDiscount;
        _ = this.AmountDiscount;
        _ = this.Reason;
    }

    public Discount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Discount(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static global::Orb.Models.CreditNoteProperties.LineItemProperties.Discount FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
