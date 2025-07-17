using InvoiceDateVariants = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyProperties.IncrementProperties.InvoiceSettingsProperties.InvoiceDateVariants;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyProperties.IncrementProperties.InvoiceSettingsProperties;

/// <summary>
/// An ISO 8601 format date that denotes when this invoice should be dated in the
/// customer's timezone. If not provided, the invoice date will default to the credit
/// block's effective date.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::UnionConverter<InvoiceDate>))]
public abstract record class InvoiceDate
{
    internal InvoiceDate() { }

    public static InvoiceDateVariants::Date Create(System::DateOnly value) => new(value);

    public static InvoiceDateVariants::DateTime Create(System::DateTime value) => new(value);

    public abstract void Validate();
}
