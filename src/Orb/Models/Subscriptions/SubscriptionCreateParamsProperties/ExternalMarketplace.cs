using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.Subscriptions.SubscriptionCreateParamsProperties;

[JsonConverter(typeof(ExternalMarketplaceConverter))]
public enum ExternalMarketplace
{
    Google,
    Aws,
    Azure,
}

sealed class ExternalMarketplaceConverter : JsonConverter<ExternalMarketplace>
{
    public override ExternalMarketplace Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "google" => ExternalMarketplace.Google,
            "aws" => ExternalMarketplace.Aws,
            "azure" => ExternalMarketplace.Azure,
            _ => (ExternalMarketplace)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExternalMarketplace value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExternalMarketplace.Google => "google",
                ExternalMarketplace.Aws => "aws",
                ExternalMarketplace.Azure => "azure",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
