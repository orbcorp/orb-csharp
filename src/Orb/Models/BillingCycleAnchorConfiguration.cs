using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<BillingCycleAnchorConfiguration>))]
public sealed record class BillingCycleAnchorConfiguration
    : ModelBase,
        IFromRaw<BillingCycleAnchorConfiguration>
{
    /// <summary>
    /// The day of the month on which the billing cycle is anchored. If the maximum
    /// number of days in a month is greater than this value, the last day of the
    /// month is the billing cycle day (e.g. billing_cycle_day=31 for April means
    /// the billing period begins on the 30th.
    /// </summary>
    public required long Day
    {
        get
        {
            if (!this._properties.TryGetValue("day", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'day' cannot be null",
                    new System::ArgumentOutOfRangeException("day", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["day"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The month on which the billing cycle is anchored (e.g. a quarterly price
    /// anchored in February would have cycles starting February, May, August, and November).
    /// </summary>
    public long? Month
    {
        get
        {
            if (!this._properties.TryGetValue("month", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["month"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The year on which the billing cycle is anchored (e.g. a 2 year billing cycle
    /// anchored on 2021 would have cycles starting on 2021, 2023, 2025, etc.).
    /// </summary>
    public long? Year
    {
        get
        {
            if (!this._properties.TryGetValue("year", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["year"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Day;
        _ = this.Month;
        _ = this.Year;
    }

    public BillingCycleAnchorConfiguration() { }

    public BillingCycleAnchorConfiguration(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingCycleAnchorConfiguration(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BillingCycleAnchorConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public BillingCycleAnchorConfiguration(long day)
        : this()
    {
        this.Day = day;
    }
}
