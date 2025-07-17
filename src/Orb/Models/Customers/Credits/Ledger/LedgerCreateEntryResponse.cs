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

    public static LedgerCreateEntryResponseVariants::IncrementLedgerEntry Create(
        IncrementLedgerEntry value
    ) => new(value);

    public static LedgerCreateEntryResponseVariants::DecrementLedgerEntry Create(
        DecrementLedgerEntry value
    ) => new(value);

    public static LedgerCreateEntryResponseVariants::ExpirationChangeLedgerEntry Create(
        ExpirationChangeLedgerEntry value
    ) => new(value);

    public static LedgerCreateEntryResponseVariants::CreditBlockExpiryLedgerEntry Create(
        CreditBlockExpiryLedgerEntry value
    ) => new(value);

    public static LedgerCreateEntryResponseVariants::VoidLedgerEntry Create(
        VoidLedgerEntry value
    ) => new(value);

    public static LedgerCreateEntryResponseVariants::VoidInitiatedLedgerEntry Create(
        VoidInitiatedLedgerEntry value
    ) => new(value);

    public static LedgerCreateEntryResponseVariants::AmendmentLedgerEntry Create(
        AmendmentLedgerEntry value
    ) => new(value);

    public abstract void Validate();
}
