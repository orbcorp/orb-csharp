using System.Text.Json.Serialization;
using GroupingValueVariants = Orb.Models.Prices.EvaluatePriceGroupProperties.GroupingValueVariants;

namespace Orb.Models.Prices.EvaluatePriceGroupProperties;

[JsonConverter(typeof(UnionConverter<GroupingValue>))]
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
