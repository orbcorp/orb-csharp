using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers.Credits.Ledger.CreditBlockExpiryLedgerEntryProperties;

namespace Orb.Models.Customers.Credits.Ledger;

[JsonConverter(typeof(ModelConverter<CreditBlockExpiryLedgerEntry>))]
public sealed record class CreditBlockExpiryLedgerEntry
    : ModelBase,
        IFromRaw<CreditBlockExpiryLedgerEntry>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentNullException("id")
                );
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required double Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new ArgumentOutOfRangeException("amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'created_at' cannot be null",
                    new ArgumentOutOfRangeException("created_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required AffectedBlock CreditBlock
    {
        get
        {
            if (!this.Properties.TryGetValue("credit_block", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'credit_block' cannot be null",
                    new ArgumentOutOfRangeException("credit_block", "Missing required argument")
                );

            return JsonSerializer.Deserialize<AffectedBlock>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'credit_block' cannot be null",
                    new ArgumentNullException("credit_block")
                );
        }
        set
        {
            this.Properties["credit_block"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new ArgumentNullException("currency")
                );
        }
        set
        {
            this.Properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required CustomerMinified Customer
    {
        get
        {
            if (!this.Properties.TryGetValue("customer", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'customer' cannot be null",
                    new ArgumentOutOfRangeException("customer", "Missing required argument")
                );

            return JsonSerializer.Deserialize<CustomerMinified>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'customer' cannot be null",
                    new ArgumentNullException("customer")
                );
        }
        set
        {
            this.Properties["customer"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? Description
    {
        get
        {
            if (!this.Properties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required double EndingBalance
    {
        get
        {
            if (!this.Properties.TryGetValue("ending_balance", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'ending_balance' cannot be null",
                    new ArgumentOutOfRangeException("ending_balance", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ending_balance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, EntryStatus> EntryStatus
    {
        get
        {
            if (!this.Properties.TryGetValue("entry_status", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'entry_status' cannot be null",
                    new ArgumentOutOfRangeException("entry_status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, EntryStatus>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["entry_status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, EntryType> EntryType
    {
        get
        {
            if (!this.Properties.TryGetValue("entry_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'entry_type' cannot be null",
                    new ArgumentOutOfRangeException("entry_type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, EntryType>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["entry_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long LedgerSequenceNumber
    {
        get
        {
            if (!this.Properties.TryGetValue("ledger_sequence_number", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'ledger_sequence_number' cannot be null",
                    new ArgumentOutOfRangeException(
                        "ledger_sequence_number",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ledger_sequence_number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User specified key-value pairs for the resource. If not present, this defaults
    /// to an empty dictionary. Individual keys can be removed by setting the value
    /// to `null`, and the entire metadata mapping can be cleared by setting `metadata`
    /// to `null`.
    /// </summary>
    public required Dictionary<string, string> Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'metadata' cannot be null",
                    new ArgumentOutOfRangeException("metadata", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, string>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'metadata' cannot be null",
                    new ArgumentNullException("metadata")
                );
        }
        set
        {
            this.Properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required double StartingBalance
    {
        get
        {
            if (!this.Properties.TryGetValue("starting_balance", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'starting_balance' cannot be null",
                    new ArgumentOutOfRangeException("starting_balance", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["starting_balance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Amount;
        _ = this.CreatedAt;
        this.CreditBlock.Validate();
        _ = this.Currency;
        this.Customer.Validate();
        _ = this.Description;
        _ = this.EndingBalance;
        this.EntryStatus.Validate();
        this.EntryType.Validate();
        _ = this.LedgerSequenceNumber;
        _ = this.Metadata;
        _ = this.StartingBalance;
    }

    public CreditBlockExpiryLedgerEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditBlockExpiryLedgerEntry(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CreditBlockExpiryLedgerEntry FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
