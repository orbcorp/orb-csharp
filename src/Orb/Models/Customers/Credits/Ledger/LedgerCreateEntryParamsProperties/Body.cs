using System.Text.Json.Serialization;
using BodyProperties = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryParamsProperties.BodyProperties;
using BodyVariants = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryParamsProperties.BodyVariants;

namespace Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryParamsProperties;

[JsonConverter(typeof(UnionConverter<Body>))]
public abstract record class Body
{
    internal Body() { }

    public static implicit operator Body(BodyProperties::Increment value) =>
        new BodyVariants::Increment(value);

    public static implicit operator Body(BodyProperties::Decrement value) =>
        new BodyVariants::Decrement(value);

    public static implicit operator Body(BodyProperties::ExpirationChange value) =>
        new BodyVariants::ExpirationChange(value);

    public static implicit operator Body(BodyProperties::Void value) =>
        new BodyVariants::Void(value);

    public static implicit operator Body(BodyProperties::Amendment value) =>
        new BodyVariants::Amendment(value);

    public abstract void Validate();
}
