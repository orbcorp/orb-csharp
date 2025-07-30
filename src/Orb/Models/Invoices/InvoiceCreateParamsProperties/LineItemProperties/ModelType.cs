using System;
using System.Text.Json.Serialization;

namespace Orb.Models.Invoices.InvoiceCreateParamsProperties.LineItemProperties;

[JsonConverter(typeof(EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : IEnum<ModelType, string>
{
    public static readonly ModelType Unit = new("unit");

    readonly string _value = value;

    public enum Value
    {
        Unit,
    }

    public Value Known() =>
        _value switch
        {
            "unit" => Value.Unit,
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
