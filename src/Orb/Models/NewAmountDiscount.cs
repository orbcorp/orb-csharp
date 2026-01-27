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

[JsonConverter(typeof(JsonModelConverter<NewAmountDiscount, NewAmountDiscountFromRaw>))]
public sealed record class NewAmountDiscount : JsonModel
{
    public required ApiEnum<string, NewAmountDiscountAdjustmentType> AdjustmentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, NewAmountDiscountAdjustmentType>>(
                "adjustment_type"
            );
        }
        init { this._rawData.Set("adjustment_type", value); }
    }

    public required string AmountDiscount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("amount_discount");
        }
        init { this._rawData.Set("amount_discount", value); }
    }

    /// <summary>
    /// If set, the adjustment will apply to every price on the subscription.
    /// </summary>
    public ApiEnum<bool, AppliesToAll>? AppliesToAll
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<bool, AppliesToAll>>("applies_to_all");
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
    public IReadOnlyList<NewAmountDiscountFilter>? Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<NewAmountDiscountFilter>>(
                "filters"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<NewAmountDiscountFilter>?>(
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
    public ApiEnum<string, PriceType>? PriceType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PriceType>>("price_type");
        }
        init { this._rawData.Set("price_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AdjustmentType.Validate();
        _ = this.AmountDiscount;
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

    public NewAmountDiscount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NewAmountDiscount(NewAmountDiscount newAmountDiscount)
        : base(newAmountDiscount) { }
#pragma warning restore CS8618

    public NewAmountDiscount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewAmountDiscount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewAmountDiscountFromRaw.FromRawUnchecked"/>
    public static NewAmountDiscount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewAmountDiscountFromRaw : IFromRawJson<NewAmountDiscount>
{
    /// <inheritdoc/>
    public NewAmountDiscount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NewAmountDiscount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(NewAmountDiscountAdjustmentTypeConverter))]
public enum NewAmountDiscountAdjustmentType
{
    AmountDiscount,
}

sealed class NewAmountDiscountAdjustmentTypeConverter
    : JsonConverter<NewAmountDiscountAdjustmentType>
{
    public override NewAmountDiscountAdjustmentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "amount_discount" => NewAmountDiscountAdjustmentType.AmountDiscount,
            _ => (NewAmountDiscountAdjustmentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewAmountDiscountAdjustmentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewAmountDiscountAdjustmentType.AmountDiscount => "amount_discount",
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
[JsonConverter(typeof(AppliesToAllConverter))]
public enum AppliesToAll
{
    True,
}

sealed class AppliesToAllConverter : JsonConverter<AppliesToAll>
{
    public override AppliesToAll Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => AppliesToAll.True,
            _ => (AppliesToAll)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AppliesToAll value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AppliesToAll.True => true,
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<NewAmountDiscountFilter, NewAmountDiscountFilterFromRaw>))]
public sealed record class NewAmountDiscountFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, NewAmountDiscountFilterField> Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, NewAmountDiscountFilterField>>(
                "field"
            );
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, NewAmountDiscountFilterOperator> Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, NewAmountDiscountFilterOperator>>(
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

    public NewAmountDiscountFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NewAmountDiscountFilter(NewAmountDiscountFilter newAmountDiscountFilter)
        : base(newAmountDiscountFilter) { }
#pragma warning restore CS8618

    public NewAmountDiscountFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewAmountDiscountFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewAmountDiscountFilterFromRaw.FromRawUnchecked"/>
    public static NewAmountDiscountFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewAmountDiscountFilterFromRaw : IFromRawJson<NewAmountDiscountFilter>
{
    /// <inheritdoc/>
    public NewAmountDiscountFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NewAmountDiscountFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(NewAmountDiscountFilterFieldConverter))]
public enum NewAmountDiscountFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class NewAmountDiscountFilterFieldConverter : JsonConverter<NewAmountDiscountFilterField>
{
    public override NewAmountDiscountFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => NewAmountDiscountFilterField.PriceID,
            "item_id" => NewAmountDiscountFilterField.ItemID,
            "price_type" => NewAmountDiscountFilterField.PriceType,
            "currency" => NewAmountDiscountFilterField.Currency,
            "pricing_unit_id" => NewAmountDiscountFilterField.PricingUnitID,
            _ => (NewAmountDiscountFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewAmountDiscountFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewAmountDiscountFilterField.PriceID => "price_id",
                NewAmountDiscountFilterField.ItemID => "item_id",
                NewAmountDiscountFilterField.PriceType => "price_type",
                NewAmountDiscountFilterField.Currency => "currency",
                NewAmountDiscountFilterField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(NewAmountDiscountFilterOperatorConverter))]
public enum NewAmountDiscountFilterOperator
{
    Includes,
    Excludes,
}

sealed class NewAmountDiscountFilterOperatorConverter
    : JsonConverter<NewAmountDiscountFilterOperator>
{
    public override NewAmountDiscountFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => NewAmountDiscountFilterOperator.Includes,
            "excludes" => NewAmountDiscountFilterOperator.Excludes,
            _ => (NewAmountDiscountFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewAmountDiscountFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewAmountDiscountFilterOperator.Includes => "includes",
                NewAmountDiscountFilterOperator.Excludes => "excludes",
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
[JsonConverter(typeof(PriceTypeConverter))]
public enum PriceType
{
    Usage,
    FixedInAdvance,
    FixedInArrears,
    Fixed,
    InArrears,
}

sealed class PriceTypeConverter : JsonConverter<PriceType>
{
    public override PriceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usage" => PriceType.Usage,
            "fixed_in_advance" => PriceType.FixedInAdvance,
            "fixed_in_arrears" => PriceType.FixedInArrears,
            "fixed" => PriceType.Fixed,
            "in_arrears" => PriceType.InArrears,
            _ => (PriceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PriceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PriceType.Usage => "usage",
                PriceType.FixedInAdvance => "fixed_in_advance",
                PriceType.FixedInArrears => "fixed_in_arrears",
                PriceType.Fixed => "fixed",
                PriceType.InArrears => "in_arrears",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
