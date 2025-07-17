using LedgerCreateEntryByExternalIDResponseVariants = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDResponseVariants;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Customers.Credits.Ledger;

/// <summary>
/// The [Credit Ledger Entry resource](/product-catalog/prepurchase) models prepaid
/// credits within Orb.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::UnionConverter<LedgerCreateEntryByExternalIDResponse>))]
public abstract record class LedgerCreateEntryByExternalIDResponse
{
    internal LedgerCreateEntryByExternalIDResponse() { }

    public static LedgerCreateEntryByExternalIDResponseVariants::IncrementLedgerEntry Create(
        IncrementLedgerEntry value
    ) => new(value);

    public static LedgerCreateEntryByExternalIDResponseVariants::DecrementLedgerEntry Create(
        DecrementLedgerEntry value
    ) => new(value);

    public static LedgerCreateEntryByExternalIDResponseVariants::ExpirationChangeLedgerEntry Create(
        ExpirationChangeLedgerEntry value
    ) => new(value);

    public static LedgerCreateEntryByExternalIDResponseVariants::CreditBlockExpiryLedgerEntry Create(
        CreditBlockExpiryLedgerEntry value
    ) => new(value);

    public static LedgerCreateEntryByExternalIDResponseVariants::VoidLedgerEntry Create(
        VoidLedgerEntry value
    ) => new(value);

    public static LedgerCreateEntryByExternalIDResponseVariants::VoidInitiatedLedgerEntry Create(
        VoidInitiatedLedgerEntry value
    ) => new(value);

    public static LedgerCreateEntryByExternalIDResponseVariants::AmendmentLedgerEntry Create(
        AmendmentLedgerEntry value
    ) => new(value);

    public abstract void Validate();
}
