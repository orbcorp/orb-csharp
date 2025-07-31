using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using NewAllocationPriceProperties = Orb.Models.NewAllocationPriceProperties;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<NewAllocationPrice>))]
public sealed record class NewAllocationPrice : ModelBase, IFromRaw<NewAllocationPrice>
{
    /// <summary>
    /// An amount of the currency to allocate to the customer at the specified cadence.
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

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("amount");
        }
        set { this.Properties["amount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The cadence at which to allocate the amount to the customer.
    /// </summary>
    public required NewAllocationPriceProperties::Cadence Cadence
    {
        get
        {
            if (!this.Properties.TryGetValue("cadence", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "cadence",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<NewAllocationPriceProperties::Cadence>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("cadence");
        }
        set { this.Properties["cadence"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An ISO 4217 currency string or a custom pricing unit identifier in which to
    /// bill this price.
    /// </summary>
    public required string Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "currency",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("currency");
        }
        set { this.Properties["currency"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The custom expiration for the allocation.
    /// </summary>
    public CustomExpiration? CustomExpiration
    {
        get
        {
            if (!this.Properties.TryGetValue("custom_expiration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CustomExpiration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["custom_expiration"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Whether the allocated amount should expire at the end of the cadence or roll
    /// over to the next period. Set to null if using custom_expiration.
    /// </summary>
    public bool? ExpiresAtEndOfCadence
    {
        get
        {
            if (!this.Properties.TryGetValue("expires_at_end_of_cadence", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["expires_at_end_of_cadence"] = JsonSerializer.SerializeToElement(value);
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
    [SetsRequiredMembers]
    NewAllocationPrice(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static NewAllocationPrice FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
