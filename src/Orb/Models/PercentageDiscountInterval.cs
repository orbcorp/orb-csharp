using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PercentageDiscountIntervalProperties = Orb.Models.PercentageDiscountIntervalProperties;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<PercentageDiscountInterval>))]
public sealed record class PercentageDiscountInterval
    : ModelBase,
        IFromRaw<PercentageDiscountInterval>
{
    /// <summary>
    /// The price interval ids that this discount interval applies to.
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
                throw new System::ArgumentOutOfRangeException(
                    "applies_to_price_interval_ids",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<string>>(element)
                ?? throw new System::ArgumentNullException("applies_to_price_interval_ids");
        }
        set
        {
            this.Properties["applies_to_price_interval_ids"] = JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public required PercentageDiscountIntervalProperties::DiscountType DiscountType
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_type", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "discount_type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<PercentageDiscountIntervalProperties::DiscountType>(
                    element
                ) ?? throw new System::ArgumentNullException("discount_type");
        }
        set { this.Properties["discount_type"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The end date of the discount interval.
    /// </summary>
    public required System::DateTime? EndDate
    {
        get
        {
            if (!this.Properties.TryGetValue("end_date", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "end_date",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set { this.Properties["end_date"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The filters that determine which prices this discount interval applies to.
    /// </summary>
    public required List<TransformPriceFilter> Filters
    {
        get
        {
            if (!this.Properties.TryGetValue("filters", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "filters",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<TransformPriceFilter>>(element)
                ?? throw new System::ArgumentNullException("filters");
        }
        set { this.Properties["filters"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Only available if discount_type is `percentage`.This is a number between 0
    /// and 1.
    /// </summary>
    public required double PercentageDiscount
    {
        get
        {
            if (!this.Properties.TryGetValue("percentage_discount", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "percentage_discount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<double>(element);
        }
        set { this.Properties["percentage_discount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The start date of the discount interval.
    /// </summary>
    public required System::DateTime StartDate
    {
        get
        {
            if (!this.Properties.TryGetValue("start_date", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "start_date",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set { this.Properties["start_date"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.AppliesToPriceIntervalIDs)
        {
            _ = item;
        }
        this.DiscountType.Validate();
        _ = this.EndDate;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.PercentageDiscount;
        _ = this.StartDate;
    }

    public PercentageDiscountInterval() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PercentageDiscountInterval(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PercentageDiscountInterval FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
