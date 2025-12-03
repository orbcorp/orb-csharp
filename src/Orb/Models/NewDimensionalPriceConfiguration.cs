using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

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
        get { return ModelBase.GetNotNullClass<List<string>>(this.RawData, "dimension_values"); }
        init { ModelBase.Set(this._rawData, "dimension_values", value); }
    }

    /// <summary>
    /// The id of the dimensional price group to include this price in
    /// </summary>
    public string? DimensionalPriceGroupID
    {
        get
        {
            return ModelBase.GetNullableClass<string>(this.RawData, "dimensional_price_group_id");
        }
        init { ModelBase.Set(this._rawData, "dimensional_price_group_id", value); }
    }

    /// <summary>
    /// The external id of the dimensional price group to include this price in
    /// </summary>
    public string? ExternalDimensionalPriceGroupID
    {
        get
        {
            return ModelBase.GetNullableClass<string>(
                this.RawData,
                "external_dimensional_price_group_id"
            );
        }
        init { ModelBase.Set(this._rawData, "external_dimensional_price_group_id", value); }
    }

    /// <inheritdoc/>
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

class NewDimensionalPriceConfigurationFromRaw : IFromRaw<NewDimensionalPriceConfiguration>
{
    /// <inheritdoc/>
    public NewDimensionalPriceConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewDimensionalPriceConfiguration.FromRawUnchecked(rawData);
}
