using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.Customers.Credits.Ledger.LedgerListParamsProperties;

[JsonConverter(typeof(EntryTypeConverter))]
public enum EntryType
{
    Increment,
    Decrement,
    ExpirationChange,
    CreditBlockExpiry,
    Void,
    VoidInitiated,
    Amendment,
}

sealed class EntryTypeConverter : JsonConverter<EntryType>
{
    public override EntryType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "increment" => EntryType.Increment,
            "decrement" => EntryType.Decrement,
            "expiration_change" => EntryType.ExpirationChange,
            "credit_block_expiry" => EntryType.CreditBlockExpiry,
            "void" => EntryType.Void,
            "void_initiated" => EntryType.VoidInitiated,
            "amendment" => EntryType.Amendment,
            _ => (EntryType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntryType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntryType.Increment => "increment",
                EntryType.Decrement => "decrement",
                EntryType.ExpirationChange => "expiration_change",
                EntryType.CreditBlockExpiry => "credit_block_expiry",
                EntryType.Void => "void",
                EntryType.VoidInitiated => "void_initiated",
                EntryType.Amendment => "amendment",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
