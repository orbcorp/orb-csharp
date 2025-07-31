using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using BillableMetricProperties = Orb.Models.Metrics.BillableMetricProperties;
using Items = Orb.Models.Items;

namespace Orb.Models.Metrics;

/// <summary>
/// The Metric resource represents a calculation of a quantity based on events. Metrics
/// are defined by the query that transforms raw usage events into meaningful values
/// for your customers.
/// </summary>
[JsonConverter(typeof(ModelConverter<BillableMetric>))]
public sealed record class BillableMetric : ModelBase, IFromRaw<BillableMetric>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("id");
        }
        set { this.Properties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string? Description
    {
        get
        {
            if (!this.Properties.TryGetValue("description", out JsonElement element))
                throw new ArgumentOutOfRangeException("description", "Missing required argument");

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["description"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// The Item resource represents a sellable product or good. Items are associated
    /// with all line items, billable metrics, and prices and are used for defining
    /// external sync behavior for invoices and tax calculation purposes.
    /// </summary>
    public required Items::Item Item
    {
        get
        {
            if (!this.Properties.TryGetValue("item", out JsonElement element))
                throw new ArgumentOutOfRangeException("item", "Missing required argument");

            return JsonSerializer.Deserialize<Items::Item>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("item");
        }
        set { this.Properties["item"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// User specified key-value pairs for the resource. If not present, this defaults
    /// to an empty dictionary. Individual keys can be removed by setting the value
    /// to `null`, and the entire metadata mapping can be cleared by setting `metadata`
    /// to `null`.
    /// </summary>
    public required Dictionary<string, string> Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out JsonElement element))
                throw new ArgumentOutOfRangeException("metadata", "Missing required argument");

            return JsonSerializer.Deserialize<Dictionary<string, string>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("metadata");
        }
        set { this.Properties["metadata"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new ArgumentOutOfRangeException("name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("name");
        }
        set { this.Properties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    public required BillableMetricProperties::Status Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new ArgumentOutOfRangeException("status", "Missing required argument");

            return JsonSerializer.Deserialize<BillableMetricProperties::Status>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("status");
        }
        set { this.Properties["status"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Description;
        this.Item.Validate();
        foreach (var item in this.Metadata.Values)
        {
            _ = item;
        }
        _ = this.Name;
        this.Status.Validate();
    }

    public BillableMetric() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillableMetric(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BillableMetric FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
