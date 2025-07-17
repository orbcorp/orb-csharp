using BodyProperties = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyProperties;
using LedgerCreateEntryByExternalIDParamsProperties = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyVariants;

[Serialization::JsonConverter(typeof(Orb::VariantConverter<Increment, BodyProperties::Increment>))]
public sealed record class Increment(BodyProperties::Increment Value)
    : LedgerCreateEntryByExternalIDParamsProperties::Body,
        Orb::IVariant<Increment, BodyProperties::Increment>
{
    public static Increment From(BodyProperties::Increment value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(typeof(Orb::VariantConverter<Decrement, BodyProperties::Decrement>))]
public sealed record class Decrement(BodyProperties::Decrement Value)
    : LedgerCreateEntryByExternalIDParamsProperties::Body,
        Orb::IVariant<Decrement, BodyProperties::Decrement>
{
    public static Decrement From(BodyProperties::Decrement value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Orb::VariantConverter<ExpirationChange, BodyProperties::ExpirationChange>)
)]
public sealed record class ExpirationChange(BodyProperties::ExpirationChange Value)
    : LedgerCreateEntryByExternalIDParamsProperties::Body,
        Orb::IVariant<ExpirationChange, BodyProperties::ExpirationChange>
{
    public static ExpirationChange From(BodyProperties::ExpirationChange value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(typeof(Orb::VariantConverter<Void, BodyProperties::Void>))]
public sealed record class Void(BodyProperties::Void Value)
    : LedgerCreateEntryByExternalIDParamsProperties::Body,
        Orb::IVariant<Void, BodyProperties::Void>
{
    public static Void From(BodyProperties::Void value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(typeof(Orb::VariantConverter<Amendment, BodyProperties::Amendment>))]
public sealed record class Amendment(BodyProperties::Amendment Value)
    : LedgerCreateEntryByExternalIDParamsProperties::Body,
        Orb::IVariant<Amendment, BodyProperties::Amendment>
{
    public static Amendment From(BodyProperties::Amendment value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
