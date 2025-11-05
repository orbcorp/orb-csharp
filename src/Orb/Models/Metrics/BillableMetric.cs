using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Items;
using System = System;

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
                throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? Description
    {
        get
        {
            if (!this.Properties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The Item resource represents a sellable product or good. Items are associated
    /// with all line items, billable metrics, and prices and are used for defining
    /// external sync behavior for invoices and tax calculation purposes.
    /// </summary>
    public required Item Item
    {
        get
        {
            if (!this.Properties.TryGetValue("item", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item' cannot be null",
                    new System::ArgumentOutOfRangeException("item", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Item>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item' cannot be null",
                    new System::ArgumentNullException("item")
                );
        }
        set
        {
            this.Properties["item"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
                throw new OrbInvalidDataException(
                    "'metadata' cannot be null",
                    new System::ArgumentOutOfRangeException("metadata", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, string>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'metadata' cannot be null",
                    new System::ArgumentNullException("metadata")
                );
        }
        set
        {
            this.Properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, global::Orb.Models.Metrics.Status> Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'status' cannot be null",
                    new System::ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, global::Orb.Models.Metrics.Status>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Description;
        this.Item.Validate();
        _ = this.Metadata;
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

[JsonConverter(typeof(global::Orb.Models.Metrics.StatusConverter))]
public enum Status
{
    Active,
    Draft,
    Archived,
}

sealed class StatusConverter : JsonConverter<global::Orb.Models.Metrics.Status>
{
    public override global::Orb.Models.Metrics.Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => global::Orb.Models.Metrics.Status.Active,
            "draft" => global::Orb.Models.Metrics.Status.Draft,
            "archived" => global::Orb.Models.Metrics.Status.Archived,
            _ => (global::Orb.Models.Metrics.Status)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Metrics.Status value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Metrics.Status.Active => "active",
                global::Orb.Models.Metrics.Status.Draft => "draft",
                global::Orb.Models.Metrics.Status.Archived => "archived",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
