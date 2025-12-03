using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

/// <summary>
/// The Price Interval resource represents a period of time for which a price will
/// bill on a subscription. A subscription’s price intervals define its billing behavior.
/// </summary>
[JsonConverter(typeof(ModelConverter<PriceInterval, PriceIntervalFromRaw>))]
public sealed record class PriceInterval : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// The day of the month that Orb bills for this price
    /// </summary>
    public required long BillingCycleDay
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "billing_cycle_day"); }
        init { ModelBase.Set(this._rawData, "billing_cycle_day", value); }
    }

    /// <summary>
    /// For in-arrears prices. If true, and the price interval ends mid-cycle, the
    /// final line item will be deferred to the next scheduled invoice instead of
    /// being billed mid-cycle.
    /// </summary>
    public required bool CanDeferBilling
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "can_defer_billing"); }
        init { ModelBase.Set(this._rawData, "can_defer_billing", value); }
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
            return ModelBase.GetNullableStruct<DateTimeOffset>(
                this.RawData,
                "current_billing_period_end_date"
            );
        }
        init { ModelBase.Set(this._rawData, "current_billing_period_end_date", value); }
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
            return ModelBase.GetNullableStruct<DateTimeOffset>(
                this.RawData,
                "current_billing_period_start_date"
            );
        }
        init { ModelBase.Set(this._rawData, "current_billing_period_start_date", value); }
    }

    /// <summary>
    /// The end date of the price interval. This is the date that Orb stops billing
    /// for this price.
    /// </summary>
    public required DateTimeOffset? EndDate
    {
        get { return ModelBase.GetNullableStruct<DateTimeOffset>(this.RawData, "end_date"); }
        init { ModelBase.Set(this._rawData, "end_date", value); }
    }

    /// <summary>
    /// An additional filter to apply to usage queries.
    /// </summary>
    public required string? Filter
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "filter"); }
        init { ModelBase.Set(this._rawData, "filter", value); }
    }

    /// <summary>
    /// The fixed fee quantity transitions for this price interval. This is only
    /// relevant for fixed fees.
    /// </summary>
    public required IReadOnlyList<FixedFeeQuantityTransition>? FixedFeeQuantityTransitions
    {
        get
        {
            return ModelBase.GetNullableClass<List<FixedFeeQuantityTransition>>(
                this.RawData,
                "fixed_fee_quantity_transitions"
            );
        }
        init { ModelBase.Set(this._rawData, "fixed_fee_quantity_transitions", value); }
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
        get { return ModelBase.GetNotNullClass<Price>(this.RawData, "price"); }
        init { ModelBase.Set(this._rawData, "price", value); }
    }

    /// <summary>
    /// The start date of the price interval. This is the date that Orb starts billing
    /// for this price.
    /// </summary>
    public required DateTimeOffset StartDate
    {
        get { return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawData, "start_date"); }
        init { ModelBase.Set(this._rawData, "start_date", value); }
    }

    /// <summary>
    /// A list of customer IDs whose usage events will be aggregated and billed under
    /// this price interval.
    /// </summary>
    public required IReadOnlyList<string>? UsageCustomerIDs
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "usage_customer_ids"); }
        init { ModelBase.Set(this._rawData, "usage_customer_ids", value); }
    }

    /// <inheritdoc/>
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

    public PriceInterval(PriceInterval priceInterval)
        : base(priceInterval) { }

    public PriceInterval(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceInterval(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PriceIntervalFromRaw.FromRawUnchecked"/>
    public static PriceInterval FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PriceIntervalFromRaw : IFromRaw<PriceInterval>
{
    /// <inheritdoc/>
    public PriceInterval FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PriceInterval.FromRawUnchecked(rawData);
}
