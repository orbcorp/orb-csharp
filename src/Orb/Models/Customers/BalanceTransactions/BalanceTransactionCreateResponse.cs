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
    typeof(JsonModelConverter<
        BalanceTransactionCreateResponse,
        BalanceTransactionCreateResponseFromRaw
    >)
)]
public sealed record class BalanceTransactionCreateResponse : JsonModel
{
    /// <summary>
    /// A unique id for this transaction.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required ApiEnum<string, Action> Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Action>>("action");
        }
        init { this._rawData.Set("action", value); }
    }

    /// <summary>
    /// The value of the amount changed in the transaction.
    /// </summary>
    public required string Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The creation time of this transaction.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required CreditNoteTiny? CreditNote
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CreditNoteTiny>("credit_note");
        }
        init { this._rawData.Set("credit_note", value); }
    }

    /// <summary>
    /// An optional description provided for manual customer balance adjustments.
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The new value of the customer's balance prior to the transaction, in the customer's currency.
    /// </summary>
    public required string EndingBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("ending_balance");
        }
        init { this._rawData.Set("ending_balance", value); }
    }

    public required InvoiceTiny? Invoice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InvoiceTiny>("invoice");
        }
        init { this._rawData.Set("invoice", value); }
    }

    /// <summary>
    /// The original value of the customer's balance prior to the transaction, in
    /// the customer's currency.
    /// </summary>
    public required string StartingBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("starting_balance");
        }
        init { this._rawData.Set("starting_balance", value); }
    }

    public required ApiEnum<string, BalanceTransactionCreateResponseType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BalanceTransactionCreateResponseType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BalanceTransactionCreateResponse(
        BalanceTransactionCreateResponse balanceTransactionCreateResponse
    )
        : base(balanceTransactionCreateResponse) { }
#pragma warning restore CS8618

    public BalanceTransactionCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceTransactionCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BalanceTransactionCreateResponseFromRaw.FromRawUnchecked"/>
    public static BalanceTransactionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BalanceTransactionCreateResponseFromRaw : IFromRawJson<BalanceTransactionCreateResponse>
{
    /// <inheritdoc/>
    public BalanceTransactionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BalanceTransactionCreateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ActionConverter))]
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

sealed class ActionConverter : JsonConverter<Action>
{
    public override Action Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "applied_to_invoice" => Action.AppliedToInvoice,
            "manual_adjustment" => Action.ManualAdjustment,
            "prorated_refund" => Action.ProratedRefund,
            "revert_prorated_refund" => Action.RevertProratedRefund,
            "return_from_voiding" => Action.ReturnFromVoiding,
            "credit_note_applied" => Action.CreditNoteApplied,
            "credit_note_voided" => Action.CreditNoteVoided,
            "overpayment_refund" => Action.OverpaymentRefund,
            "external_payment" => Action.ExternalPayment,
            "small_invoice_carryover" => Action.SmallInvoiceCarryover,
            _ => (Action)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Action value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Action.AppliedToInvoice => "applied_to_invoice",
                Action.ManualAdjustment => "manual_adjustment",
                Action.ProratedRefund => "prorated_refund",
                Action.RevertProratedRefund => "revert_prorated_refund",
                Action.ReturnFromVoiding => "return_from_voiding",
                Action.CreditNoteApplied => "credit_note_applied",
                Action.CreditNoteVoided => "credit_note_voided",
                Action.OverpaymentRefund => "overpayment_refund",
                Action.ExternalPayment => "external_payment",
                Action.SmallInvoiceCarryover => "small_invoice_carryover",
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
