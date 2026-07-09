using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(JsonModelConverter<Allocation, AllocationFromRaw>))]
public sealed record class Allocation : JsonModel
{
    public required bool AllowsRollover
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("allows_rollover");
        }
        init { this._rawData.Set("allows_rollover", value); }
    }

    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    public required CustomExpiration? CustomExpiration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomExpiration>("custom_expiration");
        }
        init { this._rawData.Set("custom_expiration", value); }
    }

    public IReadOnlyList<AllocationFilter>? Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AllocationFilter>>("filters");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<AllocationFilter>?>(
                "filters",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? LicenseTypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license_type_id");
        }
        init { this._rawData.Set("license_type_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AllowsRollover;
        _ = this.Currency;
        this.CustomExpiration?.Validate();
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
        _ = this.LicenseTypeID;
    }

    public Allocation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Allocation(Allocation allocation)
        : base(allocation) { }
#pragma warning restore CS8618

    public Allocation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Allocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AllocationFromRaw.FromRawUnchecked"/>
    public static Allocation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AllocationFromRaw : IFromRawJson<Allocation>
{
    /// <inheritdoc/>
    public Allocation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Allocation.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<AllocationFilter, AllocationFilterFromRaw>))]
public sealed record class AllocationFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, AllocationFilterField> Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AllocationFilterField>>("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, AllocationFilterOperator> Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AllocationFilterOperator>>(
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("values");
        }
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

    public AllocationFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AllocationFilter(AllocationFilter allocationFilter)
        : base(allocationFilter) { }
#pragma warning restore CS8618

    public AllocationFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AllocationFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AllocationFilterFromRaw.FromRawUnchecked"/>
    public static AllocationFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AllocationFilterFromRaw : IFromRawJson<AllocationFilter>
{
    /// <inheritdoc/>
    public AllocationFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AllocationFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(AllocationFilterFieldConverter))]
public enum AllocationFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class AllocationFilterFieldConverter : JsonConverter<AllocationFilterField>
{
    public override AllocationFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => AllocationFilterField.PriceID,
            "item_id" => AllocationFilterField.ItemID,
            "price_type" => AllocationFilterField.PriceType,
            "currency" => AllocationFilterField.Currency,
            "pricing_unit_id" => AllocationFilterField.PricingUnitID,
            _ => (AllocationFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AllocationFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AllocationFilterField.PriceID => "price_id",
                AllocationFilterField.ItemID => "item_id",
                AllocationFilterField.PriceType => "price_type",
                AllocationFilterField.Currency => "currency",
                AllocationFilterField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(AllocationFilterOperatorConverter))]
public enum AllocationFilterOperator
{
    Includes,
    Excludes,
}

sealed class AllocationFilterOperatorConverter : JsonConverter<AllocationFilterOperator>
{
    public override AllocationFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => AllocationFilterOperator.Includes,
            "excludes" => AllocationFilterOperator.Excludes,
            _ => (AllocationFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AllocationFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AllocationFilterOperator.Includes => "includes",
                AllocationFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
