using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Models.NewBillingCycleConfigurationProperties;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<NewBillingCycleConfiguration>))]
public sealed record class NewBillingCycleConfiguration
    : ModelBase,
        IFromRaw<NewBillingCycleConfiguration>
{
    /// <summary>
    /// The duration of the billing period.
    /// </summary>
    public required long Duration
    {
        get
        {
            if (!this.Properties.TryGetValue("duration", out JsonElement element))
                throw new ArgumentOutOfRangeException("duration", "Missing required argument");

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

    /// <summary>
    /// The unit of billing period duration.
    /// </summary>
    public required ApiEnum<string, DurationUnit> DurationUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("duration_unit", out JsonElement element))
                throw new ArgumentOutOfRangeException("duration_unit", "Missing required argument");

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

    public NewBillingCycleConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewBillingCycleConfiguration(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static NewBillingCycleConfiguration FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
