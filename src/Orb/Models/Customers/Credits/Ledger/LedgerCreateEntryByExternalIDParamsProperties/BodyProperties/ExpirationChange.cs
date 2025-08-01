using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyProperties;

[JsonConverter(typeof(ModelConverter<ExpirationChange>))]
public sealed record class ExpirationChange : ModelBase, IFromRaw<ExpirationChange>
{
    public JsonElement EntryType
    {
        get
        {
            if (!this.Properties.TryGetValue("entry_type", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "entry_type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["entry_type"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A future date (specified in YYYY-MM-DD format) used for expiration change,
    /// denoting when credits transferred (as part of a partial block expiration)
    /// should expire.
    /// </summary>
    public required System::DateOnly TargetExpiryDate
    {
        get
        {
            if (!this.Properties.TryGetValue("target_expiry_date", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "target_expiry_date",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<System::DateOnly>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["target_expiry_date"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The number of credits to effect. Note that this is required for increment,
    /// decrement, void, or undo operations.
    /// </summary>
    public double? Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["amount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The ID of the block affected by an expiration_change, used to differentiate
    /// between multiple blocks with the same `expiry_date`.
    /// </summary>
    public string? BlockID
    {
        get
        {
            if (!this.Properties.TryGetValue("block_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["block_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The currency or custom pricing unit to use for this ledger entry. If this
    /// is a real-world currency, it must match the customer's invoicing currency.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["currency"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Optional metadata that can be specified when adding ledger results via the
    /// API. For example, this can be used to note an increment refers to trial credits,
    /// or for noting corrections as a result of an incident, etc.
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this.Properties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["description"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An ISO 8601 format date that identifies the origination credit block to expire
    /// </summary>
    public System::DateTime? ExpiryDate
    {
        get
        {
            if (!this.Properties.TryGetValue("expiry_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["expiry_date"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["metadata"] = JsonSerializer.SerializeToElement(value); }
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
        this.EntryType = JsonSerializer.Deserialize<JsonElement>("\"expiration_change\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExpirationChange(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ExpirationChange FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
