using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using MonetaryMinimumAdjustmentProperties = Orb.Models.MonetaryMinimumAdjustmentProperties;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<MonetaryMinimumAdjustment>))]
public sealed record class MonetaryMinimumAdjustment
    : ModelBase,
        IFromRaw<MonetaryMinimumAdjustment>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("id");
        }
        set { this.Properties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required MonetaryMinimumAdjustmentProperties::AdjustmentType AdjustmentType
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustment_type", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "adjustment_type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<MonetaryMinimumAdjustmentProperties::AdjustmentType>(
                    element
                ) ?? throw new System::ArgumentNullException("adjustment_type");
        }
        set { this.Properties["adjustment_type"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The value applied by an adjustment.
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

    /// <summary>
    /// The price IDs that this adjustment applies to.
    /// </summary>
    public required List<string> AppliesToPriceIDs
    {
        get
        {
            if (!this.Properties.TryGetValue("applies_to_price_ids", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "applies_to_price_ids",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<string>>(element)
                ?? throw new System::ArgumentNullException("applies_to_price_ids");
        }
        set { this.Properties["applies_to_price_ids"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The filters that determine which prices to apply this adjustment to.
    /// </summary>
    public required List<TransformPriceFilter> Filters
    {
        get
        {
            if (!this.Properties.TryGetValue("filters", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "filters",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<TransformPriceFilter>>(element)
                ?? throw new System::ArgumentNullException("filters");
        }
        set { this.Properties["filters"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// True for adjustments that apply to an entire invocice, false for adjustments
    /// that apply to only one price.
    /// </summary>
    public required bool IsInvoiceLevel
    {
        get
        {
            if (!this.Properties.TryGetValue("is_invoice_level", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "is_invoice_level",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<bool>(element);
        }
        set { this.Properties["is_invoice_level"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The item ID that revenue from this minimum will be attributed to.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this.Properties.TryGetValue("item_id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "item_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("item_id");
        }
        set { this.Properties["item_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The minimum amount to charge in a given billing period for the prices this adjustment
    /// applies to.
    /// </summary>
    public required string MinimumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum_amount", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "minimum_amount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("minimum_amount");
        }
        set { this.Properties["minimum_amount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The reason for the adjustment.
    /// </summary>
    public required string? Reason
    {
        get
        {
            if (!this.Properties.TryGetValue("reason", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "reason",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["reason"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The adjustment id this adjustment replaces. This adjustment will take the place
    /// of the replaced adjustment in plan version migrations.
    /// </summary>
    public required string? ReplacesAdjustmentID
    {
        get
        {
            if (!this.Properties.TryGetValue("replaces_adjustment_id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "replaces_adjustment_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["replaces_adjustment_id"] = JsonSerializer.SerializeToElement(value);
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        this.AdjustmentType.Validate();
        _ = this.Amount;
        foreach (var item in this.AppliesToPriceIDs)
        {
            _ = item;
        }
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.IsInvoiceLevel;
        _ = this.ItemID;
        _ = this.MinimumAmount;
        _ = this.Reason;
        _ = this.ReplacesAdjustmentID;
    }

    public MonetaryMinimumAdjustment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MonetaryMinimumAdjustment(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MonetaryMinimumAdjustment FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
