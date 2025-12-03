using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

/// <summary>
/// The [Credit Note](/invoicing/credit-notes) resource represents a credit that
/// has been applied to a particular invoice.
/// </summary>
[JsonConverter(typeof(ModelConverter<SharedCreditNote, SharedCreditNoteFromRaw>))]
public sealed record class SharedCreditNote : ModelBase
{
    /// <summary>
    /// The Orb id of this credit note.
    /// </summary>
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// The creation time of the resource in Orb.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "created_at");
        }
        init { ModelBase.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// The unique identifier for credit notes.
    /// </summary>
    public required string CreditNoteNumber
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "credit_note_number"); }
        init { ModelBase.Set(this._rawData, "credit_note_number", value); }
    }

    /// <summary>
    /// A URL to a PDF of the credit note.
    /// </summary>
    public required string? CreditNotePdf
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "credit_note_pdf"); }
        init { ModelBase.Set(this._rawData, "credit_note_pdf", value); }
    }

    public required CustomerMinified Customer
    {
        get { return ModelBase.GetNotNullClass<CustomerMinified>(this.RawData, "customer"); }
        init { ModelBase.Set(this._rawData, "customer", value); }
    }

    /// <summary>
    /// The id of the invoice resource that this credit note is applied to.
    /// </summary>
    public required string InvoiceID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "invoice_id"); }
        init { ModelBase.Set(this._rawData, "invoice_id", value); }
    }

    /// <summary>
    /// All of the line items associated with this credit note.
    /// </summary>
    public required IReadOnlyList<SharedCreditNoteLineItem> LineItems
    {
        get
        {
            return ModelBase.GetNotNullClass<List<SharedCreditNoteLineItem>>(
                this.RawData,
                "line_items"
            );
        }
        init { ModelBase.Set(this._rawData, "line_items", value); }
    }

    /// <summary>
    /// The maximum amount applied on the original invoice
    /// </summary>
    public required MaximumAmountAdjustment? MaximumAmountAdjustment
    {
        get
        {
            return ModelBase.GetNullableClass<MaximumAmountAdjustment>(
                this.RawData,
                "maximum_amount_adjustment"
            );
        }
        init { ModelBase.Set(this._rawData, "maximum_amount_adjustment", value); }
    }

    /// <summary>
    /// An optional memo supplied on the credit note.
    /// </summary>
    public required string? Memo
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "memo"); }
        init { ModelBase.Set(this._rawData, "memo", value); }
    }

    /// <summary>
    /// Any credited amount from the applied minimum on the invoice.
    /// </summary>
    public required string? MinimumAmountRefunded
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "minimum_amount_refunded"); }
        init { ModelBase.Set(this._rawData, "minimum_amount_refunded", value); }
    }

    public required ApiEnum<string, Reason>? Reason
    {
        get { return ModelBase.GetNullableClass<ApiEnum<string, Reason>>(this.RawData, "reason"); }
        init { ModelBase.Set(this._rawData, "reason", value); }
    }

    /// <summary>
    /// The total prior to any creditable invoice-level discounts or minimums.
    /// </summary>
    public required string Subtotal
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "subtotal"); }
        init { ModelBase.Set(this._rawData, "subtotal", value); }
    }

    /// <summary>
    /// The total including creditable invoice-level discounts or minimums, and tax.
    /// </summary>
    public required string Total
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "total"); }
        init { ModelBase.Set(this._rawData, "total", value); }
    }

    public required ApiEnum<string, SharedCreditNoteType> Type
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, SharedCreditNoteType>>(
                this.RawData,
                "type"
            );
        }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// The time at which the credit note was voided in Orb, if applicable.
    /// </summary>
    public required System::DateTimeOffset? VoidedAt
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(this.RawData, "voided_at");
        }
        init { ModelBase.Set(this._rawData, "voided_at", value); }
    }

    /// <summary>
    /// Any discounts applied on the original invoice.
    /// </summary>
    public IReadOnlyList<SharedCreditNoteDiscount>? Discounts
    {
        get
        {
            return ModelBase.GetNullableClass<List<SharedCreditNoteDiscount>>(
                this.RawData,
                "discounts"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "discounts", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.CreditNoteNumber;
        _ = this.CreditNotePdf;
        this.Customer.Validate();
        _ = this.InvoiceID;
        foreach (var item in this.LineItems)
        {
            item.Validate();
        }
        this.MaximumAmountAdjustment?.Validate();
        _ = this.Memo;
        _ = this.MinimumAmountRefunded;
        this.Reason?.Validate();
        _ = this.Subtotal;
        _ = this.Total;
        this.Type.Validate();
        _ = this.VoidedAt;
        foreach (var item in this.Discounts ?? [])
        {
            item.Validate();
        }
    }

    public SharedCreditNote() { }

    public SharedCreditNote(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SharedCreditNote(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SharedCreditNoteFromRaw.FromRawUnchecked"/>
    public static SharedCreditNote FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SharedCreditNoteFromRaw : IFromRaw<SharedCreditNote>
{
    /// <inheritdoc/>
    public SharedCreditNote FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SharedCreditNote.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<SharedCreditNoteLineItem, SharedCreditNoteLineItemFromRaw>))]
public sealed record class SharedCreditNoteLineItem : ModelBase
{
    /// <summary>
    /// The Orb id of this resource.
    /// </summary>
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// The amount of the line item, including any line item minimums and discounts.
    /// </summary>
    public required string Amount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "amount"); }
        init { ModelBase.Set(this._rawData, "amount", value); }
    }

    /// <summary>
    /// The id of the item associated with this line item.
    /// </summary>
    public required string ItemID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { ModelBase.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The name of the corresponding invoice line item.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// An optional quantity credited.
    /// </summary>
    public required double? Quantity
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "quantity"); }
        init { ModelBase.Set(this._rawData, "quantity", value); }
    }

    /// <summary>
    /// The amount of the line item, excluding any line item minimums and discounts.
    /// </summary>
    public required string Subtotal
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "subtotal"); }
        init { ModelBase.Set(this._rawData, "subtotal", value); }
    }

    /// <summary>
    /// Any tax amounts applied onto the line item.
    /// </summary>
    public required IReadOnlyList<TaxAmount> TaxAmounts
    {
        get { return ModelBase.GetNotNullClass<List<TaxAmount>>(this.RawData, "tax_amounts"); }
        init { ModelBase.Set(this._rawData, "tax_amounts", value); }
    }

    /// <summary>
    /// Any line item discounts from the invoice's line item.
    /// </summary>
    public IReadOnlyList<Discount>? Discounts
    {
        get { return ModelBase.GetNullableClass<List<Discount>>(this.RawData, "discounts"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "discounts", value);
        }
    }

    /// <summary>
    /// The end time of the service period for this credit note line item.
    /// </summary>
    public System::DateTimeOffset? EndTimeExclusive
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(
                this.RawData,
                "end_time_exclusive"
            );
        }
        init { ModelBase.Set(this._rawData, "end_time_exclusive", value); }
    }

    /// <summary>
    /// The start time of the service period for this credit note line item.
    /// </summary>
    public System::DateTimeOffset? StartTimeInclusive
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(
                this.RawData,
                "start_time_inclusive"
            );
        }
        init { ModelBase.Set(this._rawData, "start_time_inclusive", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Amount;
        _ = this.ItemID;
        _ = this.Name;
        _ = this.Quantity;
        _ = this.Subtotal;
        foreach (var item in this.TaxAmounts)
        {
            item.Validate();
        }
        foreach (var item in this.Discounts ?? [])
        {
            item.Validate();
        }
        _ = this.EndTimeExclusive;
        _ = this.StartTimeInclusive;
    }

    public SharedCreditNoteLineItem() { }

    public SharedCreditNoteLineItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SharedCreditNoteLineItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SharedCreditNoteLineItemFromRaw.FromRawUnchecked"/>
    public static SharedCreditNoteLineItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SharedCreditNoteLineItemFromRaw : IFromRaw<SharedCreditNoteLineItem>
{
    /// <inheritdoc/>
    public SharedCreditNoteLineItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SharedCreditNoteLineItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Discount, DiscountFromRaw>))]
