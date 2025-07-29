using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<ExpirationChange>))]
public sealed record class ExpirationChange : Orb::ModelBase, Orb::IFromRaw<ExpirationChange>
{
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
    /// A future date (specified in YYYY-MM-DD format) used for expiration change,
    /// denoting when credits transferred (as part of a partial block expiration) should expire.
    /// </summary>
    public required System::DateOnly TargetExpiryDate
    {
        get
        {
            if (!this.Properties.TryGetValue("target_expiry_date", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "target_expiry_date",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateOnly>(element);
        }
        set
        {
            this.Properties["target_expiry_date"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The number of credits to effect. Note that this is required for increment,
    /// decrement, void, or undo operations.
    /// </summary>
    public double? Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<double?>(element);
        }
        set { this.Properties["amount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The ID of the block affected by an expiration_change, used to differentiate
    /// between multiple blocks with the same `expiry_date`.
    /// </summary>
    public string? BlockID
    {
        get
        {
            if (!this.Properties.TryGetValue("block_id", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["block_id"] = Json::JsonSerializer.SerializeToElement(value); }
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
    /// An ISO 8601 format date that identifies the origination credit block to expire
    /// </summary>
    public System::DateTime? ExpiryDate
    {
        get
        {
            if (!this.Properties.TryGetValue("expiry_date", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set { this.Properties["expiry_date"] = Json::JsonSerializer.SerializeToElement(value); }
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

    public override void Validate()
    {
        _ = this.TargetExpiryDate;
        _ = this.Amount;
        _ = this.BlockID;
        _ = this.Currency;
        _ = this.Description;
        _ = this.ExpiryDate;
        if (this.Metadata != null)
        {
            foreach (var item in this.Metadata.Values)
            {
                _ = item;
            }
        }
    }

    public ExpirationChange()
    {
        this.EntryType = Json::JsonSerializer.Deserialize<Json::JsonElement>(
            "\"expiration_change\""
        );
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    ExpirationChange(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ExpirationChange FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
