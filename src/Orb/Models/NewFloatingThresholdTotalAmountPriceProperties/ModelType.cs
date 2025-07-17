using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.NewFloatingThresholdTotalAmountPriceProperties;

[Serialization::JsonConverter(typeof(Orb::EnumConverter<ModelType, string>))]
public sealed record class ModelType(string value) : Orb::IEnum<ModelType, string>
{
    public static readonly ModelType ThresholdTotalAmount = new("threshold_total_amount");

    readonly string _value = value;

    public enum Value
    {
        ThresholdTotalAmount,
    }

    public Value Known() =>
        _value switch
        {
            "threshold_total_amount" => Value.ThresholdTotalAmount,
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
