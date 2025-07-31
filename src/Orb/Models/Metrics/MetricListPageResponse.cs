using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Models = Orb.Models;

namespace Orb.Models.Metrics;

[JsonConverter(typeof(ModelConverter<MetricListPageResponse>))]
public sealed record class MetricListPageResponse : ModelBase, IFromRaw<MetricListPageResponse>
{
    public required List<BillableMetric> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new ArgumentOutOfRangeException("data", "Missing required argument");

            return JsonSerializer.Deserialize<List<BillableMetric>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("data");
        }
        set { this.Properties["data"] = JsonSerializer.SerializeToElement(value); }
    }

    public required Models::PaginationMetadata PaginationMetadata
    {
        get
        {
            if (!this.Properties.TryGetValue("pagination_metadata", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "pagination_metadata",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<Models::PaginationMetadata>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("pagination_metadata");
        }
        set { this.Properties["pagination_metadata"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.PaginationMetadata.Validate();
    }

    public MetricListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MetricListPageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MetricListPageResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
