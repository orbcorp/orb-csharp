using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using DataProperties = Orb.Models.Subscriptions.SubscriptionFetchSchedulePageResponseProperties.DataProperties;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionFetchSchedulePageResponseProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<Data>))]
public sealed record class Data : Orb::ModelBase, Orb::IFromRaw<Data>
{
    public required System::DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "created_at",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set { this.Properties["created_at"] = Json::JsonSerializer.SerializeToElement(value); }
    }

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

    public required DataProperties::Plan? Plan
    {
        get
        {
            if (!this.Properties.TryGetValue("plan", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("plan", "Missing required argument");

            return Json::JsonSerializer.Deserialize<DataProperties::Plan?>(element);
        }
        set { this.Properties["plan"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required System::DateTime StartDate
    {
        get
        {
            if (!this.Properties.TryGetValue("start_date", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "start_date",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set { this.Properties["start_date"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.EndDate;
        this.Plan?.Validate();
        _ = this.StartDate;
    }

    public Data() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    Data(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Data FromRawUnchecked(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        return new(properties);
    }
}
