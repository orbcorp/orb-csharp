using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using GroupingValueVariants = Orb.Models.Prices.EvaluatePriceGroupProperties.GroupingValueVariants;

namespace Orb.Models.Prices.EvaluatePriceGroupProperties;

[JsonConverter(typeof(GroupingValueConverter))]
public abstract record class GroupingValue
{
    internal GroupingValue() { }

    public static implicit operator GroupingValue(string value) =>
        new GroupingValueVariants::String(value);

    public static implicit operator GroupingValue(double value) =>
        new GroupingValueVariants::Double(value);

    public static implicit operator GroupingValue(bool value) =>
        new GroupingValueVariants::Bool(value);

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as GroupingValueVariants::String)?.Value;
        return value != null;
    }

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as GroupingValueVariants::Double)?.Value;
        return value != null;
    }

    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = (this as GroupingValueVariants::Bool)?.Value;
        return value != null;
    }

    public void Switch(
        Action<GroupingValueVariants::String> @string,
        Action<GroupingValueVariants::Double> @double,
        Action<GroupingValueVariants::Bool> @bool
    )
    {
        switch (this)
        {
            case GroupingValueVariants::String inner:
                @string(inner);
                break;
            case GroupingValueVariants::Double inner:
                @double(inner);
                break;
            case GroupingValueVariants::Bool inner:
                @bool(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<GroupingValueVariants::String, T> @string,
        Func<GroupingValueVariants::Double, T> @double,
        Func<GroupingValueVariants::Bool, T> @bool
    )
    {
        return this switch
        {
            GroupingValueVariants::String inner => @string(inner),
            GroupingValueVariants::Double inner => @double(inner),
            GroupingValueVariants::Bool inner => @bool(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class GroupingValueConverter : JsonConverter<GroupingValue>
{
    public override GroupingValue? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new GroupingValueVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            return new GroupingValueVariants::Double(
                JsonSerializer.Deserialize<double>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            return new GroupingValueVariants::Bool(
                JsonSerializer.Deserialize<bool>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        GroupingValue value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            GroupingValueVariants::String(var @string) => @string,
            GroupingValueVariants::Double(var @double) => @double,
            GroupingValueVariants::Bool(var @bool) => @bool,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
