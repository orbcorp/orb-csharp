using System.Text.Json.Serialization;

namespace Orb.Models.Prices.EvaluatePriceGroupProperties.GroupingValueVariants;

[JsonConverter(typeof(VariantConverter<String, string>))]
public sealed record class String(string Value) : GroupingValue, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

[JsonConverter(typeof(VariantConverter<Double, double>))]
public sealed record class Double(double Value) : GroupingValue, IVariant<Double, double>
{
    public static Double From(double value)
    {
        return new(value);
    }

    public override void Validate() { }
}

[JsonConverter(typeof(VariantConverter<Bool, bool>))]
public sealed record class Bool(bool Value) : GroupingValue, IVariant<Bool, bool>
{
    public static Bool From(bool value)
    {
        return new(value);
    }

    public override void Validate() { }
}
