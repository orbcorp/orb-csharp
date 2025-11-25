using System.Collections.Frozen;
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
[JsonConverter(typeof(ModelConverter<BillableMetric, BillableMetricFromRaw>))]
public sealed record class BillableMetric : ModelBase
{
    public required string ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
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
        init
        {
            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? Description
    {
        get
        {
            if (!this._rawData.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["description"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("item", out JsonElement element))
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
        init
        {
            this._rawData["item"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("metadata", out JsonElement element))
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
        init
        {
            this._rawData["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Name
    {
        get
        {
            if (!this._rawData.TryGetValue("name", out JsonElement element))
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
        init
        {
            this._rawData["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, global::Orb.Models.Metrics.Status> Status
    {
        get
        {
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'status' cannot be null",
                    new System::ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, global::Orb.Models.Metrics.Status>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["status"] = JsonSerializer.SerializeToElement(
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

    public BillableMetric(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillableMetric(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BillableMetric FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BillableMetricFromRaw : IFromRaw<BillableMetric>
{
    public BillableMetric FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BillableMetric.FromRawUnchecked(rawData);
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
