using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers.Credits;

[JsonConverter(typeof(JsonModelConverter<CreditListResponse, CreditListResponseFromRaw>))]
public sealed record class CreditListResponse : JsonModel
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

    public required IReadOnlyList<global::Orb.Models.Customers.Credits.Filter> Filters
    {
        get
        {
            return JsonModel.GetNotNullClass<List<global::Orb.Models.Customers.Credits.Filter>>(
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

    public required ApiEnum<string, global::Orb.Models.Customers.Credits.Status> Status
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.Customers.Credits.Status>
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

    public CreditListResponse() { }

    public CreditListResponse(CreditListResponse creditListResponse)
        : base(creditListResponse) { }

    public CreditListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditListResponseFromRaw.FromRawUnchecked"/>
    public static CreditListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditListResponseFromRaw : IFromRawJson<CreditListResponse>
{
    /// <inheritdoc/>
    public CreditListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreditListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A PriceFilter that only allows item_id field for block filters.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        global::Orb.Models.Customers.Credits.Filter,
        global::Orb.Models.Customers.Credits.FilterFromRaw
    >)
)]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// The property of the price the block applies to. Only item_id is supported.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Customers.Credits.Field> Field
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.Customers.Credits.Field>
            >(this.RawData, "field");
        }
        init { JsonModel.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Customers.Credits.Operator> Operator
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.Customers.Credits.Operator>
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

    public Filter(global::Orb.Models.Customers.Credits.Filter filter)
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

    /// <inheritdoc cref="global::Orb.Models.Customers.Credits.FilterFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Customers.Credits.Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FilterFromRaw : IFromRawJson<global::Orb.Models.Customers.Credits.Filter>
{
    /// <inheritdoc/>
    public global::Orb.Models.Customers.Credits.Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Customers.Credits.Filter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price the block applies to. Only item_id is supported.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Customers.Credits.FieldConverter))]
public enum Field
{
    ItemID,
}

sealed class FieldConverter : JsonConverter<global::Orb.Models.Customers.Credits.Field>
{
    public override global::Orb.Models.Customers.Credits.Field Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "item_id" => global::Orb.Models.Customers.Credits.Field.ItemID,
            _ => (global::Orb.Models.Customers.Credits.Field)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Customers.Credits.Field value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Customers.Credits.Field.ItemID => "item_id",
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
[JsonConverter(typeof(global::Orb.Models.Customers.Credits.OperatorConverter))]
public enum Operator
{
    Includes,
    Excludes,
}

sealed class OperatorConverter : JsonConverter<global::Orb.Models.Customers.Credits.Operator>
{
    public override global::Orb.Models.Customers.Credits.Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => global::Orb.Models.Customers.Credits.Operator.Includes,
            "excludes" => global::Orb.Models.Customers.Credits.Operator.Excludes,
            _ => (global::Orb.Models.Customers.Credits.Operator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Customers.Credits.Operator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Customers.Credits.Operator.Includes => "includes",
                global::Orb.Models.Customers.Credits.Operator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(global::Orb.Models.Customers.Credits.StatusConverter))]
public enum Status
{
    Active,
    PendingPayment,
}

sealed class StatusConverter : JsonConverter<global::Orb.Models.Customers.Credits.Status>
{
    public override global::Orb.Models.Customers.Credits.Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => global::Orb.Models.Customers.Credits.Status.Active,
            "pending_payment" => global::Orb.Models.Customers.Credits.Status.PendingPayment,
            _ => (global::Orb.Models.Customers.Credits.Status)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Customers.Credits.Status value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Customers.Credits.Status.Active => "active",
                global::Orb.Models.Customers.Credits.Status.PendingPayment => "pending_payment",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
