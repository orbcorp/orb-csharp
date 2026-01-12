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

[JsonConverter(
    typeof(JsonModelConverter<
        CreditListByExternalIDResponse,
        CreditListByExternalIDResponseFromRaw
    >)
)]
public sealed record class CreditListByExternalIDResponse : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required double Balance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("balance");
        }
        init { this._rawData.Set("balance", value); }
    }

    public required System::DateTimeOffset? EffectiveDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("effective_date");
        }
        init { this._rawData.Set("effective_date", value); }
    }

    public required System::DateTimeOffset? ExpiryDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("expiry_date");
        }
        init { this._rawData.Set("expiry_date", value); }
    }

    public required IReadOnlyList<CreditListByExternalIDResponseFilter> Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<CreditListByExternalIDResponseFilter>
            >("filters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CreditListByExternalIDResponseFilter>>(
                "filters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required double? MaximumInitialBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("maximum_initial_balance");
        }
        init { this._rawData.Set("maximum_initial_balance", value); }
    }

    public required string? PerUnitCostBasis
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("per_unit_cost_basis");
        }
        init { this._rawData.Set("per_unit_cost_basis", value); }
    }

    public required ApiEnum<string, CreditListByExternalIDResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CreditListByExternalIDResponseStatus>
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

    public CreditListByExternalIDResponse() { }

    public CreditListByExternalIDResponse(
        CreditListByExternalIDResponse creditListByExternalIDResponse
    )
        : base(creditListByExternalIDResponse) { }

    public CreditListByExternalIDResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditListByExternalIDResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditListByExternalIDResponseFromRaw.FromRawUnchecked"/>
    public static CreditListByExternalIDResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditListByExternalIDResponseFromRaw : IFromRawJson<CreditListByExternalIDResponse>
{
    /// <inheritdoc/>
    public CreditListByExternalIDResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditListByExternalIDResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A PriceFilter that only allows item_id field for block filters.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CreditListByExternalIDResponseFilter,
        CreditListByExternalIDResponseFilterFromRaw
    >)
)]
public sealed record class CreditListByExternalIDResponseFilter : JsonModel
{
    /// <summary>
    /// The property of the price the block applies to. Only item_id is supported.
    /// </summary>
    public required ApiEnum<string, CreditListByExternalIDResponseFilterField> Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CreditListByExternalIDResponseFilterField>
            >("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, CreditListByExternalIDResponseFilterOperator> Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CreditListByExternalIDResponseFilterOperator>
            >("operator");
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

    public CreditListByExternalIDResponseFilter() { }

    public CreditListByExternalIDResponseFilter(
        CreditListByExternalIDResponseFilter creditListByExternalIDResponseFilter
    )
        : base(creditListByExternalIDResponseFilter) { }

    public CreditListByExternalIDResponseFilter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditListByExternalIDResponseFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditListByExternalIDResponseFilterFromRaw.FromRawUnchecked"/>
    public static CreditListByExternalIDResponseFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditListByExternalIDResponseFilterFromRaw
    : IFromRawJson<CreditListByExternalIDResponseFilter>
{
    /// <inheritdoc/>
    public CreditListByExternalIDResponseFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditListByExternalIDResponseFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price the block applies to. Only item_id is supported.
/// </summary>
[JsonConverter(typeof(CreditListByExternalIDResponseFilterFieldConverter))]
public enum CreditListByExternalIDResponseFilterField
{
    ItemID,
}

sealed class CreditListByExternalIDResponseFilterFieldConverter
    : JsonConverter<CreditListByExternalIDResponseFilterField>
{
    public override CreditListByExternalIDResponseFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "item_id" => CreditListByExternalIDResponseFilterField.ItemID,
            _ => (CreditListByExternalIDResponseFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreditListByExternalIDResponseFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreditListByExternalIDResponseFilterField.ItemID => "item_id",
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
[JsonConverter(typeof(CreditListByExternalIDResponseFilterOperatorConverter))]
public enum CreditListByExternalIDResponseFilterOperator
{
    Includes,
    Excludes,
}

sealed class CreditListByExternalIDResponseFilterOperatorConverter
    : JsonConverter<CreditListByExternalIDResponseFilterOperator>
{
    public override CreditListByExternalIDResponseFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => CreditListByExternalIDResponseFilterOperator.Includes,
            "excludes" => CreditListByExternalIDResponseFilterOperator.Excludes,
            _ => (CreditListByExternalIDResponseFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreditListByExternalIDResponseFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreditListByExternalIDResponseFilterOperator.Includes => "includes",
                CreditListByExternalIDResponseFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(CreditListByExternalIDResponseStatusConverter))]
public enum CreditListByExternalIDResponseStatus
{
    Active,
    PendingPayment,
}

sealed class CreditListByExternalIDResponseStatusConverter
    : JsonConverter<CreditListByExternalIDResponseStatus>
{
    public override CreditListByExternalIDResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => CreditListByExternalIDResponseStatus.Active,
            "pending_payment" => CreditListByExternalIDResponseStatus.PendingPayment,
            _ => (CreditListByExternalIDResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreditListByExternalIDResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreditListByExternalIDResponseStatus.Active => "active",
                CreditListByExternalIDResponseStatus.PendingPayment => "pending_payment",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
