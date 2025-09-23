using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using BodyProperties = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryParamsProperties.BodyProperties;
using BodyVariants = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryParamsProperties.BodyVariants;

namespace Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryParamsProperties;

[JsonConverter(typeof(BodyConverter))]
public abstract record class Body
{
    internal Body() { }

    public static implicit operator Body(BodyProperties::Increment value) =>
        new BodyVariants::Increment(value);

    public static implicit operator Body(BodyProperties::Decrement value) =>
        new BodyVariants::Decrement(value);

    public static implicit operator Body(BodyProperties::ExpirationChange value) =>
        new BodyVariants::ExpirationChange(value);

    public static implicit operator Body(BodyProperties::Void value) =>
        new BodyVariants::Void(value);

    public static implicit operator Body(BodyProperties::Amendment value) =>
        new BodyVariants::Amendment(value);

    public bool TryPickIncrement([NotNullWhen(true)] out BodyProperties::Increment? value)
    {
        value = (this as BodyVariants::Increment)?.Value;
        return value != null;
    }

    public bool TryPickDecrement([NotNullWhen(true)] out BodyProperties::Decrement? value)
    {
        value = (this as BodyVariants::Decrement)?.Value;
        return value != null;
    }

    public bool TryPickExpirationChange(
        [NotNullWhen(true)] out BodyProperties::ExpirationChange? value
    )
    {
        value = (this as BodyVariants::ExpirationChange)?.Value;
        return value != null;
    }

    public bool TryPickVoid([NotNullWhen(true)] out BodyProperties::Void? value)
    {
        value = (this as BodyVariants::Void)?.Value;
        return value != null;
    }

    public bool TryPickAmendment([NotNullWhen(true)] out BodyProperties::Amendment? value)
    {
        value = (this as BodyVariants::Amendment)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BodyVariants::Increment> increment,
        Action<BodyVariants::Decrement> decrement,
        Action<BodyVariants::ExpirationChange> expirationChange,
        Action<BodyVariants::Void> void1,
        Action<BodyVariants::Amendment> amendment
    )
    {
        switch (this)
        {
            case BodyVariants::Increment inner:
                increment(inner);
                break;
            case BodyVariants::Decrement inner:
                decrement(inner);
                break;
            case BodyVariants::ExpirationChange inner:
                expirationChange(inner);
                break;
            case BodyVariants::Void inner:
                void1(inner);
                break;
            case BodyVariants::Amendment inner:
                amendment(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BodyVariants::Increment, T> increment,
        Func<BodyVariants::Decrement, T> decrement,
        Func<BodyVariants::ExpirationChange, T> expirationChange,
        Func<BodyVariants::Void, T> void1,
        Func<BodyVariants::Amendment, T> amendment
    )
    {
        return this switch
        {
            BodyVariants::Increment inner => increment(inner),
            BodyVariants::Decrement inner => decrement(inner),
            BodyVariants::ExpirationChange inner => expirationChange(inner),
            BodyVariants::Void inner => void1(inner),
            BodyVariants::Amendment inner => amendment(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class BodyConverter : JsonConverter<Body>
{
    public override Body? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? entryType;
        try
        {
            entryType = json.GetProperty("entry_type").GetString();
        }
        catch
        {
            entryType = null;
        }

        switch (entryType)
        {
            case "increment":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BodyProperties::Increment>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BodyVariants::Increment(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "decrement":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BodyProperties::Decrement>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BodyVariants::Decrement(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "expiration_change":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BodyProperties::ExpirationChange>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BodyVariants::ExpirationChange(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "void":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BodyProperties::Void>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BodyVariants::Void(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "amendment":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BodyProperties::Amendment>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BodyVariants::Amendment(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new Exception();
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Body value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            BodyVariants::Increment(var increment) => increment,
            BodyVariants::Decrement(var decrement) => decrement,
            BodyVariants::ExpirationChange(var expirationChange) => expirationChange,
            BodyVariants::Void(var void1) => void1,
            BodyVariants::Amendment(var amendment) => amendment,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
