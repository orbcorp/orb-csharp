using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using ItemProperties = Orb.Models.Items.ItemProperties;
using Json = System.Text.Json;
using Orb = Orb;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Orb.Models.Items;

/// <summary>
/// The Item resource represents a sellable product or good. Items are associated
/// with all line items, billable metrics, and prices and are used for defining external
/// sync behavior for invoices and tax calculation purposes.
/// </summary>
[Serialization::JsonConverter(typeof(Orb::ModelConverter<Item>))]
public sealed record class Item : Orb::ModelBase, Orb::IFromRaw<Item>
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

    public required Generic::List<ItemProperties::ExternalConnection> ExternalConnections
    {
        get
        {
            if (!this.Properties.TryGetValue("external_connections", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "external_connections",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<ItemProperties::ExternalConnection>>(
                    element
                ) ?? throw new System::ArgumentNullException("external_connections");
        }
        set
        {
            this.Properties["external_connections"] = Json::JsonSerializer.SerializeToElement(
                value
            );
        }
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

    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        foreach (var item in this.ExternalConnections)
        {
            item.Validate();
        }
        foreach (var item in this.Metadata.Values)
        {
            _ = item;
        }
        _ = this.Name;
    }

    public Item() { }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    Item(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Item FromRawUnchecked(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        return new(properties);
    }
}
