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

[JsonConverter(typeof(JsonModelConverter<NewUsageDiscount, NewUsageDiscountFromRaw>))]
public sealed record class NewUsageDiscount : JsonModel
{
    public required ApiEnum<string, NewUsageDiscountAdjustmentType> AdjustmentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, NewUsageDiscountAdjustmentType>>(
                "adjustment_type"
            );
        }
        init { this._rawData.Set("adjustment_type", value); }
    }

    public required double UsageDiscount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("usage_discount");
        }
        init { this._rawData.Set("usage_discount", value); }
    }

    /// <summary>
    /// If set, the adjustment will apply to every price on the subscription.
    /// </summary>
    public ApiEnum<bool, NewUsageDiscountAppliesToAll>? AppliesToAll
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<bool, NewUsageDiscountAppliesToAll>>(
                "applies_to_all"
            );
        }
        init { this._rawData.Set("applies_to_all", value); }
    }

    /// <summary>
    /// The set of item IDs to which this adjustment applies.
    /// </summary>
    public IReadOnlyList<string>? AppliesToItemIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("applies_to_item_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "applies_to_item_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The set of price IDs to which this adjustment applies.
    /// </summary>
    public IReadOnlyList<string>? AppliesToPriceIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("applies_to_price_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "applies_to_price_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// If set, only prices in the specified currency will have the adjustment applied.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// A list of filters that determine which prices this adjustment will apply to.
    /// </summary>
    public IReadOnlyList<NewUsageDiscountFilter>? Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<NewUsageDiscountFilter>>(
                "filters"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<NewUsageDiscountFilter>?>(
                "filters",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// When false, this adjustment will be applied to a single price. Otherwise,
    /// it will be applied at the invoice level, possibly to multiple prices.
    /// </summary>
    public bool? IsInvoiceLevel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_invoice_level");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_invoice_level", value);
        }
    }

    /// <summary>
    /// If set, only prices of the specified type will have the adjustment applied.
    /// </summary>
    public ApiEnum<string, NewUsageDiscountPriceType>? PriceType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, NewUsageDiscountPriceType>>(
                "price_type"
            );
        }
        init { this._rawData.Set("price_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AdjustmentType.Validate();
        _ = this.UsageDiscount;
        this.AppliesToAll?.Validate();
        _ = this.AppliesToItemIds;
        _ = this.AppliesToPriceIds;
        _ = this.Currency;
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
        _ = this.IsInvoiceLevel;
        this.PriceType?.Validate();
    }

    public NewUsageDiscount() { }

    public NewUsageDiscount(NewUsageDiscount newUsageDiscount)
        : base(newUsageDiscount) { }

    public NewUsageDiscount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewUsageDiscount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewUsageDiscountFromRaw.FromRawUnchecked"/>
    public static NewUsageDiscount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewUsageDiscountFromRaw : IFromRawJson<NewUsageDiscount>
{
    /// <inheritdoc/>
    public NewUsageDiscount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NewUsageDiscount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(NewUsageDiscountAdjustmentTypeConverter))]
public enum NewUsageDiscountAdjustmentType
{
    UsageDiscount,
}

