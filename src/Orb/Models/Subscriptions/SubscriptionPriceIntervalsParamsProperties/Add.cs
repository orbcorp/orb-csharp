using AddProperties = Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddProperties;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<Add>))]
public sealed record class Add : Orb::ModelBase, Orb::IFromRaw<Add>
{
    /// <summary>
    /// The start date of the price interval. This is the date that the price will
    /// start billing on the subscription.
    /// </summary>
    public required AddProperties::StartDate StartDate
    {
        get
        {
            if (!this.Properties.TryGetValue("start_date", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "start_date",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<AddProperties::StartDate>(element)
                ?? throw new System::ArgumentNullException("start_date");
        }
        set { this.Properties["start_date"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The definition of a new allocation price to create and add to the subscription.
    /// </summary>
    public Models::NewAllocationPrice? AllocationPrice
    {
        get
        {
            if (!this.Properties.TryGetValue("allocation_price", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Models::NewAllocationPrice?>(element);
        }
        set
        {
            this.Properties["allocation_price"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// A list of discounts to initialize on the price interval.
    /// </summary>
    public Generic::List<AddProperties::Discount>? Discounts
    {
        get
        {
            if (!this.Properties.TryGetValue("discounts", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<AddProperties::Discount>?>(
                element
            );
        }
        set { this.Properties["discounts"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The end date of the price interval. This is the date that the price will stop
    /// billing on the subscription.
    /// </summary>
    public AddProperties::EndDate? EndDate
    {
        get
        {
            if (!this.Properties.TryGetValue("end_date", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<AddProperties::EndDate?>(element);
        }
        set { this.Properties["end_date"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The external price id of the price to add to the subscription.
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this.Properties.TryGetValue("external_price_id", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["external_price_id"] = Json::JsonSerializer.SerializeToElement(value);
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
            if (!this.Properties.TryGetValue("filter", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["filter"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A list of fixed fee quantity transitions to initialize on the price interval.
    /// </summary>
    public Generic::List<AddProperties::FixedFeeQuantityTransition>? FixedFeeQuantityTransitions
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

            return Json::JsonSerializer.Deserialize<Generic::List<AddProperties::FixedFeeQuantityTransition>?>(
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
    /// The maximum amount that will be billed for this price interval for a given billing period.
    /// </summary>
    public double? MaximumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum_amount", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<double?>(element);
        }
        set { this.Properties["maximum_amount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The minimum amount that will be billed for this price interval for a given billing period.
    /// </summary>
    public double? MinimumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum_amount", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<double?>(element);
        }
        set { this.Properties["minimum_amount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The definition of a new price to create and add to the subscription.
    /// </summary>
    public AddProperties::Price? Price
    {
        get
        {
            if (!this.Properties.TryGetValue("price", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<AddProperties::Price?>(element);
        }
        set { this.Properties["price"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The id of the price to add to the subscription.
    /// </summary>
    public string? PriceID
    {
        get
        {
            if (!this.Properties.TryGetValue("price_id", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["price_id"] = Json::JsonSerializer.SerializeToElement(value); }
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
        this.StartDate.Validate();
        this.AllocationPrice?.Validate();
        foreach (var item in this.Discounts ?? [])
        {
            item.Validate();
        }
        this.EndDate?.Validate();
        _ = this.ExternalPriceID;
        _ = this.Filter;
        foreach (var item in this.FixedFeeQuantityTransitions ?? [])
        {
            item.Validate();
        }
        _ = this.MaximumAmount;
        _ = this.MinimumAmount;
        this.Price?.Validate();
        _ = this.PriceID;
        foreach (var item in this.UsageCustomerIDs ?? [])
        {
            _ = item;
        }
    }

    public Add() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    Add(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Add FromRawUnchecked(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        return new(properties);
    }
}
