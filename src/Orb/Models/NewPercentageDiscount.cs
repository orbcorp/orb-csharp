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

[JsonConverter(typeof(JsonModelConverter<NewPercentageDiscount, NewPercentageDiscountFromRaw>))]
public sealed record class NewPercentageDiscount : JsonModel
{
    public required ApiEnum<string, NewPercentageDiscountAdjustmentType> AdjustmentType
    {
        get
        {
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NewPercentageDiscountAdjustmentType>
            >("adjustment_type");
        }
        init { this._rawData.Set("adjustment_type", value); }
    }

    public required double PercentageDiscount
    {
        get { return this._rawData.GetNotNullStruct<double>("percentage_discount"); }
        init { this._rawData.Set("percentage_discount", value); }
    }

    /// <summary>
    /// If set, the adjustment will apply to every price on the subscription.
    /// </summary>
    public ApiEnum<bool, NewPercentageDiscountAppliesToAll>? AppliesToAll
    {
        get
        {
            return this._rawData.GetNullableClass<ApiEnum<bool, NewPercentageDiscountAppliesToAll>>(
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
        get { return this._rawData.GetNullableClass<string>("currency"); }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// A list of filters that determine which prices this adjustment will apply to.
    /// </summary>
    public IReadOnlyList<NewPercentageDiscountFilter>? Filters
    {
        get
        {
            return this._rawData.GetNullableStruct<ImmutableArray<NewPercentageDiscountFilter>>(
                "filters"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<NewPercentageDiscountFilter>?>(
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
        get { return this._rawData.GetNullableStruct<bool>("is_invoice_level"); }
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
    public ApiEnum<string, NewPercentageDiscountPriceType>? PriceType
    {
        get
        {
            return this._rawData.GetNullableClass<ApiEnum<string, NewPercentageDiscountPriceType>>(
                "price_type"
            );
        }
        init { this._rawData.Set("price_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AdjustmentType.Validate();
        _ = this.PercentageDiscount;
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

    public NewPercentageDiscount() { }

    public NewPercentageDiscount(NewPercentageDiscount newPercentageDiscount)
        : base(newPercentageDiscount) { }

    public NewPercentageDiscount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewPercentageDiscount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewPercentageDiscountFromRaw.FromRawUnchecked"/>
    public static NewPercentageDiscount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewPercentageDiscountFromRaw : IFromRawJson<NewPercentageDiscount>
{
    /// <inheritdoc/>
    public NewPercentageDiscount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewPercentageDiscount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(NewPercentageDiscountAdjustmentTypeConverter))]
public enum NewPercentageDiscountAdjustmentType
{
    PercentageDiscount,
}

sealed class NewPercentageDiscountAdjustmentTypeConverter
    : JsonConverter<NewPercentageDiscountAdjustmentType>
{
    public override NewPercentageDiscountAdjustmentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "percentage_discount" => NewPercentageDiscountAdjustmentType.PercentageDiscount,
            _ => (NewPercentageDiscountAdjustmentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewPercentageDiscountAdjustmentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewPercentageDiscountAdjustmentType.PercentageDiscount => "percentage_discount",
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
[JsonConverter(typeof(NewPercentageDiscountAppliesToAllConverter))]
public enum NewPercentageDiscountAppliesToAll
{
    True,
}

sealed class NewPercentageDiscountAppliesToAllConverter
    : JsonConverter<NewPercentageDiscountAppliesToAll>
{
    public override NewPercentageDiscountAppliesToAll Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => NewPercentageDiscountAppliesToAll.True,
            _ => (NewPercentageDiscountAppliesToAll)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewPercentageDiscountAppliesToAll value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewPercentageDiscountAppliesToAll.True => true,
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<NewPercentageDiscountFilter, NewPercentageDiscountFilterFromRaw>)
)]
public sealed record class NewPercentageDiscountFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, NewPercentageDiscountFilterField> Field
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, NewPercentageDiscountFilterField>>(
                "field"
            );
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, NewPercentageDiscountFilterOperator> Operator
    {
        get
        {
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NewPercentageDiscountFilterOperator>
            >("operator");
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

    public NewPercentageDiscountFilter() { }

    public NewPercentageDiscountFilter(NewPercentageDiscountFilter newPercentageDiscountFilter)
        : base(newPercentageDiscountFilter) { }

    public NewPercentageDiscountFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewPercentageDiscountFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewPercentageDiscountFilterFromRaw.FromRawUnchecked"/>
    public static NewPercentageDiscountFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewPercentageDiscountFilterFromRaw : IFromRawJson<NewPercentageDiscountFilter>
{
    /// <inheritdoc/>
    public NewPercentageDiscountFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewPercentageDiscountFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(NewPercentageDiscountFilterFieldConverter))]
public enum NewPercentageDiscountFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class NewPercentageDiscountFilterFieldConverter
    : JsonConverter<NewPercentageDiscountFilterField>
{
    public override NewPercentageDiscountFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => NewPercentageDiscountFilterField.PriceID,
            "item_id" => NewPercentageDiscountFilterField.ItemID,
            "price_type" => NewPercentageDiscountFilterField.PriceType,
            "currency" => NewPercentageDiscountFilterField.Currency,
            "pricing_unit_id" => NewPercentageDiscountFilterField.PricingUnitID,
            _ => (NewPercentageDiscountFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewPercentageDiscountFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewPercentageDiscountFilterField.PriceID => "price_id",
                NewPercentageDiscountFilterField.ItemID => "item_id",
                NewPercentageDiscountFilterField.PriceType => "price_type",
                NewPercentageDiscountFilterField.Currency => "currency",
                NewPercentageDiscountFilterField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(NewPercentageDiscountFilterOperatorConverter))]
public enum NewPercentageDiscountFilterOperator
{
    Includes,
    Excludes,
}

sealed class NewPercentageDiscountFilterOperatorConverter
    : JsonConverter<NewPercentageDiscountFilterOperator>
{
    public override NewPercentageDiscountFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => NewPercentageDiscountFilterOperator.Includes,
            "excludes" => NewPercentageDiscountFilterOperator.Excludes,
            _ => (NewPercentageDiscountFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewPercentageDiscountFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewPercentageDiscountFilterOperator.Includes => "includes",
                NewPercentageDiscountFilterOperator.Excludes => "excludes",
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
[JsonConverter(typeof(NewPercentageDiscountPriceTypeConverter))]
public enum NewPercentageDiscountPriceType
{
    Usage,
    FixedInAdvance,
    FixedInArrears,
    Fixed,
    InArrears,
}

sealed class NewPercentageDiscountPriceTypeConverter : JsonConverter<NewPercentageDiscountPriceType>
{
    public override NewPercentageDiscountPriceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usage" => NewPercentageDiscountPriceType.Usage,
            "fixed_in_advance" => NewPercentageDiscountPriceType.FixedInAdvance,
            "fixed_in_arrears" => NewPercentageDiscountPriceType.FixedInArrears,
            "fixed" => NewPercentageDiscountPriceType.Fixed,
            "in_arrears" => NewPercentageDiscountPriceType.InArrears,
            _ => (NewPercentageDiscountPriceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewPercentageDiscountPriceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewPercentageDiscountPriceType.Usage => "usage",
                NewPercentageDiscountPriceType.FixedInAdvance => "fixed_in_advance",
                NewPercentageDiscountPriceType.FixedInArrears => "fixed_in_arrears",
                NewPercentageDiscountPriceType.Fixed => "fixed",
                NewPercentageDiscountPriceType.InArrears => "in_arrears",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
