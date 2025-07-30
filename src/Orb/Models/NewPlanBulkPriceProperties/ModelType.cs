using System;
using System.Text.Json.Serialization;

namespace Orb.Models.NewPlanBulkPriceProperties;

[JsonConverter(typeof(EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : IEnum<ModelType, string>
{
    public static readonly ModelType Bulk = new("bulk");

    readonly string _value = value;

    public enum Value
    {
        Bulk,
    }

    public Value Known() =>
        _value switch
        {
            "bulk" => Value.Bulk,
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
