using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<FixedFeeQuantityTransition>))]
public sealed record class FixedFeeQuantityTransition
    : Orb::ModelBase,
        Orb::IFromRaw<FixedFeeQuantityTransition>
{
    public required System::DateTime EffectiveDate
    {
        get
        {
            if (!this.Properties.TryGetValue("effective_date", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "effective_date",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set { this.Properties["effective_date"] = Json::JsonSerializer.SerializeToElement(value); }
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

    public required long Quantity
    {
        get
        {
            if (!this.Properties.TryGetValue("quantity", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "quantity",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long>(element);
        }
        set { this.Properties["quantity"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.EffectiveDate;
        _ = this.PriceID;
        _ = this.Quantity;
    }

    public FixedFeeQuantityTransition() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    FixedFeeQuantityTransition(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static FixedFeeQuantityTransition FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
