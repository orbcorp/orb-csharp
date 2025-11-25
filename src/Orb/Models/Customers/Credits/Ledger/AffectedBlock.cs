using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers.Credits.Ledger;

[JsonConverter(typeof(ModelConverter<AffectedBlock, AffectedBlockFromRaw>))]
public sealed record class AffectedBlock : ModelBase
{
    public required string ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
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
        init
        {
            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required System::DateTimeOffset? ExpiryDate
    {
        get
        {
            if (!this._rawData.TryGetValue("expiry_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["expiry_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required List<global::Orb.Models.Customers.Credits.Ledger.Filter1> Filters
    {
        get
        {
            if (!this._rawData.TryGetValue("filters", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'filters' cannot be null",
                    new System::ArgumentOutOfRangeException("filters", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                    List<global::Orb.Models.Customers.Credits.Ledger.Filter1>
                >(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'filters' cannot be null",
                    new System::ArgumentNullException("filters")
                );
        }
        init
        {
            this._rawData["filters"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? PerUnitCostBasis
    {
        get
        {
            if (!this._rawData.TryGetValue("per_unit_cost_basis", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["per_unit_cost_basis"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.ExpiryDate;
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        _ = this.PerUnitCostBasis;
    }

    public AffectedBlock() { }

    public AffectedBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AffectedBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AffectedBlock FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AffectedBlockFromRaw : IFromRaw<AffectedBlock>
{
    public AffectedBlock FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AffectedBlock.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Customers.Credits.Ledger.Filter1,
        global::Orb.Models.Customers.Credits.Ledger.Filter1FromRaw
    >)
)]
public sealed record class Filter1 : ModelBase
{
    /// <summary>
    /// The property of the price to filter on.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Customers.Credits.Ledger.Filter1Field> Field
    {
        get
        {
            if (!this._rawData.TryGetValue("field", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'field' cannot be null",
                    new System::ArgumentOutOfRangeException("field", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Customers.Credits.Ledger.Filter1Field>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["field"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<
        string,
        global::Orb.Models.Customers.Credits.Ledger.Filter1Operator
    > Operator
    {
        get
        {
            if (!this._rawData.TryGetValue("operator", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Customers.Credits.Ledger.Filter1Operator>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["operator"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("values", out JsonElement element))
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
        init
        {
            this._rawData["values"] = JsonSerializer.SerializeToElement(
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

    public Filter1() { }

    public Filter1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Customers.Credits.Ledger.Filter1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Filter1FromRaw : IFromRaw<global::Orb.Models.Customers.Credits.Ledger.Filter1>
{
    public global::Orb.Models.Customers.Credits.Ledger.Filter1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Customers.Credits.Ledger.Filter1.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price to filter on.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Customers.Credits.Ledger.Filter1FieldConverter))]
public enum Filter1Field
{
    PriceID,
    ItemID,
    PriceType,
    Currency,
    PricingUnitID,
}

sealed class Filter1FieldConverter
    : JsonConverter<global::Orb.Models.Customers.Credits.Ledger.Filter1Field>
{
    public override global::Orb.Models.Customers.Credits.Ledger.Filter1Field Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "price_id" => global::Orb.Models.Customers.Credits.Ledger.Filter1Field.PriceID,
            "item_id" => global::Orb.Models.Customers.Credits.Ledger.Filter1Field.ItemID,
            "price_type" => global::Orb.Models.Customers.Credits.Ledger.Filter1Field.PriceType,
            "currency" => global::Orb.Models.Customers.Credits.Ledger.Filter1Field.Currency,
            "pricing_unit_id" => global::Orb
                .Models
                .Customers
                .Credits
                .Ledger
                .Filter1Field
                .PricingUnitID,
            _ => (global::Orb.Models.Customers.Credits.Ledger.Filter1Field)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Customers.Credits.Ledger.Filter1Field value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Customers.Credits.Ledger.Filter1Field.PriceID => "price_id",
                global::Orb.Models.Customers.Credits.Ledger.Filter1Field.ItemID => "item_id",
                global::Orb.Models.Customers.Credits.Ledger.Filter1Field.PriceType => "price_type",
                global::Orb.Models.Customers.Credits.Ledger.Filter1Field.Currency => "currency",
                global::Orb.Models.Customers.Credits.Ledger.Filter1Field.PricingUnitID =>
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
[JsonConverter(typeof(global::Orb.Models.Customers.Credits.Ledger.Filter1OperatorConverter))]
public enum Filter1Operator
{
    Includes,
    Excludes,
}

sealed class Filter1OperatorConverter
    : JsonConverter<global::Orb.Models.Customers.Credits.Ledger.Filter1Operator>
{
    public override global::Orb.Models.Customers.Credits.Ledger.Filter1Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => global::Orb.Models.Customers.Credits.Ledger.Filter1Operator.Includes,
            "excludes" => global::Orb.Models.Customers.Credits.Ledger.Filter1Operator.Excludes,
            _ => (global::Orb.Models.Customers.Credits.Ledger.Filter1Operator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Customers.Credits.Ledger.Filter1Operator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Customers.Credits.Ledger.Filter1Operator.Includes => "includes",
                global::Orb.Models.Customers.Credits.Ledger.Filter1Operator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
