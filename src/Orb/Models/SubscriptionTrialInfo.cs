using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<SubscriptionTrialInfo>))]
public sealed record class SubscriptionTrialInfo
    : Orb::ModelBase,
        Orb::IFromRaw<SubscriptionTrialInfo>
{
    public required System::DateTime? EndDate
    {
        get
        {
            if (!this.Properties.TryGetValue("end_date", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "end_date",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime?>(element);
        }
        set { this.Properties["end_date"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.EndDate;
    }

    public SubscriptionTrialInfo() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    SubscriptionTrialInfo(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SubscriptionTrialInfo FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
