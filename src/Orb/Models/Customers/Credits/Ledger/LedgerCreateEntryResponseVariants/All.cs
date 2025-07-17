using Ledger = Orb.Models.Customers.Credits.Ledger;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryResponseVariants;

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<IncrementLedgerEntry, Ledger::IncrementLedgerEntry>)
)]
public sealed record class IncrementLedgerEntry(Ledger::IncrementLedgerEntry Value)
    : Ledger::LedgerCreateEntryResponse,
        Orb::IVariant<IncrementLedgerEntry, Ledger::IncrementLedgerEntry>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<DecrementLedgerEntry, Ledger::DecrementLedgerEntry>)
)]
public sealed record class DecrementLedgerEntry(Ledger::DecrementLedgerEntry Value)
    : Ledger::LedgerCreateEntryResponse,
        Orb::IVariant<DecrementLedgerEntry, Ledger::DecrementLedgerEntry>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<ExpirationChangeLedgerEntry, Ledger::ExpirationChangeLedgerEntry>)
)]
public sealed record class ExpirationChangeLedgerEntry(Ledger::ExpirationChangeLedgerEntry Value)
    : Ledger::LedgerCreateEntryResponse,
        Orb::IVariant<ExpirationChangeLedgerEntry, Ledger::ExpirationChangeLedgerEntry>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<
        CreditBlockExpiryLedgerEntry,
        Ledger::CreditBlockExpiryLedgerEntry
    >)
)]
public sealed record class CreditBlockExpiryLedgerEntry(Ledger::CreditBlockExpiryLedgerEntry Value)
    : Ledger::LedgerCreateEntryResponse,
        Orb::IVariant<CreditBlockExpiryLedgerEntry, Ledger::CreditBlockExpiryLedgerEntry>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<VoidLedgerEntry, Ledger::VoidLedgerEntry>)
)]
public sealed record class VoidLedgerEntry(Ledger::VoidLedgerEntry Value)
    : Ledger::LedgerCreateEntryResponse,
        Orb::IVariant<VoidLedgerEntry, Ledger::VoidLedgerEntry>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<VoidInitiatedLedgerEntry, Ledger::VoidInitiatedLedgerEntry>)
)]
public sealed record class VoidInitiatedLedgerEntry(Ledger::VoidInitiatedLedgerEntry Value)
    : Ledger::LedgerCreateEntryResponse,
        Orb::IVariant<VoidInitiatedLedgerEntry, Ledger::VoidInitiatedLedgerEntry>
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

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<AmendmentLedgerEntry, Ledger::AmendmentLedgerEntry>)
)]
public sealed record class AmendmentLedgerEntry(Ledger::AmendmentLedgerEntry Value)
    : Ledger::LedgerCreateEntryResponse,
        Orb::IVariant<AmendmentLedgerEntry, Ledger::AmendmentLedgerEntry>
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
