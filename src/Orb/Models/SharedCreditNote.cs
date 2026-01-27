using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
[JsonConverter(typeof(JsonModelConverter<SharedCreditNote, SharedCreditNoteFromRaw>))]
public sealed record class SharedCreditNote : JsonModel
{
    /// <summary>
    /// The Orb id of this credit note.
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

    /// <summary>
    /// The creation time of the resource in Orb.
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

    /// <summary>
    /// The unique identifier for credit notes.
    /// </summary>
    public required string CreditNoteNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("credit_note_number");
        }
        init { this._rawData.Set("credit_note_number", value); }
    }

    /// <summary>
    /// A URL to a PDF of the credit note.
    /// </summary>
    public required string? CreditNotePdf
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("credit_note_pdf");
        }
        init { this._rawData.Set("credit_note_pdf", value); }
    }

    public required CustomerMinified Customer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CustomerMinified>("customer");
        }
        init { this._rawData.Set("customer", value); }
    }

    /// <summary>
    /// The id of the invoice resource that this credit note is applied to.
    /// </summary>
    public required string InvoiceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("invoice_id");
        }
        init { this._rawData.Set("invoice_id", value); }
    }

    /// <summary>
    /// All of the line items associated with this credit note.
    /// </summary>
    public required IReadOnlyList<SharedCreditNoteLineItem> LineItems
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<SharedCreditNoteLineItem>>(
                "line_items"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<SharedCreditNoteLineItem>>(
                "line_items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The maximum amount applied on the original invoice
    /// </summary>
    public required MaximumAmountAdjustment? MaximumAmountAdjustment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MaximumAmountAdjustment>(
                "maximum_amount_adjustment"
            );
        }
        init { this._rawData.Set("maximum_amount_adjustment", value); }
    }

    /// <summary>
    /// An optional memo supplied on the credit note.
    /// </summary>
    public required string? Memo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("memo");
        }
        init { this._rawData.Set("memo", value); }
    }

    /// <summary>
    /// Any credited amount from the applied minimum on the invoice.
    /// </summary>
    public required string? MinimumAmountRefunded
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("minimum_amount_refunded");
        }
        init { this._rawData.Set("minimum_amount_refunded", value); }
    }

    public required ApiEnum<string, Reason>? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Reason>>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// The total prior to any creditable invoice-level discounts or minimums.
    /// </summary>
    public required string Subtotal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("subtotal");
        }
        init { this._rawData.Set("subtotal", value); }
    }

    /// <summary>
    /// The total including creditable invoice-level discounts or minimums, and tax.
    /// </summary>
    public required string Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("total");
        }
        init { this._rawData.Set("total", value); }
    }

    public required ApiEnum<string, SharedCreditNoteType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SharedCreditNoteType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The time at which the credit note was voided in Orb, if applicable.
    /// </summary>
    public required System::DateTimeOffset? VoidedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("voided_at");
        }
        init { this._rawData.Set("voided_at", value); }
    }

    /// <summary>
    /// Any discounts applied on the original invoice.
    /// </summary>
    public IReadOnlyList<SharedCreditNoteDiscount>? Discounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SharedCreditNoteDiscount>>(
                "discounts"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SharedCreditNoteDiscount>?>(
                "discounts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SharedCreditNote(SharedCreditNote sharedCreditNote)
        : base(sharedCreditNote) { }
#pragma warning restore CS8618

    public SharedCreditNote(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SharedCreditNote(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class SharedCreditNoteFromRaw : IFromRawJson<SharedCreditNote>
{
    /// <inheritdoc/>
    public SharedCreditNote FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SharedCreditNote.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SharedCreditNoteLineItem, SharedCreditNoteLineItemFromRaw>)
)]
public sealed record class SharedCreditNoteLineItem : JsonModel
{
    /// <summary>
    /// The Orb id of this resource.
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

    /// <summary>
    /// The amount of the line item, including any line item minimums and discounts.
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
    /// The id of the item associated with this line item.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    /// <summary>
    /// The name of the corresponding invoice line item.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// An optional quantity credited.
    /// </summary>
    public required double? Quantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("quantity");
        }
        init { this._rawData.Set("quantity", value); }
    }

    /// <summary>
    /// The amount of the line item, excluding any line item minimums and discounts.
    /// </summary>
    public required string Subtotal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("subtotal");
        }
        init { this._rawData.Set("subtotal", value); }
    }

    /// <summary>
    /// Any tax amounts applied onto the line item.
    /// </summary>
    public required IReadOnlyList<TaxAmount> TaxAmounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TaxAmount>>("tax_amounts");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TaxAmount>>(
                "tax_amounts",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Any line item discounts from the invoice's line item.
    /// </summary>
    public IReadOnlyList<Discount>? Discounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Discount>>("discounts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Discount>?>(
                "discounts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The end time of the service period for this credit note line item.
    /// </summary>
    public System::DateTimeOffset? EndTimeExclusive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("end_time_exclusive");
        }
        init { this._rawData.Set("end_time_exclusive", value); }
    }

    /// <summary>
    /// The start time of the service period for this credit note line item.
    /// </summary>
    public System::DateTimeOffset? StartTimeInclusive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("start_time_inclusive");
        }
        init { this._rawData.Set("start_time_inclusive", value); }
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SharedCreditNoteLineItem(SharedCreditNoteLineItem sharedCreditNoteLineItem)
        : base(sharedCreditNoteLineItem) { }
