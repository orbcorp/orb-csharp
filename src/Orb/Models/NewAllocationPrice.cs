using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using NewAllocationPriceProperties = Orb.Models.NewAllocationPriceProperties;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<NewAllocationPrice>))]
public sealed record class NewAllocationPrice : Orb::ModelBase, Orb::IFromRaw<NewAllocationPrice>
{
    /// <summary>
    /// An amount of the currency to allocate to the customer at the specified cadence.
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
    /// The cadence at which to allocate the amount to the customer.
    /// </summary>
    public required NewAllocationPriceProperties::Cadence Cadence
    {
        get
        {
            if (!this.Properties.TryGetValue("cadence", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "cadence",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<NewAllocationPriceProperties::Cadence>(element)
                ?? throw new System::ArgumentNullException("cadence");
        }
        set { this.Properties["cadence"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An ISO 4217 currency string or a custom pricing unit identifier in which to
    /// bill this price.
    /// </summary>
    public required string Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "currency",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("currency");
        }
        set { this.Properties["currency"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The custom expiration for the allocation.
    /// </summary>
    public CustomExpiration? CustomExpiration
    {
        get
        {
            if (!this.Properties.TryGetValue("custom_expiration", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<CustomExpiration?>(element);
        }
        set
        {
            this.Properties["custom_expiration"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// Whether the allocated amount should expire at the end of the cadence or roll
    /// over to the next period. Set to null if using custom_expiration.
    /// </summary>
    public bool? ExpiresAtEndOfCadence
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "expires_at_end_of_cadence",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<bool?>(element);
        }
        set
        {
            this.Properties["expires_at_end_of_cadence"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public override void Validate()
    {
        _ = this.Amount;
        this.Cadence.Validate();
        _ = this.Currency;
        this.CustomExpiration?.Validate();
        _ = this.ExpiresAtEndOfCadence;
    }

    public NewAllocationPrice() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    NewAllocationPrice(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static NewAllocationPrice FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
