using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(JsonModelConverter<UsageDiscount, UsageDiscountFromRaw>))]
public sealed record class UsageDiscount : JsonModel
{
    public required ApiEnum<string, UsageDiscountDiscountType> DiscountType
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, UsageDiscountDiscountType>>(
                this.RawData,
                "discount_type"
            );
        }
        init { JsonModel.Set(this._rawData, "discount_type", value); }
    }

    /// <summary>
    /// Only available if discount_type is `usage`. Number of usage units that this
    /// discount is for
    /// </summary>
    public required double UsageDiscountValue
    {
        get { return JsonModel.GetNotNullStruct<double>(this.RawData, "usage_discount"); }
        init { JsonModel.Set(this._rawData, "usage_discount", value); }
    }

    /// <summary>
    /// List of price_ids that this discount applies to. For plan/plan phase discounts,
    /// this can be a subset of prices.
    /// </summary>
    public IReadOnlyList<string>? AppliesToPriceIds
    {
        get
        {
            return JsonModel.GetNullableClass<List<string>>(this.RawData, "applies_to_price_ids");
        }
        init { JsonModel.Set(this._rawData, "applies_to_price_ids", value); }
    }

    /// <summary>
    /// The filters that determine which prices to apply this discount to.
    /// </summary>
    public IReadOnlyList<UsageDiscountFilter>? Filters
    {
        get
        {
            return JsonModel.GetNullableClass<List<UsageDiscountFilter>>(this.RawData, "filters");
        }
        init { JsonModel.Set(this._rawData, "filters", value); }
    }

    public string? Reason
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "reason"); }
        init { JsonModel.Set(this._rawData, "reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.DiscountType.Validate();
        _ = this.UsageDiscountValue;
        _ = this.AppliesToPriceIds;
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
        _ = this.Reason;
    }

    public UsageDiscount() { }

    public UsageDiscount(UsageDiscount usageDiscount)
        : base(usageDiscount) { }

    public UsageDiscount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageDiscount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageDiscountFromRaw.FromRawUnchecked"/>
    public static UsageDiscount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageDiscountFromRaw : IFromRawJson<UsageDiscount>
{
    /// <inheritdoc/>
    public UsageDiscount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UsageDiscount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UsageDiscountDiscountTypeConverter))]
public enum UsageDiscountDiscountType
{
    Usage,
}

sealed class UsageDiscountDiscountTypeConverter : JsonConverter<UsageDiscountDiscountType>
{
    public override UsageDiscountDiscountType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usage" => UsageDiscountDiscountType.Usage,
            _ => (UsageDiscountDiscountType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UsageDiscountDiscountType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UsageDiscountDiscountType.Usage => "usage",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<UsageDiscountFilter, UsageDiscountFilterFromRaw>))]
public sealed record class UsageDiscountFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, UsageDiscountFilterField> Field
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, UsageDiscountFilterField>>(
                this.RawData,
                "field"
            );
        }
        init { JsonModel.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, UsageDiscountFilterOperator> Operator
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, UsageDiscountFilterOperator>>(
                this.RawData,
                "operator"
            );
        }
        init { JsonModel.Set(this._rawData, "operator", value); }
    }

    /// <summary>
    /// The IDs or values that match this filter.
    /// </summary>
    public required IReadOnlyList<string> Values
    {
        get { return JsonModel.GetNotNullClass<List<string>>(this.RawData, "values"); }
        init { JsonModel.Set(this._rawData, "values", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Field.Validate();
        this.Operator.Validate();
        _ = this.Values;
    }

    public UsageDiscountFilter() { }

    public UsageDiscountFilter(UsageDiscountFilter usageDiscountFilter)
        : base(usageDiscountFilter) { }

    public UsageDiscountFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageDiscountFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageDiscountFilterFromRaw.FromRawUnchecked"/>
    public static UsageDiscountFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageDiscountFilterFromRaw : IFromRawJson<UsageDiscountFilter>
{
    /// <inheritdoc/>
    public UsageDiscountFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UsageDiscountFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(UsageDiscountFilterFieldConverter))]
public enum UsageDiscountFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class UsageDiscountFilterFieldConverter : JsonConverter<UsageDiscountFilterField>
{
    public override UsageDiscountFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => UsageDiscountFilterField.PriceID,
            "item_id" => UsageDiscountFilterField.ItemID,
            "price_type" => UsageDiscountFilterField.PriceType,
            "currency" => UsageDiscountFilterField.Currency,
            "pricing_unit_id" => UsageDiscountFilterField.PricingUnitID,
            _ => (UsageDiscountFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UsageDiscountFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UsageDiscountFilterField.PriceID => "price_id",
                UsageDiscountFilterField.ItemID => "item_id",
                UsageDiscountFilterField.PriceType => "price_type",
                UsageDiscountFilterField.Currency => "currency",
                UsageDiscountFilterField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(UsageDiscountFilterOperatorConverter))]
public enum UsageDiscountFilterOperator
{
    Includes,
    Excludes,
}

sealed class UsageDiscountFilterOperatorConverter : JsonConverter<UsageDiscountFilterOperator>
{
    public override UsageDiscountFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => UsageDiscountFilterOperator.Includes,
            "excludes" => UsageDiscountFilterOperator.Excludes,
            _ => (UsageDiscountFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UsageDiscountFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UsageDiscountFilterOperator.Includes => "includes",
                UsageDiscountFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
