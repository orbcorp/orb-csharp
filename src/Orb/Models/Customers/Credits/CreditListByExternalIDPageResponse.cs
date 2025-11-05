using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers.Credits;

[JsonConverter(typeof(ModelConverter<CreditListByExternalIDPageResponse>))]
public sealed record class CreditListByExternalIDPageResponse
    : ModelBase,
        IFromRaw<CreditListByExternalIDPageResponse>
{
    public required List<DataModel> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'data' cannot be null",
                    new System::ArgumentOutOfRangeException("data", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<DataModel>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'data' cannot be null",
                    new System::ArgumentNullException("data")
                );
        }
        set
        {
            this.Properties["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required PaginationMetadata PaginationMetadata
    {
        get
        {
            if (!this.Properties.TryGetValue("pagination_metadata", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'pagination_metadata' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "pagination_metadata",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<PaginationMetadata>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'pagination_metadata' cannot be null",
                    new System::ArgumentNullException("pagination_metadata")
                );
        }
        set
        {
            this.Properties["pagination_metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreditListByExternalIDPageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CreditListByExternalIDPageResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

[JsonConverter(typeof(ModelConverter<DataModel>))]
public sealed record class DataModel : ModelBase, IFromRaw<DataModel>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required double Balance
    {
        get
        {
            if (!this.Properties.TryGetValue("balance", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'balance' cannot be null",
                    new System::ArgumentOutOfRangeException("balance", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["balance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required System::DateTime? EffectiveDate
    {
        get
        {
            if (!this.Properties.TryGetValue("effective_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["effective_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required System::DateTime? ExpiryDate
    {
        get
        {
            if (!this.Properties.TryGetValue("expiry_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["expiry_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required List<global::Orb.Models.Customers.Credits.FilterModel> Filters
    {
        get
        {
            if (!this.Properties.TryGetValue("filters", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'filters' cannot be null",
                    new System::ArgumentOutOfRangeException("filters", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                    List<global::Orb.Models.Customers.Credits.FilterModel>
                >(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'filters' cannot be null",
                    new System::ArgumentNullException("filters")
                );
        }
        set
        {
            this.Properties["filters"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required double? MaximumInitialBalance
    {
        get
        {
            if (!this.Properties.TryGetValue("maximum_initial_balance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["maximum_initial_balance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? PerUnitCostBasis
    {
        get
        {
            if (!this.Properties.TryGetValue("per_unit_cost_basis", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["per_unit_cost_basis"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, global::Orb.Models.Customers.Credits.StatusModel> Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'status' cannot be null",
                    new System::ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Customers.Credits.StatusModel>
            >(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataModel(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static DataModel FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

[JsonConverter(typeof(ModelConverter<global::Orb.Models.Customers.Credits.FilterModel>))]
public sealed record class FilterModel
    : ModelBase,
        IFromRaw<global::Orb.Models.Customers.Credits.FilterModel>
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Customers.Credits.FieldModel> Field
    {
        get
        {
            if (!this.Properties.TryGetValue("field", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'field' cannot be null",
                    new System::ArgumentOutOfRangeException("field", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Customers.Credits.FieldModel>
            >(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["field"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Customers.Credits.OperatorModel> Operator
    {
        get
        {
            if (!this.Properties.TryGetValue("operator", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Customers.Credits.OperatorModel>
            >(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["operator"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The IDs or values that match this filter.
    /// </summary>
    public required List<string> Values
    {
        get
        {
            if (!this.Properties.TryGetValue("values", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'values' cannot be null",
                    new System::ArgumentOutOfRangeException("values", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'values' cannot be null",
                    new System::ArgumentNullException("values")
                );
        }
        set
        {
            this.Properties["values"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Field.Validate();
        this.Operator.Validate();
        _ = this.Values;
    }

    public FilterModel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FilterModel(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Customers.Credits.FilterModel FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Customers.Credits.FieldModelConverter))]
public enum FieldModel
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class FieldModelConverter : JsonConverter<global::Orb.Models.Customers.Credits.FieldModel>
{
    public override global::Orb.Models.Customers.Credits.FieldModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => global::Orb.Models.Customers.Credits.FieldModel.PriceID,
            "item_id" => global::Orb.Models.Customers.Credits.FieldModel.ItemID,
            "price_type" => global::Orb.Models.Customers.Credits.FieldModel.PriceType,
            "currency" => global::Orb.Models.Customers.Credits.FieldModel.Currency,
            "pricing_unit_id" => global::Orb.Models.Customers.Credits.FieldModel.PricingUnitID,
            _ => (global::Orb.Models.Customers.Credits.FieldModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Customers.Credits.FieldModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Customers.Credits.FieldModel.PriceID => "price_id",
                global::Orb.Models.Customers.Credits.FieldModel.ItemID => "item_id",
                global::Orb.Models.Customers.Credits.FieldModel.PriceType => "price_type",
                global::Orb.Models.Customers.Credits.FieldModel.Currency => "currency",
                global::Orb.Models.Customers.Credits.FieldModel.PricingUnitID => "pricing_unit_id",
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
[JsonConverter(typeof(global::Orb.Models.Customers.Credits.OperatorModelConverter))]
public enum OperatorModel
{
    Includes,
    Excludes,
}

sealed class OperatorModelConverter
    : JsonConverter<global::Orb.Models.Customers.Credits.OperatorModel>
{
    public override global::Orb.Models.Customers.Credits.OperatorModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => global::Orb.Models.Customers.Credits.OperatorModel.Includes,
            "excludes" => global::Orb.Models.Customers.Credits.OperatorModel.Excludes,
            _ => (global::Orb.Models.Customers.Credits.OperatorModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Customers.Credits.OperatorModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Customers.Credits.OperatorModel.Includes => "includes",
                global::Orb.Models.Customers.Credits.OperatorModel.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(global::Orb.Models.Customers.Credits.StatusModelConverter))]
public enum StatusModel
{
    Active,
    PendingPayment,
}

sealed class StatusModelConverter : JsonConverter<global::Orb.Models.Customers.Credits.StatusModel>
{
    public override global::Orb.Models.Customers.Credits.StatusModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => global::Orb.Models.Customers.Credits.StatusModel.Active,
            "pending_payment" => global::Orb.Models.Customers.Credits.StatusModel.PendingPayment,
            _ => (global::Orb.Models.Customers.Credits.StatusModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Customers.Credits.StatusModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Customers.Credits.StatusModel.Active => "active",
                global::Orb.Models.Customers.Credits.StatusModel.PendingPayment =>
                    "pending_payment",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
