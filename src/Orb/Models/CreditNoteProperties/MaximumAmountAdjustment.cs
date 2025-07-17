using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using MaximumAmountAdjustmentProperties = Orb.Models.CreditNoteProperties.MaximumAmountAdjustmentProperties;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.CreditNoteProperties;

/// <summary>
/// The maximum amount applied on the original invoice
/// </summary>
[Serialization::JsonConverter(typeof(Orb::ModelConverter<MaximumAmountAdjustment>))]
public sealed record class MaximumAmountAdjustment
    : Orb::ModelBase,
        Orb::IFromRaw<MaximumAmountAdjustment>
{
    public required string AmountApplied
    {
        get
        {
            if (!this.Properties.TryGetValue("amount_applied", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "amount_applied",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("amount_applied");
        }
        set { this.Properties["amount_applied"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required MaximumAmountAdjustmentProperties::DiscountType DiscountType
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "discount_type",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<MaximumAmountAdjustmentProperties::DiscountType>(
                    element
                ) ?? throw new System::ArgumentNullException("discount_type");
        }
        set { this.Properties["discount_type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required double PercentageDiscount
    {
        get
        {
            if (!this.Properties.TryGetValue("percentage_discount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "percentage_discount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<double>(element);
        }
        set
        {
            this.Properties["percentage_discount"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public Generic::List<MaximumAmountAdjustmentProperties::AppliesToPrice>? AppliesToPrices
    {
        get
        {
            if (!this.Properties.TryGetValue("applies_to_prices", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<MaximumAmountAdjustmentProperties::AppliesToPrice>?>(
                element
            );
        }
        set
        {
            this.Properties["applies_to_prices"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public string? Reason
    {
        get
        {
            if (!this.Properties.TryGetValue("reason", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["reason"] = Json::JsonSerializer.SerializeToElement(value); }
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

    public MaximumAmountAdjustment() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    MaximumAmountAdjustment(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MaximumAmountAdjustment FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
