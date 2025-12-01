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
    typeof(ModelConverter<
        CreditListByExternalIDPageResponse,
        CreditListByExternalIDPageResponseFromRaw
    >)
)]
public sealed record class CreditListByExternalIDPageResponse : ModelBase
{
    public required IReadOnlyList<DataModel> Data
    {
        get { return ModelBase.GetNotNullClass<List<DataModel>>(this.RawData, "data"); }
        init { ModelBase.Set(this._rawData, "data", value); }
    }

    public required PaginationMetadata PaginationMetadata
    {
        get
        {
            return ModelBase.GetNotNullClass<PaginationMetadata>(
                this.RawData,
                "pagination_metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "pagination_metadata", value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.PaginationMetadata.Validate();
    }

    public CreditListByExternalIDPageResponse() { }

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

    public static CreditListByExternalIDPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreditListByExternalIDPageResponseFromRaw : IFromRaw<CreditListByExternalIDPageResponse>
{
    public CreditListByExternalIDPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreditListByExternalIDPageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<DataModel, DataModelFromRaw>))]
public sealed record class DataModel : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public required double Balance
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "balance"); }
        init { ModelBase.Set(this._rawData, "balance", value); }
    }

    public required System::DateTimeOffset? EffectiveDate
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(
                this.RawData,
                "effective_date"
            );
        }
        init { ModelBase.Set(this._rawData, "effective_date", value); }
    }

    public required System::DateTimeOffset? ExpiryDate
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(this.RawData, "expiry_date");
        }
        init { ModelBase.Set(this._rawData, "expiry_date", value); }
    }

    public required IReadOnlyList<global::Orb.Models.Customers.Credits.FilterModel> Filters
    {
        get
        {
            return ModelBase.GetNotNullClass<
                List<global::Orb.Models.Customers.Credits.FilterModel>
            >(this.RawData, "filters");
        }
        init { ModelBase.Set(this._rawData, "filters", value); }
    }

    public required double? MaximumInitialBalance
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "maximum_initial_balance"); }
        init { ModelBase.Set(this._rawData, "maximum_initial_balance", value); }
    }

    public required string? PerUnitCostBasis
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "per_unit_cost_basis"); }
        init { ModelBase.Set(this._rawData, "per_unit_cost_basis", value); }
    }

    public required ApiEnum<string, DataModelStatus> Status
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, DataModelStatus>>(
                this.RawData,
                "status"
            );
        }
        init { ModelBase.Set(this._rawData, "status", value); }
    }

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

    public DataModel() { }

    public DataModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static DataModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataModelFromRaw : IFromRaw<DataModel>
{
    public DataModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DataModel.FromRawUnchecked(rawData);
}

/// <summary>
/// A PriceFilter that only allows item_id field for block filters.
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Customers.Credits.FilterModel,
        global::Orb.Models.Customers.Credits.FilterModelFromRaw
    >)
)]
public sealed record class FilterModel : ModelBase
{
    /// <summary>
    /// The property of the price the block applies to. Only item_id is supported.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Customers.Credits.FilterModelField> Field
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.Customers.Credits.FilterModelField>
            >(this.RawData, "field");
        }
        init { ModelBase.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<
        string,
        global::Orb.Models.Customers.Credits.FilterModelOperator
    > Operator
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.Customers.Credits.FilterModelOperator>
            >(this.RawData, "operator");
        }
        init { ModelBase.Set(this._rawData, "operator", value); }
    }

    /// <summary>
    /// The IDs or values that match this filter.
    /// </summary>
    public required IReadOnlyList<string> Values
    {
        get { return ModelBase.GetNotNullClass<List<string>>(this.RawData, "values"); }
        init { ModelBase.Set(this._rawData, "values", value); }
    }

    public override void Validate()
    {
        this.Field.Validate();
        this.Operator.Validate();
        _ = this.Values;
    }

    public FilterModel() { }

    public FilterModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FilterModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Customers.Credits.FilterModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FilterModelFromRaw : IFromRaw<global::Orb.Models.Customers.Credits.FilterModel>
{
    public global::Orb.Models.Customers.Credits.FilterModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Customers.Credits.FilterModel.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price the block applies to. Only item_id is supported.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Customers.Credits.FilterModelFieldConverter))]
public enum FilterModelField
{
    ItemID,
}

sealed class FilterModelFieldConverter
    : JsonConverter<global::Orb.Models.Customers.Credits.FilterModelField>
{
    public override global::Orb.Models.Customers.Credits.FilterModelField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "item_id" => global::Orb.Models.Customers.Credits.FilterModelField.ItemID,
            _ => (global::Orb.Models.Customers.Credits.FilterModelField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Customers.Credits.FilterModelField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Customers.Credits.FilterModelField.ItemID => "item_id",
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
[JsonConverter(typeof(global::Orb.Models.Customers.Credits.FilterModelOperatorConverter))]
public enum FilterModelOperator
{
    Includes,
    Excludes,
}

sealed class FilterModelOperatorConverter
    : JsonConverter<global::Orb.Models.Customers.Credits.FilterModelOperator>
{
    public override global::Orb.Models.Customers.Credits.FilterModelOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => global::Orb.Models.Customers.Credits.FilterModelOperator.Includes,
            "excludes" => global::Orb.Models.Customers.Credits.FilterModelOperator.Excludes,
            _ => (global::Orb.Models.Customers.Credits.FilterModelOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Customers.Credits.FilterModelOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Customers.Credits.FilterModelOperator.Includes => "includes",
                global::Orb.Models.Customers.Credits.FilterModelOperator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(DataModelStatusConverter))]
public enum DataModelStatus
{
    Active,
    PendingPayment,
}

sealed class DataModelStatusConverter : JsonConverter<DataModelStatus>
{
    public override DataModelStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => DataModelStatus.Active,
            "pending_payment" => DataModelStatus.PendingPayment,
            _ => (DataModelStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataModelStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataModelStatus.Active => "active",
                DataModelStatus.PendingPayment => "pending_payment",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
