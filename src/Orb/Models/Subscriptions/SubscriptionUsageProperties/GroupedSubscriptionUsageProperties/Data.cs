using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DataProperties = Orb.Models.Subscriptions.SubscriptionUsageProperties.GroupedSubscriptionUsageProperties.DataProperties;

namespace Orb.Models.Subscriptions.SubscriptionUsageProperties.GroupedSubscriptionUsageProperties;

[JsonConverter(typeof(ModelConverter<Data>))]
public sealed record class Data : ModelBase, IFromRaw<Data>
{
    public required DataProperties::BillableMetric BillableMetric
    {
        get
        {
            if (!this.Properties.TryGetValue("billable_metric", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "billable_metric",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<DataProperties::BillableMetric>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("billable_metric");
        }
        set { this.Properties["billable_metric"] = JsonSerializer.SerializeToElement(value); }
    }

    public required DataProperties::MetricGroup MetricGroup
    {
        get
        {
            if (!this.Properties.TryGetValue("metric_group", out JsonElement element))
                throw new ArgumentOutOfRangeException("metric_group", "Missing required argument");

            return JsonSerializer.Deserialize<DataProperties::MetricGroup>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("metric_group");
        }
        set { this.Properties["metric_group"] = JsonSerializer.SerializeToElement(value); }
    }

    public required List<DataProperties::Usage> Usage
    {
        get
        {
            if (!this.Properties.TryGetValue("usage", out JsonElement element))
                throw new ArgumentOutOfRangeException("usage", "Missing required argument");

            return JsonSerializer.Deserialize<List<DataProperties::Usage>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("usage");
        }
        set { this.Properties["usage"] = JsonSerializer.SerializeToElement(value); }
    }

    public required DataProperties::ViewMode ViewMode
    {
        get
        {
            if (!this.Properties.TryGetValue("view_mode", out JsonElement element))
                throw new ArgumentOutOfRangeException("view_mode", "Missing required argument");

            return JsonSerializer.Deserialize<DataProperties::ViewMode>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("view_mode");
        }
        set { this.Properties["view_mode"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.BillableMetric.Validate();
        this.MetricGroup.Validate();
        foreach (var item in this.Usage)
        {
            item.Validate();
        }
        this.ViewMode.Validate();
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Data FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
