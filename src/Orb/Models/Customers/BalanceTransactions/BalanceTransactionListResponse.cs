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
        BalanceTransactionListResponse,
        BalanceTransactionListResponseFromRaw
    >)
)]
public sealed record class BalanceTransactionListResponse : JsonModel
{
    /// <summary>
    /// A unique id for this transaction.
    /// </summary>
    public required string ID
    {
        get { return this._rawData.GetNotNullClass<string>("id"); }
        init { this._rawData.Set("id", value); }
    }

    public required ApiEnum<string, BalanceTransactionListResponseAction> Action
    {
        get
        {
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BalanceTransactionListResponseAction>
            >("action");
        }
        init { this._rawData.Set("action", value); }
    }

    /// <summary>
    /// The value of the amount changed in the transaction.
    /// </summary>
    public required string Amount
    {
        get { return this._rawData.GetNotNullClass<string>("amount"); }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// The creation time of this transaction.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get { return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at"); }
        init { this._rawData.Set("created_at", value); }
    }

    public required CreditNoteTiny? CreditNote
    {
        get { return this._rawData.GetNullableClass<CreditNoteTiny>("credit_note"); }
        init { this._rawData.Set("credit_note", value); }
    }

    /// <summary>
    /// An optional description provided for manual customer balance adjustments.
    /// </summary>
    public required string? Description
    {
        get { return this._rawData.GetNullableClass<string>("description"); }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The new value of the customer's balance prior to the transaction, in the customer's currency.
    /// </summary>
    public required string EndingBalance
    {
        get { return this._rawData.GetNotNullClass<string>("ending_balance"); }
        init { this._rawData.Set("ending_balance", value); }
    }

    public required InvoiceTiny? Invoice
    {
        get { return this._rawData.GetNullableClass<InvoiceTiny>("invoice"); }
        init { this._rawData.Set("invoice", value); }
    }

    /// <summary>
    /// The original value of the customer's balance prior to the transaction, in
    /// the customer's currency.
    /// </summary>
    public required string StartingBalance
    {
        get { return this._rawData.GetNotNullClass<string>("starting_balance"); }
        init { this._rawData.Set("starting_balance", value); }
    }

    public required ApiEnum<string, BalanceTransactionListResponseType> Type
    {
        get
        {
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BalanceTransactionListResponseType>
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

    public BalanceTransactionListResponse() { }

    public BalanceTransactionListResponse(
        BalanceTransactionListResponse balanceTransactionListResponse
    )
        : base(balanceTransactionListResponse) { }

    public BalanceTransactionListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceTransactionListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BalanceTransactionListResponseFromRaw.FromRawUnchecked"/>
    public static BalanceTransactionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BalanceTransactionListResponseFromRaw : IFromRawJson<BalanceTransactionListResponse>
{
    /// <inheritdoc/>
    public BalanceTransactionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BalanceTransactionListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BalanceTransactionListResponseActionConverter))]
public enum BalanceTransactionListResponseAction
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

sealed class BalanceTransactionListResponseActionConverter
    : JsonConverter<BalanceTransactionListResponseAction>
{
    public override BalanceTransactionListResponseAction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "applied_to_invoice" => BalanceTransactionListResponseAction.AppliedToInvoice,
            "manual_adjustment" => BalanceTransactionListResponseAction.ManualAdjustment,
            "prorated_refund" => BalanceTransactionListResponseAction.ProratedRefund,
            "revert_prorated_refund" => BalanceTransactionListResponseAction.RevertProratedRefund,
            "return_from_voiding" => BalanceTransactionListResponseAction.ReturnFromVoiding,
            "credit_note_applied" => BalanceTransactionListResponseAction.CreditNoteApplied,
            "credit_note_voided" => BalanceTransactionListResponseAction.CreditNoteVoided,
            "overpayment_refund" => BalanceTransactionListResponseAction.OverpaymentRefund,
            "external_payment" => BalanceTransactionListResponseAction.ExternalPayment,
            "small_invoice_carryover" => BalanceTransactionListResponseAction.SmallInvoiceCarryover,
            _ => (BalanceTransactionListResponseAction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BalanceTransactionListResponseAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BalanceTransactionListResponseAction.AppliedToInvoice => "applied_to_invoice",
                BalanceTransactionListResponseAction.ManualAdjustment => "manual_adjustment",
                BalanceTransactionListResponseAction.ProratedRefund => "prorated_refund",
                BalanceTransactionListResponseAction.RevertProratedRefund =>
                    "revert_prorated_refund",
                BalanceTransactionListResponseAction.ReturnFromVoiding => "return_from_voiding",
                BalanceTransactionListResponseAction.CreditNoteApplied => "credit_note_applied",
                BalanceTransactionListResponseAction.CreditNoteVoided => "credit_note_voided",
                BalanceTransactionListResponseAction.OverpaymentRefund => "overpayment_refund",
                BalanceTransactionListResponseAction.ExternalPayment => "external_payment",
                BalanceTransactionListResponseAction.SmallInvoiceCarryover =>
                    "small_invoice_carryover",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(BalanceTransactionListResponseTypeConverter))]
public enum BalanceTransactionListResponseType
{
    Increment,
    Decrement,
}

sealed class BalanceTransactionListResponseTypeConverter
    : JsonConverter<BalanceTransactionListResponseType>
{
    public override BalanceTransactionListResponseType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "increment" => BalanceTransactionListResponseType.Increment,
            "decrement" => BalanceTransactionListResponseType.Decrement,
            _ => (BalanceTransactionListResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BalanceTransactionListResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BalanceTransactionListResponseType.Increment => "increment",
                BalanceTransactionListResponseType.Decrement => "decrement",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
