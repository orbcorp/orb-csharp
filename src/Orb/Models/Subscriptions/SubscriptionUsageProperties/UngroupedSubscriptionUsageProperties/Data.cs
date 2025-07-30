using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DataProperties = Orb.Models.Subscriptions.SubscriptionUsageProperties.UngroupedSubscriptionUsageProperties.DataProperties;

namespace Orb.Models.Subscriptions.SubscriptionUsageProperties.UngroupedSubscriptionUsageProperties;

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

            return JsonSerializer.Deserialize<DataProperties::BillableMetric>(element)
                ?? throw new ArgumentNullException("billable_metric");
        }
        set { this.Properties["billable_metric"] = JsonSerializer.SerializeToElement(value); }
    }

    public required List<DataProperties::Usage> Usage
    {
        get
        {
            if (!this.Properties.TryGetValue("usage", out JsonElement element))
                throw new ArgumentOutOfRangeException("usage", "Missing required argument");

            return JsonSerializer.Deserialize<List<DataProperties::Usage>>(element)
                ?? throw new ArgumentNullException("usage");
        }
        set { this.Properties["usage"] = JsonSerializer.SerializeToElement(value); }
    }

    public required DataProperties::ViewMode ViewMode
    {
        get
        {
            if (!this.Properties.TryGetValue("view_mode", out JsonElement element))
                throw new ArgumentOutOfRangeException("view_mode", "Missing required argument");

            return JsonSerializer.Deserialize<DataProperties::ViewMode>(element)
                ?? throw new ArgumentNullException("view_mode");
        }
        set { this.Properties["view_mode"] = JsonSerializer.SerializeToElement(value); }
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
