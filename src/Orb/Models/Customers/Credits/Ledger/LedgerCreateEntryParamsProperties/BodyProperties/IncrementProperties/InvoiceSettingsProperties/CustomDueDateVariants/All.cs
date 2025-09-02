using System = System;

namespace Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryParamsProperties.BodyProperties.IncrementProperties.InvoiceSettingsProperties.CustomDueDateVariants;

public sealed record class Date(System::DateOnly Value)
    : CustomDueDate,
        IVariant<Date, System::DateOnly>
{
    public static Date From(System::DateOnly value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class DateTime(System::DateTime Value)
    : CustomDueDate,
        IVariant<DateTime, System::DateTime>
{
    public static DateTime From(System::DateTime value)
    {
        return new(value);
    }

    public override void Validate() { }
}
