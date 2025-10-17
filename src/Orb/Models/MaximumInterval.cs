using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.MaximumIntervalProperties;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<MaximumInterval>))]
public sealed record class MaximumInterval : ModelBase, IFromRaw<MaximumInterval>
{
    /// <summary>
    /// The price interval ids that this maximum interval applies to.
    /// </summary>
    public required List<string> AppliesToPriceIntervalIDs
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "applies_to_price_interval_ids",
                    out JsonElement element
                )
            )
                throw new OrbInvalidDataException(
                    "'applies_to_price_interval_ids' cannot be null",
                    new ArgumentOutOfRangeException(
                        "applies_to_price_interval_ids",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'applies_to_price_interval_ids' cannot be null",
                    new ArgumentNullException("applies_to_price_interval_ids")
                );
        }
        set
        {
            this.Properties["applies_to_price_interval_ids"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The end date of the maximum interval.
    /// </summary>
    public required DateTime? EndDate
    {
        get
        {
            if (!this.Properties.TryGetValue("end_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
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
    /// The filters that determine which prices this maximum interval applies to.
    /// </summary>
    public required List<Filter> Filters
    {
        get
        {
            if (!this.Properties.TryGetValue("filters", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'filters' cannot be null",
                    new ArgumentOutOfRangeException("filters", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Filter>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'filters' cannot be null",
                    new ArgumentNullException("filters")
                );
        }
        set
        {
            this.Properties["filters"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The maximum amount to charge in a given billing period for the price intervals
    /// this transform applies to.
    /// </summary>
    public required string MaximumAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum_amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'maximum_amount' cannot be null",
                    new ArgumentOutOfRangeException("maximum_amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'maximum_amount' cannot be null",
                    new ArgumentNullException("maximum_amount")
                );
        }
        set
        {
            this.Properties["maximum_amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The start date of the maximum interval.
    /// </summary>
    public required DateTime StartDate
    {
        get
        {
            if (!this.Properties.TryGetValue("start_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'start_date' cannot be null",
                    new ArgumentOutOfRangeException("start_date", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["start_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
        _ = this.MaximumAmount;
        _ = this.StartDate;
    }

    public MaximumInterval() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MaximumInterval(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MaximumInterval FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