#pragma warning restore CS8618

    public SharedCreditNoteLineItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SharedCreditNoteLineItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class SharedCreditNoteLineItemFromRaw : IFromRawJson<SharedCreditNoteLineItem>
{
    /// <inheritdoc/>
    public SharedCreditNoteLineItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SharedCreditNoteLineItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Discount, DiscountFromRaw>))]
public sealed record class Discount : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string AmountApplied
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("amount_applied");
        }
        init { this._rawData.Set("amount_applied", value); }
    }

    public required IReadOnlyList<string> AppliesToPriceIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("applies_to_price_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "applies_to_price_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, DiscountDiscountType> DiscountType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DiscountDiscountType>>(
                "discount_type"
            );
        }
        init { this._rawData.Set("discount_type", value); }
    }

    public required double PercentageDiscount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("percentage_discount");
        }
        init { this._rawData.Set("percentage_discount", value); }
    }

    public string? AmountDiscount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("amount_discount");
        }
        init { this._rawData.Set("amount_discount", value); }
    }

    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AmountApplied;
        _ = this.AppliesToPriceIds;
        this.DiscountType.Validate();
        _ = this.PercentageDiscount;
        _ = this.AmountDiscount;
        _ = this.Reason;
    }

    public Discount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Discount(Discount discount)
        : base(discount) { }
#pragma warning restore CS8618

    public Discount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Discount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DiscountFromRaw.FromRawUnchecked"/>
    public static Discount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DiscountFromRaw : IFromRawJson<Discount>
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
[JsonConverter(typeof(JsonModelConverter<MaximumAmountAdjustment, MaximumAmountAdjustmentFromRaw>))]
public sealed record class MaximumAmountAdjustment : JsonModel
{
    public required string AmountApplied
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("amount_applied");
        }
        init { this._rawData.Set("amount_applied", value); }
    }

    public required ApiEnum<string, MaximumAmountAdjustmentDiscountType> DiscountType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, MaximumAmountAdjustmentDiscountType>
            >("discount_type");
        }
        init { this._rawData.Set("discount_type", value); }
    }

    public required double PercentageDiscount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("percentage_discount");
        }
        init { this._rawData.Set("percentage_discount", value); }
    }

    public IReadOnlyList<AppliesToPrice>? AppliesToPrices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AppliesToPrice>>(
                "applies_to_prices"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<AppliesToPrice>?>(
                "applies_to_prices",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MaximumAmountAdjustment(MaximumAmountAdjustment maximumAmountAdjustment)
        : base(maximumAmountAdjustment) { }
#pragma warning restore CS8618

    public MaximumAmountAdjustment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MaximumAmountAdjustment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class MaximumAmountAdjustmentFromRaw : IFromRawJson<MaximumAmountAdjustment>
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

[JsonConverter(typeof(JsonModelConverter<AppliesToPrice, AppliesToPriceFromRaw>))]
public sealed record class AppliesToPrice : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public AppliesToPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AppliesToPrice(AppliesToPrice appliesToPrice)
        : base(appliesToPrice) { }
#pragma warning restore CS8618

    public AppliesToPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AppliesToPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AppliesToPriceFromRaw.FromRawUnchecked"/>
    public static AppliesToPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AppliesToPriceFromRaw : IFromRawJson<AppliesToPrice>
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

[JsonConverter(
    typeof(JsonModelConverter<SharedCreditNoteDiscount, SharedCreditNoteDiscountFromRaw>)
)]
public sealed record class SharedCreditNoteDiscount : JsonModel
{
    public required string AmountApplied
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("amount_applied");
        }
        init { this._rawData.Set("amount_applied", value); }
    }

    public required ApiEnum<string, SharedCreditNoteDiscountDiscountType> DiscountType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SharedCreditNoteDiscountDiscountType>
            >("discount_type");
        }
        init { this._rawData.Set("discount_type", value); }
    }

    public required double PercentageDiscount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("percentage_discount");
        }
        init { this._rawData.Set("percentage_discount", value); }
    }

    public IReadOnlyList<SharedCreditNoteDiscountAppliesToPrice>? AppliesToPrices
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<SharedCreditNoteDiscountAppliesToPrice>
            >("applies_to_prices");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SharedCreditNoteDiscountAppliesToPrice>?>(
                "applies_to_prices",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SharedCreditNoteDiscount(SharedCreditNoteDiscount sharedCreditNoteDiscount)
        : base(sharedCreditNoteDiscount) { }
#pragma warning restore CS8618

    public SharedCreditNoteDiscount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SharedCreditNoteDiscount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class SharedCreditNoteDiscountFromRaw : IFromRawJson<SharedCreditNoteDiscount>
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
    typeof(JsonModelConverter<
        SharedCreditNoteDiscountAppliesToPrice,
        SharedCreditNoteDiscountAppliesToPriceFromRaw
    >)
)]
public sealed record class SharedCreditNoteDiscountAppliesToPrice : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public SharedCreditNoteDiscountAppliesToPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SharedCreditNoteDiscountAppliesToPrice(
        SharedCreditNoteDiscountAppliesToPrice sharedCreditNoteDiscountAppliesToPrice
    )
        : base(sharedCreditNoteDiscountAppliesToPrice) { }
#pragma warning restore CS8618

    public SharedCreditNoteDiscountAppliesToPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SharedCreditNoteDiscountAppliesToPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
    : IFromRawJson<SharedCreditNoteDiscountAppliesToPrice>
{
    /// <inheritdoc/>
    public SharedCreditNoteDiscountAppliesToPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SharedCreditNoteDiscountAppliesToPrice.FromRawUnchecked(rawData);
}
