using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using PlanPhaseAmountDiscountAdjustmentProperties = Orb.Models.PlanPhaseAmountDiscountAdjustmentProperties;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<PlanPhaseAmountDiscountAdjustment>))]
public sealed record class PlanPhaseAmountDiscountAdjustment
    : Orb::ModelBase,
        Orb::IFromRaw<PlanPhaseAmountDiscountAdjustment>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("id", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("id");
        }
        set { this.Properties["id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required PlanPhaseAmountDiscountAdjustmentProperties::AdjustmentType AdjustmentType
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustment_type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "adjustment_type",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<PlanPhaseAmountDiscountAdjustmentProperties::AdjustmentType>(
                    element
                ) ?? throw new System::ArgumentNullException("adjustment_type");
        }
        set { this.Properties["adjustment_type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The amount by which to discount the prices this adjustment applies to in a given
    /// billing period.
    /// </summary>
    public required string AmountDiscount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount_discount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "amount_discount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("amount_discount");
        }
        set { this.Properties["amount_discount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The price IDs that this adjustment applies to.
    /// </summary>
    public required Generic::List<string> AppliesToPriceIDs
    {
        get
        {
            if (!this.Properties.TryGetValue("applies_to_price_ids", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "applies_to_price_ids",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<string>>(element)
                ?? throw new System::ArgumentNullException("applies_to_price_ids");
        }
        set
        {
            this.Properties["applies_to_price_ids"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// The filters that determine which prices to apply this adjustment to.
    /// </summary>
    public required Generic::List<TransformPriceFilter> Filters
    {
        get
        {
            if (!this.Properties.TryGetValue("filters", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "filters",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<TransformPriceFilter>>(element)
                ?? throw new System::ArgumentNullException("filters");
        }
        set { this.Properties["filters"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// True for adjustments that apply to an entire invocice, false for adjustments
    /// that apply to only one price.
    /// </summary>
    public required bool IsInvoiceLevel
    {
        get
        {
            if (!this.Properties.TryGetValue("is_invoice_level", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "is_invoice_level",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<bool>(element);
        }
        set
        {
            this.Properties["is_invoice_level"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The plan phase in which this adjustment is active.
    /// </summary>
    public required long? PlanPhaseOrder
    {
        get
        {
            if (!this.Properties.TryGetValue("plan_phase_order", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "plan_phase_order",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long?>(element);
        }
        set
        {
            this.Properties["plan_phase_order"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The reason for the adjustment.
    /// </summary>
    public required string? Reason
    {
        get
        {
            if (!this.Properties.TryGetValue("reason", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "reason",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["reason"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The adjustment id this adjustment replaces. This adjustment will take the place
    /// of the replaced adjustment in plan version migrations.
    /// </summary>
    public required string? ReplacesAdjustmentID
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "replaces_adjustment_id",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "replaces_adjustment_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["replaces_adjustment_id"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        this.AdjustmentType.Validate();
        _ = this.AmountDiscount;
        foreach (var item in this.AppliesToPriceIDs)
        {
            _ = item;
        }
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.IsInvoiceLevel;
        _ = this.PlanPhaseOrder;
        _ = this.Reason;
        _ = this.ReplacesAdjustmentID;
    }

    public PlanPhaseAmountDiscountAdjustment() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    PlanPhaseAmountDiscountAdjustment(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PlanPhaseAmountDiscountAdjustment FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
