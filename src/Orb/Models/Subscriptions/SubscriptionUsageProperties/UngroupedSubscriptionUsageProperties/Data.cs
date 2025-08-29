using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Models.Subscriptions.SubscriptionUsageProperties.UngroupedSubscriptionUsageProperties.DataProperties;

namespace Orb.Models.Subscriptions.SubscriptionUsageProperties.UngroupedSubscriptionUsageProperties;

[JsonConverter(typeof(ModelConverter<Data>))]
public sealed record class Data : ModelBase, IFromRaw<Data>
{
    public required BillableMetric BillableMetric
    {
        get
        {
            if (!this.Properties.TryGetValue("billable_metric", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "billable_metric",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<BillableMetric>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("billable_metric");
        }
        set
        {
            this.Properties["billable_metric"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required List<Usage> Usage
    {
        get
        {
            if (!this.Properties.TryGetValue("usage", out JsonElement element))
                throw new ArgumentOutOfRangeException("usage", "Missing required argument");

            return JsonSerializer.Deserialize<List<Usage>>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("usage");
        }
        set
        {
            this.Properties["usage"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, ViewMode> ViewMode
    {
        get
        {
            if (!this.Properties.TryGetValue("view_mode", out JsonElement element))
                throw new ArgumentOutOfRangeException("view_mode", "Missing required argument");

            return JsonSerializer.Deserialize<ApiEnum<string, ViewMode>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["view_mode"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
