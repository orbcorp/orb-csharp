using System.Text.Json.Serialization;
using InvoiceDateVariants = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyProperties.IncrementProperties.InvoiceSettingsProperties.InvoiceDateVariants;
using System = System;

namespace Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyProperties.IncrementProperties.InvoiceSettingsProperties;

/// <summary>
/// An ISO 8601 format date that denotes when this invoice should be dated in the
/// customer's timezone. If not provided, the invoice date will default to the credit
/// block's effective date.
/// </summary>
[JsonConverter(typeof(UnionConverter<InvoiceDate>))]
public abstract record class InvoiceDate
{
    internal InvoiceDate() { }

    public static implicit operator InvoiceDate(System::DateOnly value) =>
        new InvoiceDateVariants::Date(value);

    public static implicit operator InvoiceDate(System::DateTime value) =>
        new InvoiceDateVariants::DateTime(value);

    public abstract void Validate();
}
