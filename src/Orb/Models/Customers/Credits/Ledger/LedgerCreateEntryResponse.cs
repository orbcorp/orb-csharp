using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LedgerCreateEntryResponseVariants = Orb.Models.Customers.Credits.Ledger.LedgerCreateEntryResponseVariants;

namespace Orb.Models.Customers.Credits.Ledger;

/// <summary>
/// The [Credit Ledger Entry resource](/product-catalog/prepurchase) models prepaid
/// credits within Orb.
/// </summary>
[JsonConverter(typeof(LedgerCreateEntryResponseConverter))]
public abstract record class LedgerCreateEntryResponse
{
    internal LedgerCreateEntryResponse() { }

    public static implicit operator LedgerCreateEntryResponse(IncrementLedgerEntry value) =>
        new LedgerCreateEntryResponseVariants::IncrementLedgerEntry(value);

    public static implicit operator LedgerCreateEntryResponse(DecrementLedgerEntry value) =>
        new LedgerCreateEntryResponseVariants::DecrementLedgerEntry(value);

    public static implicit operator LedgerCreateEntryResponse(ExpirationChangeLedgerEntry value) =>
        new LedgerCreateEntryResponseVariants::ExpirationChangeLedgerEntry(value);

    public static implicit operator LedgerCreateEntryResponse(CreditBlockExpiryLedgerEntry value) =>
        new LedgerCreateEntryResponseVariants::CreditBlockExpiryLedgerEntry(value);

    public static implicit operator LedgerCreateEntryResponse(VoidLedgerEntry value) =>
        new LedgerCreateEntryResponseVariants::VoidLedgerEntry(value);

    public static implicit operator LedgerCreateEntryResponse(VoidInitiatedLedgerEntry value) =>
        new LedgerCreateEntryResponseVariants::VoidInitiatedLedgerEntry(value);

    public static implicit operator LedgerCreateEntryResponse(AmendmentLedgerEntry value) =>
        new LedgerCreateEntryResponseVariants::AmendmentLedgerEntry(value);

    public bool TryPickIncrementLedgerEntry([NotNullWhen(true)] out IncrementLedgerEntry? value)
    {
        value = (this as LedgerCreateEntryResponseVariants::IncrementLedgerEntry)?.Value;
        return value != null;
    }

    public bool TryPickDecrementLedgerEntry([NotNullWhen(true)] out DecrementLedgerEntry? value)
    {
        value = (this as LedgerCreateEntryResponseVariants::DecrementLedgerEntry)?.Value;
        return value != null;
    }

    public bool TryPickExpirationChangeLedgerEntry(
        [NotNullWhen(true)] out ExpirationChangeLedgerEntry? value
    )
    {
        value = (this as LedgerCreateEntryResponseVariants::ExpirationChangeLedgerEntry)?.Value;
        return value != null;
    }

    public bool TryPickCreditBlockExpiryLedgerEntry(
        [NotNullWhen(true)] out CreditBlockExpiryLedgerEntry? value
    )
    {
        value = (this as LedgerCreateEntryResponseVariants::CreditBlockExpiryLedgerEntry)?.Value;
        return value != null;
    }

    public bool TryPickVoidLedgerEntry([NotNullWhen(true)] out VoidLedgerEntry? value)
    {
        value = (this as LedgerCreateEntryResponseVariants::VoidLedgerEntry)?.Value;
        return value != null;
    }

    public bool TryPickVoidInitiatedLedgerEntry(
        [NotNullWhen(true)] out VoidInitiatedLedgerEntry? value
    )
    {
        value = (this as LedgerCreateEntryResponseVariants::VoidInitiatedLedgerEntry)?.Value;
        return value != null;
    }

    public bool TryPickAmendmentLedgerEntry([NotNullWhen(true)] out AmendmentLedgerEntry? value)
    {
        value = (this as LedgerCreateEntryResponseVariants::AmendmentLedgerEntry)?.Value;
        return value != null;
    }

