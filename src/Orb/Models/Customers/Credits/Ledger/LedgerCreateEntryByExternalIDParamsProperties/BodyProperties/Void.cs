using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;
using VoidProperties = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyProperties.VoidProperties;

namespace Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<Void>))]
public sealed record class Void : Orb::ModelBase, Orb::IFromRaw<Void>
{
    /// <summary>
    /// The number of credits to effect. Note that this is required for increment,
    /// decrement, void, or undo operations.
    /// </summary>
    public required double Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "amount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<double>(element);
        }
        set { this.Properties["amount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The ID of the block to void.
    /// </summary>
    public required string BlockID
    {
        get
        {
            if (!this.Properties.TryGetValue("block_id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "block_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("block_id");
        }
        set { this.Properties["block_id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public Json::JsonElement EntryType
    {
        get
        {
            if (!this.Properties.TryGetValue("entry_type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "entry_type",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Json::JsonElement>(element);
        }
        set { this.Properties["entry_type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The currency or custom pricing unit to use for this ledger entry. If this is
    /// a real-world currency, it must match the customer's invoicing currency.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["currency"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Optional metadata that can be specified when adding ledger results via the API.
    /// For example, this can be used to note an increment refers to trial credits,
    /// or for noting corrections as a result of an incident, etc.
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this.Properties.TryGetValue("description", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["description"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Generic::Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::Dictionary<string, string?>?>(element);
        }
        set { this.Properties["metadata"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Can only be specified when `entry_type=void`. The reason for the void.
    /// </summary>
    public VoidProperties::VoidReason? VoidReason
    {
        get
        {
            if (!this.Properties.TryGetValue("void_reason", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<VoidProperties::VoidReason?>(element);
        }
        set { this.Properties["void_reason"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Amount;
        _ = this.BlockID;
        if (!this.EntryType.Equals(Json::JsonSerializer.Deserialize<Json::JsonElement>("\"void\"")))
        {
            throw new System::Exception();
        }
        _ = this.Currency;
        _ = this.Description;
        if (this.Metadata != null)
        {
            foreach (var item in this.Metadata.Values)
            {
                _ = item;
            }
        }
        this.VoidReason?.Validate();
    }

    public Void()
    {
        this.EntryType = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"void\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    Void(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Void FromRawUnchecked(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        return new(properties);
    }
}
