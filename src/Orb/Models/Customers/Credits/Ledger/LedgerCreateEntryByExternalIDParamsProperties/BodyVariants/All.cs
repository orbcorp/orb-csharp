using BodyProperties = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyProperties;

namespace Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyVariants;

public sealed record class Increment(BodyProperties::Increment Value)
    : Body,
        IVariant<Increment, BodyProperties::Increment>
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

public sealed record class Decrement(BodyProperties::Decrement Value)
    : Body,
        IVariant<Decrement, BodyProperties::Decrement>
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

public sealed record class ExpirationChange(BodyProperties::ExpirationChange Value)
    : Body,
        IVariant<ExpirationChange, BodyProperties::ExpirationChange>
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

public sealed record class Void(BodyProperties::Void Value)
    : Body,
        IVariant<Void, BodyProperties::Void>
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

public sealed record class Amendment(BodyProperties::Amendment Value)
    : Body,
        IVariant<Amendment, BodyProperties::Amendment>
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
