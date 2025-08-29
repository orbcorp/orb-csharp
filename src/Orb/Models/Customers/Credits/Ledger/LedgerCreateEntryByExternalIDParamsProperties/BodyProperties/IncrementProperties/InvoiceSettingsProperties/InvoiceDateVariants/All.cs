using System = System;

namespace Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyProperties.IncrementProperties.InvoiceSettingsProperties.InvoiceDateVariants;

public sealed record class Date(System::DateOnly Value)
    : InvoiceDate,
        IVariant<Date, System::DateOnly>
{
    public static Date From(System::DateOnly value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class DateTime(System::DateTime Value)
    : InvoiceDate,
        IVariant<DateTime, System::DateTime>
{
    public static DateTime From(System::DateTime value)
    {
        return new(value);
    }

    public override void Validate() { }
}
