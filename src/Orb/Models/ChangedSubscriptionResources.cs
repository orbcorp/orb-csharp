using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<ChangedSubscriptionResources>))]
public sealed record class ChangedSubscriptionResources
    : Orb::ModelBase,
        Orb::IFromRaw<ChangedSubscriptionResources>
{
    /// <summary>
    /// The credit notes that were created as part of this operation.
    /// </summary>
    public required Generic::List<CreditNote> CreatedCreditNotes
    {
        get
        {
            if (!this.Properties.TryGetValue("created_credit_notes", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "created_credit_notes",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<CreditNote>>(element)
                ?? throw new System::ArgumentNullException("created_credit_notes");
        }
        set
        {
            this.Properties["created_credit_notes"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
    }

    /// <summary>
    /// The invoices that were created as part of this operation.
    /// </summary>
    public required Generic::List<Invoice> CreatedInvoices
    {
        get
        {
            if (!this.Properties.TryGetValue("created_invoices", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "created_invoices",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<Invoice>>(element)
                ?? throw new System::ArgumentNullException("created_invoices");
        }
        set
        {
            this.Properties["created_invoices"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The credit notes that were voided as part of this operation.
    /// </summary>
    public required Generic::List<CreditNote> VoidedCreditNotes
    {
        get
        {
            if (!this.Properties.TryGetValue("voided_credit_notes", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "voided_credit_notes",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<CreditNote>>(element)
                ?? throw new System::ArgumentNullException("voided_credit_notes");
        }
        set
        {
            this.Properties["voided_credit_notes"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The invoices that were voided as part of this operation.
    /// </summary>
    public required Generic::List<Invoice> VoidedInvoices
    {
        get
        {
            if (!this.Properties.TryGetValue("voided_invoices", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "voided_invoices",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<Invoice>>(element)
                ?? throw new System::ArgumentNullException("voided_invoices");
        }
        set { this.Properties["voided_invoices"] = Json::JsonSerializer.SerializeToElement(value); }
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
    [CodeAnalysis::SetsRequiredMembers]
    ChangedSubscriptionResources(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ChangedSubscriptionResources FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
