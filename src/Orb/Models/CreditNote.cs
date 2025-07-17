using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using CreditNoteProperties = Orb.Models.CreditNoteProperties;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

/// <summary>
/// The [Credit Note](/invoicing/credit-notes) resource represents a credit that has
/// been applied to a particular invoice.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::ModelConverter<CreditNote>))]
public sealed record class CreditNote : Orb::ModelBase, Orb::IFromRaw<CreditNote>
{
    /// <summary>
    /// The Orb id of this credit note.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("id", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("id");
        }
        set { this.Properties["id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The creation time of the resource in Orb.
    /// </summary>
    public required System::DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "created_at",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set { this.Properties["created_at"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The unique identifier for credit notes.
    /// </summary>
    public required string CreditNoteNumber
    {
        get
        {
            if (!this.Properties.TryGetValue("credit_note_number", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "credit_note_number",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("credit_note_number");
        }
        set
        {
            this.Properties["credit_note_number"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// A URL to a PDF of the credit note.
    /// </summary>
    public required string? CreditNotePdf
    {
        get
        {
            if (!this.Properties.TryGetValue("credit_note_pdf", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "credit_note_pdf",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["credit_note_pdf"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required CustomerMinified Customer
    {
        get
        {
            if (!this.Properties.TryGetValue("customer", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "customer",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<CustomerMinified>(element)
                ?? throw new System::ArgumentNullException("customer");
        }
        set { this.Properties["customer"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The id of the invoice resource that this credit note is applied to.
    /// </summary>
    public required string InvoiceID
    {
        get
        {
            if (!this.Properties.TryGetValue("invoice_id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "invoice_id",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("invoice_id");
        }
        set { this.Properties["invoice_id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// All of the line items associated with this credit note.
    /// </summary>
    public required Generic::List<CreditNoteProperties::LineItem> LineItems
    {
        get
        {
            if (!this.Properties.TryGetValue("line_items", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "line_items",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<CreditNoteProperties::LineItem>>(
                    element
                ) ?? throw new System::ArgumentNullException("line_items");
        }
        set { this.Properties["line_items"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The maximum amount applied on the original invoice
    /// </summary>
    public required CreditNoteProperties::MaximumAmountAdjustment? MaximumAmountAdjustment
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "maximum_amount_adjustment",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "maximum_amount_adjustment",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<CreditNoteProperties::MaximumAmountAdjustment?>(
                element
            );
        }
        set
        {
            this.Properties["maximum_amount_adjustment"] = Json::JsonSerializer.SerializeToElement(
                value
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
            if (!this.Properties.TryGetValue("memo", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("memo", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["memo"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Any credited amount from the applied minimum on the invoice.
    /// </summary>
    public required string? MinimumAmountRefunded
    {
        get
        {
            if (
                !this.Properties.TryGetValue(
                    "minimum_amount_refunded",
                    out Json::JsonElement element
                )
            )
                throw new System::ArgumentOutOfRangeException(
                    "minimum_amount_refunded",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set
        {
            this.Properties["minimum_amount_refunded"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    public required CreditNoteProperties::Reason? Reason
    {
        get
        {
            if (!this.Properties.TryGetValue("reason", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "reason",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<CreditNoteProperties::Reason?>(element);
        }
        set { this.Properties["reason"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The total prior to any creditable invoice-level discounts or minimums.
    /// </summary>
    public required string Subtotal
    {
        get
        {
            if (!this.Properties.TryGetValue("subtotal", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "subtotal",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("subtotal");
        }
        set { this.Properties["subtotal"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The total including creditable invoice-level discounts or minimums, and tax.
    /// </summary>
    public required string Total
    {
        get
        {
            if (!this.Properties.TryGetValue("total", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("total", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("total");
        }
        set { this.Properties["total"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required CreditNoteProperties::Type Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return Json::JsonSerializer.Deserialize<CreditNoteProperties::Type>(element)
                ?? throw new System::ArgumentNullException("type");
        }
        set { this.Properties["type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The time at which the credit note was voided in Orb, if applicable.
    /// </summary>
    public required System::DateTime? VoidedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("voided_at", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "voided_at",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set { this.Properties["voided_at"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Any discounts applied on the original invoice.
    /// </summary>
    public Generic::List<CreditNoteProperties::Discount>? Discounts
    {
        get
        {
            if (!this.Properties.TryGetValue("discounts", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<CreditNoteProperties::Discount>?>(
                element
            );
        }
        set { this.Properties["discounts"] = Json::JsonSerializer.SerializeToElement(value); }
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
    [CodeAnalysis::SetsRequiredMembers]
    CreditNote(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CreditNote FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
