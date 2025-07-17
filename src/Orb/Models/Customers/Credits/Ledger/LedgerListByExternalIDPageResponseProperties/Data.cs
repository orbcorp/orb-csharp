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

    public static DataVariants::IncrementLedgerEntry Create(Ledger::IncrementLedgerEntry value) =>
        new(value);

    public static DataVariants::DecrementLedgerEntry Create(Ledger::DecrementLedgerEntry value) =>
        new(value);

    public static DataVariants::ExpirationChangeLedgerEntry Create(
        Ledger::ExpirationChangeLedgerEntry value
    ) => new(value);

    public static DataVariants::CreditBlockExpiryLedgerEntry Create(
        Ledger::CreditBlockExpiryLedgerEntry value
    ) => new(value);

    public static DataVariants::VoidLedgerEntry Create(Ledger::VoidLedgerEntry value) => new(value);

    public static DataVariants::VoidInitiatedLedgerEntry Create(
        Ledger::VoidInitiatedLedgerEntry value
    ) => new(value);

    public static DataVariants::AmendmentLedgerEntry Create(Ledger::AmendmentLedgerEntry value) =>
        new(value);

    public abstract void Validate();
}
