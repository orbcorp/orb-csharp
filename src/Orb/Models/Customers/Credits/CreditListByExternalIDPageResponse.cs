using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers.Credits;

[JsonConverter(
    typeof(JsonModelConverter<
        CreditListByExternalIDPageResponse,
        CreditListByExternalIDPageResponseFromRaw
    >)
)]
public sealed record class CreditListByExternalIDPageResponse : JsonModel
{
    public required IReadOnlyList<CreditListByExternalIDPageResponseData> Data
    {
        get
        {
            return JsonModel.GetNotNullClass<List<CreditListByExternalIDPageResponseData>>(
                this.RawData,
                "data"
            );
        }
        init { JsonModel.Set(this._rawData, "data", value); }
    }

    public required PaginationMetadata PaginationMetadata
    {
        get
        {
            return JsonModel.GetNotNullClass<PaginationMetadata>(
                this.RawData,
                "pagination_metadata"
            );
        }
        init { JsonModel.Set(this._rawData, "pagination_metadata", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.PaginationMetadata.Validate();
    }

    public CreditListByExternalIDPageResponse() { }

    public CreditListByExternalIDPageResponse(
        CreditListByExternalIDPageResponse creditListByExternalIDPageResponse
    )
        : base(creditListByExternalIDPageResponse) { }

    public CreditListByExternalIDPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditListByExternalIDPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditListByExternalIDPageResponseFromRaw.FromRawUnchecked"/>
    public static CreditListByExternalIDPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditListByExternalIDPageResponseFromRaw : IFromRawJson<CreditListByExternalIDPageResponse>
{
    /// <inheritdoc/>
    public CreditListByExternalIDPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditListByExternalIDPageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CreditListByExternalIDPageResponseData,
        CreditListByExternalIDPageResponseDataFromRaw
    >)
)]
public sealed record class CreditListByExternalIDPageResponseData : JsonModel
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

    public required IReadOnlyList<CreditListByExternalIDPageResponseDataFilter> Filters
    {
        get
        {
            return JsonModel.GetNotNullClass<List<CreditListByExternalIDPageResponseDataFilter>>(
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

    public required ApiEnum<string, CreditListByExternalIDPageResponseDataStatus> Status
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, CreditListByExternalIDPageResponseDataStatus>
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

    public CreditListByExternalIDPageResponseData() { }

    public CreditListByExternalIDPageResponseData(
        CreditListByExternalIDPageResponseData creditListByExternalIDPageResponseData
    )
        : base(creditListByExternalIDPageResponseData) { }

    public CreditListByExternalIDPageResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditListByExternalIDPageResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditListByExternalIDPageResponseDataFromRaw.FromRawUnchecked"/>
    public static CreditListByExternalIDPageResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditListByExternalIDPageResponseDataFromRaw
    : IFromRawJson<CreditListByExternalIDPageResponseData>
{
    /// <inheritdoc/>
    public CreditListByExternalIDPageResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditListByExternalIDPageResponseData.FromRawUnchecked(rawData);
}

/// <summary>
/// A PriceFilter that only allows item_id field for block filters.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CreditListByExternalIDPageResponseDataFilter,
        CreditListByExternalIDPageResponseDataFilterFromRaw
    >)
)]
public sealed record class CreditListByExternalIDPageResponseDataFilter : JsonModel
{
    /// <summary>
    /// The property of the price the block applies to. Only item_id is supported.
    /// </summary>
    public required ApiEnum<string, CreditListByExternalIDPageResponseDataFilterField> Field
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, CreditListByExternalIDPageResponseDataFilterField>
            >(this.RawData, "field");
        }
        init { JsonModel.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, CreditListByExternalIDPageResponseDataFilterOperator> Operator
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, CreditListByExternalIDPageResponseDataFilterOperator>
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

    public CreditListByExternalIDPageResponseDataFilter() { }

    public CreditListByExternalIDPageResponseDataFilter(
        CreditListByExternalIDPageResponseDataFilter creditListByExternalIDPageResponseDataFilter
    )
        : base(creditListByExternalIDPageResponseDataFilter) { }

    public CreditListByExternalIDPageResponseDataFilter(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditListByExternalIDPageResponseDataFilter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditListByExternalIDPageResponseDataFilterFromRaw.FromRawUnchecked"/>
    public static CreditListByExternalIDPageResponseDataFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditListByExternalIDPageResponseDataFilterFromRaw
    : IFromRawJson<CreditListByExternalIDPageResponseDataFilter>
{
    /// <inheritdoc/>
    public CreditListByExternalIDPageResponseDataFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditListByExternalIDPageResponseDataFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price the block applies to. Only item_id is supported.
/// </summary>
[JsonConverter(typeof(CreditListByExternalIDPageResponseDataFilterFieldConverter))]
public enum CreditListByExternalIDPageResponseDataFilterField
{
    ItemID,
}

sealed class CreditListByExternalIDPageResponseDataFilterFieldConverter
    : JsonConverter<CreditListByExternalIDPageResponseDataFilterField>
{
    public override CreditListByExternalIDPageResponseDataFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "item_id" => CreditListByExternalIDPageResponseDataFilterField.ItemID,
            _ => (CreditListByExternalIDPageResponseDataFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreditListByExternalIDPageResponseDataFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreditListByExternalIDPageResponseDataFilterField.ItemID => "item_id",
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
[JsonConverter(typeof(CreditListByExternalIDPageResponseDataFilterOperatorConverter))]
public enum CreditListByExternalIDPageResponseDataFilterOperator
{
    Includes,
    Excludes,
}

sealed class CreditListByExternalIDPageResponseDataFilterOperatorConverter
    : JsonConverter<CreditListByExternalIDPageResponseDataFilterOperator>
{
    public override CreditListByExternalIDPageResponseDataFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => CreditListByExternalIDPageResponseDataFilterOperator.Includes,
            "excludes" => CreditListByExternalIDPageResponseDataFilterOperator.Excludes,
            _ => (CreditListByExternalIDPageResponseDataFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreditListByExternalIDPageResponseDataFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreditListByExternalIDPageResponseDataFilterOperator.Includes => "includes",
                CreditListByExternalIDPageResponseDataFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(CreditListByExternalIDPageResponseDataStatusConverter))]
public enum CreditListByExternalIDPageResponseDataStatus
{
    Active,
    PendingPayment,
}

sealed class CreditListByExternalIDPageResponseDataStatusConverter
    : JsonConverter<CreditListByExternalIDPageResponseDataStatus>
{
    public override CreditListByExternalIDPageResponseDataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => CreditListByExternalIDPageResponseDataStatus.Active,
            "pending_payment" => CreditListByExternalIDPageResponseDataStatus.PendingPayment,
            _ => (CreditListByExternalIDPageResponseDataStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreditListByExternalIDPageResponseDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreditListByExternalIDPageResponseDataStatus.Active => "active",
                CreditListByExternalIDPageResponseDataStatus.PendingPayment => "pending_payment",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
