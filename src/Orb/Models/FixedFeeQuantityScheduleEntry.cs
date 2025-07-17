using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<FixedFeeQuantityScheduleEntry>))]
public sealed record class FixedFeeQuantityScheduleEntry
    : Orb::ModelBase,
        Orb::IFromRaw<FixedFeeQuantityScheduleEntry>
{
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

    public required string PriceID
    {
        get
        {
            if (!this.Properties.TryGetValue("price_id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "price_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("price_id");
        }
        set { this.Properties["price_id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required double Quantity
    {
        get
        {
            if (!this.Properties.TryGetValue("quantity", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "quantity",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<double>(element);
        }
        set { this.Properties["quantity"] = Json::JsonSerializer.SerializeToElement(value); }
    }

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
        _ = this.EndDate;
        _ = this.PriceID;
        _ = this.Quantity;
        _ = this.StartDate;
    }

    public FixedFeeQuantityScheduleEntry() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    FixedFeeQuantityScheduleEntry(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static FixedFeeQuantityScheduleEntry FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
