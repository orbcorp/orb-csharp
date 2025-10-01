using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using DataProperties = Orb.Models.Customers.BalanceTransactions.BalanceTransactionListPageResponseProperties.DataProperties;

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

    public required ApiEnum<string, DataProperties::Action> Action
    {
        get
        {
            if (!this.Properties.TryGetValue("action", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'action' cannot be null",
                    new ArgumentOutOfRangeException("action", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, DataProperties::Action>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["action"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The value of the amount changed in the transaction.
    /// </summary>
    public required string Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new ArgumentOutOfRangeException("amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new ArgumentNullException("amount")
                );
        }
        set
        {
            this.Properties["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The creation time of this transaction.
    /// </summary>
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

    public required CreditNoteTiny? CreditNote
    {
        get
        {
            if (!this.Properties.TryGetValue("credit_note", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CreditNoteTiny?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["credit_note"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An optional description provided for manual customer balance adjustments.
    /// </summary>
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

    /// <summary>
    /// The new value of the customer's balance prior to the transaction, in the
    /// customer's currency.
    /// </summary>
    public required string EndingBalance
    {
        get
        {
            if (!this.Properties.TryGetValue("ending_balance", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'ending_balance' cannot be null",
                    new ArgumentOutOfRangeException("ending_balance", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'ending_balance' cannot be null",
                    new ArgumentNullException("ending_balance")
                );
        }
        set
        {
            this.Properties["ending_balance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required InvoiceTiny? Invoice
    {
        get
        {
            if (!this.Properties.TryGetValue("invoice", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<InvoiceTiny?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["invoice"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The original value of the customer's balance prior to the transaction, in
    /// the customer's currency.
    /// </summary>
    public required string StartingBalance
    {
        get
        {
            if (!this.Properties.TryGetValue("starting_balance", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'starting_balance' cannot be null",
                    new ArgumentOutOfRangeException("starting_balance", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'starting_balance' cannot be null",
                    new ArgumentNullException("starting_balance")
                );
        }
        set
        {
            this.Properties["starting_balance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, DataProperties::Type> Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, DataProperties::Type>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
