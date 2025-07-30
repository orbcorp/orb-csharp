using GroupingValueVariants = Orb.Models.Prices.EvaluatePriceGroupProperties.GroupingValueVariants;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Prices.EvaluatePriceGroupProperties;

[Serialization::JsonConverter(typeof(Orb::UnionConverter<GroupingValue>))]
public abstract record class GroupingValue
{
    internal GroupingValue() { }

    public static implicit operator GroupingValue(string value) =>
        new GroupingValueVariants::String(value);

    public static implicit operator GroupingValue(double value) =>
        new GroupingValueVariants::Double(value);

    public static implicit operator GroupingValue(bool value) =>
        new GroupingValueVariants::Bool(value);

    public abstract void Validate();
}
