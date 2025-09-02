using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties.AddAdjustmentProperties;

namespace Orb.Models.Subscriptions.SubscriptionPriceIntervalsParamsProperties;

[JsonConverter(typeof(ModelConverter<AddAdjustment>))]
public sealed record class AddAdjustment : ModelBase, IFromRaw<AddAdjustment>
{
    /// <summary>
    /// The start date of the adjustment interval. This is the date that the adjustment
    /// will start affecting prices on the subscription. The adjustment will apply
    /// to invoice dates that overlap with this `start_date`. This `start_date` is
    /// treated as inclusive for in-advance prices, and exclusive for in-arrears prices.
    /// </summary>
    public required StartDate StartDate
    {
        get
        {
            if (!this.Properties.TryGetValue("start_date", out JsonElement element))
                throw new ArgumentOutOfRangeException("start_date", "Missing required argument");

            return JsonSerializer.Deserialize<StartDate>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("start_date");
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
    /// The definition of a new adjustment to create and add to the subscription.
    /// </summary>
    public Adjustment? Adjustment
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustment", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Adjustment?>(element, ModelBase.SerializerOptions);
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
    /// The ID of the adjustment to add to the subscription. Adjustment IDs can be
    /// re-used from existing subscriptions or plans, but adjustments associated
    /// with coupon redemptions cannot be re-used.
    /// </summary>
    public string? AdjustmentID
    {
        get
        {
            if (!this.Properties.TryGetValue("adjustment_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["adjustment_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The end date of the adjustment interval. This is the date that the adjustment
    /// will stop affecting prices on the subscription. The adjustment will apply
    /// to invoice dates that overlap with this `end_date`.This `end_date` is treated
    /// as exclusive for in-advance prices, and inclusive for in-arrears prices.
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

    public override void Validate()
    {
        this.StartDate.Validate();
        this.Adjustment?.Validate();
        _ = this.AdjustmentID;
        this.EndDate?.Validate();
    }

    public AddAdjustment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AddAdjustment(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AddAdjustment FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public AddAdjustment(StartDate startDate)
        : this()
    {
        this.StartDate = startDate;
    }
}
