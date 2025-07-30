using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DiscountProperties = Orb.Models.CreditNoteProperties.DiscountProperties;
using System = System;

namespace Orb.Models.CreditNoteProperties;

[JsonConverter(typeof(ModelConverter<Discount1>))]
public sealed record class Discount1 : ModelBase, IFromRaw<Discount1>
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

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("amount_applied");
        }
        set { this.Properties["amount_applied"] = JsonSerializer.SerializeToElement(value); }
    }

    public required DiscountProperties::DiscountType DiscountType
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_type", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "discount_type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<DiscountProperties::DiscountType>(element)
                ?? throw new System::ArgumentNullException("discount_type");
        }
        set { this.Properties["discount_type"] = JsonSerializer.SerializeToElement(value); }
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

            return JsonSerializer.Deserialize<double>(element);
        }
        set { this.Properties["percentage_discount"] = JsonSerializer.SerializeToElement(value); }
    }

    public List<DiscountProperties::AppliesToPrice>? AppliesToPrices
    {
        get
        {
            if (!this.Properties.TryGetValue("applies_to_prices", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<DiscountProperties::AppliesToPrice>?>(element);
        }
        set { this.Properties["applies_to_prices"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? Reason
    {
        get
        {
            if (!this.Properties.TryGetValue("reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["reason"] = JsonSerializer.SerializeToElement(value); }
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

    public Discount1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Discount1(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Discount1 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
