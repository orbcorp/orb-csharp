using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CreditNoteProperties = Orb.Models.CreditNoteProperties;
using System = System;

namespace Orb.Models;

/// <summary>
/// The [Credit Note](/invoicing/credit-notes) resource represents a credit that has
/// been applied to a particular invoice.
/// </summary>
[JsonConverter(typeof(ModelConverter<CreditNote>))]
public sealed record class CreditNote : ModelBase, IFromRaw<CreditNote>
{
    /// <summary>
    /// The Orb id of this credit note.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("id");
        }
        set { this.Properties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The creation time of the resource in Orb.
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

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["created_at"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The unique identifier for credit notes.
    /// </summary>
    public required string CreditNoteNumber
    {
        get
        {
            if (!this.Properties.TryGetValue("credit_note_number", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "credit_note_number",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("credit_note_number");
        }
        set { this.Properties["credit_note_number"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A URL to a PDF of the credit note.
    /// </summary>
    public required string? CreditNotePdf
    {
        get
        {
            if (!this.Properties.TryGetValue("credit_note_pdf", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "credit_note_pdf",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["credit_note_pdf"] = JsonSerializer.SerializeToElement(value); }
    }

    public required CustomerMinified Customer
    {
        get
        {
            if (!this.Properties.TryGetValue("customer", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "customer",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<CustomerMinified>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("customer");
        }
        set { this.Properties["customer"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The id of the invoice resource that this credit note is applied to.
    /// </summary>
    public required string InvoiceID
    {
        get
        {
            if (!this.Properties.TryGetValue("invoice_id", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "invoice_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("invoice_id");
        }
        set { this.Properties["invoice_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// All of the line items associated with this credit note.
    /// </summary>
    public required List<CreditNoteProperties::LineItem> LineItems
    {
        get
        {
            if (!this.Properties.TryGetValue("line_items", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "line_items",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<CreditNoteProperties::LineItem>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("line_items");
        }
        set { this.Properties["line_items"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The maximum amount applied on the original invoice
    /// </summary>
    public required CreditNoteProperties::MaximumAmountAdjustment? MaximumAmountAdjustment
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum_amount_adjustment", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "maximum_amount_adjustment",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<CreditNoteProperties::MaximumAmountAdjustment?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["maximum_amount_adjustment"] = JsonSerializer.SerializeToElement(value);
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
                throw new System::ArgumentOutOfRangeException("memo", "Missing required argument");

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["memo"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Any credited amount from the applied minimum on the invoice.
    /// </summary>
    public required string? MinimumAmountRefunded
    {
        get
        {
            if (!this.Properties.TryGetValue("minimum_amount_refunded", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "minimum_amount_refunded",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["minimum_amount_refunded"] = JsonSerializer.SerializeToElement(value);
        }
    }

    public required CreditNoteProperties::Reason? Reason
    {
        get
        {
            if (!this.Properties.TryGetValue("reason", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "reason",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<CreditNoteProperties::Reason?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["reason"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The total prior to any creditable invoice-level discounts or minimums.
    /// </summary>
    public required string Subtotal
    {
        get
        {
            if (!this.Properties.TryGetValue("subtotal", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "subtotal",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("subtotal");
        }
        set { this.Properties["subtotal"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The total including creditable invoice-level discounts or minimums, and tax.
    /// </summary>
    public required string Total
    {
        get
        {
            if (!this.Properties.TryGetValue("total", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("total", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("total");
        }
        set { this.Properties["total"] = JsonSerializer.SerializeToElement(value); }
    }

    public required CreditNoteProperties::Type Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<CreditNoteProperties::Type>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("type");
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The time at which the credit note was voided in Orb, if applicable.
    /// </summary>
    public required System::DateTime? VoidedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("voided_at", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "voided_at",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["voided_at"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Any discounts applied on the original invoice.
    /// </summary>
    public List<CreditNoteProperties::Discount1>? Discounts
    {
        get
        {
            if (!this.Properties.TryGetValue("discounts", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<CreditNoteProperties::Discount1>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["discounts"] = JsonSerializer.SerializeToElement(value); }
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

    public CreditNote() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditNote(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CreditNote FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
