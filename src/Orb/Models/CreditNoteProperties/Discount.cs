using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Models.CreditNoteProperties.DiscountProperties;
using System = System;

namespace Orb.Models.CreditNoteProperties;

[JsonConverter(typeof(ModelConverter<Discount>))]
public sealed record class Discount : ModelBase, IFromRaw<Discount>
{
    public required string AmountApplied
    {
        get
        {
            if (!this.Properties.TryGetValue("amount_applied", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "amount_applied",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("amount_applied");
        }
        set
        {
            this.Properties["amount_applied"] = JsonSerializer.SerializeToElement(
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
                throw new System::ArgumentOutOfRangeException(
                    "discount_type",
                    "Missing required argument"
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
                throw new System::ArgumentOutOfRangeException(
                    "percentage_discount",
                    "Missing required argument"
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

    public List<AppliesToPrice>? AppliesToPrices
    {
        get
        {
            if (!this.Properties.TryGetValue("applies_to_prices", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AppliesToPrice>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["applies_to_prices"] = JsonSerializer.SerializeToElement(
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
        _ = this.AmountApplied;
        this.DiscountType.Validate();
        _ = this.PercentageDiscount;
        foreach (var item in this.AppliesToPrices ?? [])
        {
            item.Validate();
        }
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

    public static Discount FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
