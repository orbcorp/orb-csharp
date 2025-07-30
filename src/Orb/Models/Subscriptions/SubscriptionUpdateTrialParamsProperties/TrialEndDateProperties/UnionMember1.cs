using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.SubscriptionUpdateTrialParamsProperties.TrialEndDateProperties;

[JsonConverter(typeof(EnumConverter<UnionMember1, string>))]
public sealed record class UnionMember1(string value) : IEnum<UnionMember1, string>
{
    public static readonly UnionMember1 Immediate = new("immediate");

    readonly string _value = value;

    public enum Value
    {
        Immediate,
    }

    public Value Known() =>
        _value switch
        {
            "immediate" => Value.Immediate,
            _ => throw new ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static UnionMember1 FromRaw(string value)
    {
        return new(value);
    }
}
