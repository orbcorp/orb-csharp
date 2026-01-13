using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(typeof(JsonModelConverter<SubLineItemMatrixConfig, SubLineItemMatrixConfigFromRaw>))]
public sealed record class SubLineItemMatrixConfig : JsonModel
{
    /// <summary>
    /// The ordered dimension values for this line item.
    /// </summary>
    public required IReadOnlyList<string?> DimensionValues
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string?>>("dimension_values");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string?>>(
                "dimension_values",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DimensionValues;
    }

    public SubLineItemMatrixConfig() { }

    public SubLineItemMatrixConfig(SubLineItemMatrixConfig subLineItemMatrixConfig)
        : base(subLineItemMatrixConfig) { }

    public SubLineItemMatrixConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubLineItemMatrixConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubLineItemMatrixConfigFromRaw.FromRawUnchecked"/>
    public static SubLineItemMatrixConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubLineItemMatrixConfig(IReadOnlyList<string?> dimensionValues)
        : this()
    {
        this.DimensionValues = dimensionValues;
    }
}

class SubLineItemMatrixConfigFromRaw : IFromRawJson<SubLineItemMatrixConfig>
{
    /// <inheritdoc/>
    public SubLineItemMatrixConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubLineItemMatrixConfig.FromRawUnchecked(rawData);
}
