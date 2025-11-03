using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using BodyProperties = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties.BodyProperties;

namespace Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDParamsProperties;

[JsonConverter(typeof(BodyConverter))]
public record class Body
{
    public object Value { get; private init; }

    public double? Amount
    {
        get
        {
            return Match<double?>(
                increment: (x) => x.Amount,
                decrement: (x) => x.Amount,
                expirationChange: (x) => x.Amount,
                void1: (x) => x.Amount,
                amendment: (x) => x.Amount
            );
        }
    }

    public string? Currency
    {
        get
        {
            return Match<string?>(
                increment: (x) => x.Currency,
                decrement: (x) => x.Currency,
                expirationChange: (x) => x.Currency,
                void1: (x) => x.Currency,
                amendment: (x) => x.Currency
            );
        }
    }

    public string? Description
    {
        get
        {
            return Match<string?>(
                increment: (x) => x.Description,
                decrement: (x) => x.Description,
                expirationChange: (x) => x.Description,
                void1: (x) => x.Description,
                amendment: (x) => x.Description
            );
        }
    }

    public DateTime? ExpiryDate
    {
        get
        {
            return Match<DateTime?>(
                increment: (x) => x.ExpiryDate,
                decrement: (_) => null,
                expirationChange: (x) => x.ExpiryDate,
                void1: (_) => null,
                amendment: (_) => null
            );
        }
    }

    public string? BlockID
    {
        get
        {
            return Match<string?>(
                increment: (_) => null,
                decrement: (_) => null,
                expirationChange: (x) => x.BlockID,
                void1: (x) => x.BlockID,
                amendment: (x) => x.BlockID
            );
        }
    }

    public Body(BodyProperties::Increment value)
    {
        Value = value;
    }

    public Body(BodyProperties::Decrement value)
    {
        Value = value;
    }

    public Body(BodyProperties::ExpirationChange value)
    {
        Value = value;
    }

    public Body(BodyProperties::Void value)
    {
        Value = value;
    }

    public Body(BodyProperties::Amendment value)
    {
        Value = value;
    }

    Body(UnknownVariant value)
    {
        Value = value;
    }

    public static Body CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickIncrement([NotNullWhen(true)] out BodyProperties::Increment? value)
    {
        value = this.Value as BodyProperties::Increment;
        return value != null;
    }

    public bool TryPickDecrement([NotNullWhen(true)] out BodyProperties::Decrement? value)
    {
        value = this.Value as BodyProperties::Decrement;
        return value != null;
    }

    public bool TryPickExpirationChange(
        [NotNullWhen(true)] out BodyProperties::ExpirationChange? value
    )
    {
        value = this.Value as BodyProperties::ExpirationChange;
        return value != null;
    }

    public bool TryPickVoid([NotNullWhen(true)] out BodyProperties::Void? value)
    {
        value = this.Value as BodyProperties::Void;
        return value != null;
    }

    public bool TryPickAmendment([NotNullWhen(true)] out BodyProperties::Amendment? value)
    {
        value = this.Value as BodyProperties::Amendment;
        return value != null;
    }

    public void Switch(
        Action<BodyProperties::Increment> increment,
        Action<BodyProperties::Decrement> decrement,
        Action<BodyProperties::ExpirationChange> expirationChange,
        Action<BodyProperties::Void> void1,
        Action<BodyProperties::Amendment> amendment
    )
    {
        switch (this.Value)
        {
            case BodyProperties::Increment value:
                increment(value);
                break;
            case BodyProperties::Decrement value:
                decrement(value);
                break;
            case BodyProperties::ExpirationChange value:
                expirationChange(value);
                break;
            case BodyProperties::Void value:
                void1(value);
                break;
            case BodyProperties::Amendment value:
                amendment(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of Body");
        }
    }

    public T Match<T>(
        Func<BodyProperties::Increment, T> increment,
        Func<BodyProperties::Decrement, T> decrement,
        Func<BodyProperties::ExpirationChange, T> expirationChange,
        Func<BodyProperties::Void, T> void1,
        Func<BodyProperties::Amendment, T> amendment
    )
    {
        return this.Value switch
        {
            BodyProperties::Increment value => increment(value),
            BodyProperties::Decrement value => decrement(value),
            BodyProperties::ExpirationChange value => expirationChange(value),
            BodyProperties::Void value => void1(value),
            BodyProperties::Amendment value => amendment(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of Body"),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of Body");
        }
    }

    record struct UnknownVariant(JsonElement value);
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
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BodyProperties::Increment>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Body(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'BodyProperties::Increment'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "decrement":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BodyProperties::Decrement>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Body(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'BodyProperties::Decrement'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "expiration_change":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BodyProperties::ExpirationChange>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Body(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'BodyProperties::ExpirationChange'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "void":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BodyProperties::Void>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Body(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'BodyProperties::Void'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "amendment":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BodyProperties::Amendment>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Body(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'BodyProperties::Amendment'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Body value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
