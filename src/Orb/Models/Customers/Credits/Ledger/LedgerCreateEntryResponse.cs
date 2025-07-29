using LedgerCreateEntryResponseVariants = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryResponseVariants;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Customers.Credits.Ledger;

/// <summary>
/// The [Credit Ledger Entry resource](/product-catalog/prepurchase) models prepaid
/// credits within Orb.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::UnionConverter<LedgerCreateEntryResponse>))]
public abstract record class LedgerCreateEntryResponse
{
    internal LedgerCreateEntryResponse() { }

    public static implicit operator LedgerCreateEntryResponse(IncrementLedgerEntry value) =>
        new LedgerCreateEntryResponseVariants::IncrementLedgerEntry(value);

    public static implicit operator LedgerCreateEntryResponse(DecrementLedgerEntry value) =>
        new LedgerCreateEntryResponseVariants::DecrementLedgerEntry(value);

    public static implicit operator LedgerCreateEntryResponse(ExpirationChangeLedgerEntry value) =>
        new LedgerCreateEntryResponseVariants::ExpirationChangeLedgerEntry(value);

    public static implicit operator LedgerCreateEntryResponse(CreditBlockExpiryLedgerEntry value) =>
        new LedgerCreateEntryResponseVariants::CreditBlockExpiryLedgerEntry(value);

    public static implicit operator LedgerCreateEntryResponse(VoidLedgerEntry value) =>
        new LedgerCreateEntryResponseVariants::VoidLedgerEntry(value);

    public static implicit operator LedgerCreateEntryResponse(VoidInitiatedLedgerEntry value) =>
        new LedgerCreateEntryResponseVariants::VoidInitiatedLedgerEntry(value);

    public static implicit operator LedgerCreateEntryResponse(AmendmentLedgerEntry value) =>
        new LedgerCreateEntryResponseVariants::AmendmentLedgerEntry(value);

    public abstract void Validate();
}
