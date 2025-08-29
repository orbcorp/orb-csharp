using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EditProperties = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.EditProperties;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties;

[JsonConverter(typeof(ModelConverter<Edit>))]
public sealed record class Edit : ModelBase, IFromRaw<Edit>
{
    /// <summary>
    /// The id of the price interval to edit.
    /// </summary>
    public required string PriceIntervalID
    {
        get
        {
            if (!this.Properties.TryGetValue("price_interval_id", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "price_interval_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("price_interval_id");
        }
        set
        {
            this.Properties["price_interval_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("billing_cycle_day", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["billing_cycle_day"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("end_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<EditProperties::EndDate?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
            if (!this.Properties.TryGetValue("filter", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["filter"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A list of fixed fee quantity transitions to use for this price interval.
    /// Note that this list will overwrite all existing fixed fee quantity transitions
    /// on the price interval.
    /// </summary>
    public List<EditProperties::FixedFeeQuantityTransition>? FixedFeeQuantityTransitions
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "fixed_fee_quantity_transitions",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<List<EditProperties::FixedFeeQuantityTransition>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["fixed_fee_quantity_transitions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("start_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<EditProperties::StartDate?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["start_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A list of customer IDs whose usage events will be aggregated and billed under
    /// this subscription. By default, a subscription only considers usage events
    /// associated with its attached customer's customer_id. When usage_customer_ids
    /// is provided, the subscription includes usage events from the specified customers
    /// only. Provided usage_customer_ids must be either the customer for this subscription
    /// itself, or any of that customer's children.
    /// </summary>
    public List<string>? UsageCustomerIDs
    {
        get
        {
            if (!this.Properties.TryGetValue("usage_customer_ids", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["usage_customer_ids"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
    [SetsRequiredMembers]
    Edit(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Edit FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Edit(string priceIntervalID)
        : this()
    {
        this.PriceIntervalID = priceIntervalID;
    }
}
