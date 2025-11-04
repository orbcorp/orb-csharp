using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.AdjustmentIntervalProperties;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<AdjustmentInterval>))]
public sealed record class AdjustmentInterval : ModelBase, IFromRaw<AdjustmentInterval>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
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
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Adjustment Adjustment
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustment", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjustment' cannot be null",
                    new ArgumentOutOfRangeException("adjustment", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Adjustment>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'adjustment' cannot be null",
                    new ArgumentNullException("adjustment")
                );
        }
        set
        {
            this.Properties["adjustment"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The price interval IDs that this adjustment applies to.
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
    /// The end date of the adjustment interval.
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
    /// The start date of the adjustment interval.
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
        _ = this.ID;
        this.Adjustment.Validate();
        _ = this.AppliesToPriceIntervalIDs;
        _ = this.EndDate;
        _ = this.StartDate;
    }

    public AdjustmentInterval() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AdjustmentInterval(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AdjustmentInterval FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
