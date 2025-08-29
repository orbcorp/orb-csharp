using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LedgerCreateEntryByExternalIDResponseVariants = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryByExternalIDResponseVariants;

namespace Orb.Models.Customers.Credits.Ledger;

/// <summary>
/// The [Credit Ledger Entry resource](/product-catalog/prepurchase) models prepaid
/// credits within Orb.
/// </summary>
[JsonConverter(typeof(LedgerCreateEntryByExternalIDResponseConverter))]
public abstract record class LedgerCreateEntryByExternalIDResponse
{
    internal LedgerCreateEntryByExternalIDResponse() { }

    public static implicit operator LedgerCreateEntryByExternalIDResponse(
        IncrementLedgerEntry value
    ) => new LedgerCreateEntryByExternalIDResponseVariants::IncrementLedgerEntry(value);

    public static implicit operator LedgerCreateEntryByExternalIDResponse(
        DecrementLedgerEntry value
    ) => new LedgerCreateEntryByExternalIDResponseVariants::DecrementLedgerEntry(value);

    public static implicit operator LedgerCreateEntryByExternalIDResponse(
        ExpirationChangeLedgerEntry value
    ) => new LedgerCreateEntryByExternalIDResponseVariants::ExpirationChangeLedgerEntry(value);

    public static implicit operator LedgerCreateEntryByExternalIDResponse(
        CreditBlockExpiryLedgerEntry value
    ) => new LedgerCreateEntryByExternalIDResponseVariants::CreditBlockExpiryLedgerEntry(value);

    public static implicit operator LedgerCreateEntryByExternalIDResponse(VoidLedgerEntry value) =>
        new LedgerCreateEntryByExternalIDResponseVariants::VoidLedgerEntry(value);

    public static implicit operator LedgerCreateEntryByExternalIDResponse(
        VoidInitiatedLedgerEntry value
    ) => new LedgerCreateEntryByExternalIDResponseVariants::VoidInitiatedLedgerEntry(value);

    public static implicit operator LedgerCreateEntryByExternalIDResponse(
        AmendmentLedgerEntry value
    ) => new LedgerCreateEntryByExternalIDResponseVariants::AmendmentLedgerEntry(value);

    public bool TryPickIncrementLedgerEntry([NotNullWhen(true)] out IncrementLedgerEntry? value)
    {
        value = (
            this as LedgerCreateEntryByExternalIDResponseVariants::IncrementLedgerEntry
        )?.Value;
        return value != null;
    }

    public bool TryPickDecrementLedgerEntry([NotNullWhen(true)] out DecrementLedgerEntry? value)
    {
        value = (
            this as LedgerCreateEntryByExternalIDResponseVariants::DecrementLedgerEntry
        )?.Value;
        return value != null;
    }

    public bool TryPickExpirationChangeLedgerEntry(
        [NotNullWhen(true)] out ExpirationChangeLedgerEntry? value
    )
    {
        value = (
            this as LedgerCreateEntryByExternalIDResponseVariants::ExpirationChangeLedgerEntry
        )?.Value;
        return value != null;
    }

    public bool TryPickCreditBlockExpiryLedgerEntry(
        [NotNullWhen(true)] out CreditBlockExpiryLedgerEntry? value
    )
    {
        value = (
            this as LedgerCreateEntryByExternalIDResponseVariants::CreditBlockExpiryLedgerEntry
        )?.Value;
        return value != null;
    }

    public bool TryPickVoidLedgerEntry([NotNullWhen(true)] out VoidLedgerEntry? value)
    {
        value = (this as LedgerCreateEntryByExternalIDResponseVariants::VoidLedgerEntry)?.Value;
        return value != null;
    }

    public bool TryPickVoidInitiatedLedgerEntry(
        [NotNullWhen(true)] out VoidInitiatedLedgerEntry? value
    )
    {
        value = (
            this as LedgerCreateEntryByExternalIDResponseVariants::VoidInitiatedLedgerEntry
        )?.Value;
        return value != null;
    }

    public bool TryPickAmendmentLedgerEntry([NotNullWhen(true)] out AmendmentLedgerEntry? value)
    {
        value = (
            this as LedgerCreateEntryByExternalIDResponseVariants::AmendmentLedgerEntry
        )?.Value;
        return value != null;
    }