sealed class NewUsageDiscountAdjustmentTypeConverter : JsonConverter<NewUsageDiscountAdjustmentType>
{
    public override NewUsageDiscountAdjustmentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usage_discount" => NewUsageDiscountAdjustmentType.UsageDiscount,
            _ => (NewUsageDiscountAdjustmentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewUsageDiscountAdjustmentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewUsageDiscountAdjustmentType.UsageDiscount => "usage_discount",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If set, the adjustment will apply to every price on the subscription.
/// </summary>
[JsonConverter(typeof(NewUsageDiscountAppliesToAllConverter))]
public enum NewUsageDiscountAppliesToAll
{
    True,
}

sealed class NewUsageDiscountAppliesToAllConverter : JsonConverter<NewUsageDiscountAppliesToAll>
{
    public override NewUsageDiscountAppliesToAll Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => NewUsageDiscountAppliesToAll.True,
            _ => (NewUsageDiscountAppliesToAll)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewUsageDiscountAppliesToAll value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewUsageDiscountAppliesToAll.True => true,
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<NewUsageDiscountFilter, NewUsageDiscountFilterFromRaw>))]
public sealed record class NewUsageDiscountFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, NewUsageDiscountFilterField> Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, NewUsageDiscountFilterField>>(
                "field"
            );
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, NewUsageDiscountFilterOperator> Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, NewUsageDiscountFilterOperator>>(
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

    public NewUsageDiscountFilter() { }

    public NewUsageDiscountFilter(NewUsageDiscountFilter newUsageDiscountFilter)
        : base(newUsageDiscountFilter) { }

    public NewUsageDiscountFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewUsageDiscountFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewUsageDiscountFilterFromRaw.FromRawUnchecked"/>
    public static NewUsageDiscountFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewUsageDiscountFilterFromRaw : IFromRawJson<NewUsageDiscountFilter>
{
    /// <inheritdoc/>
    public NewUsageDiscountFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewUsageDiscountFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(NewUsageDiscountFilterFieldConverter))]
public enum NewUsageDiscountFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class NewUsageDiscountFilterFieldConverter : JsonConverter<NewUsageDiscountFilterField>
{
    public override NewUsageDiscountFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => NewUsageDiscountFilterField.PriceID,
            "item_id" => NewUsageDiscountFilterField.ItemID,
            "price_type" => NewUsageDiscountFilterField.PriceType,
            "currency" => NewUsageDiscountFilterField.Currency,
            "pricing_unit_id" => NewUsageDiscountFilterField.PricingUnitID,
            _ => (NewUsageDiscountFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewUsageDiscountFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewUsageDiscountFilterField.PriceID => "price_id",
                NewUsageDiscountFilterField.ItemID => "item_id",
                NewUsageDiscountFilterField.PriceType => "price_type",
                NewUsageDiscountFilterField.Currency => "currency",
                NewUsageDiscountFilterField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(NewUsageDiscountFilterOperatorConverter))]
public enum NewUsageDiscountFilterOperator
{
    Includes,
    Excludes,
}

sealed class NewUsageDiscountFilterOperatorConverter : JsonConverter<NewUsageDiscountFilterOperator>
{
    public override NewUsageDiscountFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => NewUsageDiscountFilterOperator.Includes,
            "excludes" => NewUsageDiscountFilterOperator.Excludes,
            _ => (NewUsageDiscountFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewUsageDiscountFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewUsageDiscountFilterOperator.Includes => "includes",
                NewUsageDiscountFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If set, only prices of the specified type will have the adjustment applied.
/// </summary>
[JsonConverter(typeof(NewUsageDiscountPriceTypeConverter))]
public enum NewUsageDiscountPriceType
{
    Usage,
    FixedInAdvance,
    FixedInArrears,
    Fixed,
    InArrears,
}

sealed class NewUsageDiscountPriceTypeConverter : JsonConverter<NewUsageDiscountPriceType>
{
    public override NewUsageDiscountPriceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usage" => NewUsageDiscountPriceType.Usage,
            "fixed_in_advance" => NewUsageDiscountPriceType.FixedInAdvance,
            "fixed_in_arrears" => NewUsageDiscountPriceType.FixedInArrears,
            "fixed" => NewUsageDiscountPriceType.Fixed,
            "in_arrears" => NewUsageDiscountPriceType.InArrears,
            _ => (NewUsageDiscountPriceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewUsageDiscountPriceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewUsageDiscountPriceType.Usage => "usage",
                NewUsageDiscountPriceType.FixedInAdvance => "fixed_in_advance",
                NewUsageDiscountPriceType.FixedInArrears => "fixed_in_arrears",
                NewUsageDiscountPriceType.Fixed => "fixed",
                NewUsageDiscountPriceType.InArrears => "in_arrears",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
