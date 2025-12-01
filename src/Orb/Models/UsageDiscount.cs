using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<UsageDiscount, UsageDiscountFromRaw>))]
public sealed record class UsageDiscount : ModelBase
{
    public required ApiEnum<string, UsageDiscountDiscountType> DiscountType
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, UsageDiscountDiscountType>>(
                this.RawData,
                "discount_type"
            );
        }
        init { ModelBase.Set(this._rawData, "discount_type", value); }
    }

    /// <summary>
    /// Only available if discount_type is `usage`. Number of usage units that this
    /// discount is for
    /// </summary>
    public required double UsageDiscount1
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "usage_discount"); }
        init { ModelBase.Set(this._rawData, "usage_discount", value); }
    }

    /// <summary>
    /// List of price_ids that this discount applies to. For plan/plan phase discounts,
    /// this can be a subset of prices.
    /// </summary>
    public IReadOnlyList<string>? AppliesToPriceIDs
    {
        get
        {
            return ModelBase.GetNullableClass<List<string>>(this.RawData, "applies_to_price_ids");
        }
        init { ModelBase.Set(this._rawData, "applies_to_price_ids", value); }
    }

    /// <summary>
    /// The filters that determine which prices to apply this discount to.
    /// </summary>
    public IReadOnlyList<Filter26>? Filters
    {
        get { return ModelBase.GetNullableClass<List<Filter26>>(this.RawData, "filters"); }
        init { ModelBase.Set(this._rawData, "filters", value); }
    }

    public string? Reason
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "reason"); }
        init { ModelBase.Set(this._rawData, "reason", value); }
    }

    public override void Validate()
    {
        this.DiscountType.Validate();
        _ = this.UsageDiscount1;
        _ = this.AppliesToPriceIDs;
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
        _ = this.Reason;
    }

    public UsageDiscount() { }

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

    public static UsageDiscount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageDiscountFromRaw : IFromRaw<UsageDiscount>
{
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

[JsonConverter(typeof(ModelConverter<Filter26, Filter26FromRaw>))]
public sealed record class Filter26 : ModelBase
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, Filter26Field> Field
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Filter26Field>>(this.RawData, "field");
        }
        init { ModelBase.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, Filter26Operator> Operator
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Filter26Operator>>(
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

    public Filter26() { }

    public Filter26(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter26(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Filter26 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Filter26FromRaw : IFromRaw<Filter26>
{
    public Filter26 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Filter26.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(Filter26FieldConverter))]
public enum Filter26Field
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class Filter26FieldConverter : JsonConverter<Filter26Field>
{
    public override Filter26Field Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => Filter26Field.PriceID,
            "item_id" => Filter26Field.ItemID,
            "price_type" => Filter26Field.PriceType,
            "currency" => Filter26Field.Currency,
            "pricing_unit_id" => Filter26Field.PricingUnitID,
            _ => (Filter26Field)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter26Field value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter26Field.PriceID => "price_id",
                Filter26Field.ItemID => "item_id",
                Filter26Field.PriceType => "price_type",
                Filter26Field.Currency => "currency",
                Filter26Field.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(Filter26OperatorConverter))]
public enum Filter26Operator
{
    Includes,
    Excludes,
}

sealed class Filter26OperatorConverter : JsonConverter<Filter26Operator>
{
    public override Filter26Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => Filter26Operator.Includes,
            "excludes" => Filter26Operator.Excludes,
            _ => (Filter26Operator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter26Operator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter26Operator.Includes => "includes",
                Filter26Operator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
