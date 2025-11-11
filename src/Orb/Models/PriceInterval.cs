using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models;

/// <summary>
/// The Price Interval resource represents a period of time for which a price will
/// bill on a subscription. A subscription’s price intervals define its billing behavior.
/// </summary>
[JsonConverter(typeof(ModelConverter<PriceInterval>))]
public sealed record class PriceInterval : ModelBase, IFromRaw<PriceInterval>
{
    public required string ID
    {
        get
        {
            if (!this._properties.TryGetValue("id", out JsonElement element))
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
        init
        {
            this._properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The day of the month that Orb bills for this price
    /// </summary>
    public required long BillingCycleDay
    {
        get
        {
            if (!this._properties.TryGetValue("billing_cycle_day", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'billing_cycle_day' cannot be null",
                    new ArgumentOutOfRangeException(
                        "billing_cycle_day",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["billing_cycle_day"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// For in-arrears prices. If true, and the price interval ends mid-cycle, the
    /// final line item will be deferred to the next scheduled invoice instead of
    /// being billed mid-cycle.
    /// </summary>
    public required bool CanDeferBilling
    {
        get
        {
            if (!this._properties.TryGetValue("can_defer_billing", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'can_defer_billing' cannot be null",
                    new ArgumentOutOfRangeException(
                        "can_defer_billing",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["can_defer_billing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The end of the current billing period. This is an exclusive timestamp, such
    /// that the instant returned is exactly the end of the billing period. Set to
    /// null if this price interval is not currently active.
    /// </summary>
    public required DateTimeOffset? CurrentBillingPeriodEndDate
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "current_billing_period_end_date",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["current_billing_period_end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The start date of the current billing period. This is an inclusive timestamp;
    /// the instant returned is exactly the beginning of the billing period. Set to
    /// null if this price interval is not currently active.
    /// </summary>
    public required DateTimeOffset? CurrentBillingPeriodStartDate
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "current_billing_period_start_date",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["current_billing_period_start_date"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    /// <summary>
    /// The end date of the price interval. This is the date that Orb stops billing
    /// for this price.
    /// </summary>
    public required DateTimeOffset? EndDate
    {
        get
        {
            if (!this._properties.TryGetValue("end_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An additional filter to apply to usage queries.
    /// </summary>
    public required string? Filter
    {
        get
        {
            if (!this._properties.TryGetValue("filter", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["filter"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The fixed fee quantity transitions for this price interval. This is only
    /// relevant for fixed fees.
    /// </summary>
    public required List<FixedFeeQuantityTransition>? FixedFeeQuantityTransitions
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "fixed_fee_quantity_transitions",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<List<FixedFeeQuantityTransition>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["fixed_fee_quantity_transitions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The Price resource represents a price that can be billed on a subscription,
    /// resulting in a charge on an invoice in the form of an invoice line item.
    /// Prices take a quantity and determine an amount to bill.
    ///
    /// <para>Orb supports a few different pricing models out of the box. Each of
    /// these models is serialized differently in a given Price object. The model_type
    /// field determines the key for the configuration object that is present.</para>
    ///
    /// <para>For more on the types of prices, see [the core concepts documentation](/core-concepts#plan-and-price)</para>
    /// </summary>
    public required Price Price
    {
        get
        {
            if (!this._properties.TryGetValue("price", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'price' cannot be null",
                    new ArgumentOutOfRangeException("price", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Price>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'price' cannot be null",
                    new ArgumentNullException("price")
                );
        }
        init
        {
            this._properties["price"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The start date of the price interval. This is the date that Orb starts billing
    /// for this price.
    /// </summary>
    public required DateTimeOffset StartDate
    {
        get
        {
            if (!this._properties.TryGetValue("start_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'start_date' cannot be null",
                    new ArgumentOutOfRangeException("start_date", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTimeOffset>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["start_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A list of customer IDs whose usage events will be aggregated and billed under
    /// this price interval.
    /// </summary>
    public required List<string>? UsageCustomerIDs
    {
        get
        {
            if (!this._properties.TryGetValue("usage_customer_ids", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["usage_customer_ids"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.BillingCycleDay;
        _ = this.CanDeferBilling;
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
        _ = this.UsageCustomerIDs;
    }

    public PriceInterval() { }

    public PriceInterval(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceInterval(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static PriceInterval FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
