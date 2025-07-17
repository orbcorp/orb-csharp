using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Customers.Credits.Ledger;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<AffectedBlock>))]
public sealed record class AffectedBlock : Orb::ModelBase, Orb::IFromRaw<AffectedBlock>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("id", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("id");
        }
        set { this.Properties["id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required System::DateTime? ExpiryDate
    {
        get
        {
            if (!this.Properties.TryGetValue("expiry_date", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "expiry_date",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set { this.Properties["expiry_date"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string? PerUnitCostBasis
    {
        get
        {
            if (!this.Properties.TryGetValue("per_unit_cost_basis", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "per_unit_cost_basis",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["per_unit_cost_basis"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.ExpiryDate;
        _ = this.PerUnitCostBasis;
    }

    public AffectedBlock() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    AffectedBlock(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AffectedBlock FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
