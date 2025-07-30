using System;
using System.Text.Json.Serialization;

namespace Orb.Models.NewFloatingBulkWithProrationPriceProperties;

[JsonConverter(typeof(EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : IEnum<ModelType, string>
{
    public static readonly ModelType BulkWithProration = new("bulk_with_proration");

    readonly string _value = value;

    public enum Value
    {
        BulkWithProration,
    }

    public Value Known() =>
        _value switch
        {
            "bulk_with_proration" => Value.BulkWithProration,
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
