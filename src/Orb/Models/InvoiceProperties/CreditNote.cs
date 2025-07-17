using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.InvoiceProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<CreditNote>))]
public sealed record class CreditNote : Orb::ModelBase, Orb::IFromRaw<CreditNote>
{
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

    public required string Reason
    {
        get
        {
            if (!this.Properties.TryGetValue("reason", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "reason",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("reason");
        }
        set { this.Properties["reason"] = Json::JsonSerializer.SerializeToElement(value); }
    }

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

    public required string Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("type");
        }
        set { this.Properties["type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// If the credit note has a status of `void`, this gives a timestamp when the
    /// credit note was voided.
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

    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreditNoteNumber;
        _ = this.Memo;
        _ = this.Reason;
        _ = this.Total;
        _ = this.Type;
        _ = this.VoidedAt;
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
