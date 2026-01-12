using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers.Credits.Ledger;

[JsonConverter(typeof(JsonModelConverter<AffectedBlock, AffectedBlockFromRaw>))]
public sealed record class AffectedBlock : JsonModel
{
    public required string ID
    {
        get { return this._rawData.GetNotNullClass<string>("id"); }
        init { this._rawData.Set("id", value); }
    }

    public required System::DateTimeOffset? ExpiryDate
    {
        get { return this._rawData.GetNullableStruct<System::DateTimeOffset>("expiry_date"); }
        init { this._rawData.Set("expiry_date", value); }
    }

    public required IReadOnlyList<AffectedBlockFilter> Filters
    {
        get
        {
            return this._rawData.GetNotNullStruct<ImmutableArray<AffectedBlockFilter>>("filters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AffectedBlockFilter>>(
                "filters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string? PerUnitCostBasis
    {
        get { return this._rawData.GetNullableClass<string>("per_unit_cost_basis"); }
        init { this._rawData.Set("per_unit_cost_basis", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ExpiryDate;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.PerUnitCostBasis;
    }

    public AffectedBlock() { }

    public AffectedBlock(AffectedBlock affectedBlock)
        : base(affectedBlock) { }

    public AffectedBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AffectedBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AffectedBlockFromRaw.FromRawUnchecked"/>
    public static AffectedBlock FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AffectedBlockFromRaw : IFromRawJson<AffectedBlock>
{
    /// <inheritdoc/>
    public AffectedBlock FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AffectedBlock.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<AffectedBlockFilter, AffectedBlockFilterFromRaw>))]
public sealed record class AffectedBlockFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, AffectedBlockFilterField> Field
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, AffectedBlockFilterField>>(
                "field"
            );
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, AffectedBlockFilterOperator> Operator
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, AffectedBlockFilterOperator>>(
                "operator"
            );
        }
        init { this._rawData.Set("operator", value); }
    }

    /// <summary>
    /// The IDs or values that match this filter.
    /// </summary>
    public required IReadOnlyList<string> Values
    {
        get { return this._rawData.GetNotNullStruct<ImmutableArray<string>>("values"); }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "values",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Field.Validate();
        this.Operator.Validate();
        _ = this.Values;
    }

    public AffectedBlockFilter() { }

    public AffectedBlockFilter(AffectedBlockFilter affectedBlockFilter)
        : base(affectedBlockFilter) { }

    public AffectedBlockFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AffectedBlockFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AffectedBlockFilterFromRaw.FromRawUnchecked"/>
    public static AffectedBlockFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AffectedBlockFilterFromRaw : IFromRawJson<AffectedBlockFilter>
{
    /// <inheritdoc/>
    public AffectedBlockFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AffectedBlockFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(AffectedBlockFilterFieldConverter))]
public enum AffectedBlockFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class AffectedBlockFilterFieldConverter : JsonConverter<AffectedBlockFilterField>
{
    public override AffectedBlockFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => AffectedBlockFilterField.PriceID,
            "item_id" => AffectedBlockFilterField.ItemID,
            "price_type" => AffectedBlockFilterField.PriceType,
            "currency" => AffectedBlockFilterField.Currency,
            "pricing_unit_id" => AffectedBlockFilterField.PricingUnitID,
            _ => (AffectedBlockFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AffectedBlockFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AffectedBlockFilterField.PriceID => "price_id",
                AffectedBlockFilterField.ItemID => "item_id",
                AffectedBlockFilterField.PriceType => "price_type",
                AffectedBlockFilterField.Currency => "currency",
                AffectedBlockFilterField.PricingUnitID => "pricing_unit_id",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Should prices that match the filter be included or excluded.
/// </summary>
[JsonConverter(typeof(AffectedBlockFilterOperatorConverter))]
public enum AffectedBlockFilterOperator
{
    Includes,
    Excludes,
}

sealed class AffectedBlockFilterOperatorConverter : JsonConverter<AffectedBlockFilterOperator>
{
    public override AffectedBlockFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => AffectedBlockFilterOperator.Includes,
            "excludes" => AffectedBlockFilterOperator.Excludes,
            _ => (AffectedBlockFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AffectedBlockFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AffectedBlockFilterOperator.Includes => "includes",
                AffectedBlockFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
