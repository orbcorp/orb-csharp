using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<NewAllocationPrice, NewAllocationPriceFromRaw>))]
public sealed record class NewAllocationPrice : ModelBase
{
    /// <summary>
    /// An amount of the currency to allocate to the customer at the specified cadence.
    /// </summary>
    public required string Amount
    {
        get
        {
            if (!this._rawData.TryGetValue("amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new System::ArgumentOutOfRangeException("amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new System::ArgumentNullException("amount")
                );
        }
        init
        {
            this._rawData["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The cadence at which to allocate the amount to the customer.
    /// </summary>
    public required ApiEnum<string, Cadence> Cadence
    {
        get
        {
            if (!this._rawData.TryGetValue("cadence", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'cadence' cannot be null",
                    new System::ArgumentOutOfRangeException("cadence", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Cadence>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 4217 currency string or a custom pricing unit identifier in which to
    /// bill this price.
    /// </summary>
    public required string Currency
    {
        get
        {
            if (!this._rawData.TryGetValue("currency", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentNullException("currency")
                );
        }
        init
        {
            this._rawData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The custom expiration for the allocation.
    /// </summary>
    public CustomExpiration? CustomExpiration
    {
        get
        {
            if (!this._rawData.TryGetValue("custom_expiration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CustomExpiration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["custom_expiration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether the allocated amount should expire at the end of the cadence or roll
    /// over to the next period. Set to null if using custom_expiration.
    /// </summary>
    public bool? ExpiresAtEndOfCadence
    {
        get
        {
            if (!this._rawData.TryGetValue("expires_at_end_of_cadence", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["expires_at_end_of_cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The filters that determine which items the allocation applies to.
    /// </summary>
    public IReadOnlyList<Filter11>? Filters
    {
        get
        {
            if (!this._rawData.TryGetValue("filters", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Filter11>?>(
                element,
                ModelBase.SerializerOptions
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

    /// <summary>
    /// The item ID that line items representing charges for this allocation will
    /// be associated with. If not provided, the default allocation item for the
    /// currency will be used (e.g. 'Included Allocation (USD)').
    /// </summary>
    public string? ItemID
    {
        get
        {
            if (!this._rawData.TryGetValue("item_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The (per-unit) cost basis of each created block. If non-zero, a customer
    /// will be invoiced according to the quantity and per unit cost basis specified
    /// for the allocation each cadence.
    /// </summary>
    public string? PerUnitCostBasis
    {
        get
        {
            if (!this._rawData.TryGetValue("per_unit_cost_basis", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["per_unit_cost_basis"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Amount;
        this.Cadence.Validate();
        _ = this.Currency;
        this.CustomExpiration?.Validate();
        _ = this.ExpiresAtEndOfCadence;
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
        _ = this.ItemID;
        _ = this.PerUnitCostBasis;
    }

    public NewAllocationPrice() { }

    public NewAllocationPrice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewAllocationPrice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static NewAllocationPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NewAllocationPriceFromRaw : IFromRaw<NewAllocationPrice>
{
    public NewAllocationPrice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NewAllocationPrice.FromRawUnchecked(rawData);
}

/// <summary>
/// The cadence at which to allocate the amount to the customer.
/// </summary>
[JsonConverter(typeof(CadenceConverter))]
public enum Cadence
{
    OneTime,
    Monthly,
    Quarterly,
    SemiAnnual,
    Annual,
}

sealed class CadenceConverter : JsonConverter<Cadence>
{
    public override Cadence Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "one_time" => Cadence.OneTime,
            "monthly" => Cadence.Monthly,
            "quarterly" => Cadence.Quarterly,
            "semi_annual" => Cadence.SemiAnnual,
            "annual" => Cadence.Annual,
            _ => (Cadence)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Cadence value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Cadence.OneTime => "one_time",
                Cadence.Monthly => "monthly",
                Cadence.Quarterly => "quarterly",
                Cadence.SemiAnnual => "semi_annual",
                Cadence.Annual => "annual",
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
[JsonConverter(typeof(ModelConverter<Filter11, Filter11FromRaw>))]
public sealed record class Filter11 : ModelBase
{
    /// <summary>
    /// The property of the price the block applies to. Only item_id is supported.
    /// </summary>
    public required ApiEnum<string, Filter11Field> Field
    {
        get
        {
            if (!this._rawData.TryGetValue("field", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'field' cannot be null",
                    new System::ArgumentOutOfRangeException("field", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Filter11Field>>(
                element,
                ModelBase.SerializerOptions
            );
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
    public required ApiEnum<string, Filter11Operator> Operator
    {
        get
        {
            if (!this._rawData.TryGetValue("operator", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Filter11Operator>>(
                element,
                ModelBase.SerializerOptions
            );
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
    public required IReadOnlyList<string> Values
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

    public Filter11() { }

    public Filter11(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter11(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Filter11 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Filter11FromRaw : IFromRaw<Filter11>
{
    public Filter11 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Filter11.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price the block applies to. Only item_id is supported.
/// </summary>
[JsonConverter(typeof(Filter11FieldConverter))]
public enum Filter11Field
{
    ItemID,
}

sealed class Filter11FieldConverter : JsonConverter<Filter11Field>
{
    public override Filter11Field Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "item_id" => Filter11Field.ItemID,
            _ => (Filter11Field)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter11Field value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter11Field.ItemID => "item_id",
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
[JsonConverter(typeof(Filter11OperatorConverter))]
public enum Filter11Operator
{
    Includes,
    Excludes,
}

sealed class Filter11OperatorConverter : JsonConverter<Filter11Operator>
{
    public override Filter11Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => Filter11Operator.Includes,
            "excludes" => Filter11Operator.Excludes,
            _ => (Filter11Operator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Filter11Operator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Filter11Operator.Includes => "includes",
                Filter11Operator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