    public void Switch(
        Action<LedgerCreateEntryResponseVariants::IncrementLedgerEntry> incrementLedgerEntry,
        Action<LedgerCreateEntryResponseVariants::DecrementLedgerEntry> decrementLedgerEntry,
        Action<LedgerCreateEntryResponseVariants::ExpirationChangeLedgerEntry> expirationChangeLedgerEntry,
        Action<LedgerCreateEntryResponseVariants::CreditBlockExpiryLedgerEntry> creditBlockExpiryLedgerEntry,
        Action<LedgerCreateEntryResponseVariants::VoidLedgerEntry> voidLedgerEntry,
        Action<LedgerCreateEntryResponseVariants::VoidInitiatedLedgerEntry> voidInitiatedLedgerEntry,
        Action<LedgerCreateEntryResponseVariants::AmendmentLedgerEntry> amendmentLedgerEntry
    )
    {
        switch (this)
        {
            case LedgerCreateEntryResponseVariants::IncrementLedgerEntry inner:
                incrementLedgerEntry(inner);
                break;
            case LedgerCreateEntryResponseVariants::DecrementLedgerEntry inner:
                decrementLedgerEntry(inner);
                break;
            case LedgerCreateEntryResponseVariants::ExpirationChangeLedgerEntry inner:
                expirationChangeLedgerEntry(inner);
                break;
            case LedgerCreateEntryResponseVariants::CreditBlockExpiryLedgerEntry inner:
                creditBlockExpiryLedgerEntry(inner);
                break;
            case LedgerCreateEntryResponseVariants::VoidLedgerEntry inner:
                voidLedgerEntry(inner);
                break;
            case LedgerCreateEntryResponseVariants::VoidInitiatedLedgerEntry inner:
                voidInitiatedLedgerEntry(inner);
                break;
            case LedgerCreateEntryResponseVariants::AmendmentLedgerEntry inner:
                amendmentLedgerEntry(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<LedgerCreateEntryResponseVariants::IncrementLedgerEntry, T> incrementLedgerEntry,
        Func<LedgerCreateEntryResponseVariants::DecrementLedgerEntry, T> decrementLedgerEntry,
        Func<
            LedgerCreateEntryResponseVariants::ExpirationChangeLedgerEntry,
            T
        > expirationChangeLedgerEntry,
        Func<
            LedgerCreateEntryResponseVariants::CreditBlockExpiryLedgerEntry,
            T
        > creditBlockExpiryLedgerEntry,
        Func<LedgerCreateEntryResponseVariants::VoidLedgerEntry, T> voidLedgerEntry,
        Func<
            LedgerCreateEntryResponseVariants::VoidInitiatedLedgerEntry,
            T
        > voidInitiatedLedgerEntry,
        Func<LedgerCreateEntryResponseVariants::AmendmentLedgerEntry, T> amendmentLedgerEntry
    )
    {
        return this switch
        {
            LedgerCreateEntryResponseVariants::IncrementLedgerEntry inner => incrementLedgerEntry(
                inner
            ),
            LedgerCreateEntryResponseVariants::DecrementLedgerEntry inner => decrementLedgerEntry(
                inner
            ),
            LedgerCreateEntryResponseVariants::ExpirationChangeLedgerEntry inner =>
                expirationChangeLedgerEntry(inner),
            LedgerCreateEntryResponseVariants::CreditBlockExpiryLedgerEntry inner =>
                creditBlockExpiryLedgerEntry(inner),
            LedgerCreateEntryResponseVariants::VoidLedgerEntry inner => voidLedgerEntry(inner),
            LedgerCreateEntryResponseVariants::VoidInitiatedLedgerEntry inner =>
                voidInitiatedLedgerEntry(inner),
            LedgerCreateEntryResponseVariants::AmendmentLedgerEntry inner => amendmentLedgerEntry(
                inner
            ),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class LedgerCreateEntryResponseConverter : JsonConverter<LedgerCreateEntryResponse>
{
    public override LedgerCreateEntryResponse? Read(
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
                        return new LedgerCreateEntryResponseVariants::IncrementLedgerEntry(
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
                        return new LedgerCreateEntryResponseVariants::DecrementLedgerEntry(
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
                        return new LedgerCreateEntryResponseVariants::ExpirationChangeLedgerEntry(
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
                        return new LedgerCreateEntryResponseVariants::CreditBlockExpiryLedgerEntry(
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
                        return new LedgerCreateEntryResponseVariants::VoidLedgerEntry(deserialized);
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
                        return new LedgerCreateEntryResponseVariants::VoidInitiatedLedgerEntry(
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
                        return new LedgerCreateEntryResponseVariants::AmendmentLedgerEntry(
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
        LedgerCreateEntryResponse value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            LedgerCreateEntryResponseVariants::IncrementLedgerEntry(var incrementLedgerEntry) =>
                incrementLedgerEntry,
            LedgerCreateEntryResponseVariants::DecrementLedgerEntry(var decrementLedgerEntry) =>
                decrementLedgerEntry,
            LedgerCreateEntryResponseVariants::ExpirationChangeLedgerEntry(
                var expirationChangeLedgerEntry
            ) => expirationChangeLedgerEntry,
            LedgerCreateEntryResponseVariants::CreditBlockExpiryLedgerEntry(
                var creditBlockExpiryLedgerEntry
            ) => creditBlockExpiryLedgerEntry,
            LedgerCreateEntryResponseVariants::VoidLedgerEntry(var voidLedgerEntry) =>
                voidLedgerEntry,
            LedgerCreateEntryResponseVariants::VoidInitiatedLedgerEntry(
                var voidInitiatedLedgerEntry
            ) => voidInitiatedLedgerEntry,
            LedgerCreateEntryResponseVariants::AmendmentLedgerEntry(var amendmentLedgerEntry) =>
                amendmentLedgerEntry,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
