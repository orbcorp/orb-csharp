using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<MinimumInterval>))]
public sealed record class MinimumInterval : Orb::ModelBase, Orb::IFromRaw<MinimumInterval>
{
    /// <summary>
    /// The price interval ids that this minimum interval applies to.
    /// </summary>
    public required Generic::List<string> AppliesToPriceIntervalIDs
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "applies_to_price_interval_ids",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "applies_to_price_interval_ids",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<string>>(element)
                ?? throw new System::ArgumentNullException("applies_to_price_interval_ids");
        }
        set
        {
            this.Properties["applies_to_price_interval_ids"] =
                Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The end date of the minimum interval.
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
    /// The filters that determine which prices this minimum interval applies to.
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
    /// The minimum amount to charge in a given billing period for the price intervals
    /// this minimum applies to.
    /// </summary>
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
    /// The start date of the minimum interval.
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

    public override void Validate()
    {
        foreach (var item in this.AppliesToPriceIntervalIDs)
        {
            _ = item;
        }
        _ = this.EndDate;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.MinimumAmount;
        _ = this.StartDate;
    }

    public MinimumInterval() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    MinimumInterval(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MinimumInterval FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
