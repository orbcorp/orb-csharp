using System = System;

namespace Orb.Models.Invoices.InvoiceUpdateParamsProperties.DueDateVariants;

public sealed record class Date(System::DateOnly Value) : DueDate, IVariant<Date, System::DateOnly>
{
    public static Date From(System::DateOnly value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class DateTime(System::DateTime Value)
    : DueDate,
        IVariant<DateTime, System::DateTime>
{
    public static DateTime From(System::DateTime value)
    {
        return new(value);
    }

    public override void Validate() { }
}
