using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Alerts.AlertProperties;

/// <summary>
/// The type of alert. This must be a valid alert type.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    CreditBalanceDepleted,
    CreditBalanceDropped,
    CreditBalanceRecovered,
    UsageExceeded,
    CostExceeded,
}

sealed class TypeConverter : JsonConverter<Type>
{
    public override Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "credit_balance_depleted" => AlertProperties.Type.CreditBalanceDepleted,
            "credit_balance_dropped" => AlertProperties.Type.CreditBalanceDropped,
            "credit_balance_recovered" => AlertProperties.Type.CreditBalanceRecovered,
            "usage_exceeded" => AlertProperties.Type.UsageExceeded,
            "cost_exceeded" => AlertProperties.Type.CostExceeded,
            _ => (Type)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AlertProperties.Type.CreditBalanceDepleted => "credit_balance_depleted",
                AlertProperties.Type.CreditBalanceDropped => "credit_balance_dropped",
                AlertProperties.Type.CreditBalanceRecovered => "credit_balance_recovered",
                AlertProperties.Type.UsageExceeded => "usage_exceeded",
                AlertProperties.Type.CostExceeded => "cost_exceeded",
                _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
