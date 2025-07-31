using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<FixedFeeQuantityScheduleEntry>))]
public sealed record class FixedFeeQuantityScheduleEntry
    : ModelBase,
        IFromRaw<FixedFeeQuantityScheduleEntry>
{
    public required System::DateTime? EndDate
    {
        get
        {
            if (!this.Properties.TryGetValue("end_date", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "end_date",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["end_date"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string PriceID
    {
        get
        {
            if (!this.Properties.TryGetValue("price_id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "price_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("price_id");
        }
        set { this.Properties["price_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required double Quantity
    {
        get
        {
            if (!this.Properties.TryGetValue("quantity", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "quantity",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["quantity"] = JsonSerializer.SerializeToElement(value); }
    }

    public required System::DateTime StartDate
    {
        get
        {
            if (!this.Properties.TryGetValue("start_date", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "start_date",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["start_date"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.EndDate;
        _ = this.PriceID;
        _ = this.Quantity;
        _ = this.StartDate;
    }

    public FixedFeeQuantityScheduleEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FixedFeeQuantityScheduleEntry(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static FixedFeeQuantityScheduleEntry FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
