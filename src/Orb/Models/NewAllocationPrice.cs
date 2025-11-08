using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models;

[JsonConverter(typeof(ModelConverter<NewAllocationPrice>))]
public sealed record class NewAllocationPrice : ModelBase, IFromRaw<NewAllocationPrice>
{
    /// <summary>
    /// An amount of the currency to allocate to the customer at the specified cadence.
    /// </summary>
    public required string Amount
    {
        get
        {
            if (!this._properties.TryGetValue("amount", out JsonElement element))
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
            this._properties["amount"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("cadence", out JsonElement element))
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
            this._properties["cadence"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("currency", out JsonElement element))
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
            this._properties["currency"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("custom_expiration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CustomExpiration?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["custom_expiration"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("expires_at_end_of_cadence", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["expires_at_end_of_cadence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The filters that determine which items the allocation applies to.
    /// </summary>
    public List<Filter11>? Filters
    {
        get
        {
            if (!this._properties.TryGetValue("filters", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Filter11>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["filters"] = JsonSerializer.SerializeToElement(
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
    }

    public NewAllocationPrice() { }

    public NewAllocationPrice(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NewAllocationPrice(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static NewAllocationPrice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
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
[JsonConverter(typeof(ModelConverter<Filter11>))]
public sealed record class Filter11 : ModelBase, IFromRaw<Filter11>
{
    /// <summary>
    /// The property of the price the block applies to. Only item_id is supported.
    /// </summary>
    public required ApiEnum<string, Field11> Field
    {
        get
        {
            if (!this._properties.TryGetValue("field", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'field' cannot be null",
                    new System::ArgumentOutOfRangeException("field", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Field11>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["field"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, Operator11> Operator
    {
        get
        {
            if (!this._properties.TryGetValue("operator", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Operator11>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["operator"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("values", out JsonElement element))
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
            this._properties["values"] = JsonSerializer.SerializeToElement(
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

    public Filter11(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter11(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Filter11 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The property of the price the block applies to. Only item_id is supported.
/// </summary>
[JsonConverter(typeof(Field11Converter))]
public enum Field11
{
    ItemID,
}

sealed class Field11Converter : JsonConverter<Field11>
{
    public override Field11 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "item_id" => Field11.ItemID,
            _ => (Field11)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Field11 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Field11.ItemID => "item_id",
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
[JsonConverter(typeof(Operator11Converter))]
public enum Operator11
{
    Includes,
    Excludes,
}

sealed class Operator11Converter : JsonConverter<Operator11>
{
    public override Operator11 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => Operator11.Includes,
            "excludes" => Operator11.Excludes,
            _ => (Operator11)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Operator11 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Operator11.Includes => "includes",
                Operator11.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
