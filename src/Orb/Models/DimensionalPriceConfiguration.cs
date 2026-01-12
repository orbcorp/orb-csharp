using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(
    typeof(JsonModelConverter<DimensionalPriceConfiguration, DimensionalPriceConfigurationFromRaw>)
)]
public sealed record class DimensionalPriceConfiguration : JsonModel
{
    public required IReadOnlyList<string> DimensionValues
    {
        get { return this._rawData.GetNotNullStruct<ImmutableArray<string>>("dimension_values"); }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "dimension_values",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string DimensionalPriceGroupID
    {
        get { return this._rawData.GetNotNullClass<string>("dimensional_price_group_id"); }
        init { this._rawData.Set("dimensional_price_group_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DimensionValues;
        _ = this.DimensionalPriceGroupID;
    }

    public DimensionalPriceConfiguration() { }

    public DimensionalPriceConfiguration(
        DimensionalPriceConfiguration dimensionalPriceConfiguration
    )
        : base(dimensionalPriceConfiguration) { }

    public DimensionalPriceConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DimensionalPriceConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DimensionalPriceConfigurationFromRaw.FromRawUnchecked"/>
    public static DimensionalPriceConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DimensionalPriceConfigurationFromRaw : IFromRawJson<DimensionalPriceConfiguration>
{
    /// <inheritdoc/>
    public DimensionalPriceConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DimensionalPriceConfiguration.FromRawUnchecked(rawData);
}
