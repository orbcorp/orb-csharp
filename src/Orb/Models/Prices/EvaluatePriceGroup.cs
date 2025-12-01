using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Prices;

[JsonConverter(typeof(ModelConverter<EvaluatePriceGroup, EvaluatePriceGroupFromRaw>))]
public sealed record class EvaluatePriceGroup : ModelBase
{
    /// <summary>
    /// The price's output for the group
    /// </summary>
    public required string Amount
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "amount"); }
        init { ModelBase.Set(this._rawData, "amount", value); }
    }

    /// <summary>
    /// The values for the group in the order specified by `grouping_keys`
    /// </summary>
    public required IReadOnlyList<GroupingValue> GroupingValues
    {
        get
        {
            return ModelBase.GetNotNullClass<List<GroupingValue>>(this.RawData, "grouping_values");
        }
        init { ModelBase.Set(this._rawData, "grouping_values", value); }
    }

    /// <summary>
    /// The price's usage quantity for the group
    /// </summary>
    public required double Quantity
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "quantity"); }
        init { ModelBase.Set(this._rawData, "quantity", value); }
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

    public EvaluatePriceGroup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EvaluatePriceGroup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static EvaluatePriceGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EvaluatePriceGroupFromRaw : IFromRaw<EvaluatePriceGroup>
{
    public EvaluatePriceGroup FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EvaluatePriceGroup.FromRawUnchecked(rawData);
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

    public virtual bool Equals(GroupingValue? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
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
