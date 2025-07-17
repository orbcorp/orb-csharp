using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using EditProperties = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.EditProperties;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<Edit>))]
public sealed record class Edit : Orb::ModelBase, Orb::IFromRaw<Edit>
{
    /// <summary>
    /// The id of the price interval to edit.
    /// </summary>
    public required string PriceIntervalID
    {
        get
        {
            if (!this.Properties.TryGetValue("price_interval_id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "price_interval_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("price_interval_id");
        }
        set
        {
            this.Properties["price_interval_id"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The updated billing cycle day for this price interval. If not specified, the
    /// billing cycle day will not be updated. Note that overlapping price intervals
    /// must have the same billing cycle day.
    /// </summary>
    public long? BillingCycleDay
    {
        get
        {
            if (!this.Properties.TryGetValue("billing_cycle_day", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<long?>(element);
        }
        set
        {
            this.Properties["billing_cycle_day"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The updated end date of this price interval. If not specified, the end date
    /// will not be updated.
    /// </summary>
    public EditProperties::EndDate? EndDate
    {
        get
        {
            if (!this.Properties.TryGetValue("end_date", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<EditProperties::EndDate?>(element);
        }
        set { this.Properties["end_date"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An additional filter to apply to usage queries. This filter must be expressed
    /// as a boolean [computed property](/extensibility/advanced-metrics#computed-properties).
    /// If null, usage queries will not include any additional filter.
    /// </summary>
    public string? Filter
    {
        get
        {
            if (!this.Properties.TryGetValue("filter", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["filter"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A list of fixed fee quantity transitions to use for this price interval. Note
    /// that this list will overwrite all existing fixed fee quantity transitions on
    /// the price interval.
    /// </summary>
    public Generic::List<EditProperties::FixedFeeQuantityTransition>? FixedFeeQuantityTransitions
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "fixed_fee_quantity_transitions",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<EditProperties::FixedFeeQuantityTransition>?>(
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
    /// The updated start date of this price interval. If not specified, the start
    /// date will not be updated.
    /// </summary>
    public EditProperties::StartDate? StartDate
    {
        get
        {
            if (!this.Properties.TryGetValue("start_date", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<EditProperties::StartDate?>(element);
        }
        set { this.Properties["start_date"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A list of customer IDs whose usage events will be aggregated and billed under
    /// this subscription. By default, a subscription only considers usage events associated
    /// with its attached customer's customer_id. When usage_customer_ids is provided,
    /// the subscription includes usage events from the specified customers only. Provided
    /// usage_customer_ids must be either the customer for this subscription itself,
    /// or any of that customer's children.
    /// </summary>
    public Generic::List<string>? UsageCustomerIDs
    {
        get
        {
            if (!this.Properties.TryGetValue("usage_customer_ids", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<string>?>(element);
        }
        set
        {
            this.Properties["usage_customer_ids"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override void Validate()
    {
        _ = this.PriceIntervalID;
        _ = this.BillingCycleDay;
        this.EndDate?.Validate();
        _ = this.Filter;
        foreach (var item in this.FixedFeeQuantityTransitions ?? [])
        {
            item.Validate();
        }
        this.StartDate?.Validate();
        foreach (var item in this.UsageCustomerIDs ?? [])
        {
            _ = item;
        }
    }

    public Edit() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    Edit(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Edit FromRawUnchecked(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        return new(properties);
    }
}
