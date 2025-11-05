using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

/// <summary>
/// The [Credit Note](/invoicing/credit-notes) resource represents a credit that has
/// been applied to a particular invoice.
/// </summary>
[JsonConverter(typeof(ModelConverter<CreditNoteModel>))]
public sealed record class CreditNoteModel : ModelBase, IFromRaw<CreditNoteModel>
{
    /// <summary>
    /// The Orb id of this credit note.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
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
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The creation time of the resource in Orb.
    /// </summary>
    public required System::DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'created_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "created_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The unique identifier for credit notes.
    /// </summary>
    public required string CreditNoteNumber
    {
        get
        {
            if (!this.Properties.TryGetValue("credit_note_number", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'credit_note_number' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "credit_note_number",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'credit_note_number' cannot be null",
                    new System::ArgumentNullException("credit_note_number")
                );
        }
        set
        {
            this.Properties["credit_note_number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A URL to a PDF of the credit note.
    /// </summary>
    public required string? CreditNotePdf
    {
        get
        {
            if (!this.Properties.TryGetValue("credit_note_pdf", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["credit_note_pdf"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required CustomerMinified Customer
    {
        get
        {
            if (!this.Properties.TryGetValue("customer", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'customer' cannot be null",
                    new System::ArgumentOutOfRangeException("customer", "Missing required argument")
                );

            return JsonSerializer.Deserialize<CustomerMinified>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'customer' cannot be null",
                    new System::ArgumentNullException("customer")
                );
        }
        set
        {
            this.Properties["customer"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the invoice resource that this credit note is applied to.
    /// </summary>
    public required string InvoiceID
    {
        get
        {
            if (!this.Properties.TryGetValue("invoice_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'invoice_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "invoice_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'invoice_id' cannot be null",
                    new System::ArgumentNullException("invoice_id")
                );
        }
        set
        {
            this.Properties["invoice_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// All of the line items associated with this credit note.
    /// </summary>
    public required List<LineItemModel> LineItems
    {
        get
        {
            if (!this.Properties.TryGetValue("line_items", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'line_items' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "line_items",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<LineItemModel>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'line_items' cannot be null",
                    new System::ArgumentNullException("line_items")
                );
        }
        set
        {
            this.Properties["line_items"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this.Properties.TryGetValue("maximum_amount_adjustment", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<MaximumAmountAdjustment?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["maximum_amount_adjustment"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An optional memo supplied on the credit note.
    /// </summary>
    public required string? Memo
    {
        get
        {
            if (!this.Properties.TryGetValue("memo", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["memo"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Any credited amount from the applied minimum on the invoice.
    /// </summary>
    public required string? MinimumAmountRefunded
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum_amount_refunded", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["minimum_amount_refunded"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Reason>? Reason
    {
        get
        {
            if (!this.Properties.TryGetValue("reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Reason>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["reason"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The total prior to any creditable invoice-level discounts or minimums.
    /// </summary>
    public required string Subtotal
    {
        get
        {
            if (!this.Properties.TryGetValue("subtotal", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'subtotal' cannot be null",
                    new System::ArgumentOutOfRangeException("subtotal", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'subtotal' cannot be null",
                    new System::ArgumentNullException("subtotal")
                );
        }
        set
        {
            this.Properties["subtotal"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The total including creditable invoice-level discounts or minimums, and tax.
    /// </summary>
    public required string Total
    {
        get
        {
            if (!this.Properties.TryGetValue("total", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'total' cannot be null",
                    new System::ArgumentOutOfRangeException("total", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'total' cannot be null",
                    new System::ArgumentNullException("total")
                );
        }
        set
        {
            this.Properties["total"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, TypeModel> Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, TypeModel>>(
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

    /// <summary>
    /// The time at which the credit note was voided in Orb, if applicable.
    /// </summary>
    public required System::DateTime? VoidedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("voided_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["voided_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Any discounts applied on the original invoice.
    /// </summary>
    public List<DiscountModel>? Discounts
    {
        get
        {
            if (!this.Properties.TryGetValue("discounts", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<DiscountModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["discounts"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public CreditNoteModel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditNoteModel(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CreditNoteModel FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

[JsonConverter(typeof(ModelConverter<LineItemModel>))]
public sealed record class LineItemModel : ModelBase, IFromRaw<LineItemModel>
{
    /// <summary>
    /// The Orb id of this resource.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
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
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The amount of the line item, including any line item minimums and discounts.
    /// </summary>
    public required string Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out JsonElement element))
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
        set
        {
            this.Properties["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the item associated with this line item.
    /// </summary>
    public required string ItemID
    {
        get
        {
            if (!this.Properties.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        set
        {
            this.Properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the corresponding invoice line item.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An optional quantity credited.
    /// </summary>
    public required double? Quantity
    {
        get
        {
            if (!this.Properties.TryGetValue("quantity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The amount of the line item, excluding any line item minimums and discounts.
    /// </summary>
    public required string Subtotal
    {
        get
        {
            if (!this.Properties.TryGetValue("subtotal", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'subtotal' cannot be null",
                    new System::ArgumentOutOfRangeException("subtotal", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'subtotal' cannot be null",
                    new System::ArgumentNullException("subtotal")
                );
        }
        set
        {
            this.Properties["subtotal"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Any tax amounts applied onto the line item.
    /// </summary>
    public required List<TaxAmount> TaxAmounts
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_amounts", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'tax_amounts' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tax_amounts",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<TaxAmount>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'tax_amounts' cannot be null",
                    new System::ArgumentNullException("tax_amounts")
                );
        }
        set
        {
            this.Properties["tax_amounts"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Any line item discounts from the invoice's line item.
    /// </summary>
    public List<Discount>? Discounts
    {
        get
        {
            if (!this.Properties.TryGetValue("discounts", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Discount>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["discounts"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The end time of the service period for this credit note line item.
    /// </summary>
    public System::DateTime? EndTimeExclusive
    {
        get
        {
            if (!this.Properties.TryGetValue("end_time_exclusive", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["end_time_exclusive"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The start time of the service period for this credit note line item.
    /// </summary>
    public System::DateTime? StartTimeInclusive
    {
        get
        {
            if (!this.Properties.TryGetValue("start_time_inclusive", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["start_time_inclusive"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public LineItemModel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LineItemModel(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static LineItemModel FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

[JsonConverter(typeof(ModelConverter<Discount>))]
public sealed record class Discount : ModelBase, IFromRaw<Discount>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
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
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string AmountApplied
    {
        get
        {
            if (!this.Properties.TryGetValue("amount_applied", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount_applied' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "amount_applied",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'amount_applied' cannot be null",
                    new System::ArgumentNullException("amount_applied")
                );
        }
        set
        {
            this.Properties["amount_applied"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required List<string> AppliesToPriceIDs
    {
        get
        {
            if (!this.Properties.TryGetValue("applies_to_price_ids", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'applies_to_price_ids' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "applies_to_price_ids",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'applies_to_price_ids' cannot be null",
                    new System::ArgumentNullException("applies_to_price_ids")
                );
        }
        set
        {
            this.Properties["applies_to_price_ids"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, DiscountType1> DiscountType
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'discount_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "discount_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, DiscountType1>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["discount_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required double PercentageDiscount
    {
        get
        {
            if (!this.Properties.TryGetValue("percentage_discount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'percentage_discount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "percentage_discount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["percentage_discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? AmountDiscount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount_discount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["amount_discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Reason
    {
        get
        {
            if (!this.Properties.TryGetValue("reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["reason"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Discount(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Discount FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

[JsonConverter(typeof(DiscountType1Converter))]
public enum DiscountType1
{
    Percentage,
    Amount,
}

sealed class DiscountType1Converter : JsonConverter<DiscountType1>
{
    public override DiscountType1 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "percentage" => DiscountType1.Percentage,
            "amount" => DiscountType1.Amount,
            _ => (DiscountType1)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DiscountType1 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DiscountType1.Percentage => "percentage",
                DiscountType1.Amount => "amount",
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
[JsonConverter(typeof(ModelConverter<MaximumAmountAdjustment>))]
public sealed record class MaximumAmountAdjustment : ModelBase, IFromRaw<MaximumAmountAdjustment>
{
    public required string AmountApplied
    {
        get
        {
            if (!this.Properties.TryGetValue("amount_applied", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount_applied' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "amount_applied",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'amount_applied' cannot be null",
                    new System::ArgumentNullException("amount_applied")
                );
        }
        set
        {
            this.Properties["amount_applied"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, DiscountType2> DiscountType
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'discount_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "discount_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, DiscountType2>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["discount_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required double PercentageDiscount
    {
        get
        {
            if (!this.Properties.TryGetValue("percentage_discount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'percentage_discount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "percentage_discount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["percentage_discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public List<AppliesToPrice>? AppliesToPrices
    {
        get
        {
            if (!this.Properties.TryGetValue("applies_to_prices", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AppliesToPrice>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["applies_to_prices"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Reason
    {
        get
        {
            if (!this.Properties.TryGetValue("reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["reason"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
    MaximumAmountAdjustment(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MaximumAmountAdjustment FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

[JsonConverter(typeof(DiscountType2Converter))]
public enum DiscountType2
{
    Percentage,
}

sealed class DiscountType2Converter : JsonConverter<DiscountType2>
{
    public override DiscountType2 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "percentage" => DiscountType2.Percentage,
            _ => (DiscountType2)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DiscountType2 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DiscountType2.Percentage => "percentage",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<AppliesToPrice>))]
public sealed record class AppliesToPrice : ModelBase, IFromRaw<AppliesToPrice>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
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
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public AppliesToPrice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AppliesToPrice(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AppliesToPrice FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
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

[JsonConverter(typeof(TypeModelConverter))]
public enum TypeModel
{
    Refund,
    Adjustment,
}

sealed class TypeModelConverter : JsonConverter<TypeModel>
{
    public override TypeModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "refund" => TypeModel.Refund,
            "adjustment" => TypeModel.Adjustment,
            _ => (TypeModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TypeModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TypeModel.Refund => "refund",
                TypeModel.Adjustment => "adjustment",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<DiscountModel>))]
public sealed record class DiscountModel : ModelBase, IFromRaw<DiscountModel>
{
    public required string AmountApplied
    {
        get
        {
            if (!this.Properties.TryGetValue("amount_applied", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount_applied' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "amount_applied",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'amount_applied' cannot be null",
                    new System::ArgumentNullException("amount_applied")
                );
        }
        set
        {
            this.Properties["amount_applied"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, DiscountType3> DiscountType
    {
        get
        {
            if (!this.Properties.TryGetValue("discount_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'discount_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "discount_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, DiscountType3>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["discount_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required double PercentageDiscount
    {
        get
        {
            if (!this.Properties.TryGetValue("percentage_discount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'percentage_discount' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "percentage_discount",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["percentage_discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public List<AppliesToPriceModel>? AppliesToPrices
    {
        get
        {
            if (!this.Properties.TryGetValue("applies_to_prices", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AppliesToPriceModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["applies_to_prices"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Reason
    {
        get
        {
            if (!this.Properties.TryGetValue("reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["reason"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public DiscountModel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DiscountModel(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static DiscountModel FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

[JsonConverter(typeof(DiscountType3Converter))]
public enum DiscountType3
{
    Percentage,
}

sealed class DiscountType3Converter : JsonConverter<DiscountType3>
{
    public override DiscountType3 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "percentage" => DiscountType3.Percentage,
            _ => (DiscountType3)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DiscountType3 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DiscountType3.Percentage => "percentage",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<AppliesToPriceModel>))]
public sealed record class AppliesToPriceModel : ModelBase, IFromRaw<AppliesToPriceModel>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
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
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public AppliesToPriceModel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AppliesToPriceModel(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AppliesToPriceModel FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
