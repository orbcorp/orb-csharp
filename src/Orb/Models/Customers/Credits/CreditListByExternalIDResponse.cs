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

    /// <summary>
    /// How this credit block was created: `allocation` (a subscription's recurring
    /// credit allocation), `top_up` (an automatic balance-threshold top-up), or
    /// `manual` (a manual credit ledger increment, including credits voided or expired
    /// off another block).
    /// </summary>
    public required ApiEnum<
        string,
        CreditListByExternalIDResponseCreditBlockSource
    > CreditBlockSource
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CreditListByExternalIDResponseCreditBlockSource>
            >("credit_block_source");
        }
        init { this._rawData.Set("credit_block_source", value); }
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

    /// <summary>
    /// User specified key-value pairs for the resource. If not present, this defaults
    /// to an empty dictionary. Individual keys can be removed by setting the value
    /// to `null`, and the entire metadata mapping can be cleared by setting `metadata`
    /// to `null`.
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
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

    /// <summary>
    /// The credit allocation that funded a block. Extends the allocation resource
    /// serialized on prices with the catalog-item attribution of the funding price.
    /// </summary>
    public CreditListByExternalIDResponseCreditAllocation? CreditAllocation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CreditListByExternalIDResponseCreditAllocation>(
                "credit_allocation"
            );
        }
        init { this._rawData.Set("credit_allocation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Balance;
        this.CreditBlockSource.Validate();
        _ = this.EffectiveDate;
        _ = this.ExpiryDate;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.MaximumInitialBalance;
        _ = this.Metadata;
        _ = this.PerUnitCostBasis;
        this.Status.Validate();
        this.CreditAllocation?.Validate();
    }

    public CreditListByExternalIDResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditListByExternalIDResponse(
        CreditListByExternalIDResponse creditListByExternalIDResponse
    )
        : base(creditListByExternalIDResponse) { }
#pragma warning restore CS8618

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
/// How this credit block was created: `allocation` (a subscription's recurring credit
/// allocation), `top_up` (an automatic balance-threshold top-up), or `manual` (a
/// manual credit ledger increment, including credits voided or expired off another block).
/// </summary>
[JsonConverter(typeof(CreditListByExternalIDResponseCreditBlockSourceConverter))]
public enum CreditListByExternalIDResponseCreditBlockSource
{
    Allocation,
    TopUp,
    Manual,
}

sealed class CreditListByExternalIDResponseCreditBlockSourceConverter
    : JsonConverter<CreditListByExternalIDResponseCreditBlockSource>
{
    public override CreditListByExternalIDResponseCreditBlockSource Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "allocation" => CreditListByExternalIDResponseCreditBlockSource.Allocation,
            "top_up" => CreditListByExternalIDResponseCreditBlockSource.TopUp,
            "manual" => CreditListByExternalIDResponseCreditBlockSource.Manual,
            _ => (CreditListByExternalIDResponseCreditBlockSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreditListByExternalIDResponseCreditBlockSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreditListByExternalIDResponseCreditBlockSource.Allocation => "allocation",
                CreditListByExternalIDResponseCreditBlockSource.TopUp => "top_up",
                CreditListByExternalIDResponseCreditBlockSource.Manual => "manual",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditListByExternalIDResponseFilter(
        CreditListByExternalIDResponseFilter creditListByExternalIDResponseFilter
    )
        : base(creditListByExternalIDResponseFilter) { }
#pragma warning restore CS8618

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

/// <summary>
/// The credit allocation that funded a block. Extends the allocation resource serialized
/// on prices with the catalog-item attribution of the funding price.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CreditListByExternalIDResponseCreditAllocation,
        CreditListByExternalIDResponseCreditAllocationFromRaw
    >)
)]
public sealed record class CreditListByExternalIDResponseCreditAllocation : JsonModel
{
    public required bool AllowsRollover
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("allows_rollover");
        }
        init { this._rawData.Set("allows_rollover", value); }
    }

    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    public required CustomExpiration? CustomExpiration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CustomExpiration>("custom_expiration");
        }
        init { this._rawData.Set("custom_expiration", value); }
    }

    /// <summary>
    /// The ID of the catalog item this block was allocated from, derived from the
    /// allocation's price.
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

    public IReadOnlyList<CreditListByExternalIDResponseCreditAllocationFilter>? Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<CreditListByExternalIDResponseCreditAllocationFilter>
            >("filters");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CreditListByExternalIDResponseCreditAllocationFilter>?>(
                "filters",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? LicenseTypeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license_type_id");
        }
        init { this._rawData.Set("license_type_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AllowsRollover;
        _ = this.Currency;
        this.CustomExpiration?.Validate();
        _ = this.ItemID;
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
        _ = this.LicenseTypeID;
    }

    public CreditListByExternalIDResponseCreditAllocation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditListByExternalIDResponseCreditAllocation(
        CreditListByExternalIDResponseCreditAllocation creditListByExternalIDResponseCreditAllocation
    )
        : base(creditListByExternalIDResponseCreditAllocation) { }
#pragma warning restore CS8618

    public CreditListByExternalIDResponseCreditAllocation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditListByExternalIDResponseCreditAllocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditListByExternalIDResponseCreditAllocationFromRaw.FromRawUnchecked"/>
    public static CreditListByExternalIDResponseCreditAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditListByExternalIDResponseCreditAllocationFromRaw
    : IFromRawJson<CreditListByExternalIDResponseCreditAllocation>
{
    /// <inheritdoc/>
    public CreditListByExternalIDResponseCreditAllocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditListByExternalIDResponseCreditAllocation.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        CreditListByExternalIDResponseCreditAllocationFilter,
        CreditListByExternalIDResponseCreditAllocationFilterFromRaw
    >)
)]
public sealed record class CreditListByExternalIDResponseCreditAllocationFilter : JsonModel
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, CreditListByExternalIDResponseCreditAllocationFilterField> Field
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CreditListByExternalIDResponseCreditAllocationFilterField>
            >("field");
        }
        init { this._rawData.Set("field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<
        string,
        CreditListByExternalIDResponseCreditAllocationFilterOperator
    > Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, CreditListByExternalIDResponseCreditAllocationFilterOperator>
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

    public CreditListByExternalIDResponseCreditAllocationFilter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreditListByExternalIDResponseCreditAllocationFilter(
        CreditListByExternalIDResponseCreditAllocationFilter creditListByExternalIDResponseCreditAllocationFilter
    )
        : base(creditListByExternalIDResponseCreditAllocationFilter) { }
#pragma warning restore CS8618

    public CreditListByExternalIDResponseCreditAllocationFilter(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditListByExternalIDResponseCreditAllocationFilter(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreditListByExternalIDResponseCreditAllocationFilterFromRaw.FromRawUnchecked"/>
    public static CreditListByExternalIDResponseCreditAllocationFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditListByExternalIDResponseCreditAllocationFilterFromRaw
    : IFromRawJson<CreditListByExternalIDResponseCreditAllocationFilter>
{
    /// <inheritdoc/>
    public CreditListByExternalIDResponseCreditAllocationFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditListByExternalIDResponseCreditAllocationFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(CreditListByExternalIDResponseCreditAllocationFilterFieldConverter))]
public enum CreditListByExternalIDResponseCreditAllocationFilterField
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class CreditListByExternalIDResponseCreditAllocationFilterFieldConverter
    : JsonConverter<CreditListByExternalIDResponseCreditAllocationFilterField>
{
    public override CreditListByExternalIDResponseCreditAllocationFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => CreditListByExternalIDResponseCreditAllocationFilterField.PriceID,
            "item_id" => CreditListByExternalIDResponseCreditAllocationFilterField.ItemID,
            "price_type" => CreditListByExternalIDResponseCreditAllocationFilterField.PriceType,
            "currency" => CreditListByExternalIDResponseCreditAllocationFilterField.Currency,
            "pricing_unit_id" =>
                CreditListByExternalIDResponseCreditAllocationFilterField.PricingUnitID,
            _ => (CreditListByExternalIDResponseCreditAllocationFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreditListByExternalIDResponseCreditAllocationFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreditListByExternalIDResponseCreditAllocationFilterField.PriceID => "price_id",
                CreditListByExternalIDResponseCreditAllocationFilterField.ItemID => "item_id",
                CreditListByExternalIDResponseCreditAllocationFilterField.PriceType => "price_type",
                CreditListByExternalIDResponseCreditAllocationFilterField.Currency => "currency",
                CreditListByExternalIDResponseCreditAllocationFilterField.PricingUnitID =>
                    "pricing_unit_id",
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
[JsonConverter(typeof(CreditListByExternalIDResponseCreditAllocationFilterOperatorConverter))]
public enum CreditListByExternalIDResponseCreditAllocationFilterOperator
{
    Includes,
    Excludes,
}

sealed class CreditListByExternalIDResponseCreditAllocationFilterOperatorConverter
    : JsonConverter<CreditListByExternalIDResponseCreditAllocationFilterOperator>
{
    public override CreditListByExternalIDResponseCreditAllocationFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes,
            "excludes" => CreditListByExternalIDResponseCreditAllocationFilterOperator.Excludes,
            _ => (CreditListByExternalIDResponseCreditAllocationFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreditListByExternalIDResponseCreditAllocationFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreditListByExternalIDResponseCreditAllocationFilterOperator.Includes => "includes",
                CreditListByExternalIDResponseCreditAllocationFilterOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