public sealed record class Discount : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public required string AmountApplied
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "amount_applied"); }
        init { ModelBase.Set(this._rawData, "amount_applied", value); }
    }

    public required IReadOnlyList<string> AppliesToPriceIDs
    {
        get
        {
            return ModelBase.GetNotNullClass<List<string>>(this.RawData, "applies_to_price_ids");
        }
        init { ModelBase.Set(this._rawData, "applies_to_price_ids", value); }
    }

    public required ApiEnum<string, DiscountDiscountType> DiscountType
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, DiscountDiscountType>>(
                this.RawData,
                "discount_type"
            );
        }
        init { ModelBase.Set(this._rawData, "discount_type", value); }
    }

    public required double PercentageDiscount
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "percentage_discount"); }
        init { ModelBase.Set(this._rawData, "percentage_discount", value); }
    }

    public string? AmountDiscount
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "amount_discount"); }
        init { ModelBase.Set(this._rawData, "amount_discount", value); }
    }

    public string? Reason
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "reason"); }
        init { ModelBase.Set(this._rawData, "reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AmountApplied;
        _ = this.AppliesToPriceIDs;
        this.DiscountType.Validate();
        _ = this.PercentageDiscount;
        _ = this.AmountDiscount;
        _ = this.Reason;
    }

    public Discount() { }

    public Discount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Discount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DiscountFromRaw.FromRawUnchecked"/>
    public static Discount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DiscountFromRaw : IFromRaw<Discount>
{
    /// <inheritdoc/>
    public Discount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Discount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DiscountDiscountTypeConverter))]
