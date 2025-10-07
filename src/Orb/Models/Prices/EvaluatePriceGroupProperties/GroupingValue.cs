using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;

namespace Orb.Models.Prices.EvaluatePriceGroupProperties;

[JsonConverter(typeof(GroupingValueConverter))]
public record class GroupingValue
{
    public object Value { get; private init; }

    public GroupingValue(string value)
    {
        Value = value;
    }

    public GroupingValue(double value)
    {
        Value = value;
    }

    public GroupingValue(bool value)
    {
        Value = value;
    }

    GroupingValue(UnknownVariant value)
    {
        Value = value;
    }

    public static GroupingValue CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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

    public void Switch(Action<string> @string, Action<double> @double, Action<bool> @bool)
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

    public T Match<T>(Func<string, T> @string, Func<double, T> @double, Func<bool, T> @bool)
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

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of GroupingValue");
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class GroupingValueConverter : JsonConverter<GroupingValue>
{
    public override GroupingValue? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<OrbInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new GroupingValue(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException("Data does not match union variant 'string'", e)
            );
        }

        try
        {
            return new GroupingValue(JsonSerializer.Deserialize<double>(ref reader, options));
        }
        catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException("Data does not match union variant 'double'", e)
            );
        }

        try
        {
            return new GroupingValue(JsonSerializer.Deserialize<bool>(ref reader, options));
        }
        catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException("Data does not match union variant 'bool'", e)
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        GroupingValue value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
