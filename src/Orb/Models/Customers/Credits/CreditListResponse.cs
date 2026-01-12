using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        get { return this._rawData.GetNotNullClass<string>("id"); }
        init { this._rawData.Set("id", value); }
    }

    public required double Balance
    {
        get { return this._rawData.GetNotNullStruct<double>("balance"); }
        init { this._rawData.Set("balance", value); }
    }

    public required System::DateTimeOffset? EffectiveDate
    {
        get { return this._rawData.GetNullableStruct<System::DateTimeOffset>("effective_date"); }
        init { this._rawData.Set("effective_date", value); }
    }

    public required System::DateTimeOffset? ExpiryDate
    {
        get { return this._rawData.GetNullableStruct<System::DateTimeOffset>("expiry_date"); }
        init { this._rawData.Set("expiry_date", value); }
    }

    public required IReadOnlyList<global::Orb.Models.Customers.Credits.Filter> Filters
    {
        get
        {
            return this._rawData.GetNotNullStruct<
                ImmutableArray<global::Orb.Models.Customers.Credits.Filter>
            >("filters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<global::Orb.Models.Customers.Credits.Filter>>(
                "filters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required double? MaximumInitialBalance
    {
        get { return this._rawData.GetNullableStruct<double>("maximum_initial_balance"); }
        init { this._rawData.Set("maximum_initial_balance", value); }
    }

    public required string? PerUnitCostBasis
    {
        get { return this._rawData.GetNullableClass<string>("per_unit_cost_basis"); }
        init { this._rawData.Set("per_unit_cost_basis", value); }
    }

    public required ApiEnum<string, global::Orb.Models.Customers.Credits.Status> Status
    {
        get
        {
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.Customers.Credits.Status>
            >("status");
        }
        init { this._rawData.Set("status", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.Customers.Credits.Field>
            >("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Customers.Credits.Operator> Operator
    {
        get
        {
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.Customers.Credits.Operator>
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

    public Filter() { }

    public Filter(global::Orb.Models.Customers.Credits.Filter filter)
        : base(filter) { }

    public Filter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
