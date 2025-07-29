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

    public static implicit operator LedgerCreateEntryByExternalIDResponse(
        IncrementLedgerEntry value
    ) => new LedgerCreateEntryByExternalIDResponseVariants::IncrementLedgerEntry(value);

    public static implicit operator LedgerCreateEntryByExternalIDResponse(
        DecrementLedgerEntry value
    ) => new LedgerCreateEntryByExternalIDResponseVariants::DecrementLedgerEntry(value);

    public static implicit operator LedgerCreateEntryByExternalIDResponse(
        ExpirationChangeLedgerEntry value
    ) => new LedgerCreateEntryByExternalIDResponseVariants::ExpirationChangeLedgerEntry(value);

    public static implicit operator LedgerCreateEntryByExternalIDResponse(
        CreditBlockExpiryLedgerEntry value
    ) => new LedgerCreateEntryByExternalIDResponseVariants::CreditBlockExpiryLedgerEntry(value);

    public static implicit operator LedgerCreateEntryByExternalIDResponse(VoidLedgerEntry value) =>
        new LedgerCreateEntryByExternalIDResponseVariants::VoidLedgerEntry(value);

    public static implicit operator LedgerCreateEntryByExternalIDResponse(
        VoidInitiatedLedgerEntry value
    ) => new LedgerCreateEntryByExternalIDResponseVariants::VoidInitiatedLedgerEntry(value);

    public static implicit operator LedgerCreateEntryByExternalIDResponse(
        AmendmentLedgerEntry value
    ) => new LedgerCreateEntryByExternalIDResponseVariants::AmendmentLedgerEntry(value);

    public abstract void Validate();
}
