using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(
    typeof(JsonModelConverter<
        NewDimensionalPriceConfiguration,
        NewDimensionalPriceConfigurationFromRaw
    >)
)]
public sealed record class NewDimensionalPriceConfiguration : JsonModel
{
    /// <summary>
    /// The list of dimension values matching (in order) the dimensions of the price group
    /// </summary>
    public required IReadOnlyList<string> DimensionValues
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("dimension_values");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "dimension_values",
                ImmutableArray.ToImmutableArray(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("dimensional_price_group_id");
        }
        init { this._rawData.Set("dimensional_price_group_id", value); }
    }

    /// <summary>
    /// The external id of the dimensional price group to include this price in
    /// </summary>
    public string? ExternalDimensionalPriceGroupID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_dimensional_price_group_id");
        }
        init { this._rawData.Set("external_dimensional_price_group_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DimensionValues;
        _ = this.DimensionalPriceGroupID;
        _ = this.ExternalDimensionalPriceGroupID;
    }

    public NewDimensionalPriceConfiguration() { }

    public NewDimensionalPriceConfiguration(
        NewDimensionalPriceConfiguration newDimensionalPriceConfiguration
    )
        : base(newDimensionalPriceConfiguration) { }

    public NewDimensionalPriceConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewDimensionalPriceConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewDimensionalPriceConfigurationFromRaw.FromRawUnchecked"/>
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

class NewDimensionalPriceConfigurationFromRaw : IFromRawJson<NewDimensionalPriceConfiguration>
{
    /// <inheritdoc/>
    public NewDimensionalPriceConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewDimensionalPriceConfiguration.FromRawUnchecked(rawData);
}
