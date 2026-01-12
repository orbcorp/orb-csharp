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

[JsonConverter(typeof(JsonModelConverter<NewMinimum, NewMinimumFromRaw>))]
public sealed record class NewMinimum : JsonModel
{
    public required ApiEnum<string, NewMinimumAdjustmentType> AdjustmentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, NewMinimumAdjustmentType>>(
                "adjustment_type"
            );
        }
        init { this._rawData.Set("adjustment_type", value); }
    }

    /// <summary>
    /// The item ID that revenue from this minimum will be attributed to.
    /// </summary>
    public required string ItemID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("item_id");
        }
        init { this._rawData.Set("item_id", value); }
    }

    public required string MinimumAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("minimum_amount");
        }
        init { this._rawData.Set("minimum_amount", value); }
    }

    /// <summary>
    /// If set, the adjustment will apply to every price on the subscription.
    /// </summary>
    public ApiEnum<bool, NewMinimumAppliesToAll>? AppliesToAll
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<bool, NewMinimumAppliesToAll>>(
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
    public IReadOnlyList<NewMinimumFilter>? Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<NewMinimumFilter>>("filters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<NewMinimumFilter>?>(
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
    public ApiEnum<string, NewMinimumPriceType>? PriceType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, NewMinimumPriceType>>(
                "price_type"
            );
        }
        init { this._rawData.Set("price_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AdjustmentType.Validate();
        _ = this.ItemID;
        _ = this.MinimumAmount;
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

    public NewMinimum() { }

    public NewMinimum(NewMinimum newMinimum)
        : base(newMinimum) { }

    public NewMinimum(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewMinimum(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewMinimumFromRaw.FromRawUnchecked"/>
    public static NewMinimum FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewMinimumFromRaw : IFromRawJson<NewMinimum>
{
    /// <inheritdoc/>
    public NewMinimum FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NewMinimum.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(NewMinimumAdjustmentTypeConverter))]
public enum NewMinimumAdjustmentType
{
    Minimum,
}

sealed class NewMinimumAdjustmentTypeConverter : JsonConverter<NewMinimumAdjustmentType>
{
    public override NewMinimumAdjustmentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "minimum" => NewMinimumAdjustmentType.Minimum,
            _ => (NewMinimumAdjustmentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewMinimumAdjustmentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewMinimumAdjustmentType.Minimum => "minimum",
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
[JsonConverter(typeof(NewMinimumAppliesToAllConverter))]
public enum NewMinimumAppliesToAll
{
    True,
}

sealed class NewMinimumAppliesToAllConverter : JsonConverter<NewMinimumAppliesToAll>
{
    public override NewMinimumAppliesToAll Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => NewMinimumAppliesToAll.True,
            _ => (NewMinimumAppliesToAll)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewMinimumAppliesToAll value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewMinimumAppliesToAll.True => true,
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<NewMinimumFilter, NewMinimumFilterFromRaw>))]
public sealed record class NewMinimumFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, NewMinimumFilterField> Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, NewMinimumFilterField>>("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, NewMinimumFilterOperator> Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, NewMinimumFilterOperator>>(
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

    public NewMinimumFilter() { }

    public NewMinimumFilter(NewMinimumFilter newMinimumFilter)
        : base(newMinimumFilter) { }

    public NewMinimumFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewMinimumFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewMinimumFilterFromRaw.FromRawUnchecked"/>
    public static NewMinimumFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewMinimumFilterFromRaw : IFromRawJson<NewMinimumFilter>
{
    /// <inheritdoc/>
    public NewMinimumFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NewMinimumFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(NewMinimumFilterFieldConverter))]
public enum NewMinimumFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class NewMinimumFilterFieldConverter : JsonConverter<NewMinimumFilterField>
{
    public override NewMinimumFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => NewMinimumFilterField.PriceID,
            "item_id" => NewMinimumFilterField.ItemID,
            "price_type" => NewMinimumFilterField.PriceType,
            "currency" => NewMinimumFilterField.Currency,
            "pricing_unit_id" => NewMinimumFilterField.PricingUnitID,
            _ => (NewMinimumFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewMinimumFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewMinimumFilterField.PriceID => "price_id",
                NewMinimumFilterField.ItemID => "item_id",
                NewMinimumFilterField.PriceType => "price_type",
                NewMinimumFilterField.Currency => "currency",
                NewMinimumFilterField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(NewMinimumFilterOperatorConverter))]
public enum NewMinimumFilterOperator
{
    Includes,
    Excludes,
}

sealed class NewMinimumFilterOperatorConverter : JsonConverter<NewMinimumFilterOperator>
{
    public override NewMinimumFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => NewMinimumFilterOperator.Includes,
            "excludes" => NewMinimumFilterOperator.Excludes,
            _ => (NewMinimumFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewMinimumFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewMinimumFilterOperator.Includes => "includes",
                NewMinimumFilterOperator.Excludes => "excludes",
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
[JsonConverter(typeof(NewMinimumPriceTypeConverter))]
public enum NewMinimumPriceType
{
    Usage,
    FixedInAdvance,
    FixedInArrears,
    Fixed,
    InArrears,
}

sealed class NewMinimumPriceTypeConverter : JsonConverter<NewMinimumPriceType>
{
    public override NewMinimumPriceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usage" => NewMinimumPriceType.Usage,
            "fixed_in_advance" => NewMinimumPriceType.FixedInAdvance,
            "fixed_in_arrears" => NewMinimumPriceType.FixedInArrears,
            "fixed" => NewMinimumPriceType.Fixed,
            "in_arrears" => NewMinimumPriceType.InArrears,
            _ => (NewMinimumPriceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewMinimumPriceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewMinimumPriceType.Usage => "usage",
                NewMinimumPriceType.FixedInAdvance => "fixed_in_advance",
                NewMinimumPriceType.FixedInArrears => "fixed_in_arrears",
                NewMinimumPriceType.Fixed => "fixed",
                NewMinimumPriceType.InArrears => "in_arrears",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
