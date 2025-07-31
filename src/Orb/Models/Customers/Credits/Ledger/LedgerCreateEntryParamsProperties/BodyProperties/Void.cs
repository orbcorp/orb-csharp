using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;
using VoidProperties = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryParamsProperties.BodyProperties.VoidProperties;

namespace Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryParamsProperties.BodyProperties;

[JsonConverter(typeof(ModelConverter<Void>))]
public sealed record class Void : ModelBase, IFromRaw<Void>
{
    /// <summary>
    /// The number of credits to effect. Note that this is required for increment,
    /// decrement, void, or undo operations.
    /// </summary>
    public required double Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "amount",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["amount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The ID of the block to void.
    /// </summary>
    public required string BlockID
    {
        get
        {
            if (!this.Properties.TryGetValue("block_id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "block_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("block_id");
        }
        set { this.Properties["block_id"] = JsonSerializer.SerializeToElement(value); }
    }

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
    /// The currency or custom pricing unit to use for this ledger entry. If this is
    /// a real-world currency, it must match the customer's invoicing currency.
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
    /// Optional metadata that can be specified when adding ledger results via the API.
    /// For example, this can be used to note an increment refers to trial credits,
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

    /// <summary>
    /// Can only be specified when `entry_type=void`. The reason for the void.
    /// </summary>
    public VoidProperties::VoidReason? VoidReason
    {
        get
        {
            if (!this.Properties.TryGetValue("void_reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<VoidProperties::VoidReason?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["void_reason"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Amount;
        _ = this.BlockID;
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
        this.EntryType = JsonSerializer.Deserialize<JsonElement>("\"void\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Void(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Void FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
