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

[JsonConverter(typeof(JsonModelConverter<NewMaximum, NewMaximumFromRaw>))]
public sealed record class NewMaximum : JsonModel
{
    public required ApiEnum<string, NewMaximumAdjustmentType> AdjustmentType
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, NewMaximumAdjustmentType>>(
                "adjustment_type"
            );
        }
        init { this._rawData.Set("adjustment_type", value); }
    }

    public required string MaximumAmount
    {
        get { return this._rawData.GetNotNullClass<string>("maximum_amount"); }
        init { this._rawData.Set("maximum_amount", value); }
    }

    /// <summary>
    /// If set, the adjustment will apply to every price on the subscription.
    /// </summary>
    public ApiEnum<bool, NewMaximumAppliesToAll>? AppliesToAll
    {
        get
        {
            return this._rawData.GetNullableClass<ApiEnum<bool, NewMaximumAppliesToAll>>(
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
    public IReadOnlyList<NewMaximumFilter>? Filters
    {
        get { return this._rawData.GetNullableStruct<ImmutableArray<NewMaximumFilter>>("filters"); }
        init
        {
            this._rawData.Set<ImmutableArray<NewMaximumFilter>?>(
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
    public ApiEnum<string, NewMaximumPriceType>? PriceType
    {
        get
        {
            return this._rawData.GetNullableClass<ApiEnum<string, NewMaximumPriceType>>(
                "price_type"
            );
        }
        init { this._rawData.Set("price_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AdjustmentType.Validate();
        _ = this.MaximumAmount;
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

    public NewMaximum() { }

    public NewMaximum(NewMaximum newMaximum)
        : base(newMaximum) { }

    public NewMaximum(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewMaximum(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewMaximumFromRaw.FromRawUnchecked"/>
    public static NewMaximum FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewMaximumFromRaw : IFromRawJson<NewMaximum>
{
    /// <inheritdoc/>
    public NewMaximum FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NewMaximum.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(NewMaximumAdjustmentTypeConverter))]
public enum NewMaximumAdjustmentType
{
    Maximum,
}

sealed class NewMaximumAdjustmentTypeConverter : JsonConverter<NewMaximumAdjustmentType>
{
    public override NewMaximumAdjustmentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "maximum" => NewMaximumAdjustmentType.Maximum,
            _ => (NewMaximumAdjustmentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewMaximumAdjustmentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewMaximumAdjustmentType.Maximum => "maximum",
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
[JsonConverter(typeof(NewMaximumAppliesToAllConverter))]
public enum NewMaximumAppliesToAll
{
    True,
}

sealed class NewMaximumAppliesToAllConverter : JsonConverter<NewMaximumAppliesToAll>
{
    public override NewMaximumAppliesToAll Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => NewMaximumAppliesToAll.True,
            _ => (NewMaximumAppliesToAll)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewMaximumAppliesToAll value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewMaximumAppliesToAll.True => true,
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<NewMaximumFilter, NewMaximumFilterFromRaw>))]
public sealed record class NewMaximumFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, NewMaximumFilterField> Field
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, NewMaximumFilterField>>("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, NewMaximumFilterOperator> Operator
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, NewMaximumFilterOperator>>(
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

    public NewMaximumFilter() { }

    public NewMaximumFilter(NewMaximumFilter newMaximumFilter)
        : base(newMaximumFilter) { }

    public NewMaximumFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewMaximumFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NewMaximumFilterFromRaw.FromRawUnchecked"/>
    public static NewMaximumFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewMaximumFilterFromRaw : IFromRawJson<NewMaximumFilter>
{
    /// <inheritdoc/>
    public NewMaximumFilter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NewMaximumFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(NewMaximumFilterFieldConverter))]
public enum NewMaximumFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class NewMaximumFilterFieldConverter : JsonConverter<NewMaximumFilterField>
{
    public override NewMaximumFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => NewMaximumFilterField.PriceID,
            "item_id" => NewMaximumFilterField.ItemID,
            "price_type" => NewMaximumFilterField.PriceType,
            "currency" => NewMaximumFilterField.Currency,
            "pricing_unit_id" => NewMaximumFilterField.PricingUnitID,
            _ => (NewMaximumFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewMaximumFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewMaximumFilterField.PriceID => "price_id",
                NewMaximumFilterField.ItemID => "item_id",
                NewMaximumFilterField.PriceType => "price_type",
                NewMaximumFilterField.Currency => "currency",
                NewMaximumFilterField.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(NewMaximumFilterOperatorConverter))]
public enum NewMaximumFilterOperator
{
    Includes,
    Excludes,
}

sealed class NewMaximumFilterOperatorConverter : JsonConverter<NewMaximumFilterOperator>
{
    public override NewMaximumFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => NewMaximumFilterOperator.Includes,
            "excludes" => NewMaximumFilterOperator.Excludes,
            _ => (NewMaximumFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewMaximumFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewMaximumFilterOperator.Includes => "includes",
                NewMaximumFilterOperator.Excludes => "excludes",
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
[JsonConverter(typeof(NewMaximumPriceTypeConverter))]
public enum NewMaximumPriceType
{
    Usage,
    FixedInAdvance,
    FixedInArrears,
    Fixed,
    InArrears,
}

sealed class NewMaximumPriceTypeConverter : JsonConverter<NewMaximumPriceType>
{
    public override NewMaximumPriceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usage" => NewMaximumPriceType.Usage,
            "fixed_in_advance" => NewMaximumPriceType.FixedInAdvance,
            "fixed_in_arrears" => NewMaximumPriceType.FixedInArrears,
            "fixed" => NewMaximumPriceType.Fixed,
            "in_arrears" => NewMaximumPriceType.InArrears,
            _ => (NewMaximumPriceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NewMaximumPriceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NewMaximumPriceType.Usage => "usage",
                NewMaximumPriceType.FixedInAdvance => "fixed_in_advance",
                NewMaximumPriceType.FixedInArrears => "fixed_in_arrears",
                NewMaximumPriceType.Fixed => "fixed",
                NewMaximumPriceType.InArrears => "in_arrears",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
