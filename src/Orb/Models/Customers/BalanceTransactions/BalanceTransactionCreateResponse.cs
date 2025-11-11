using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers.BalanceTransactions;

[JsonConverter(typeof(ModelConverter<BalanceTransactionCreateResponse>))]
public sealed record class BalanceTransactionCreateResponse
    : ModelBase,
        IFromRaw<BalanceTransactionCreateResponse>
{
    /// <summary>
    /// A unique id for this transaction.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this._properties.TryGetValue("id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        init
        {
            this._properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, global::Orb.Models.Customers.BalanceTransactions.Action> Action
    {
        get
        {
            if (!this._properties.TryGetValue("action", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'action' cannot be null",
                    new System::ArgumentOutOfRangeException("action", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Customers.BalanceTransactions.Action>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["action"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new System::ArgumentOutOfRangeException("amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new System::ArgumentNullException("amount")
                );
        }
        init
        {
            this._properties["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The creation time of this transaction.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            if (!this._properties.TryGetValue("created_at", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'created_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "created_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTimeOffset>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required CreditNoteTiny? CreditNote
    {
        get
        {
            if (!this._properties.TryGetValue("credit_note", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CreditNoteTiny?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["credit_note"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The new value of the customer's balance prior to the transaction, in the customer's currency.
    /// </summary>
    public required string EndingBalance
    {
        get
        {
            if (!this._properties.TryGetValue("ending_balance", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'ending_balance' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "ending_balance",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'ending_balance' cannot be null",
                    new System::ArgumentNullException("ending_balance")
                );
        }
        init
        {
            this._properties["ending_balance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required InvoiceTiny? Invoice
    {
        get
        {
            if (!this._properties.TryGetValue("invoice", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<InvoiceTiny?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("starting_balance", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'starting_balance' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "starting_balance",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'starting_balance' cannot be null",
                    new System::ArgumentNullException("starting_balance")
                );
        }
        init
        {
            this._properties["starting_balance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, global::Orb.Models.Customers.BalanceTransactions.TypeModel> Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Customers.BalanceTransactions.TypeModel>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
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

    public BalanceTransactionCreateResponse() { }

    public BalanceTransactionCreateResponse(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceTransactionCreateResponse(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BalanceTransactionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(global::Orb.Models.Customers.BalanceTransactions.ActionConverter))]
public enum Action
{
    AppliedToInvoice,
    ManualAdjustment,
    ProratedRefund,
    RevertProratedRefund,
    ReturnFromVoiding,
    CreditNoteApplied,
    CreditNoteVoided,
    OverpaymentRefund,
    ExternalPayment,
    SmallInvoiceCarryover,
}

sealed class ActionConverter
    : JsonConverter<global::Orb.Models.Customers.BalanceTransactions.Action>
{
    public override global::Orb.Models.Customers.BalanceTransactions.Action Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "applied_to_invoice" => global::Orb
                .Models
                .Customers
                .BalanceTransactions
                .Action
                .AppliedToInvoice,
            "manual_adjustment" => global::Orb
                .Models
                .Customers
                .BalanceTransactions
                .Action
                .ManualAdjustment,
            "prorated_refund" => global::Orb
                .Models
                .Customers
                .BalanceTransactions
                .Action
                .ProratedRefund,
            "revert_prorated_refund" => global::Orb
                .Models
                .Customers
                .BalanceTransactions
                .Action
                .RevertProratedRefund,
            "return_from_voiding" => global::Orb
                .Models
                .Customers
                .BalanceTransactions
                .Action
                .ReturnFromVoiding,
            "credit_note_applied" => global::Orb
                .Models
                .Customers
                .BalanceTransactions
                .Action
                .CreditNoteApplied,
            "credit_note_voided" => global::Orb
                .Models
                .Customers
                .BalanceTransactions
                .Action
                .CreditNoteVoided,
            "overpayment_refund" => global::Orb
                .Models
                .Customers
                .BalanceTransactions
                .Action
                .OverpaymentRefund,
            "external_payment" => global::Orb
                .Models
                .Customers
                .BalanceTransactions
                .Action
                .ExternalPayment,
            "small_invoice_carryover" => global::Orb
                .Models
                .Customers
                .BalanceTransactions
                .Action
                .SmallInvoiceCarryover,
            _ => (global::Orb.Models.Customers.BalanceTransactions.Action)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Customers.BalanceTransactions.Action value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Customers.BalanceTransactions.Action.AppliedToInvoice =>
                    "applied_to_invoice",
                global::Orb.Models.Customers.BalanceTransactions.Action.ManualAdjustment =>
                    "manual_adjustment",
                global::Orb.Models.Customers.BalanceTransactions.Action.ProratedRefund =>
                    "prorated_refund",
                global::Orb.Models.Customers.BalanceTransactions.Action.RevertProratedRefund =>
                    "revert_prorated_refund",
                global::Orb.Models.Customers.BalanceTransactions.Action.ReturnFromVoiding =>
                    "return_from_voiding",
                global::Orb.Models.Customers.BalanceTransactions.Action.CreditNoteApplied =>
                    "credit_note_applied",
                global::Orb.Models.Customers.BalanceTransactions.Action.CreditNoteVoided =>
                    "credit_note_voided",
                global::Orb.Models.Customers.BalanceTransactions.Action.OverpaymentRefund =>
                    "overpayment_refund",
                global::Orb.Models.Customers.BalanceTransactions.Action.ExternalPayment =>
                    "external_payment",
                global::Orb.Models.Customers.BalanceTransactions.Action.SmallInvoiceCarryover =>
                    "small_invoice_carryover",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(global::Orb.Models.Customers.BalanceTransactions.TypeModelConverter))]
public enum TypeModel
{
    Increment,
    Decrement,
}

sealed class TypeModelConverter
    : JsonConverter<global::Orb.Models.Customers.BalanceTransactions.TypeModel>
{
    public override global::Orb.Models.Customers.BalanceTransactions.TypeModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "increment" => global::Orb.Models.Customers.BalanceTransactions.TypeModel.Increment,
            "decrement" => global::Orb.Models.Customers.BalanceTransactions.TypeModel.Decrement,
            _ => (global::Orb.Models.Customers.BalanceTransactions.TypeModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Customers.BalanceTransactions.TypeModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Customers.BalanceTransactions.TypeModel.Increment => "increment",
                global::Orb.Models.Customers.BalanceTransactions.TypeModel.Decrement => "decrement",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
