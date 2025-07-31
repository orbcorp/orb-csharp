using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ExpirationChangeLedgerEntryProperties = Orb.Models.Customers.Credits.Ledger.ExpirationChangeLedgerEntryProperties;
using System = System;

namespace Orb.Models.Customers.Credits.Ledger;

[JsonConverter(typeof(ModelConverter<ExpirationChangeLedgerEntry>))]
public sealed record class ExpirationChangeLedgerEntry
    : ModelBase,
        IFromRaw<ExpirationChangeLedgerEntry>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("id");
        }
        set { this.Properties["id"] = JsonSerializer.SerializeToElement(value); }
    }

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

    public required System::DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "created_at",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["created_at"] = JsonSerializer.SerializeToElement(value); }
    }

    public required AffectedBlock CreditBlock
    {
        get
        {
            if (!this.Properties.TryGetValue("credit_block", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "credit_block",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<AffectedBlock>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("credit_block");
        }
        set { this.Properties["credit_block"] = JsonSerializer.SerializeToElement(value); }
    }

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

    public required CustomerMinified Customer
    {
        get
        {
            if (!this.Properties.TryGetValue("customer", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "customer",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<CustomerMinified>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("customer");
        }
        set { this.Properties["customer"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string? Description
    {
        get
        {
            if (!this.Properties.TryGetValue("description", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "description",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["description"] = JsonSerializer.SerializeToElement(value); }
    }

    public required double EndingBalance
    {
        get
        {
            if (!this.Properties.TryGetValue("ending_balance", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "ending_balance",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["ending_balance"] = JsonSerializer.SerializeToElement(value); }
    }

    public required ExpirationChangeLedgerEntryProperties::EntryStatus EntryStatus
    {
        get
        {
            if (!this.Properties.TryGetValue("entry_status", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "entry_status",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<ExpirationChangeLedgerEntryProperties::EntryStatus>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("entry_status");
        }
        set { this.Properties["entry_status"] = JsonSerializer.SerializeToElement(value); }
    }

    public required ExpirationChangeLedgerEntryProperties::EntryType EntryType
    {
        get
        {
            if (!this.Properties.TryGetValue("entry_type", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "entry_type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<ExpirationChangeLedgerEntryProperties::EntryType>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("entry_type");
        }
        set { this.Properties["entry_type"] = JsonSerializer.SerializeToElement(value); }
    }

    public required long LedgerSequenceNumber
    {
        get
        {
            if (!this.Properties.TryGetValue("ledger_sequence_number", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "ledger_sequence_number",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ledger_sequence_number"] = JsonSerializer.SerializeToElement(value);
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
                throw new System::ArgumentOutOfRangeException(
                    "metadata",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<Dictionary<string, string>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("metadata");
        }
        set { this.Properties["metadata"] = JsonSerializer.SerializeToElement(value); }
    }

    public required System::DateTime? NewBlockExpiryDate
    {
        get
        {
            if (!this.Properties.TryGetValue("new_block_expiry_date", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "new_block_expiry_date",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["new_block_expiry_date"] = JsonSerializer.SerializeToElement(value); }
    }

    public required double StartingBalance
    {
        get
        {
            if (!this.Properties.TryGetValue("starting_balance", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "starting_balance",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["starting_balance"] = JsonSerializer.SerializeToElement(value); }
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
        foreach (var item in this.Metadata.Values)
        {
            _ = item;
        }
        _ = this.NewBlockExpiryDate;
        _ = this.StartingBalance;
    }

    public ExpirationChangeLedgerEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExpirationChangeLedgerEntry(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ExpirationChangeLedgerEntry FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
