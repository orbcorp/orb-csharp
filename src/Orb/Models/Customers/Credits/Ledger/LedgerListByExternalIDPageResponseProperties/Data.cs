using System.Text.Json.Serialization;
using DataVariants = Orb.Models.Customers.Credits.Ledger.LedgerListByExternalIDPageResponseProperties.DataVariants;

namespace Orb.Models.Customers.Credits.Ledger.LedgerListByExternalIDPageResponseProperties;

/// <summary>
/// The [Credit Ledger Entry resource](/product-catalog/prepurchase) models prepaid
/// credits within Orb.
/// </summary>
[JsonConverter(typeof(UnionConverter<Data>))]
public abstract record class Data
{
    internal Data() { }

    public static implicit operator Data(IncrementLedgerEntry value) =>
        new DataVariants::IncrementLedgerEntryVariant(value);

    public static implicit operator Data(DecrementLedgerEntry value) =>
        new DataVariants::DecrementLedgerEntryVariant(value);

    public static implicit operator Data(ExpirationChangeLedgerEntry value) =>
        new DataVariants::ExpirationChangeLedgerEntryVariant(value);

    public static implicit operator Data(CreditBlockExpiryLedgerEntry value) =>
        new DataVariants::CreditBlockExpiryLedgerEntryVariant(value);

    public static implicit operator Data(VoidLedgerEntry value) =>
        new DataVariants::VoidLedgerEntryVariant(value);

    public static implicit operator Data(VoidInitiatedLedgerEntry value) =>
        new DataVariants::VoidInitiatedLedgerEntryVariant(value);

    public static implicit operator Data(AmendmentLedgerEntry value) =>
        new DataVariants::AmendmentLedgerEntryVariant(value);

    public abstract void Validate();
}
