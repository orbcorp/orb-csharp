using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;

namespace Orb.Models;

[JsonConverter(
    typeof(ModelConverter<
        NewDimensionalPriceConfiguration,
        NewDimensionalPriceConfigurationFromRaw
    >)
)]
public sealed record class NewDimensionalPriceConfiguration : ModelBase
{
    /// <summary>
    /// The list of dimension values matching (in order) the dimensions of the price group
    /// </summary>
    public required IReadOnlyList<string> DimensionValues
    {
        get
        {
            if (!this._rawData.TryGetValue("dimension_values", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'dimension_values' cannot be null",
                    new ArgumentOutOfRangeException("dimension_values", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'dimension_values' cannot be null",
                    new ArgumentNullException("dimension_values")
                );
        }
        init
        {
            this._rawData["dimension_values"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the dimensional price group to include this price in
    /// </summary>
    public string? DimensionalPriceGroupID
    {
        get
        {
            if (!this._rawData.TryGetValue("dimensional_price_group_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["dimensional_price_group_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The external id of the dimensional price group to include this price in
    /// </summary>
    public string? ExternalDimensionalPriceGroupID
    {
        get
        {
            if (
                !this._rawData.TryGetValue(
                    "external_dimensional_price_group_id",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["external_dimensional_price_group_id"] =
                JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions);
        }
    }

    public override void Validate()
    {
        _ = this.DimensionValues;
        _ = this.DimensionalPriceGroupID;
        _ = this.ExternalDimensionalPriceGroupID;
    }

    public NewDimensionalPriceConfiguration() { }

    public NewDimensionalPriceConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewDimensionalPriceConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static NewDimensionalPriceConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public NewDimensionalPriceConfiguration(List<string> dimensionValues)
        : this()
    {
        this.DimensionValues = dimensionValues;
    }
}

class NewDimensionalPriceConfigurationFromRaw : IFromRaw<NewDimensionalPriceConfiguration>
{
    public NewDimensionalPriceConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewDimensionalPriceConfiguration.FromRawUnchecked(rawData);
}
