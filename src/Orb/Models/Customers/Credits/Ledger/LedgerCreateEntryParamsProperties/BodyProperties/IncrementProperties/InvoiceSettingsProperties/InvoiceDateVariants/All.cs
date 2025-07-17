using InvoiceSettingsProperties = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryParamsProperties.BodyProperties.IncrementProperties.InvoiceSettingsProperties;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryParamsProperties.BodyProperties.IncrementProperties.InvoiceSettingsProperties.InvoiceDateVariants;

[Serialization::JsonConverter(typeof(Orb::VariantConverter<Date, System::DateOnly>))]
public sealed record class Date(System::DateOnly Value)
    : InvoiceSettingsProperties::InvoiceDate,
        Orb::IVariant<Date, System::DateOnly>
{
    public static Date From(System::DateOnly value)
    {
        return new(value);
    }

    public override void Validate() { }
}

[Serialization::JsonConverter(typeof(Orb::VariantConverter<DateTime, System::DateTime>))]
public sealed record class DateTime(System::DateTime Value)
    : InvoiceSettingsProperties::InvoiceDate,
        Orb::IVariant<DateTime, System::DateTime>
{
    public static DateTime From(System::DateTime value)
    {
        return new(value);
    }

    public override void Validate() { }
}