    public void Switch(
        Action<LedgerCreateEntryByExternalIDResponseVariants::IncrementLedgerEntry> incrementLedgerEntry,
        Action<LedgerCreateEntryByExternalIDResponseVariants::DecrementLedgerEntry> decrementLedgerEntry,
        Action<LedgerCreateEntryByExternalIDResponseVariants::ExpirationChangeLedgerEntry> expirationChangeLedgerEntry,
        Action<LedgerCreateEntryByExternalIDResponseVariants::CreditBlockExpiryLedgerEntry> creditBlockExpiryLedgerEntry,
        Action<LedgerCreateEntryByExternalIDResponseVariants::VoidLedgerEntry> voidLedgerEntry,
        Action<LedgerCreateEntryByExternalIDResponseVariants::VoidInitiatedLedgerEntry> voidInitiatedLedgerEntry,
        Action<LedgerCreateEntryByExternalIDResponseVariants::AmendmentLedgerEntry> amendmentLedgerEntry
    )
    {
        switch (this)
        {
            case LedgerCreateEntryByExternalIDResponseVariants::IncrementLedgerEntry inner:
                incrementLedgerEntry(inner);
                break;
            case LedgerCreateEntryByExternalIDResponseVariants::DecrementLedgerEntry inner:
                decrementLedgerEntry(inner);
                break;
            case LedgerCreateEntryByExternalIDResponseVariants::ExpirationChangeLedgerEntry inner:
                expirationChangeLedgerEntry(inner);
                break;
            case LedgerCreateEntryByExternalIDResponseVariants::CreditBlockExpiryLedgerEntry inner:
                creditBlockExpiryLedgerEntry(inner);
                break;
            case LedgerCreateEntryByExternalIDResponseVariants::VoidLedgerEntry inner:
                voidLedgerEntry(inner);
                break;
            case LedgerCreateEntryByExternalIDResponseVariants::VoidInitiatedLedgerEntry inner:
                voidInitiatedLedgerEntry(inner);
                break;
            case LedgerCreateEntryByExternalIDResponseVariants::AmendmentLedgerEntry inner:
                amendmentLedgerEntry(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<
            LedgerCreateEntryByExternalIDResponseVariants::IncrementLedgerEntry,
            T
        > incrementLedgerEntry,
        Func<
            LedgerCreateEntryByExternalIDResponseVariants::DecrementLedgerEntry,
            T
        > decrementLedgerEntry,
        Func<
            LedgerCreateEntryByExternalIDResponseVariants::ExpirationChangeLedgerEntry,
            T
        > expirationChangeLedgerEntry,
        Func<
            LedgerCreateEntryByExternalIDResponseVariants::CreditBlockExpiryLedgerEntry,
            T
        > creditBlockExpiryLedgerEntry,
        Func<LedgerCreateEntryByExternalIDResponseVariants::VoidLedgerEntry, T> voidLedgerEntry,
        Func<
            LedgerCreateEntryByExternalIDResponseVariants::VoidInitiatedLedgerEntry,
            T
        > voidInitiatedLedgerEntry,
        Func<
            LedgerCreateEntryByExternalIDResponseVariants::AmendmentLedgerEntry,
            T
        > amendmentLedgerEntry
    )
    {
        return this switch
        {
            LedgerCreateEntryByExternalIDResponseVariants::IncrementLedgerEntry inner =>
                incrementLedgerEntry(inner),
            LedgerCreateEntryByExternalIDResponseVariants::DecrementLedgerEntry inner =>
                decrementLedgerEntry(inner),
            LedgerCreateEntryByExternalIDResponseVariants::ExpirationChangeLedgerEntry inner =>
                expirationChangeLedgerEntry(inner),
            LedgerCreateEntryByExternalIDResponseVariants::CreditBlockExpiryLedgerEntry inner =>
                creditBlockExpiryLedgerEntry(inner),
            LedgerCreateEntryByExternalIDResponseVariants::VoidLedgerEntry inner => voidLedgerEntry(
                inner
            ),
            LedgerCreateEntryByExternalIDResponseVariants::VoidInitiatedLedgerEntry inner =>
                voidInitiatedLedgerEntry(inner),
            LedgerCreateEntryByExternalIDResponseVariants::AmendmentLedgerEntry inner =>
                amendmentLedgerEntry(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class LedgerCreateEntryByExternalIDResponseConverter
    : JsonConverter<LedgerCreateEntryByExternalIDResponse>
{
    public override LedgerCreateEntryByExternalIDResponse? Read(
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
                        return new LedgerCreateEntryByExternalIDResponseVariants::IncrementLedgerEntry(
                            deserialized
                        );
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
                        return new LedgerCreateEntryByExternalIDResponseVariants::DecrementLedgerEntry(
                            deserialized
                        );
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
                        return new LedgerCreateEntryByExternalIDResponseVariants::ExpirationChangeLedgerEntry(
                            deserialized
                        );
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
                        return new LedgerCreateEntryByExternalIDResponseVariants::CreditBlockExpiryLedgerEntry(
                            deserialized
                        );
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
                        return new LedgerCreateEntryByExternalIDResponseVariants::VoidLedgerEntry(
                            deserialized
                        );
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
                        return new LedgerCreateEntryByExternalIDResponseVariants::VoidInitiatedLedgerEntry(
                            deserialized
                        );
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
                        return new LedgerCreateEntryByExternalIDResponseVariants::AmendmentLedgerEntry(
                            deserialized
                        );
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

    public override void Write(
        Utf8JsonWriter writer,
        LedgerCreateEntryByExternalIDResponse value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            LedgerCreateEntryByExternalIDResponseVariants::IncrementLedgerEntry(
                var incrementLedgerEntry
            ) => incrementLedgerEntry,
            LedgerCreateEntryByExternalIDResponseVariants::DecrementLedgerEntry(
                var decrementLedgerEntry
            ) => decrementLedgerEntry,
            LedgerCreateEntryByExternalIDResponseVariants::ExpirationChangeLedgerEntry(
                var expirationChangeLedgerEntry
            ) => expirationChangeLedgerEntry,
            LedgerCreateEntryByExternalIDResponseVariants::CreditBlockExpiryLedgerEntry(
                var creditBlockExpiryLedgerEntry
            ) => creditBlockExpiryLedgerEntry,
            LedgerCreateEntryByExternalIDResponseVariants::VoidLedgerEntry(var voidLedgerEntry) =>
                voidLedgerEntry,
            LedgerCreateEntryByExternalIDResponseVariants::VoidInitiatedLedgerEntry(
                var voidInitiatedLedgerEntry
            ) => voidInitiatedLedgerEntry,
            LedgerCreateEntryByExternalIDResponseVariants::AmendmentLedgerEntry(
                var amendmentLedgerEntry
            ) => amendmentLedgerEntry,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
