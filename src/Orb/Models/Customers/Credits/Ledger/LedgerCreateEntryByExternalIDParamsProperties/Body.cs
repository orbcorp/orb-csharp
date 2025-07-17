using BodyProperties = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyProperties;
using BodyVariants = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyVariants;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties;

[Serialization::JsonConverter(typeof(Orb::UnionConverter<Body>))]
public abstract record class Body
{
    internal Body() { }

    public static BodyVariants::Increment Create(BodyProperties::Increment value) => new(value);

    public static BodyVariants::Decrement Create(BodyProperties::Decrement value) => new(value);

    public static BodyVariants::ExpirationChange Create(BodyProperties::ExpirationChange value) =>
        new(value);

    public static BodyVariants::Void Create(BodyProperties::Void value) => new(value);

    public static BodyVariants::Amendment Create(BodyProperties::Amendment value) => new(value);

    public abstract void Validate();
}
