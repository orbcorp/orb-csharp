using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<ChangedSubscriptionResources>))]
public sealed record class ChangedSubscriptionResources
    : ModelBase,
        IFromRaw<ChangedSubscriptionResources>
{
    /// <summary>
    /// The credit notes that were created as part of this operation.
    /// </summary>
    public required List<CreditNote> CreatedCreditNotes
    {
        get
        {
            if (!this.Properties.TryGetValue("created_credit_notes", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "created_credit_notes",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<CreditNote>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("created_credit_notes");
        }
        set
        {
            this.Properties["created_credit_notes"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The invoices that were created as part of this operation.
    /// </summary>
    public required List<Invoice> CreatedInvoices
    {
        get
        {
            if (!this.Properties.TryGetValue("created_invoices", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "created_invoices",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<Invoice>>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("created_invoices");
        }
        set
        {
            this.Properties["created_invoices"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The credit notes that were voided as part of this operation.
    /// </summary>
    public required List<CreditNote> VoidedCreditNotes
    {
        get
        {
            if (!this.Properties.TryGetValue("voided_credit_notes", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "voided_credit_notes",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<CreditNote>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("voided_credit_notes");
        }
        set
        {
            this.Properties["voided_credit_notes"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The invoices that were voided as part of this operation.
    /// </summary>
    public required List<Invoice> VoidedInvoices
    {
        get
        {
            if (!this.Properties.TryGetValue("voided_invoices", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "voided_invoices",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<List<Invoice>>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("voided_invoices");
        }
        set
        {
            this.Properties["voided_invoices"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.CreatedCreditNotes)
        {
            item.Validate();
        }
        foreach (var item in this.CreatedInvoices)
        {
            item.Validate();
        }
        foreach (var item in this.VoidedCreditNotes)
        {
            item.Validate();
        }
        foreach (var item in this.VoidedInvoices)
        {
            item.Validate();
        }
    }

    public ChangedSubscriptionResources() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChangedSubscriptionResources(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ChangedSubscriptionResources FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
