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
        BalanceTransactionListPageResponse,
        BalanceTransactionListPageResponseFromRaw
    >)
)]
public sealed record class BalanceTransactionListPageResponse : ModelBase
{
    public required IReadOnlyList<Data> Data
    {
        get { return ModelBase.GetNotNullClass<List<Data>>(this.RawData, "data"); }
        init { ModelBase.Set(this._rawData, "data", value); }
    }

    public required PaginationMetadata PaginationMetadata
    {
        get
        {
            return ModelBase.GetNotNullClass<PaginationMetadata>(
                this.RawData,
                "pagination_metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "pagination_metadata", value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.PaginationMetadata.Validate();
    }

    public BalanceTransactionListPageResponse() { }

    public BalanceTransactionListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BalanceTransactionListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BalanceTransactionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BalanceTransactionListPageResponseFromRaw : IFromRaw<BalanceTransactionListPageResponse>
{
    public BalanceTransactionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BalanceTransactionListPageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Data, DataFromRaw>))]
public sealed record class Data : ModelBase
{
    /// <summary>
    /// A unique id for this transaction.
    /// </summary>
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public required ApiEnum<string, DataAction> Action
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, DataAction>>(this.RawData, "action");
        }
        init { ModelBase.Set(this._rawData, "action", value); }
    }

    /// <summary>
    /// The value of the amount changed in the transaction.
    /// </summary>
    public required string Amount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "amount"); }
        init { ModelBase.Set(this._rawData, "amount", value); }
    }

    /// <summary>
    /// The creation time of this transaction.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "created_at");
        }
        init { ModelBase.Set(this._rawData, "created_at", value); }
    }

    public required CreditNoteTiny? CreditNote
    {
        get { return ModelBase.GetNullableClass<CreditNoteTiny>(this.RawData, "credit_note"); }
        init { ModelBase.Set(this._rawData, "credit_note", value); }
    }

    /// <summary>
    /// An optional description provided for manual customer balance adjustments.
    /// </summary>
    public required string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "description"); }
        init { ModelBase.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// The new value of the customer's balance prior to the transaction, in the customer's currency.
    /// </summary>
    public required string EndingBalance
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "ending_balance"); }
        init { ModelBase.Set(this._rawData, "ending_balance", value); }
    }

    public required InvoiceTiny? Invoice
    {
        get { return ModelBase.GetNullableClass<InvoiceTiny>(this.RawData, "invoice"); }
        init { ModelBase.Set(this._rawData, "invoice", value); }
    }

    /// <summary>
    /// The original value of the customer's balance prior to the transaction, in
    /// the customer's currency.
    /// </summary>
    public required string StartingBalance
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "starting_balance"); }
        init { ModelBase.Set(this._rawData, "starting_balance", value); }
    }

    public required ApiEnum<string, DataType> Type
    {
        get { return ModelBase.GetNotNullClass<ApiEnum<string, DataType>>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
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

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRaw<Data>
{
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DataActionConverter))]
public enum DataAction
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

sealed class DataActionConverter : JsonConverter<DataAction>
{
    public override DataAction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "applied_to_invoice" => DataAction.AppliedToInvoice,
            "manual_adjustment" => DataAction.ManualAdjustment,
            "prorated_refund" => DataAction.ProratedRefund,
            "revert_prorated_refund" => DataAction.RevertProratedRefund,
            "return_from_voiding" => DataAction.ReturnFromVoiding,
            "credit_note_applied" => DataAction.CreditNoteApplied,
            "credit_note_voided" => DataAction.CreditNoteVoided,
            "overpayment_refund" => DataAction.OverpaymentRefund,
            "external_payment" => DataAction.ExternalPayment,
            "small_invoice_carryover" => DataAction.SmallInvoiceCarryover,
            _ => (DataAction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataAction.AppliedToInvoice => "applied_to_invoice",
                DataAction.ManualAdjustment => "manual_adjustment",
                DataAction.ProratedRefund => "prorated_refund",
                DataAction.RevertProratedRefund => "revert_prorated_refund",
                DataAction.ReturnFromVoiding => "return_from_voiding",
                DataAction.CreditNoteApplied => "credit_note_applied",
                DataAction.CreditNoteVoided => "credit_note_voided",
                DataAction.OverpaymentRefund => "overpayment_refund",
                DataAction.ExternalPayment => "external_payment",
                DataAction.SmallInvoiceCarryover => "small_invoice_carryover",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(DataTypeConverter))]
public enum DataType
{
    Increment,
    Decrement,
}

sealed class DataTypeConverter : JsonConverter<DataType>
{
    public override DataType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "increment" => DataType.Increment,
            "decrement" => DataType.Decrement,
            _ => (DataType)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, DataType value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataType.Increment => "increment",
                DataType.Decrement => "decrement",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
