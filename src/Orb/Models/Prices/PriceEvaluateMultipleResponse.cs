using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.Prices;

[JsonConverter(typeof(ModelConverter<PriceEvaluateMultipleResponse>))]
public sealed record class PriceEvaluateMultipleResponse
    : ModelBase,
        IFromRaw<PriceEvaluateMultipleResponse>
{
    public required List<Data> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'data' cannot be null",
                    new ArgumentOutOfRangeException("data", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Data>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'data' cannot be null",
                    new ArgumentNullException("data")
                );
        }
        set
        {
            this.Properties["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public PriceEvaluateMultipleResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluateMultipleResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PriceEvaluateMultipleResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public PriceEvaluateMultipleResponse(List<Data> data)
        : this()
    {
        this.Data = data;
    }
}

[JsonConverter(typeof(ModelConverter<Data>))]
public sealed record class Data : ModelBase, IFromRaw<Data>
{
    /// <summary>
    /// The currency of the price
    /// </summary>
    public required string Currency
    {
        get
        {
            if (!this.Properties.TryGetValue("currency", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new ArgumentNullException("currency")
                );
        }
        set
        {
            this.Properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The computed price groups associated with input price.
    /// </summary>
    public required List<EvaluatePriceGroup> PriceGroups
    {
        get
        {
            if (!this.Properties.TryGetValue("price_groups", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'price_groups' cannot be null",
                    new ArgumentOutOfRangeException("price_groups", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<EvaluatePriceGroup>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'price_groups' cannot be null",
                    new ArgumentNullException("price_groups")
                );
        }
        set
        {
            this.Properties["price_groups"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The external ID of the price
    /// </summary>
    public string? ExternalPriceID
    {
        get
        {
            if (!this.Properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["external_price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The index of the inline price
    /// </summary>
    public long? InlinePriceIndex
    {
        get
        {
            if (!this.Properties.TryGetValue("inline_price_index", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["inline_price_index"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The ID of the price
    /// </summary>
    public string? PriceID
    {
        get
        {
            if (!this.Properties.TryGetValue("price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["price_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Currency;
        foreach (var item in this.PriceGroups)
        {
            item.Validate();
        }
        _ = this.ExternalPriceID;
        _ = this.InlinePriceIndex;
        _ = this.PriceID;
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
