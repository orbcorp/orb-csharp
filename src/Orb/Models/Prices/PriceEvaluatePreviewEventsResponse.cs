using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models.Prices;

[JsonConverter(typeof(ModelConverter<PriceEvaluatePreviewEventsResponse>))]
public sealed record class PriceEvaluatePreviewEventsResponse
    : ModelBase,
        IFromRaw<PriceEvaluatePreviewEventsResponse>
{
    public required List<DataModel> Data
    {
        get
        {
            if (!this._properties.TryGetValue("data", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'data' cannot be null",
                    new ArgumentOutOfRangeException("data", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<DataModel>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'data' cannot be null",
                    new ArgumentNullException("data")
                );
        }
        init
        {
            this._properties["data"] = JsonSerializer.SerializeToElement(
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

    public PriceEvaluatePreviewEventsResponse() { }

    public PriceEvaluatePreviewEventsResponse(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PriceEvaluatePreviewEventsResponse(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static PriceEvaluatePreviewEventsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public PriceEvaluatePreviewEventsResponse(List<DataModel> data)
        : this()
    {
        this.Data = data;
    }
}

[JsonConverter(typeof(ModelConverter<DataModel>))]
public sealed record class DataModel : ModelBase, IFromRaw<DataModel>
{
    /// <summary>
    /// The currency of the price
    /// </summary>
    public required string Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
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
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("price_groups", out JsonElement element))
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
        init
        {
            this._properties["price_groups"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("external_price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["external_price_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("inline_price_index", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["inline_price_index"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("price_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["price_id"] = JsonSerializer.SerializeToElement(
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

    public DataModel() { }

    public DataModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static DataModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
