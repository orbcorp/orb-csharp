using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<BillingCycleAnchorConfiguration>))]
public sealed record class BillingCycleAnchorConfiguration
    : Orb::ModelBase,
        Orb::IFromRaw<BillingCycleAnchorConfiguration>
{
    /// <summary>
    /// The day of the month on which the billing cycle is anchored. If the maximum
    /// number of days in a month is greater than this value, the last day of the month
    /// is the billing cycle day (e.g. billing_cycle_day=31 for April means the billing
    /// period begins on the 30th.
    /// </summary>
    public required long Day
    {
        get
        {
            if (!this.Properties.TryGetValue("day", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("day", "Missing required argument");

            return Json::JsonSerializer.Deserialize<long>(element);
        }
        set { this.Properties["day"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The month on which the billing cycle is anchored (e.g. a quarterly price anchored
    /// in February would have cycles starting February, May, August, and November).
    /// </summary>
    public long? Month
    {
        get
        {
            if (!this.Properties.TryGetValue("month", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<long?>(element);
        }
        set { this.Properties["month"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The year on which the billing cycle is anchored (e.g. a 2 year billing cycle
    /// anchored on 2021 would have cycles starting on 2021, 2023, 2025, etc.).
    /// </summary>
    public long? Year
    {
        get
        {
            if (!this.Properties.TryGetValue("year", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<long?>(element);
        }
        set { this.Properties["year"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Day;
        _ = this.Month;
        _ = this.Year;
    }

    public BillingCycleAnchorConfiguration() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BillingCycleAnchorConfiguration(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BillingCycleAnchorConfiguration FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
