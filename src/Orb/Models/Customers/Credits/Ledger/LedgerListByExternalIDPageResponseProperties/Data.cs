using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DataVariants = Orb.Models.Customers.Credits.Ledger.LedgerListByExternalIDPageResponseProperties.DataVariants;

namespace Orb.Models.Customers.Credits.Ledger.LedgerListByExternalIDPageResponseProperties;

/// <summary>
/// The [Credit Ledger Entry resource](/product-catalog/prepurchase) models prepaid
/// credits within Orb.
/// </summary>
[JsonConverter(typeof(DataConverter))]
public abstract record class Data
{
    internal Data() { }

    public static implicit operator Data(IncrementLedgerEntry value) =>
        new DataVariants::IncrementLedgerEntry(value);

    public static implicit operator Data(DecrementLedgerEntry value) =>
        new DataVariants::DecrementLedgerEntry(value);

    public static implicit operator Data(ExpirationChangeLedgerEntry value) =>
        new DataVariants::ExpirationChangeLedgerEntry(value);

    public static implicit operator Data(CreditBlockExpiryLedgerEntry value) =>
        new DataVariants::CreditBlockExpiryLedgerEntry(value);

    public static implicit operator Data(VoidLedgerEntry value) =>
        new DataVariants::VoidLedgerEntry(value);

    public static implicit operator Data(VoidInitiatedLedgerEntry value) =>
        new DataVariants::VoidInitiatedLedgerEntry(value);

    public static implicit operator Data(AmendmentLedgerEntry value) =>
        new DataVariants::AmendmentLedgerEntry(value);

    public bool TryPickIncrementLedgerEntry([NotNullWhen(true)] out IncrementLedgerEntry? value)
    {
        value = (this as DataVariants::IncrementLedgerEntry)?.Value;
        return value != null;
    }

    public bool TryPickDecrementLedgerEntry([NotNullWhen(true)] out DecrementLedgerEntry? value)
    {
        value = (this as DataVariants::DecrementLedgerEntry)?.Value;
        return value != null;
    }

    public bool TryPickExpirationChangeLedgerEntry(
        [NotNullWhen(true)] out ExpirationChangeLedgerEntry? value
    )
    {
        value = (this as DataVariants::ExpirationChangeLedgerEntry)?.Value;
        return value != null;
    }

    public bool TryPickCreditBlockExpiryLedgerEntry(
        [NotNullWhen(true)] out CreditBlockExpiryLedgerEntry? value
    )
    {
        value = (this as DataVariants::CreditBlockExpiryLedgerEntry)?.Value;
        return value != null;
    }

    public bool TryPickVoidLedgerEntry([NotNullWhen(true)] out VoidLedgerEntry? value)
    {
        value = (this as DataVariants::VoidLedgerEntry)?.Value;
        return value != null;
    }

    public bool TryPickVoidInitiatedLedgerEntry(
        [NotNullWhen(true)] out VoidInitiatedLedgerEntry? value
    )
    {
        value = (this as DataVariants::VoidInitiatedLedgerEntry)?.Value;
        return value != null;
    }

    public bool TryPickAmendmentLedgerEntry([NotNullWhen(true)] out AmendmentLedgerEntry? value)
    {
        value = (this as DataVariants::AmendmentLedgerEntry)?.Value;
        return value != null;
    }

