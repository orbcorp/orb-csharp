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
    public required IReadOnlyList<Filter1> Filters
    {
        get { return ModelBase.GetNotNullClass<List<Filter1>>(this.RawData, "filters"); }
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

    public static AmountDiscountInterval FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AmountDiscountIntervalFromRaw : IFromRaw<AmountDiscountInterval>
{
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

[JsonConverter(typeof(ModelConverter<Filter1, Filter1FromRaw>))]
public sealed record class Filter1 : ModelBase
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, Filter1Field> Field
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Filter1Field>>(this.RawData, "field");
        }
        init { ModelBase.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, Filter1Operator> Operator
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Filter1Operator>>(
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

    public override void Validate()
    {
        this.Field.Validate();
        this.Operator.Validate();
        _ = this.Values;
    }

    public Filter1() { }

    public Filter1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Filter1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Filter1FromRaw : IFromRaw<Filter1>
{
    public Filter1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Filter1.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(Filter1FieldConverter))]
public enum Filter1Field
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class Filter1FieldConverter : JsonConverter<Filter1Field>
{
    public override Filter1Field Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => Filter1Field.PriceID,
            "item_id" => Filter1Field.ItemID,
            "price_type" => Filter1Field.PriceType,
            "currency" => Filter1Field.Currency,
            "pricing_unit_id" => Filter1Field.PricingUnitID,
            _ => (Filter1Field)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter1Field value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter1Field.PriceID => "price_id",
                Filter1Field.ItemID => "item_id",
                Filter1Field.PriceType => "price_type",
                Filter1Field.Currency => "currency",
                Filter1Field.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(Filter1OperatorConverter))]
public enum Filter1Operator
{
    Includes,
    Excludes,
}

sealed class Filter1OperatorConverter : JsonConverter<Filter1Operator>
{
    public override Filter1Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => Filter1Operator.Includes,
            "excludes" => Filter1Operator.Excludes,
            _ => (Filter1Operator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter1Operator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter1Operator.Includes => "includes",
                Filter1Operator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
