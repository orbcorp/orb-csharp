using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.CreditBlocks;

/// <summary>
/// The Credit Block resource models prepaid credits within Orb.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CreditBlockRetrieveResponse, CreditBlockRetrieveResponseFromRaw>)
)]
public sealed record class CreditBlockRetrieveResponse : JsonModel
{
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    public required double Balance
    {
        get { return JsonModel.GetNotNullStruct<double>(this.RawData, "balance"); }
        init { JsonModel.Set(this._rawData, "balance", value); }
    }

    public required System::DateTimeOffset? EffectiveDate
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(
                this.RawData,
                "effective_date"
            );
        }
        init { JsonModel.Set(this._rawData, "effective_date", value); }
    }

    public required System::DateTimeOffset? ExpiryDate
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(this.RawData, "expiry_date");
        }
        init { JsonModel.Set(this._rawData, "expiry_date", value); }
    }

    public required IReadOnlyList<global::Orb.Models.CreditBlocks.Filter> Filters
    {
        get
        {
            return JsonModel.GetNotNullClass<List<global::Orb.Models.CreditBlocks.Filter>>(
                this.RawData,
                "filters"
            );
        }
        init { JsonModel.Set(this._rawData, "filters", value); }
    }

    public required double? MaximumInitialBalance
    {
        get { return JsonModel.GetNullableStruct<double>(this.RawData, "maximum_initial_balance"); }
        init { JsonModel.Set(this._rawData, "maximum_initial_balance", value); }
    }

    public required string? PerUnitCostBasis
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "per_unit_cost_basis"); }
        init { JsonModel.Set(this._rawData, "per_unit_cost_basis", value); }
    }

    public required ApiEnum<string, global::Orb.Models.CreditBlocks.Status> Status
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.CreditBlocks.Status>
            >(this.RawData, "status");
        }
        init { JsonModel.Set(this._rawData, "status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Balance;
        _ = this.EffectiveDate;
        _ = this.ExpiryDate;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.MaximumInitialBalance;
        _ = this.PerUnitCostBasis;
        this.Status.Validate();
    }

    public CreditBlockRetrieveResponse() { }

    public CreditBlockRetrieveResponse(CreditBlockRetrieveResponse creditBlockRetrieveResponse)
        : base(creditBlockRetrieveResponse) { }

    public CreditBlockRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditBlockRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditBlockRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static CreditBlockRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditBlockRetrieveResponseFromRaw : IFromRawJson<CreditBlockRetrieveResponse>
{
    /// <inheritdoc/>
    public CreditBlockRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditBlockRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        global::Orb.Models.CreditBlocks.Filter,
        global::Orb.Models.CreditBlocks.FilterFromRaw
    >)
)]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.CreditBlocks.Field> Field
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.CreditBlocks.Field>
            >(this.RawData, "field");
        }
        init { JsonModel.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.CreditBlocks.Operator> Operator
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.CreditBlocks.Operator>
            >(this.RawData, "operator");
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

    public Filter() { }

    public Filter(global::Orb.Models.CreditBlocks.Filter filter)
        : base(filter) { }

    public Filter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.CreditBlocks.FilterFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.CreditBlocks.Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FilterFromRaw : IFromRawJson<global::Orb.Models.CreditBlocks.Filter>
{
    /// <inheritdoc/>
    public global::Orb.Models.CreditBlocks.Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.CreditBlocks.Filter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.CreditBlocks.FieldConverter))]
public enum Field
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class FieldConverter : JsonConverter<global::Orb.Models.CreditBlocks.Field>
{
    public override global::Orb.Models.CreditBlocks.Field Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => global::Orb.Models.CreditBlocks.Field.PriceID,
            "item_id" => global::Orb.Models.CreditBlocks.Field.ItemID,
            "price_type" => global::Orb.Models.CreditBlocks.Field.PriceType,
            "currency" => global::Orb.Models.CreditBlocks.Field.Currency,
            "pricing_unit_id" => global::Orb.Models.CreditBlocks.Field.PricingUnitID,
            _ => (global::Orb.Models.CreditBlocks.Field)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.CreditBlocks.Field value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.CreditBlocks.Field.PriceID => "price_id",
                global::Orb.Models.CreditBlocks.Field.ItemID => "item_id",
                global::Orb.Models.CreditBlocks.Field.PriceType => "price_type",
                global::Orb.Models.CreditBlocks.Field.Currency => "currency",
                global::Orb.Models.CreditBlocks.Field.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(global::Orb.Models.CreditBlocks.OperatorConverter))]
public enum Operator
{
    Includes,
    Excludes,
}

sealed class OperatorConverter : JsonConverter<global::Orb.Models.CreditBlocks.Operator>
{
    public override global::Orb.Models.CreditBlocks.Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => global::Orb.Models.CreditBlocks.Operator.Includes,
            "excludes" => global::Orb.Models.CreditBlocks.Operator.Excludes,
            _ => (global::Orb.Models.CreditBlocks.Operator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.CreditBlocks.Operator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.CreditBlocks.Operator.Includes => "includes",
                global::Orb.Models.CreditBlocks.Operator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(global::Orb.Models.CreditBlocks.StatusConverter))]
public enum Status
{
    Active,
    PendingPayment,
}

sealed class StatusConverter : JsonConverter<global::Orb.Models.CreditBlocks.Status>
{
    public override global::Orb.Models.CreditBlocks.Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => global::Orb.Models.CreditBlocks.Status.Active,
            "pending_payment" => global::Orb.Models.CreditBlocks.Status.PendingPayment,
            _ => (global::Orb.Models.CreditBlocks.Status)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.CreditBlocks.Status value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.CreditBlocks.Status.Active => "active",
                global::Orb.Models.CreditBlocks.Status.PendingPayment => "pending_payment",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