    public void Switch(
        Action<DataVariants::IncrementLedgerEntry> incrementLedgerEntry,
        Action<DataVariants::DecrementLedgerEntry> decrementLedgerEntry,
        Action<DataVariants::ExpirationChangeLedgerEntry> expirationChangeLedgerEntry,
        Action<DataVariants::CreditBlockExpiryLedgerEntry> creditBlockExpiryLedgerEntry,
        Action<DataVariants::VoidLedgerEntry> voidLedgerEntry,
        Action<DataVariants::VoidInitiatedLedgerEntry> voidInitiatedLedgerEntry,
        Action<DataVariants::AmendmentLedgerEntry> amendmentLedgerEntry
    )
    {
        switch (this)
        {
            case DataVariants::IncrementLedgerEntry inner:
                incrementLedgerEntry(inner);
                break;
            case DataVariants::DecrementLedgerEntry inner:
                decrementLedgerEntry(inner);
                break;
            case DataVariants::ExpirationChangeLedgerEntry inner:
                expirationChangeLedgerEntry(inner);
                break;
            case DataVariants::CreditBlockExpiryLedgerEntry inner:
                creditBlockExpiryLedgerEntry(inner);
                break;
            case DataVariants::VoidLedgerEntry inner:
                voidLedgerEntry(inner);
                break;
            case DataVariants::VoidInitiatedLedgerEntry inner:
                voidInitiatedLedgerEntry(inner);
                break;
            case DataVariants::AmendmentLedgerEntry inner:
                amendmentLedgerEntry(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<DataVariants::IncrementLedgerEntry, T> incrementLedgerEntry,
        Func<DataVariants::DecrementLedgerEntry, T> decrementLedgerEntry,
        Func<DataVariants::ExpirationChangeLedgerEntry, T> expirationChangeLedgerEntry,
        Func<DataVariants::CreditBlockExpiryLedgerEntry, T> creditBlockExpiryLedgerEntry,
        Func<DataVariants::VoidLedgerEntry, T> voidLedgerEntry,
        Func<DataVariants::VoidInitiatedLedgerEntry, T> voidInitiatedLedgerEntry,
        Func<DataVariants::AmendmentLedgerEntry, T> amendmentLedgerEntry
    )
    {
        return this switch
        {
            DataVariants::IncrementLedgerEntry inner => incrementLedgerEntry(inner),
            DataVariants::DecrementLedgerEntry inner => decrementLedgerEntry(inner),
            DataVariants::ExpirationChangeLedgerEntry inner => expirationChangeLedgerEntry(inner),
            DataVariants::CreditBlockExpiryLedgerEntry inner => creditBlockExpiryLedgerEntry(inner),
            DataVariants::VoidLedgerEntry inner => voidLedgerEntry(inner),
            DataVariants::VoidInitiatedLedgerEntry inner => voidInitiatedLedgerEntry(inner),
            DataVariants::AmendmentLedgerEntry inner => amendmentLedgerEntry(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class DataConverter : JsonConverter<Data>
{
    public override Data? Read(
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
                    var deserialized = JsonSerializer.Deserialize<IncrementLedgerEntry>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new DataVariants::IncrementLedgerEntry(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<DecrementLedgerEntry>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new DataVariants::DecrementLedgerEntry(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<ExpirationChangeLedgerEntry>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new DataVariants::ExpirationChangeLedgerEntry(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "credit_block_expiry":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<CreditBlockExpiryLedgerEntry>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new DataVariants::CreditBlockExpiryLedgerEntry(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<VoidLedgerEntry>(json, options);
                    if (deserialized != null)
                    {
                        return new DataVariants::VoidLedgerEntry(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "void_initiated":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<VoidInitiatedLedgerEntry>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new DataVariants::VoidInitiatedLedgerEntry(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<AmendmentLedgerEntry>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new DataVariants::AmendmentLedgerEntry(deserialized);
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

    public override void Write(Utf8JsonWriter writer, Data value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            DataVariants::IncrementLedgerEntry(var incrementLedgerEntry) => incrementLedgerEntry,
            DataVariants::DecrementLedgerEntry(var decrementLedgerEntry) => decrementLedgerEntry,
            DataVariants::ExpirationChangeLedgerEntry(var expirationChangeLedgerEntry) =>
                expirationChangeLedgerEntry,
            DataVariants::CreditBlockExpiryLedgerEntry(var creditBlockExpiryLedgerEntry) =>
                creditBlockExpiryLedgerEntry,
            DataVariants::VoidLedgerEntry(var voidLedgerEntry) => voidLedgerEntry,
            DataVariants::VoidInitiatedLedgerEntry(var voidInitiatedLedgerEntry) =>
                voidInitiatedLedgerEntry,
            DataVariants::AmendmentLedgerEntry(var amendmentLedgerEntry) => amendmentLedgerEntry,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
