using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DataProperties = Orb.Models.Customers.BalanceTransactions.BalanceTransactionListPageResponseProperties.DataProperties;
using System = System;

namespace Orb.Models.Customers.BalanceTransactions.BalanceTransactionListPageResponseProperties;

[JsonConverter(typeof(ModelConverter<Data>))]
public sealed record class Data : ModelBase, IFromRaw<Data>
{
    /// <summary>
    /// A unique id for this transaction.
    /// </summary>
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

    public required DataProperties::Action Action
    {
        get
        {
            if (!this.Properties.TryGetValue("action", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "action",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<DataProperties::Action>(element)
                ?? throw new System::ArgumentNullException("action");
        }
        set { this.Properties["action"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The value of the amount changed in the transaction.
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

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("amount");
        }
        set { this.Properties["amount"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The creation time of this transaction.
    /// </summary>
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

    public required CreditNoteTiny? CreditNote
    {
        get
        {
            if (!this.Properties.TryGetValue("credit_note", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "credit_note",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<CreditNoteTiny?>(element);
        }
        set { this.Properties["credit_note"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An optional description provided for manual customer balance adjustments.
    /// </summary>
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

    /// <summary>
    /// The new value of the customer's balance prior to the transaction, in the customer's currency.
    /// </summary>
    public required string EndingBalance
    {
        get
        {
            if (!this.Properties.TryGetValue("ending_balance", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "ending_balance",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("ending_balance");
        }
        set { this.Properties["ending_balance"] = JsonSerializer.SerializeToElement(value); }
    }

    public required InvoiceTiny? Invoice
    {
        get
        {
            if (!this.Properties.TryGetValue("invoice", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "invoice",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<InvoiceTiny?>(element);
        }
        set { this.Properties["invoice"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The original value of the customer's balance prior to the transaction, in the
    /// customer's currency.
    /// </summary>
    public required string StartingBalance
    {
        get
        {
            if (!this.Properties.TryGetValue("starting_balance", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "starting_balance",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("starting_balance");
        }
        set { this.Properties["starting_balance"] = JsonSerializer.SerializeToElement(value); }
    }

    public required DataProperties::Type Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<DataProperties::Type>(element)
                ?? throw new System::ArgumentNullException("type");
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ID;
        this.Action.Validate();
        _ = this.Amount;
        _ = this.CreatedAt;
        this.CreditNote?.Validate();
        _ = this.Description;
        _ = this.EndingBalance;
        this.Invoice?.Validate();
        _ = this.StartingBalance;
        this.Type.Validate();
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Data FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
