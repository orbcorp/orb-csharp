using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using AmountDiscountIntervalProperties = Orb.Models.AmountDiscountIntervalProperties;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<AmountDiscountInterval>))]
public sealed record class AmountDiscountInterval : ModelBase, IFromRaw<AmountDiscountInterval>
{
    /// <summary>
    /// Only available if discount_type is `amount`.
    /// </summary>
    public required string AmountDiscount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount_discount", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "amount_discount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("amount_discount");
        }
        set { this.Properties["amount_discount"] = JsonSerializer.SerializeToElement(value); }
    }

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

    public required AmountDiscountIntervalProperties::DiscountType DiscountType
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_type", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "discount_type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<AmountDiscountIntervalProperties::DiscountType>(
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
        _ = this.AmountDiscount;
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
        _ = this.StartDate;
    }

    public AmountDiscountInterval() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AmountDiscountInterval(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AmountDiscountInterval FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
