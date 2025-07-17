using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Subscriptions.NewSubscriptionTierWithProrationPriceProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : Orb::IEnum<ModelType, string>
{
    public static readonly ModelType TieredWithProration = new("tiered_with_proration");

    readonly string _value = value;

    public enum Value
    {
        TieredWithProration,
    }

    public Value Known() =>
        _value switch
        {
            "tiered_with_proration" => Value.TieredWithProration,
            _ => throw new System::ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static ModelType FromRaw(string value)
    {
        return new(value);
    }
}
