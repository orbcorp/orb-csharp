using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using CreditNoteProperties = Orb.Models.CreditNoteProperties;

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

    /// <summary>
    /// The creation time of the resource in Orb.
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
                    new ArgumentOutOfRangeException(
                        "credit_note_number",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'credit_note_number' cannot be null",
                    new ArgumentNullException("credit_note_number")
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
                    new ArgumentOutOfRangeException("customer", "Missing required argument")
                );

            return JsonSerializer.Deserialize<CustomerMinified>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'customer' cannot be null",
                    new ArgumentNullException("customer")
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
                    new ArgumentOutOfRangeException("invoice_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'invoice_id' cannot be null",
                    new ArgumentNullException("invoice_id")
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
    public required List<CreditNoteProperties::LineItem> LineItems
    {
        get
        {
            if (!this.Properties.TryGetValue("line_items", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'line_items' cannot be null",
                    new ArgumentOutOfRangeException("line_items", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<CreditNoteProperties::LineItem>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'line_items' cannot be null",
                    new ArgumentNullException("line_items")
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
    public required CreditNoteProperties::MaximumAmountAdjustment? MaximumAmountAdjustment
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum_amount_adjustment", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CreditNoteProperties::MaximumAmountAdjustment?>(
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

    public required ApiEnum<string, CreditNoteProperties::Reason>? Reason
    {
        get
        {
            if (!this.Properties.TryGetValue("reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, CreditNoteProperties::Reason>?>(
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
                    new ArgumentOutOfRangeException("subtotal", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'subtotal' cannot be null",
                    new ArgumentNullException("subtotal")
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
                    new ArgumentOutOfRangeException("total", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'total' cannot be null",
                    new ArgumentNullException("total")
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

    public required ApiEnum<string, CreditNoteProperties::Type> Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, CreditNoteProperties::Type>>(
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
    public required DateTime? VoidedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("voided_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
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
    public List<CreditNoteProperties::Discount>? Discounts
    {
        get
        {
            if (!this.Properties.TryGetValue("discounts", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<CreditNoteProperties::Discount>?>(
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
