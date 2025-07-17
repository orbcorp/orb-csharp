using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

/// <summary>
/// The Price Interval resource represents a period of time for which a price will
/// bill on a subscription. A subscription’s price intervals define its billing behavior.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::ModelConverter<PriceInterval>))]
public sealed record class PriceInterval : Orb::ModelBase, Orb::IFromRaw<PriceInterval>
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

    /// <summary>
    /// The day of the month that Orb bills for this price
    /// </summary>
    public required long BillingCycleDay
    {
        get
        {
            if (!this.Properties.TryGetValue("billing_cycle_day", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "billing_cycle_day",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long>(element);
        }
        set
        {
            this.Properties["billing_cycle_day"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The end of the current billing period. This is an exclusive timestamp, such
    /// that the instant returned is exactly the end of the billing period. Set to
    /// null if this price interval is not currently active.
    /// </summary>
    public required System::DateTime? CurrentBillingPeriodEndDate
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "current_billing_period_end_date",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "current_billing_period_end_date",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.Properties["current_billing_period_end_date"] =
                Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The start date of the current billing period. This is an inclusive timestamp;
    /// the instant returned is exactly the beginning of the billing period. Set to
    /// null if this price interval is not currently active.
    /// </summary>
    public required System::DateTime? CurrentBillingPeriodStartDate
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "current_billing_period_start_date",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "current_billing_period_start_date",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set
        {
            this.Properties["current_billing_period_start_date"] =
                Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The end date of the price interval. This is the date that Orb stops billing
    /// for this price.
    /// </summary>
    public required System::DateTime? EndDate
    {
        get
        {
            if (!this.Properties.TryGetValue("end_date", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "end_date",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set { this.Properties["end_date"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An additional filter to apply to usage queries.
    /// </summary>
    public required string? Filter
    {
        get
        {
            if (!this.Properties.TryGetValue("filter", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "filter",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["filter"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The fixed fee quantity transitions for this price interval. This is only relevant
    /// for fixed fees.
    /// </summary>
    public required Generic::List<FixedFeeQuantityTransition>? FixedFeeQuantityTransitions
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "fixed_fee_quantity_transitions",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "fixed_fee_quantity_transitions",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<FixedFeeQuantityTransition>?>(
                element
            );
        }
        set
        {
            this.Properties["fixed_fee_quantity_transitions"] =
                Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The Price resource represents a price that can be billed on a subscription,
    /// resulting in a charge on an invoice in the form of an invoice line item. Prices
    /// take a quantity and determine an amount to bill.
    ///
    /// Orb supports a few different pricing models out of the box. Each of these models
    /// is serialized differently in a given Price object. The model_type field determines
    /// the key for the configuration object that is present.
    ///
    /// For more on the types of prices, see [the core concepts documentation](/core-concepts#plan-and-price)
    /// </summary>
    public required Price Price
    {
        get
        {
            if (!this.Properties.TryGetValue("price", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("price", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Price>(element)
                ?? throw new System::ArgumentNullException("price");
        }
        set { this.Properties["price"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The start date of the price interval. This is the date that Orb starts billing
    /// for this price.
    /// </summary>
    public required System::DateTime StartDate
    {
        get
        {
            if (!this.Properties.TryGetValue("start_date", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "start_date",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set { this.Properties["start_date"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A list of customer IDs whose usage events will be aggregated and billed under
    /// this price interval.
    /// </summary>
    public required Generic::List<string>? UsageCustomerIDs
    {
        get
        {
            if (!this.Properties.TryGetValue("usage_customer_ids", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "usage_customer_ids",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<string>?>(element);
        }
        set
        {
            this.Properties["usage_customer_ids"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.BillingCycleDay;
        _ = this.CurrentBillingPeriodEndDate;
        _ = this.CurrentBillingPeriodStartDate;
        _ = this.EndDate;
        _ = this.Filter;
        foreach (var item in this.FixedFeeQuantityTransitions ?? [])
        {
            item.Validate();
        }
        this.Price.Validate();
        _ = this.StartDate;
        foreach (var item in this.UsageCustomerIDs ?? [])
        {
            _ = item;
        }
    }

    public PriceInterval() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    PriceInterval(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PriceInterval FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
