using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using BillingCycleConfigurationProperties = Orb.Models.BillingCycleConfigurationProperties;
using System = System;

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
                throw new System::ArgumentOutOfRangeException(
                    "duration",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["duration"] = JsonSerializer.SerializeToElement(value); }
    }

    public required BillingCycleConfigurationProperties::DurationUnit DurationUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("duration_unit", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "duration_unit",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<BillingCycleConfigurationProperties::DurationUnit>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("duration_unit");
        }
        set { this.Properties["duration_unit"] = JsonSerializer.SerializeToElement(value); }
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