public enum DiscountDiscountType
{
    Percentage,
    Amount,
}

sealed class DiscountDiscountTypeConverter : JsonConverter<DiscountDiscountType>
{
    public override DiscountDiscountType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "percentage" => DiscountDiscountType.Percentage,
            "amount" => DiscountDiscountType.Amount,
            _ => (DiscountDiscountType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DiscountDiscountType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DiscountDiscountType.Percentage => "percentage",
                DiscountDiscountType.Amount => "amount",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The maximum amount applied on the original invoice
/// </summary>
[JsonConverter(typeof(ModelConverter<MaximumAmountAdjustment, MaximumAmountAdjustmentFromRaw>))]
public sealed record class MaximumAmountAdjustment : ModelBase
{
    public required string AmountApplied
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "amount_applied"); }
        init { ModelBase.Set(this._rawData, "amount_applied", value); }
    }

    public required ApiEnum<string, MaximumAmountAdjustmentDiscountType> DiscountType
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, MaximumAmountAdjustmentDiscountType>>(
                this.RawData,
                "discount_type"
            );
        }
        init { ModelBase.Set(this._rawData, "discount_type", value); }
    }

    public required double PercentageDiscount
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "percentage_discount"); }
        init { ModelBase.Set(this._rawData, "percentage_discount", value); }
    }

    public IReadOnlyList<AppliesToPrice>? AppliesToPrices
    {
        get
        {
            return ModelBase.GetNullableClass<List<AppliesToPrice>>(
                this.RawData,
                "applies_to_prices"
            );
        }
        init { ModelBase.Set(this._rawData, "applies_to_prices", value); }
    }

    public string? Reason
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "reason"); }
        init { ModelBase.Set(this._rawData, "reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AmountApplied;
        this.DiscountType.Validate();
        _ = this.PercentageDiscount;
        foreach (var item in this.AppliesToPrices ?? [])
        {
            item.Validate();
        }
        _ = this.Reason;
    }

    public MaximumAmountAdjustment() { }

    public MaximumAmountAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MaximumAmountAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MaximumAmountAdjustmentFromRaw.FromRawUnchecked"/>
    public static MaximumAmountAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MaximumAmountAdjustmentFromRaw : IFromRaw<MaximumAmountAdjustment>
{
    /// <inheritdoc/>
    public MaximumAmountAdjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MaximumAmountAdjustment.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MaximumAmountAdjustmentDiscountTypeConverter))]
public enum MaximumAmountAdjustmentDiscountType
{
    Percentage,
}

sealed class MaximumAmountAdjustmentDiscountTypeConverter
    : JsonConverter<MaximumAmountAdjustmentDiscountType>
{
    public override MaximumAmountAdjustmentDiscountType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "percentage" => MaximumAmountAdjustmentDiscountType.Percentage,
            _ => (MaximumAmountAdjustmentDiscountType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MaximumAmountAdjustmentDiscountType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MaximumAmountAdjustmentDiscountType.Percentage => "percentage",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<AppliesToPrice, AppliesToPriceFromRaw>))]
public sealed record class AppliesToPrice : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public AppliesToPrice() { }

    public AppliesToPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AppliesToPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AppliesToPriceFromRaw.FromRawUnchecked"/>
    public static AppliesToPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AppliesToPriceFromRaw : IFromRaw<AppliesToPrice>
{
    /// <inheritdoc/>
    public AppliesToPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AppliesToPrice.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ReasonConverter))]
public enum Reason
{
    Duplicate,
    Fraudulent,
    OrderChange,
    ProductUnsatisfactory,
}

