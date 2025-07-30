using System.Text.Json.Serialization;

namespace Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDResponseVariants;

[JsonConverter(typeof(VariantConverter<IncrementLedgerEntryVariant, IncrementLedgerEntry>))]
public sealed record class IncrementLedgerEntryVariant(IncrementLedgerEntry Value)
    : LedgerCreateEntryByExternalIDResponse,
        IVariant<IncrementLedgerEntryVariant, IncrementLedgerEntry>
{
    public static IncrementLedgerEntryVariant From(IncrementLedgerEntry value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<DecrementLedgerEntryVariant, DecrementLedgerEntry>))]
public sealed record class DecrementLedgerEntryVariant(DecrementLedgerEntry Value)
    : LedgerCreateEntryByExternalIDResponse,
        IVariant<DecrementLedgerEntryVariant, DecrementLedgerEntry>
{
    public static DecrementLedgerEntryVariant From(DecrementLedgerEntry value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<ExpirationChangeLedgerEntryVariant, ExpirationChangeLedgerEntry>)
)]
public sealed record class ExpirationChangeLedgerEntryVariant(ExpirationChangeLedgerEntry Value)
    : LedgerCreateEntryByExternalIDResponse,
        IVariant<ExpirationChangeLedgerEntryVariant, ExpirationChangeLedgerEntry>
{
    public static ExpirationChangeLedgerEntryVariant From(ExpirationChangeLedgerEntry value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<CreditBlockExpiryLedgerEntryVariant, CreditBlockExpiryLedgerEntry>)
)]
public sealed record class CreditBlockExpiryLedgerEntryVariant(CreditBlockExpiryLedgerEntry Value)
    : LedgerCreateEntryByExternalIDResponse,
        IVariant<CreditBlockExpiryLedgerEntryVariant, CreditBlockExpiryLedgerEntry>
{
    public static CreditBlockExpiryLedgerEntryVariant From(CreditBlockExpiryLedgerEntry value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<VoidLedgerEntryVariant, VoidLedgerEntry>))]
public sealed record class VoidLedgerEntryVariant(VoidLedgerEntry Value)
    : LedgerCreateEntryByExternalIDResponse,
        IVariant<VoidLedgerEntryVariant, VoidLedgerEntry>
{
    public static VoidLedgerEntryVariant From(VoidLedgerEntry value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<VoidInitiatedLedgerEntryVariant, VoidInitiatedLedgerEntry>))]
public sealed record class VoidInitiatedLedgerEntryVariant(VoidInitiatedLedgerEntry Value)
    : LedgerCreateEntryByExternalIDResponse,
        IVariant<VoidInitiatedLedgerEntryVariant, VoidInitiatedLedgerEntry>
{
    public static VoidInitiatedLedgerEntryVariant From(VoidInitiatedLedgerEntry value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<AmendmentLedgerEntryVariant, AmendmentLedgerEntry>))]
public sealed record class AmendmentLedgerEntryVariant(AmendmentLedgerEntry Value)
    : LedgerCreateEntryByExternalIDResponse,
        IVariant<AmendmentLedgerEntryVariant, AmendmentLedgerEntry>
{
    public static AmendmentLedgerEntryVariant From(AmendmentLedgerEntry value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
