using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.EditAdjustmentProperties;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties;

[JsonConverter(typeof(ModelConverter<EditAdjustment>))]
public sealed record class EditAdjustment : ModelBase, IFromRaw<EditAdjustment>
{
    /// <summary>
    /// The id of the adjustment interval to edit.
    /// </summary>
    public required string AdjustmentIntervalID
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustment_interval_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'adjustment_interval_id' cannot be null",
                    new ArgumentOutOfRangeException(
                        "adjustment_interval_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'adjustment_interval_id' cannot be null",
                    new ArgumentNullException("adjustment_interval_id")
                );
        }
        set
        {
            this.Properties["adjustment_interval_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The updated end date of this adjustment interval. If not specified, the end
    /// date will not be updated.
    /// </summary>
    public EndDate? EndDate
    {
        get
        {
            if (!this.Properties.TryGetValue("end_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<EndDate?>(element, ModelBase.SerializerOptions);
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
    /// The updated start date of this adjustment interval. If not specified, the
    /// start date will not be updated.
    /// </summary>
    public StartDate? StartDate
    {
        get
        {
            if (!this.Properties.TryGetValue("start_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<StartDate?>(element, ModelBase.SerializerOptions);
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
        _ = this.AdjustmentIntervalID;
        this.EndDate?.Validate();
        this.StartDate?.Validate();
    }

    public EditAdjustment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EditAdjustment(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static EditAdjustment FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public EditAdjustment(string adjustmentIntervalID)
        : this()
    {
        this.AdjustmentIntervalID = adjustmentIntervalID;
    }
}
