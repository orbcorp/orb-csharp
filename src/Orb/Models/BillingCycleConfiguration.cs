using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.BillingCycleConfigurationProperties;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<BillingCycleConfiguration>))]
public sealed record class BillingCycleConfiguration
    : ModelBase,
        IFromRaw<BillingCycleConfiguration>
{
    public required long Duration
    {
        get
        {
            if (!this.Properties.TryGetValue("duration", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'duration' cannot be null",
                    new ArgumentOutOfRangeException("duration", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["duration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, DurationUnit> DurationUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("duration_unit", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'duration_unit' cannot be null",
                    new ArgumentOutOfRangeException("duration_unit", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, DurationUnit>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["duration_unit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Duration;
        this.DurationUnit.Validate();
    }

    public BillingCycleConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingCycleConfiguration(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BillingCycleConfiguration FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
