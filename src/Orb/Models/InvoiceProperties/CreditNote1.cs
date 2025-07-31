using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.InvoiceProperties;

[JsonConverter(typeof(ModelConverter<CreditNote1>))]
public sealed record class CreditNote1 : ModelBase, IFromRaw<CreditNote1>
{
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

    public required string Reason
    {
        get
        {
            if (!this.Properties.TryGetValue("reason", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "reason",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("reason");
        }
        set { this.Properties["reason"] = JsonSerializer.SerializeToElement(value); }
    }

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

    public required string Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("type");
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// If the credit note has a status of `void`, this gives a timestamp when the
    /// credit note was voided.
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

    public CreditNote1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditNote1(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CreditNote1 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
