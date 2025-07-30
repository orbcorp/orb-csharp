using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;
using TieredConversionRateConfigProperties = Orb.Models.TieredConversionRateConfigProperties;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<TieredConversionRateConfig>))]
public sealed record class TieredConversionRateConfig
    : ModelBase,
        IFromRaw<TieredConversionRateConfig>
{
    public required TieredConversionRateConfigProperties::ConversionRateType ConversionRateType
    {
        get
        {
            if (!this.Properties.TryGetValue("conversion_rate_type", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "conversion_rate_type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<TieredConversionRateConfigProperties::ConversionRateType>(
                    element
                ) ?? throw new System::ArgumentNullException("conversion_rate_type");
        }
        set { this.Properties["conversion_rate_type"] = JsonSerializer.SerializeToElement(value); }
    }

    public required ConversionRateTieredConfig TieredConfig
    {
        get
        {
            if (!this.Properties.TryGetValue("tiered_config", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "tiered_config",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<ConversionRateTieredConfig>(element)
                ?? throw new System::ArgumentNullException("tiered_config");
        }
        set { this.Properties["tiered_config"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.ConversionRateType.Validate();
        this.TieredConfig.Validate();
    }

    public TieredConversionRateConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TieredConversionRateConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TieredConversionRateConfig FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
