using System.Text.Json.Serialization;
using LedgerCreateEntryByExternalIDResponseVariants = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDResponseVariants;

namespace Orb.Models.Customers.Credits.Ledger;

/// <summary>
/// The [Credit Ledger Entry resource](/product-catalog/prepurchase) models prepaid
/// credits within Orb.
/// </summary>
[JsonConverter(typeof(UnionConverter<LedgerCreateEntryByExternalIDResponse>))]
public abstract record class LedgerCreateEntryByExternalIDResponse
{
    internal LedgerCreateEntryByExternalIDResponse() { }

    public static implicit operator LedgerCreateEntryByExternalIDResponse(
        IncrementLedgerEntry value
    ) => new LedgerCreateEntryByExternalIDResponseVariants::IncrementLedgerEntryVariant(value);

    public static implicit operator LedgerCreateEntryByExternalIDResponse(
        DecrementLedgerEntry value
    ) => new LedgerCreateEntryByExternalIDResponseVariants::DecrementLedgerEntryVariant(value);

    public static implicit operator LedgerCreateEntryByExternalIDResponse(
        ExpirationChangeLedgerEntry value
    ) =>
        new LedgerCreateEntryByExternalIDResponseVariants::ExpirationChangeLedgerEntryVariant(
            value
        );

    public static implicit operator LedgerCreateEntryByExternalIDResponse(
        CreditBlockExpiryLedgerEntry value
    ) =>
        new LedgerCreateEntryByExternalIDResponseVariants::CreditBlockExpiryLedgerEntryVariant(
            value
        );

    public static implicit operator LedgerCreateEntryByExternalIDResponse(VoidLedgerEntry value) =>
        new LedgerCreateEntryByExternalIDResponseVariants::VoidLedgerEntryVariant(value);

    public static implicit operator LedgerCreateEntryByExternalIDResponse(
        VoidInitiatedLedgerEntry value
    ) => new LedgerCreateEntryByExternalIDResponseVariants::VoidInitiatedLedgerEntryVariant(value);

    public static implicit operator LedgerCreateEntryByExternalIDResponse(
        AmendmentLedgerEntry value
    ) => new LedgerCreateEntryByExternalIDResponseVariants::AmendmentLedgerEntryVariant(value);

    public abstract void Validate();
}