sealed class ReasonConverter : JsonConverter<Reason>
{
    public override Reason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Duplicate" => Reason.Duplicate,
            "Fraudulent" => Reason.Fraudulent,
            "Order change" => Reason.OrderChange,
            "Product unsatisfactory" => Reason.ProductUnsatisfactory,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.Duplicate => "Duplicate",
                Reason.Fraudulent => "Fraudulent",
                Reason.OrderChange => "Order change",
                Reason.ProductUnsatisfactory => "Product unsatisfactory",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(SharedCreditNoteTypeConverter))]
public enum SharedCreditNoteType
{
    Refund,
    Adjustment,
}

sealed class SharedCreditNoteTypeConverter : JsonConverter<SharedCreditNoteType>
{
    public override SharedCreditNoteType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "refund" => SharedCreditNoteType.Refund,
            "adjustment" => SharedCreditNoteType.Adjustment,
            _ => (SharedCreditNoteType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SharedCreditNoteType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SharedCreditNoteType.Refund => "refund",
                SharedCreditNoteType.Adjustment => "adjustment",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<SharedCreditNoteDiscount, SharedCreditNoteDiscountFromRaw>))]
public sealed record class SharedCreditNoteDiscount : ModelBase
{
    public required string AmountApplied
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "amount_applied"); }
        init { ModelBase.Set(this._rawData, "amount_applied", value); }
    }

    public required ApiEnum<string, SharedCreditNoteDiscountDiscountType> DiscountType
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, SharedCreditNoteDiscountDiscountType>>(
                this.RawData,
                "discount_type"
            );
        }
        init { ModelBase.Set(this._rawData, "discount_type", value); }
    }

    public required double PercentageDiscount
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "percentage_discount"); }
        init { ModelBase.Set(this._rawData, "percentage_discount", value); }
    }

    public IReadOnlyList<SharedCreditNoteDiscountAppliesToPrice>? AppliesToPrices
    {
        get
        {
            return ModelBase.GetNullableClass<List<SharedCreditNoteDiscountAppliesToPrice>>(
                this.RawData,
                "applies_to_prices"
            );
        }
        init { ModelBase.Set(this._rawData, "applies_to_prices", value); }
    }

    public string? Reason
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "reason"); }
        init { ModelBase.Set(this._rawData, "reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AmountApplied;
        this.DiscountType.Validate();
        _ = this.PercentageDiscount;
        foreach (var item in this.AppliesToPrices ?? [])
        {
            item.Validate();
        }
        _ = this.Reason;
    }

    public SharedCreditNoteDiscount() { }

    public SharedCreditNoteDiscount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SharedCreditNoteDiscount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SharedCreditNoteDiscountFromRaw.FromRawUnchecked"/>
    public static SharedCreditNoteDiscount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SharedCreditNoteDiscountFromRaw : IFromRaw<SharedCreditNoteDiscount>
{
    /// <inheritdoc/>
    public SharedCreditNoteDiscount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SharedCreditNoteDiscount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SharedCreditNoteDiscountDiscountTypeConverter))]
public enum SharedCreditNoteDiscountDiscountType
{
    Percentage,
}

sealed class SharedCreditNoteDiscountDiscountTypeConverter
    : JsonConverter<SharedCreditNoteDiscountDiscountType>
{
    public override SharedCreditNoteDiscountDiscountType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "percentage" => SharedCreditNoteDiscountDiscountType.Percentage,
            _ => (SharedCreditNoteDiscountDiscountType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SharedCreditNoteDiscountDiscountType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SharedCreditNoteDiscountDiscountType.Percentage => "percentage",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(ModelConverter<
        SharedCreditNoteDiscountAppliesToPrice,
        SharedCreditNoteDiscountAppliesToPriceFromRaw
    >)
)]
public sealed record class SharedCreditNoteDiscountAppliesToPrice : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public SharedCreditNoteDiscountAppliesToPrice() { }

    public SharedCreditNoteDiscountAppliesToPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SharedCreditNoteDiscountAppliesToPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SharedCreditNoteDiscountAppliesToPriceFromRaw.FromRawUnchecked"/>
    public static SharedCreditNoteDiscountAppliesToPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SharedCreditNoteDiscountAppliesToPriceFromRaw
    : IFromRaw<SharedCreditNoteDiscountAppliesToPrice>
{
    /// <inheritdoc/>
    public SharedCreditNoteDiscountAppliesToPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SharedCreditNoteDiscountAppliesToPrice.FromRawUnchecked(rawData);
}
