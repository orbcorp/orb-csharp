using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<TaxAmount>))]
public sealed record class TaxAmount : ModelBase, IFromRaw<TaxAmount>
{
    /// <summary>
    /// The amount of additional tax incurred by this tax rate.
    /// </summary>
    public required string Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "amount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("amount");
        }
        set { this.Properties["amount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The human-readable description of the applied tax rate.
    /// </summary>
    public required string TaxRateDescription
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_rate_description", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "tax_rate_description",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("tax_rate_description");
        }
        set { this.Properties["tax_rate_description"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The tax rate percentage, out of 100.
    /// </summary>
    public required string? TaxRatePercentage
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_rate_percentage", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "tax_rate_percentage",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["tax_rate_percentage"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Amount;
        _ = this.TaxRateDescription;
        _ = this.TaxRatePercentage;
    }

    public TaxAmount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TaxAmount(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TaxAmount FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
