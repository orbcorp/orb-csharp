using BillableMetricProperties = Orb.Models.Metrics.BillableMetricProperties;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Items = Orb.Models.Items;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Metrics;

/// <summary>
/// The Metric resource represents a calculation of a quantity based on events. Metrics
/// are defined by the query that transforms raw usage events into meaningful values
/// for your customers.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::ModelConverter<BillableMetric>))]
public sealed record class BillableMetric : Orb::ModelBase, Orb::IFromRaw<BillableMetric>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("id", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("id");
        }
        set { this.Properties["id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string? Description
    {
        get
        {
            if (!this.Properties.TryGetValue("description", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "description",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["description"] = Json::JsonSerializer.SerializeToElement(value); }
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
            if (!this.Properties.TryGetValue("item", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("item", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Items::Item>(element)
                ?? throw new System::ArgumentNullException("item");
        }
        set { this.Properties["item"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// User specified key-value pairs for the resource. If not present, this defaults
    /// to an empty dictionary. Individual keys can be removed by setting the value
    /// to `null`, and the entire metadata mapping can be cleared by setting `metadata`
    /// to `null`.
    /// </summary>
    public required Generic::Dictionary<string, string> Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "metadata",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::Dictionary<string, string>>(element)
                ?? throw new System::ArgumentNullException("metadata");
        }
        set { this.Properties["metadata"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("name", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("name");
        }
        set { this.Properties["name"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public required BillableMetricProperties::Status Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "status",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<BillableMetricProperties::Status>(element)
                ?? throw new System::ArgumentNullException("status");
        }
        set { this.Properties["status"] = Json::JsonSerializer.SerializeToElement(value); }
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
    [CodeAnalysis::SetsRequiredMembers]
    BillableMetric(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BillableMetric FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
