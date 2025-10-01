using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Alerts.AlertCreateForExternalCustomerParamsProperties;

/// <summary>
/// The type of alert to create. This must be a valid alert type.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    CreditBalanceDepleted,
    CreditBalanceDropped,
    CreditBalanceRecovered,
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
            "credit_balance_depleted" => AlertCreateForExternalCustomerParamsProperties
                .Type
                .CreditBalanceDepleted,
            "credit_balance_dropped" => AlertCreateForExternalCustomerParamsProperties
                .Type
                .CreditBalanceDropped,
            "credit_balance_recovered" => AlertCreateForExternalCustomerParamsProperties
                .Type
                .CreditBalanceRecovered,
            _ => (Type)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AlertCreateForExternalCustomerParamsProperties.Type.CreditBalanceDepleted =>
                    "credit_balance_depleted",
                AlertCreateForExternalCustomerParamsProperties.Type.CreditBalanceDropped =>
                    "credit_balance_dropped",
                AlertCreateForExternalCustomerParamsProperties.Type.CreditBalanceRecovered =>
                    "credit_balance_recovered",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
