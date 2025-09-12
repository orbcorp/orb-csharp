using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models.Items.ItemProperties.ExternalConnectionProperties;

[JsonConverter(typeof(ExternalConnectionNameConverter))]
public enum ExternalConnectionName
{
    Stripe,
    Quickbooks,
    BillCom,
    Netsuite,
    Taxjar,
    Avalara,
    Anrok,
    Numeral,
}

sealed class ExternalConnectionNameConverter : JsonConverter<ExternalConnectionName>
{
    public override ExternalConnectionName Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "stripe" => ExternalConnectionName.Stripe,
            "quickbooks" => ExternalConnectionName.Quickbooks,
            "bill.com" => ExternalConnectionName.BillCom,
            "netsuite" => ExternalConnectionName.Netsuite,
            "taxjar" => ExternalConnectionName.Taxjar,
            "avalara" => ExternalConnectionName.Avalara,
            "anrok" => ExternalConnectionName.Anrok,
            "numeral" => ExternalConnectionName.Numeral,
            _ => (ExternalConnectionName)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExternalConnectionName value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExternalConnectionName.Stripe => "stripe",
                ExternalConnectionName.Quickbooks => "quickbooks",
                ExternalConnectionName.BillCom => "bill.com",
                ExternalConnectionName.Netsuite => "netsuite",
                ExternalConnectionName.Taxjar => "taxjar",
                ExternalConnectionName.Avalara => "avalara",
                ExternalConnectionName.Anrok => "anrok",
                ExternalConnectionName.Numeral => "numeral",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
