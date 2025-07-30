using EvaluatePriceGroupProperties = Orb.Models.Prices.EvaluatePriceGroupProperties;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Prices.EvaluatePriceGroupProperties.GroupingValueVariants;

[Serialization::JsonConverter(typeof(Orb::VariantConverter<String, string>))]
public sealed record class String(string Value)
    : EvaluatePriceGroupProperties::GroupingValue,
        Orb::IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

[Serialization::JsonConverter(typeof(Orb::VariantConverter<Double, double>))]
public sealed record class Double(double Value)
    : EvaluatePriceGroupProperties::GroupingValue,
        Orb::IVariant<Double, double>
{
    public static Double From(double value)
    {
        return new(value);
    }

    public override void Validate() { }
}

[Serialization::JsonConverter(typeof(Orb::VariantConverter<Bool, bool>))]
public sealed record class Bool(bool Value)
    : EvaluatePriceGroupProperties::GroupingValue,
        Orb::IVariant<Bool, bool>
{
    public static Bool From(bool value)
    {
        return new(value);
    }

    public override void Validate() { }
}
