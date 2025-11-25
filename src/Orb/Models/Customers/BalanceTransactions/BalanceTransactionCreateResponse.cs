using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers.BalanceTransactions;

[JsonConverter(
    typeof(ModelConverter<
        BalanceTransactionCreateResponse,
        BalanceTransactionCreateResponseFromRaw
    >)
)]
public sealed record class BalanceTransactionCreateResponse : ModelBase
{
    /// <summary>
    /// A unique id for this transaction.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
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
            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, global::Orb.Models.Customers.BalanceTransactions.Action> Action
    {
        get
        {
            if (!this._rawData.TryGetValue("action", out JsonElement element))
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
            this._rawData["action"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("amount", out JsonElement element))
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
            this._rawData["amount"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("created_at", out JsonElement element))
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
            this._rawData["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required CreditNoteTiny? CreditNote
    {
        get
        {
            if (!this._rawData.TryGetValue("credit_note", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CreditNoteTiny?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["credit_note"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["description"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("ending_balance", out JsonElement element))
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
            this._rawData["ending_balance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required InvoiceTiny? Invoice
    {
        get
        {
            if (!this._rawData.TryGetValue("invoice", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<InvoiceTiny?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["invoice"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("starting_balance", out JsonElement element))
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
            this._rawData["starting_balance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, BalanceTransactionCreateResponseType> Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, BalanceTransactionCreateResponseType>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
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

    public BalanceTransactionCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceTransactionCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BalanceTransactionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BalanceTransactionCreateResponseFromRaw : IFromRaw<BalanceTransactionCreateResponse>
{
    public BalanceTransactionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BalanceTransactionCreateResponse.FromRawUnchecked(rawData);
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

[JsonConverter(typeof(BalanceTransactionCreateResponseTypeConverter))]
public enum BalanceTransactionCreateResponseType
{
    Increment,
    Decrement,
}

sealed class BalanceTransactionCreateResponseTypeConverter
    : JsonConverter<BalanceTransactionCreateResponseType>
{
    public override BalanceTransactionCreateResponseType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "increment" => BalanceTransactionCreateResponseType.Increment,
            "decrement" => BalanceTransactionCreateResponseType.Decrement,
            _ => (BalanceTransactionCreateResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BalanceTransactionCreateResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BalanceTransactionCreateResponseType.Increment => "increment",
                BalanceTransactionCreateResponseType.Decrement => "decrement",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
