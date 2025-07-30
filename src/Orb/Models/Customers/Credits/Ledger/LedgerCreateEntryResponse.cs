using System.Text.Json.Serialization;
using LedgerCreateEntryResponseVariants = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryResponseVariants;

namespace Orb.Models.Customers.Credits.Ledger;

/// <summary>
/// The [Credit Ledger Entry resource](/product-catalog/prepurchase) models prepaid
/// credits within Orb.
/// </summary>
[JsonConverter(typeof(UnionConverter<LedgerCreateEntryResponse>))]
public abstract record class LedgerCreateEntryResponse
{
    internal LedgerCreateEntryResponse() { }

    public static implicit operator LedgerCreateEntryResponse(IncrementLedgerEntry value) =>
        new LedgerCreateEntryResponseVariants::IncrementLedgerEntryVariant(value);

    public static implicit operator LedgerCreateEntryResponse(DecrementLedgerEntry value) =>
        new LedgerCreateEntryResponseVariants::DecrementLedgerEntryVariant(value);

    public static implicit operator LedgerCreateEntryResponse(ExpirationChangeLedgerEntry value) =>
        new LedgerCreateEntryResponseVariants::ExpirationChangeLedgerEntryVariant(value);

    public static implicit operator LedgerCreateEntryResponse(CreditBlockExpiryLedgerEntry value) =>
        new LedgerCreateEntryResponseVariants::CreditBlockExpiryLedgerEntryVariant(value);

    public static implicit operator LedgerCreateEntryResponse(VoidLedgerEntry value) =>
        new LedgerCreateEntryResponseVariants::VoidLedgerEntryVariant(value);

    public static implicit operator LedgerCreateEntryResponse(VoidInitiatedLedgerEntry value) =>
        new LedgerCreateEntryResponseVariants::VoidInitiatedLedgerEntryVariant(value);

    public static implicit operator LedgerCreateEntryResponse(AmendmentLedgerEntry value) =>
        new LedgerCreateEntryResponseVariants::AmendmentLedgerEntryVariant(value);

    public abstract void Validate();
}
