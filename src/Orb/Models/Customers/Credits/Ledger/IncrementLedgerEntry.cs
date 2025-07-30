using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using IncrementLedgerEntryProperties = Orb.Models.Customers.Credits.Ledger.IncrementLedgerEntryProperties;
using System = System;

namespace Orb.Models.Customers.Credits.Ledger;

[JsonConverter(typeof(ModelConverter<IncrementLedgerEntry>))]
public sealed record class IncrementLedgerEntry : ModelBase, IFromRaw<IncrementLedgerEntry>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element)
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

            return JsonSerializer.Deserialize<double>(element);
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

            return JsonSerializer.Deserialize<System::DateTime>(element);
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

            return JsonSerializer.Deserialize<AffectedBlock>(element)
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

            return JsonSerializer.Deserialize<string>(element)
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

            return JsonSerializer.Deserialize<CustomerMinified>(element)
                ?? throw new System::ArgumentNullException("customer");
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

            return JsonSerializer.Deserialize<string?>(element);
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

            return JsonSerializer.Deserialize<double>(element);
        }
        set { this.Properties["ending_balance"] = JsonSerializer.SerializeToElement(value); }
    }

    public required IncrementLedgerEntryProperties::EntryStatus EntryStatus
    {
        get
        {
            if (!this.Properties.TryGetValue("entry_status", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "entry_status",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<IncrementLedgerEntryProperties::EntryStatus>(element)
                ?? throw new System::ArgumentNullException("entry_status");
        }
        set { this.Properties["entry_status"] = JsonSerializer.SerializeToElement(value); }
    }

    public required IncrementLedgerEntryProperties::EntryType EntryType
    {
        get
        {
            if (!this.Properties.TryGetValue("entry_type", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "entry_type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<IncrementLedgerEntryProperties::EntryType>(element)
                ?? throw new System::ArgumentNullException("entry_type");
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

            return JsonSerializer.Deserialize<long>(element);
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

            return JsonSerializer.Deserialize<Dictionary<string, string>>(element)
                ?? throw new System::ArgumentNullException("metadata");
        }
        set { this.Properties["metadata"] = JsonSerializer.SerializeToElement(value); }
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

            return JsonSerializer.Deserialize<double>(element);
        }
        set { this.Properties["starting_balance"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// If the increment resulted in invoice creation, the list of created invoices
    /// </summary>
    public List<Invoice>? CreatedInvoices
    {
        get
        {
            if (!this.Properties.TryGetValue("created_invoices", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Invoice>?>(element);
        }
        set { this.Properties["created_invoices"] = JsonSerializer.SerializeToElement(value); }
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
        _ = this.StartingBalance;
        foreach (var item in this.CreatedInvoices ?? [])
        {
            item.Validate();
        }
    }

    public IncrementLedgerEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IncrementLedgerEntry(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static IncrementLedgerEntry FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
