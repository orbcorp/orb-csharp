using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using DataProperties = Orb.Models.Subscriptions.SubscriptionUsageProperties.UngroupedSubscriptionUsageProperties.DataProperties;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Subscriptions.SubscriptionUsageProperties.UngroupedSubscriptionUsageProperties;

[Serialization::JsonConverter(typeof(Orb::ModelConverter<Data>))]
public sealed record class Data : Orb::ModelBase, Orb::IFromRaw<Data>
{
    public required DataProperties::BillableMetric BillableMetric
    {
        get
        {
            if (!this.Properties.TryGetValue("billable_metric", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "billable_metric",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<DataProperties::BillableMetric>(element)
                ?? throw new System::ArgumentNullException("billable_metric");
        }
        set { this.Properties["billable_metric"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required Generic::List<DataProperties::Usage> Usage
    {
        get
        {
            if (!this.Properties.TryGetValue("usage", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("usage", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Generic::List<DataProperties::Usage>>(element)
                ?? throw new System::ArgumentNullException("usage");
        }
        set { this.Properties["usage"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required DataProperties::ViewMode ViewMode
    {
        get
        {
            if (!this.Properties.TryGetValue("view_mode", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "view_mode",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<DataProperties::ViewMode>(element)
                ?? throw new System::ArgumentNullException("view_mode");
        }
        set { this.Properties["view_mode"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.BillableMetric.Validate();
        foreach (var item in this.Usage)
        {
            item.Validate();
        }
        this.ViewMode.Validate();
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
