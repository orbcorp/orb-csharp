using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<AmountDiscountInterval, AmountDiscountIntervalFromRaw>))]
public sealed record class AmountDiscountInterval : ModelBase
{
    /// <summary>
    /// Only available if discount_type is `amount`.
    /// </summary>
    public required string AmountDiscount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "amount_discount"); }
        init { ModelBase.Set(this._rawData, "amount_discount", value); }
    }

    /// <summary>
    /// The price interval ids that this discount interval applies to.
    /// </summary>
    public required IReadOnlyList<string> AppliesToPriceIntervalIDs
    {
        get
        {
            return ModelBase.GetNotNullClass<List<string>>(
                this.RawData,
                "applies_to_price_interval_ids"
            );
        }
        init { ModelBase.Set(this._rawData, "applies_to_price_interval_ids", value); }
    }

    public required ApiEnum<string, AmountDiscountIntervalDiscountType> DiscountType
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, AmountDiscountIntervalDiscountType>>(
                this.RawData,
                "discount_type"
            );
        }
        init { ModelBase.Set(this._rawData, "discount_type", value); }
    }

    /// <summary>
    /// The end date of the discount interval.
    /// </summary>
    public required System::DateTimeOffset? EndDate
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(this.RawData, "end_date");
        }
        init { ModelBase.Set(this._rawData, "end_date", value); }
    }

    /// <summary>
    /// The filters that determine which prices this discount interval applies to.
    /// </summary>
    public required IReadOnlyList<AmountDiscountIntervalFilter> Filters
    {
        get
        {
            return ModelBase.GetNotNullClass<List<AmountDiscountIntervalFilter>>(
                this.RawData,
                "filters"
            );
        }
        init { ModelBase.Set(this._rawData, "filters", value); }
    }

    /// <summary>
    /// The start date of the discount interval.
    /// </summary>
    public required System::DateTimeOffset StartDate
    {
        get
        {
            return ModelBase.GetNotNullStruct<System::DateTimeOffset>(this.RawData, "start_date");
        }
        init { ModelBase.Set(this._rawData, "start_date", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AmountDiscount;
        _ = this.AppliesToPriceIntervalIDs;
        this.DiscountType.Validate();
        _ = this.EndDate;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.StartDate;
    }

    public AmountDiscountInterval() { }

    public AmountDiscountInterval(AmountDiscountInterval amountDiscountInterval)
        : base(amountDiscountInterval) { }

    public AmountDiscountInterval(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AmountDiscountInterval(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AmountDiscountIntervalFromRaw.FromRawUnchecked"/>
    public static AmountDiscountInterval FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AmountDiscountIntervalFromRaw : IFromRaw<AmountDiscountInterval>
{
    /// <inheritdoc/>
    public AmountDiscountInterval FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AmountDiscountInterval.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AmountDiscountIntervalDiscountTypeConverter))]
public enum AmountDiscountIntervalDiscountType
{
    Amount,
}

sealed class AmountDiscountIntervalDiscountTypeConverter
    : JsonConverter<AmountDiscountIntervalDiscountType>
{
    public override AmountDiscountIntervalDiscountType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "amount" => AmountDiscountIntervalDiscountType.Amount,
            _ => (AmountDiscountIntervalDiscountType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AmountDiscountIntervalDiscountType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AmountDiscountIntervalDiscountType.Amount => "amount",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(ModelConverter<AmountDiscountIntervalFilter, AmountDiscountIntervalFilterFromRaw>)
)]
public sealed record class AmountDiscountIntervalFilter : ModelBase
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, AmountDiscountIntervalFilterField> Field
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, AmountDiscountIntervalFilterField>>(
                this.RawData,
                "field"
            );
        }
        init { ModelBase.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, AmountDiscountIntervalFilterOperator> Operator
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, AmountDiscountIntervalFilterOperator>>(
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

    public AmountDiscountIntervalFilter() { }

    public AmountDiscountIntervalFilter(AmountDiscountIntervalFilter amountDiscountIntervalFilter)
        : base(amountDiscountIntervalFilter) { }

    public AmountDiscountIntervalFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AmountDiscountIntervalFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AmountDiscountIntervalFilterFromRaw.FromRawUnchecked"/>
    public static AmountDiscountIntervalFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AmountDiscountIntervalFilterFromRaw : IFromRaw<AmountDiscountIntervalFilter>
{
    /// <inheritdoc/>
    public AmountDiscountIntervalFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AmountDiscountIntervalFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(AmountDiscountIntervalFilterFieldConverter))]
public enum AmountDiscountIntervalFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class AmountDiscountIntervalFilterFieldConverter
    : JsonConverter<AmountDiscountIntervalFilterField>
{
    public override AmountDiscountIntervalFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => AmountDiscountIntervalFilterField.PriceID,
            "item_id" => AmountDiscountIntervalFilterField.ItemID,
            "price_type" => AmountDiscountIntervalFilterField.PriceType,
            "currency" => AmountDiscountIntervalFilterField.Currency,
            "pricing_unit_id" => AmountDiscountIntervalFilterField.PricingUnitID,
            _ => (AmountDiscountIntervalFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AmountDiscountIntervalFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AmountDiscountIntervalFilterField.PriceID => "price_id",
                AmountDiscountIntervalFilterField.ItemID => "item_id",
                AmountDiscountIntervalFilterField.PriceType => "price_type",
                AmountDiscountIntervalFilterField.Currency => "currency",
                AmountDiscountIntervalFilterField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(AmountDiscountIntervalFilterOperatorConverter))]
public enum AmountDiscountIntervalFilterOperator
{
    Includes,
    Excludes,
}

sealed class AmountDiscountIntervalFilterOperatorConverter
    : JsonConverter<AmountDiscountIntervalFilterOperator>
{
    public override AmountDiscountIntervalFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => AmountDiscountIntervalFilterOperator.Includes,
            "excludes" => AmountDiscountIntervalFilterOperator.Excludes,
            _ => (AmountDiscountIntervalFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AmountDiscountIntervalFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AmountDiscountIntervalFilterOperator.Includes => "includes",
                AmountDiscountIntervalFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
