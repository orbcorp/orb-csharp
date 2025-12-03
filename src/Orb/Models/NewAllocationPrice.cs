using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<NewAllocationPrice, NewAllocationPriceFromRaw>))]
public sealed record class NewAllocationPrice : ModelBase
{
    /// <summary>
    /// An amount of the currency to allocate to the customer at the specified cadence.
    /// </summary>
    public required string Amount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "amount"); }
        init { ModelBase.Set(this._rawData, "amount", value); }
    }

    /// <summary>
    /// The cadence at which to allocate the amount to the customer.
    /// </summary>
    public required ApiEnum<string, Cadence> Cadence
    {
        get { return ModelBase.GetNotNullClass<ApiEnum<string, Cadence>>(this.RawData, "cadence"); }
        init { ModelBase.Set(this._rawData, "cadence", value); }
    }

    /// <summary>
    /// An ISO 4217 currency string or a custom pricing unit identifier in which to
    /// bill this price.
    /// </summary>
    public required string Currency
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// The custom expiration for the allocation.
    /// </summary>
    public CustomExpiration? CustomExpiration
    {
        get
        {
            return ModelBase.GetNullableClass<CustomExpiration>(this.RawData, "custom_expiration");
        }
        init { ModelBase.Set(this._rawData, "custom_expiration", value); }
    }

    /// <summary>
    /// Whether the allocated amount should expire at the end of the cadence or roll
    /// over to the next period. Set to null if using custom_expiration.
    /// </summary>
    public bool? ExpiresAtEndOfCadence
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "expires_at_end_of_cadence"); }
        init { ModelBase.Set(this._rawData, "expires_at_end_of_cadence", value); }
    }

    /// <summary>
    /// The filters that determine which items the allocation applies to.
    /// </summary>
    public IReadOnlyList<NewAllocationPriceFilter>? Filters
    {
        get
        {
            return ModelBase.GetNullableClass<List<NewAllocationPriceFilter>>(
                this.RawData,
                "filters"
            );
        }
        init { ModelBase.Set(this._rawData, "filters", value); }
    }

    /// <summary>
    /// The item ID that line items representing charges for this allocation will
    /// be associated with. If not provided, the default allocation item for the
    /// currency will be used (e.g. 'Included Allocation (USD)').
    /// </summary>
    public string? ItemID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "item_id"); }
        init { ModelBase.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// The (per-unit) cost basis of each created block. If non-zero, a customer
    /// will be invoiced according to the quantity and per unit cost basis specified
    /// for the allocation each cadence.
    /// </summary>
    public string? PerUnitCostBasis
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "per_unit_cost_basis"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "per_unit_cost_basis", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Cadence.Validate();
        _ = this.Currency;
        this.CustomExpiration?.Validate();
        _ = this.ExpiresAtEndOfCadence;
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
        _ = this.ItemID;
        _ = this.PerUnitCostBasis;
    }

    public NewAllocationPrice() { }

    public NewAllocationPrice(NewAllocationPrice newAllocationPrice)
        : base(newAllocationPrice) { }

    public NewAllocationPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewAllocationPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewAllocationPriceFromRaw.FromRawUnchecked"/>
    public static NewAllocationPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewAllocationPriceFromRaw : IFromRaw<NewAllocationPrice>
{
    /// <inheritdoc/>
    public NewAllocationPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NewAllocationPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence at which to allocate the amount to the customer.
/// </summary>
[JsonConverter(typeof(CadenceConverter))]
public enum Cadence
{
    OneTime,
    Monthly,
    Quarterly,
    SemiAnnual,
    Annual,
}

sealed class CadenceConverter : JsonConverter<Cadence>
{
    public override Cadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "one_time" => Cadence.OneTime,
            "monthly" => Cadence.Monthly,
            "quarterly" => Cadence.Quarterly,
            "semi_annual" => Cadence.SemiAnnual,
            "annual" => Cadence.Annual,
            _ => (Cadence)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Cadence value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Cadence.OneTime => "one_time",
                Cadence.Monthly => "monthly",
                Cadence.Quarterly => "quarterly",
                Cadence.SemiAnnual => "semi_annual",
                Cadence.Annual => "annual",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A PriceFilter that only allows item_id field for block filters.
/// </summary>
[JsonConverter(typeof(ModelConverter<NewAllocationPriceFilter, NewAllocationPriceFilterFromRaw>))]
public sealed record class NewAllocationPriceFilter : ModelBase
{
    /// <summary>
    /// The property of the price the block applies to. Only item_id is supported.
    /// </summary>
    public required ApiEnum<string, NewAllocationPriceFilterField> Field
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, NewAllocationPriceFilterField>>(
                this.RawData,
                "field"
            );
        }
        init { ModelBase.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, NewAllocationPriceFilterOperator> Operator
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, NewAllocationPriceFilterOperator>>(
                this.RawData,
                "operator"
            );
        }
        init { ModelBase.Set(this._rawData, "operator", value); }
    }

    /// <summary>
    /// The IDs or values that match this filter.
    /// </summary>
    public required IReadOnlyList<string> Values
    {
        get { return ModelBase.GetNotNullClass<List<string>>(this.RawData, "values"); }
        init { ModelBase.Set(this._rawData, "values", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Field.Validate();
        this.Operator.Validate();
        _ = this.Values;
    }

    public NewAllocationPriceFilter() { }

    public NewAllocationPriceFilter(NewAllocationPriceFilter newAllocationPriceFilter)
        : base(newAllocationPriceFilter) { }

    public NewAllocationPriceFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewAllocationPriceFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewAllocationPriceFilterFromRaw.FromRawUnchecked"/>
    public static NewAllocationPriceFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewAllocationPriceFilterFromRaw : IFromRaw<NewAllocationPriceFilter>
{
    /// <inheritdoc/>
    public NewAllocationPriceFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewAllocationPriceFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price the block applies to. Only item_id is supported.
/// </summary>
[JsonConverter(typeof(NewAllocationPriceFilterFieldConverter))]
public enum NewAllocationPriceFilterField
{
    ItemID,
}

sealed class NewAllocationPriceFilterFieldConverter : JsonConverter<NewAllocationPriceFilterField>
{
    public override NewAllocationPriceFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "item_id" => NewAllocationPriceFilterField.ItemID,
            _ => (NewAllocationPriceFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewAllocationPriceFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewAllocationPriceFilterField.ItemID => "item_id",
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
[JsonConverter(typeof(NewAllocationPriceFilterOperatorConverter))]
public enum NewAllocationPriceFilterOperator
{
    Includes,
    Excludes,
}

sealed class NewAllocationPriceFilterOperatorConverter
    : JsonConverter<NewAllocationPriceFilterOperator>
{
    public override NewAllocationPriceFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => NewAllocationPriceFilterOperator.Includes,
            "excludes" => NewAllocationPriceFilterOperator.Excludes,
            _ => (NewAllocationPriceFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewAllocationPriceFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewAllocationPriceFilterOperator.Includes => "includes",
                NewAllocationPriceFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
