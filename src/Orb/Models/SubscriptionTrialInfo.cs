using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<SubscriptionTrialInfo>))]
public sealed record class SubscriptionTrialInfo : ModelBase, IFromRaw<SubscriptionTrialInfo>
{
    public required DateTime? EndDate
    {
        get
        {
            if (!this.Properties.TryGetValue("end_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

    [SetsRequiredMembers]
    public SubscriptionTrialInfo(DateTime? endDate)
        : this()
    {
        this.EndDate = endDate;
    }
}
