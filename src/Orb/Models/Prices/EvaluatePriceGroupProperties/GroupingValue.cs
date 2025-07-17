using GroupingValueVariants = Orb.Models.Prices.EvaluatePriceGroupProperties.GroupingValueVariants;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;

namespace Orb.Models.Prices.EvaluatePriceGroupProperties;

[Serialization::JsonConverter(typeof(Orb::UnionConverter<GroupingValue>))]
public abstract record class GroupingValue
{
    internal GroupingValue() { }

    public static GroupingValueVariants::UnionMember0 Create(string value) => new(value);

    public static GroupingValueVariants::UnionMember1 Create(double value) => new(value);

    public static GroupingValueVariants::UnionMember2 Create(bool value) => new(value);

    public abstract void Validate();
}
