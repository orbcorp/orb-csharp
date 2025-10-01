using Orb.Core;
using Ledger = Orb.Models.Customers.Credits.Ledger;

namespace Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDResponseVariants;

public sealed record class IncrementLedgerEntry(Ledger::IncrementLedgerEntry Value)
    : Ledger::LedgerCreateEntryByExternalIDResponse,
        IVariant<IncrementLedgerEntry, Ledger::IncrementLedgerEntry>
{
    public static IncrementLedgerEntry From(Ledger::IncrementLedgerEntry value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class DecrementLedgerEntry(Ledger::DecrementLedgerEntry Value)
    : Ledger::LedgerCreateEntryByExternalIDResponse,
        IVariant<DecrementLedgerEntry, Ledger::DecrementLedgerEntry>
{
    public static DecrementLedgerEntry From(Ledger::DecrementLedgerEntry value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ExpirationChangeLedgerEntry(Ledger::ExpirationChangeLedgerEntry Value)
    : Ledger::LedgerCreateEntryByExternalIDResponse,
        IVariant<ExpirationChangeLedgerEntry, Ledger::ExpirationChangeLedgerEntry>
{
    public static ExpirationChangeLedgerEntry From(Ledger::ExpirationChangeLedgerEntry value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class CreditBlockExpiryLedgerEntry(Ledger::CreditBlockExpiryLedgerEntry Value)
    : Ledger::LedgerCreateEntryByExternalIDResponse,
        IVariant<CreditBlockExpiryLedgerEntry, Ledger::CreditBlockExpiryLedgerEntry>
{
    public static CreditBlockExpiryLedgerEntry From(Ledger::CreditBlockExpiryLedgerEntry value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class VoidLedgerEntry(Ledger::VoidLedgerEntry Value)
    : Ledger::LedgerCreateEntryByExternalIDResponse,
        IVariant<VoidLedgerEntry, Ledger::VoidLedgerEntry>
{
    public static VoidLedgerEntry From(Ledger::VoidLedgerEntry value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class VoidInitiatedLedgerEntry(Ledger::VoidInitiatedLedgerEntry Value)
    : Ledger::LedgerCreateEntryByExternalIDResponse,
        IVariant<VoidInitiatedLedgerEntry, Ledger::VoidInitiatedLedgerEntry>
{
    public static VoidInitiatedLedgerEntry From(Ledger::VoidInitiatedLedgerEntry value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class AmendmentLedgerEntry(Ledger::AmendmentLedgerEntry Value)
    : Ledger::LedgerCreateEntryByExternalIDResponse,
        IVariant<AmendmentLedgerEntry, Ledger::AmendmentLedgerEntry>
{
    public static AmendmentLedgerEntry From(Ledger::AmendmentLedgerEntry value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
