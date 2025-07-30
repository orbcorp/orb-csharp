using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Subscriptions.NewSubscriptionCumulativeGroupedBulkPriceProperties;

[JsonConverter(typeof(EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : IEnum<ModelType, string>
{
    public static readonly ModelType CumulativeGroupedBulk = new("cumulative_grouped_bulk");

    readonly string _value = value;

    public enum Value
    {
        CumulativeGroupedBulk,
    }

    public Value Known() =>
        _value switch
        {
            "cumulative_grouped_bulk" => Value.CumulativeGroupedBulk,
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

    public static ModelType FromRaw(string value)
    {
        return new(value);
    }
}
