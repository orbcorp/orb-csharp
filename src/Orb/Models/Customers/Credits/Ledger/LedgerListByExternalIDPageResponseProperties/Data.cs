using DataVariants = Orb.Models.Customers.Credits.Ledger.LedgerListByExternalIDPageResponseProperties.DataVariants;
using Ledger = Orb.Models.Customers.Credits.Ledger;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Customers.Credits.Ledger.LedgerListByExternalIDPageResponseProperties;

/// <summary>
/// The [Credit Ledger Entry resource](/product-catalog/prepurchase) models prepaid
/// credits within Orb.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::UnionConverter<Data>))]
public abstract record class Data
{
    internal Data() { }

    public static implicit operator Data(Ledger::IncrementLedgerEntry value) =>
        new DataVariants::IncrementLedgerEntry(value);

    public static implicit operator Data(Ledger::DecrementLedgerEntry value) =>
        new DataVariants::DecrementLedgerEntry(value);

    public static implicit operator Data(Ledger::ExpirationChangeLedgerEntry value) =>
        new DataVariants::ExpirationChangeLedgerEntry(value);

    public static implicit operator Data(Ledger::CreditBlockExpiryLedgerEntry value) =>
        new DataVariants::CreditBlockExpiryLedgerEntry(value);

    public static implicit operator Data(Ledger::VoidLedgerEntry value) =>
        new DataVariants::VoidLedgerEntry(value);

    public static implicit operator Data(Ledger::VoidInitiatedLedgerEntry value) =>
        new DataVariants::VoidInitiatedLedgerEntry(value);

    public static implicit operator Data(Ledger::AmendmentLedgerEntry value) =>
        new DataVariants::AmendmentLedgerEntry(value);

    public abstract void Validate();
}
