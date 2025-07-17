using EvaluatePriceGroupProperties = Orb.Models.Prices.EvaluatePriceGroupProperties;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Prices.EvaluatePriceGroupProperties.GroupingValueVariants;

[Serialization::JsonConverter(typeof(Orb::VariantConverter<UnionMember0, string>))]
public sealed record class UnionMember0(string Value)
    : EvaluatePriceGroupProperties::GroupingValue,
        Orb::IVariant<UnionMember0, string>
{
    public static UnionMember0 From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

[Serialization::JsonConverter(typeof(Orb::VariantConverter<UnionMember1, double>))]
public sealed record class UnionMember1(double Value)
    : EvaluatePriceGroupProperties::GroupingValue,
        Orb::IVariant<UnionMember1, double>
{
    public static UnionMember1 From(double value)
    {
        return new(value);
    }

    public override void Validate() { }
}

[Serialization::JsonConverter(typeof(Orb::VariantConverter<UnionMember2, bool>))]
public sealed record class UnionMember2(bool Value)
    : EvaluatePriceGroupProperties::GroupingValue,
        Orb::IVariant<UnionMember2, bool>
{
    public static UnionMember2 From(bool value)
    {
        return new(value);
    }

    public override void Validate() { }
}
