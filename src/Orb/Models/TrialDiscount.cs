using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;
using TrialDiscountProperties = Orb.Models.TrialDiscountProperties;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<TrialDiscount>))]
public sealed record class TrialDiscount : ModelBase, IFromRaw<TrialDiscount>
{
    public required TrialDiscountProperties::DiscountType DiscountType
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_type", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "discount_type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<TrialDiscountProperties::DiscountType>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("discount_type");
        }
        set { this.Properties["discount_type"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// List of price_ids that this discount applies to. For plan/plan phase discounts,
    /// this can be a subset of prices.
    /// </summary>
    public List<string>? AppliesToPriceIDs
    {
        get
        {
            if (!this.Properties.TryGetValue("applies_to_price_ids", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["applies_to_price_ids"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The filters that determine which prices to apply this discount to.
    /// </summary>
    public List<TransformPriceFilter>? Filters
    {
        get
        {
            if (!this.Properties.TryGetValue("filters", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<TransformPriceFilter>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["filters"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? Reason
    {
        get
        {
            if (!this.Properties.TryGetValue("reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["reason"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Only available if discount_type is `trial`
    /// </summary>
    public string? TrialAmountDiscount
    {
        get
        {
            if (!this.Properties.TryGetValue("trial_amount_discount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["trial_amount_discount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Only available if discount_type is `trial`
    /// </summary>
    public double? TrialPercentageDiscount
    {
        get
        {
            if (!this.Properties.TryGetValue("trial_percentage_discount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["trial_percentage_discount"] = JsonSerializer.SerializeToElement(value);
        }
    }

    public override void Validate()
    {
        this.DiscountType.Validate();
        foreach (var item in this.AppliesToPriceIDs ?? [])
        {
            _ = item;
        }
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
        _ = this.Reason;
        _ = this.TrialAmountDiscount;
        _ = this.TrialPercentageDiscount;
    }

    public TrialDiscount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrialDiscount(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TrialDiscount FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    public TrialDiscount(TrialDiscountProperties::DiscountType discountType)
    {
        this.DiscountType = discountType;
    }
}
