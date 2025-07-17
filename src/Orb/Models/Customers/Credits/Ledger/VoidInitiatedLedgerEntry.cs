using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Models = Orb.Models;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;
using VoidInitiatedLedgerEntryProperties = Orb.Models.Customers.Credits.Ledger.VoidInitiatedLedgerEntryProperties;

namespace Orb.Models.Customers.Credits.Ledger;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<VoidInitiatedLedgerEntry>))]
public sealed record class VoidInitiatedLedgerEntry
    : Orb::ModelBase,
        Orb::IFromRaw<VoidInitiatedLedgerEntry>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("id", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("id");
        }
        set { this.Properties["id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

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

    public required System::DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "created_at",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set { this.Properties["created_at"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required AffectedBlock CreditBlock
    {
        get
        {
            if (!this.Properties.TryGetValue("credit_block", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "credit_block",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<AffectedBlock>(element)
                ?? throw new System::ArgumentNullException("credit_block");
        }
        set { this.Properties["credit_block"] = Json::JsonSerializer.SerializeToElement(value); }
    }

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

    public required Models::CustomerMinified Customer
    {
        get
        {
            if (!this.Properties.TryGetValue("customer", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "customer",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Models::CustomerMinified>(element)
                ?? throw new System::ArgumentNullException("customer");
        }
        set { this.Properties["customer"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string? Description
    {
        get
        {
            if (!this.Properties.TryGetValue("description", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "description",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["description"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required double EndingBalance
    {
        get
        {
            if (!this.Properties.TryGetValue("ending_balance", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "ending_balance",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<double>(element);
        }
        set { this.Properties["ending_balance"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required VoidInitiatedLedgerEntryProperties::EntryStatus EntryStatus
    {
        get
        {
            if (!this.Properties.TryGetValue("entry_status", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "entry_status",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<VoidInitiatedLedgerEntryProperties::EntryStatus>(
                    element
                ) ?? throw new System::ArgumentNullException("entry_status");
        }
        set { this.Properties["entry_status"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required VoidInitiatedLedgerEntryProperties::EntryType EntryType
    {
        get
        {
            if (!this.Properties.TryGetValue("entry_type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "entry_type",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<VoidInitiatedLedgerEntryProperties::EntryType>(
                    element
                ) ?? throw new System::ArgumentNullException("entry_type");
        }
        set { this.Properties["entry_type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required long LedgerSequenceNumber
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "ledger_sequence_number",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "ledger_sequence_number",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long>(element);
        }
        set
        {
            this.Properties["ledger_sequence_number"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// User specified key-value pairs for the resource. If not present, this defaults
    /// to an empty dictionary. Individual keys can be removed by setting the value
    /// to `null`, and the entire metadata mapping can be cleared by setting `metadata`
    /// to `null`.
    /// </summary>
    public required Generic::Dictionary<string, string> Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "metadata",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::Dictionary<string, string>>(element)
                ?? throw new System::ArgumentNullException("metadata");
        }
        set { this.Properties["metadata"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required System::DateTime NewBlockExpiryDate
    {
        get
        {
            if (
                !this.Properties.TryGetValue("new_block_expiry_date", out Json::JsonElement element)
            )
                throw new System::ArgumentOutOfRangeException(
                    "new_block_expiry_date",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set
        {
            this.Properties["new_block_expiry_date"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public required double StartingBalance
    {
        get
        {
            if (!this.Properties.TryGetValue("starting_balance", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "starting_balance",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<double>(element);
        }
        set
        {
            this.Properties["starting_balance"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public required double VoidAmount
    {
        get
        {
            if (!this.Properties.TryGetValue("void_amount", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "void_amount",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<double>(element);
        }
        set { this.Properties["void_amount"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string? VoidReason
    {
        get
        {
            if (!this.Properties.TryGetValue("void_reason", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "void_reason",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["void_reason"] = Json::JsonSerializer.SerializeToElement(value); }
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
        _ = this.VoidAmount;
        _ = this.VoidReason;
    }

    public VoidInitiatedLedgerEntry() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    VoidInitiatedLedgerEntry(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static VoidInitiatedLedgerEntry FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
