using System.Collections.Frozen;
using System.Collections.Generic;
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
        get { return JsonModel.GetNotNullClass<List<string>>(this.RawData, "dimension_values"); }
        init { JsonModel.Set(this._rawData, "dimension_values", value); }
    }

    public required string DimensionalPriceGroupID
    {
        get
        {
            return JsonModel.GetNotNullClass<string>(this.RawData, "dimensional_price_group_id");
        }
        init { JsonModel.Set(this._rawData, "dimensional_price_group_id", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DimensionalPriceConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
