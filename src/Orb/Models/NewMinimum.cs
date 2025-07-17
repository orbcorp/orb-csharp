using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using NewMinimumProperties = Orb.Models.NewMinimumProperties;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<NewMinimum>))]
public sealed record class NewMinimum : Orb::ModelBase, Orb::IFromRaw<NewMinimum>
{
    public required NewMinimumProperties::AdjustmentType AdjustmentType
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustment_type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "adjustment_type",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<NewMinimumProperties::AdjustmentType>(element)
                ?? throw new System::ArgumentNullException("adjustment_type");
        }
        set { this.Properties["adjustment_type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The item ID that revenue from this minimum will be attributed to.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this.Properties.TryGetValue("item_id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "item_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("item_id");
        }
        set { this.Properties["item_id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string MinimumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum_amount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "minimum_amount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("minimum_amount");
        }
        set { this.Properties["minimum_amount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// If set, the adjustment will apply to every price on the subscription.
    /// </summary>
    public NewMinimumProperties::AppliesToAll? AppliesToAll
    {
        get
        {
            if (!this.Properties.TryGetValue("applies_to_all", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<NewMinimumProperties::AppliesToAll?>(element);
        }
        set { this.Properties["applies_to_all"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The set of item IDs to which this adjustment applies.
    /// </summary>
    public Generic::List<string>? AppliesToItemIDs
    {
        get
        {
            if (!this.Properties.TryGetValue("applies_to_item_ids", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<string>?>(element);
        }
        set
        {
            this.Properties["applies_to_item_ids"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The set of price IDs to which this adjustment applies.
    /// </summary>
    public Generic::List<string>? AppliesToPriceIDs
    {
        get
        {
            if (!this.Properties.TryGetValue("applies_to_price_ids", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<string>?>(element);
        }
        set
        {
            this.Properties["applies_to_price_ids"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// If set, only prices in the specified currency will have the adjustment applied.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["currency"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A list of filters that determine which prices this adjustment will apply to.
    /// </summary>
    public Generic::List<TransformPriceFilter>? Filters
    {
        get
        {
            if (!this.Properties.TryGetValue("filters", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<TransformPriceFilter>?>(element);
        }
        set { this.Properties["filters"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// When false, this adjustment will be applied to a single price. Otherwise, it
    /// will be applied at the invoice level, possibly to multiple prices.
    /// </summary>
    public bool? IsInvoiceLevel
    {
        get
        {
            if (!this.Properties.TryGetValue("is_invoice_level", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<bool?>(element);
        }
        set
        {
            this.Properties["is_invoice_level"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// If set, only prices of the specified type will have the adjustment applied.
    /// </summary>
    public NewMinimumProperties::PriceType? PriceType
    {
        get
        {
            if (!this.Properties.TryGetValue("price_type", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<NewMinimumProperties::PriceType?>(element);
        }
        set { this.Properties["price_type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.AdjustmentType.Validate();
        _ = this.ItemID;
        _ = this.MinimumAmount;
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

    public NewMinimum() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    NewMinimum(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static NewMinimum FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
