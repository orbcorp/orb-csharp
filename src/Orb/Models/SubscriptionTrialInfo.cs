using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<SubscriptionTrialInfo>))]
public sealed record class SubscriptionTrialInfo : ModelBase, IFromRaw<SubscriptionTrialInfo>
{
    public required System::DateTime? EndDate
    {
        get
        {
            if (!this.Properties.TryGetValue("end_date", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "end_date",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["end_date"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.EndDate;
    }

    public SubscriptionTrialInfo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionTrialInfo(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SubscriptionTrialInfo FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    public SubscriptionTrialInfo(System::DateTime? endDate)
    {
        this.EndDate = endDate;
    }
}
