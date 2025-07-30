using System.Text.Json.Serialization;

namespace Orb.Models.Customers.Credits.Ledger.LedgerListByExternalIDPageResponseProperties.DataVariants;

[JsonConverter(typeof(VariantConverter<IncrementLedgerEntryVariant, IncrementLedgerEntry>))]
public sealed record class IncrementLedgerEntryVariant(IncrementLedgerEntry Value)
    : Data,
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
    : Data,
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
    : Data,
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
    : Data,
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
    : Data,
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
    : Data,
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
    : Data,
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
