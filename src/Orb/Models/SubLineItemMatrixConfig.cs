using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<SubLineItemMatrixConfig, SubLineItemMatrixConfigFromRaw>))]
public sealed record class SubLineItemMatrixConfig : ModelBase
{
    /// <summary>
    /// The ordered dimension values for this line item.
    /// </summary>
    public required IReadOnlyList<string?> DimensionValues
    {
        get { return ModelBase.GetNotNullClass<List<string?>>(this.RawData, "dimension_values"); }
        init { ModelBase.Set(this._rawData, "dimension_values", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DimensionValues;
    }

    public SubLineItemMatrixConfig() { }

    public SubLineItemMatrixConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubLineItemMatrixConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
    public SubLineItemMatrixConfig(List<string?> dimensionValues)
        : this()
    {
        this.DimensionValues = dimensionValues;
    }
}

class SubLineItemMatrixConfigFromRaw : IFromRaw<SubLineItemMatrixConfig>
{
    /// <inheritdoc/>
    public SubLineItemMatrixConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubLineItemMatrixConfig.FromRawUnchecked(rawData);
}
