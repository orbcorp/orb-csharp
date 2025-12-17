using System.Collections.Frozen;
using System.Collections.Generic;
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
            return JsonModel.GetNotNullClass<ApiEnum<string, NewMinimumAdjustmentType>>(
                this.RawData,
                "adjustment_type"
            );
        }
        init { JsonModel.Set(this._rawData, "adjustment_type", value); }
    }

    /// <summary>
    /// The item ID that revenue from this minimum will be attributed to.
    /// </summary>
    public required string ItemID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { JsonModel.Set(this._rawData, "item_id", value); }
    }

    public required string MinimumAmount
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "minimum_amount"); }
        init { JsonModel.Set(this._rawData, "minimum_amount", value); }
    }

    /// <summary>
    /// If set, the adjustment will apply to every price on the subscription.
    /// </summary>
    public ApiEnum<bool, NewMinimumAppliesToAll>? AppliesToAll
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<bool, NewMinimumAppliesToAll>>(
                this.RawData,
                "applies_to_all"
            );
        }
        init { JsonModel.Set(this._rawData, "applies_to_all", value); }
    }

    /// <summary>
    /// The set of item IDs to which this adjustment applies.
    /// </summary>
    public IReadOnlyList<string>? AppliesToItemIDs
    {
        get
        {
            return JsonModel.GetNullableClass<List<string>>(this.RawData, "applies_to_item_ids");
        }
        init { JsonModel.Set(this._rawData, "applies_to_item_ids", value); }
    }

    /// <summary>
    /// The set of price IDs to which this adjustment applies.
    /// </summary>
    public IReadOnlyList<string>? AppliesToPriceIDs
    {
        get
        {
            return JsonModel.GetNullableClass<List<string>>(this.RawData, "applies_to_price_ids");
        }
        init { JsonModel.Set(this._rawData, "applies_to_price_ids", value); }
    }

    /// <summary>
    /// If set, only prices in the specified currency will have the adjustment applied.
    /// </summary>
    public string? Currency
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "currency"); }
        init { JsonModel.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// A list of filters that determine which prices this adjustment will apply to.
    /// </summary>
    public IReadOnlyList<NewMinimumFilter>? Filters
    {
        get { return JsonModel.GetNullableClass<List<NewMinimumFilter>>(this.RawData, "filters"); }
        init { JsonModel.Set(this._rawData, "filters", value); }
    }

    /// <summary>
    /// When false, this adjustment will be applied to a single price. Otherwise,
    /// it will be applied at the invoice level, possibly to multiple prices.
    /// </summary>
    public bool? IsInvoiceLevel
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "is_invoice_level"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "is_invoice_level", value);
        }
    }

    /// <summary>
    /// If set, only prices of the specified type will have the adjustment applied.
    /// </summary>
    public ApiEnum<string, NewMinimumPriceType>? PriceType
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, NewMinimumPriceType>>(
                this.RawData,
                "price_type"
            );
        }
        init { JsonModel.Set(this._rawData, "price_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AdjustmentType.Validate();
        _ = this.ItemID;
        _ = this.MinimumAmount;
        this.AppliesToAll?.Validate();
        _ = this.AppliesToItemIDs;
        _ = this.AppliesToPriceIDs;
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewMinimum(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
            return JsonModel.GetNotNullClass<ApiEnum<string, NewMinimumFilterField>>(
                this.RawData,
                "field"
            );
        }
        init { JsonModel.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, NewMinimumFilterOperator> Operator
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, NewMinimumFilterOperator>>(
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

    public NewMinimumFilter() { }

    public NewMinimumFilter(NewMinimumFilter newMinimumFilter)
        : base(newMinimumFilter) { }

    public NewMinimumFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewMinimumFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
