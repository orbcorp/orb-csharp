using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Plans.PlanProperties.TrialConfigProperties;

namespace Orb.Models.Plans.PlanProperties;

[JsonConverter(typeof(ModelConverter<TrialConfig>))]
public sealed record class TrialConfig : ModelBase, IFromRaw<TrialConfig>
{
    public required long? TrialPeriod
    {
        get
        {
            if (!this.Properties.TryGetValue("trial_period", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["trial_period"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, TrialPeriodUnit> TrialPeriodUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("trial_period_unit", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'trial_period_unit' cannot be null",
                    new ArgumentOutOfRangeException(
                        "trial_period_unit",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, TrialPeriodUnit>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["trial_period_unit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.TrialPeriod;
        this.TrialPeriodUnit.Validate();
    }

    public TrialConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrialConfig(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TrialConfig FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
