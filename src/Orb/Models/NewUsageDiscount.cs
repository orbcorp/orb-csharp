using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using NewUsageDiscountProperties = Orb.Models.NewUsageDiscountProperties;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<NewUsageDiscount>))]
public sealed record class NewUsageDiscount : ModelBase, IFromRaw<NewUsageDiscount>
{
    public required NewUsageDiscountProperties::AdjustmentType AdjustmentType
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustment_type", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "adjustment_type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<NewUsageDiscountProperties::AdjustmentType>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("adjustment_type");
        }
        set { this.Properties["adjustment_type"] = JsonSerializer.SerializeToElement(value); }
    }

    public required double UsageDiscount
    {
        get
        {
            if (!this.Properties.TryGetValue("usage_discount", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "usage_discount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["usage_discount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// If set, the adjustment will apply to every price on the subscription.
    /// </summary>
    public NewUsageDiscountProperties::AppliesToAll? AppliesToAll
    {
        get
        {
            if (!this.Properties.TryGetValue("applies_to_all", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewUsageDiscountProperties::AppliesToAll?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["applies_to_all"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The set of item IDs to which this adjustment applies.
    /// </summary>
    public List<string>? AppliesToItemIDs
    {
        get
        {
            if (!this.Properties.TryGetValue("applies_to_item_ids", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["applies_to_item_ids"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The set of price IDs to which this adjustment applies.
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
    /// If set, only prices in the specified currency will have the adjustment applied.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["currency"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A list of filters that determine which prices this adjustment will apply to.
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

    /// <summary>
    /// When false, this adjustment will be applied to a single price. Otherwise, it
    /// will be applied at the invoice level, possibly to multiple prices.
    /// </summary>
    public bool? IsInvoiceLevel
    {
        get
        {
            if (!this.Properties.TryGetValue("is_invoice_level", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["is_invoice_level"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// If set, only prices of the specified type will have the adjustment applied.
    /// </summary>
    public NewUsageDiscountProperties::PriceType? PriceType
    {
        get
        {
            if (!this.Properties.TryGetValue("price_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<NewUsageDiscountProperties::PriceType?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["price_type"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.AdjustmentType.Validate();
        _ = this.UsageDiscount;
        this.AppliesToAll?.Validate();
        foreach (var item in this.AppliesToItemIDs ?? [])
        {
            _ = item;
        }
        foreach (var item in this.AppliesToPriceIDs ?? [])
        {
            _ = item;
        }
        _ = this.Currency;
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
        _ = this.IsInvoiceLevel;
        this.PriceType?.Validate();
    }

    public NewUsageDiscount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewUsageDiscount(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static NewUsageDiscount FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
