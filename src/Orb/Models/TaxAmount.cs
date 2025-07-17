using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<TaxAmount>))]
public sealed record class TaxAmount : Orb::ModelBase, Orb::IFromRaw<TaxAmount>
{
    /// <summary>
    /// The amount of additional tax incurred by this tax rate.
    /// </summary>
    public required string Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "amount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("amount");
        }
        set { this.Properties["amount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The human-readable description of the applied tax rate.
    /// </summary>
    public required string TaxRateDescription
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_rate_description", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "tax_rate_description",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("tax_rate_description");
        }
        set
        {
            this.Properties["tax_rate_description"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// The tax rate percentage, out of 100.
    /// </summary>
    public required string? TaxRatePercentage
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_rate_percentage", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "tax_rate_percentage",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["tax_rate_percentage"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override void Validate()
    {
        _ = this.Amount;
        _ = this.TaxRateDescription;
        _ = this.TaxRatePercentage;
    }

    public TaxAmount() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    TaxAmount(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TaxAmount FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
