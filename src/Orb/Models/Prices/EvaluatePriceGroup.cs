using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Prices;

[JsonConverter(typeof(ModelConverter<EvaluatePriceGroup>))]
public sealed record class EvaluatePriceGroup : ModelBase, IFromRaw<EvaluatePriceGroup>
{
    /// <summary>
    /// The price's output for the group
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
    /// The values for the group in the order specified by `grouping_keys`
    /// </summary>
    public required List<GroupingValue> GroupingValues
    {
        get
        {
            if (!this._properties.TryGetValue("grouping_values", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'grouping_values' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "grouping_values",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<GroupingValue>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'grouping_values' cannot be null",
                    new System::ArgumentNullException("grouping_values")
                );
        }
        init
        {
            this._properties["grouping_values"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The price's usage quantity for the group
    /// </summary>
    public required double Quantity
    {
        get
        {
            if (!this._properties.TryGetValue("quantity", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'quantity' cannot be null",
                    new System::ArgumentOutOfRangeException("quantity", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Amount;
        foreach (var item in this.GroupingValues)
        {
            item.Validate();
        }
        _ = this.Quantity;
    }

    public EvaluatePriceGroup() { }

    public EvaluatePriceGroup(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EvaluatePriceGroup(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static EvaluatePriceGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(GroupingValueConverter))]
public record class GroupingValue
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public GroupingValue(string value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public GroupingValue(double value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public GroupingValue(bool value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public GroupingValue(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    public void Switch(
        System::Action<string> @string,
        System::Action<double> @double,
        System::Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of GroupingValue"
                );
        }
    }

    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of GroupingValue"
            ),
        };
    }

    public static implicit operator GroupingValue(string value) => new(value);

    public static implicit operator GroupingValue(double value) => new(value);

    public static implicit operator GroupingValue(bool value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of GroupingValue");
        }
    }
}

sealed class GroupingValueConverter : JsonConverter<GroupingValue>
{
    public override GroupingValue? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(json, options);
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(json, options));
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(json, options));
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        GroupingValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
