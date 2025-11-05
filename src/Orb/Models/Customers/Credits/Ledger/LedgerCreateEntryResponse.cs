using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers.Credits.Ledger;

/// <summary>
/// The [Credit Ledger Entry resource](/product-catalog/prepurchase) models prepaid
/// credits within Orb.
/// </summary>
[JsonConverter(typeof(LedgerCreateEntryResponseConverter))]
public record class LedgerCreateEntryResponse
{
    public object Value { get; private init; }

    public string ID
    {
        get
        {
            return Match(
                incrementLedgerEntry: (x) => x.ID,
                decrementLedgerEntry: (x) => x.ID,
                expirationChangeLedgerEntry: (x) => x.ID,
                creditBlockExpiryLedgerEntry: (x) => x.ID,
                voidLedgerEntry: (x) => x.ID,
                voidInitiatedLedgerEntry: (x) => x.ID,
                amendmentLedgerEntry: (x) => x.ID
            );
        }
    }

    public double Amount
    {
        get
        {
            return Match(
                incrementLedgerEntry: (x) => x.Amount,
                decrementLedgerEntry: (x) => x.Amount,
                expirationChangeLedgerEntry: (x) => x.Amount,
                creditBlockExpiryLedgerEntry: (x) => x.Amount,
                voidLedgerEntry: (x) => x.Amount,
                voidInitiatedLedgerEntry: (x) => x.Amount,
                amendmentLedgerEntry: (x) => x.Amount
            );
        }
    }

    public System::DateTime CreatedAt
    {
        get
        {
            return Match(
                incrementLedgerEntry: (x) => x.CreatedAt,
                decrementLedgerEntry: (x) => x.CreatedAt,
                expirationChangeLedgerEntry: (x) => x.CreatedAt,
                creditBlockExpiryLedgerEntry: (x) => x.CreatedAt,
                voidLedgerEntry: (x) => x.CreatedAt,
                voidInitiatedLedgerEntry: (x) => x.CreatedAt,
                amendmentLedgerEntry: (x) => x.CreatedAt
            );
        }
    }

    public AffectedBlock CreditBlock
    {
        get
        {
            return Match(
                incrementLedgerEntry: (x) => x.CreditBlock,
                decrementLedgerEntry: (x) => x.CreditBlock,
                expirationChangeLedgerEntry: (x) => x.CreditBlock,
                creditBlockExpiryLedgerEntry: (x) => x.CreditBlock,
                voidLedgerEntry: (x) => x.CreditBlock,
                voidInitiatedLedgerEntry: (x) => x.CreditBlock,
                amendmentLedgerEntry: (x) => x.CreditBlock
            );
        }
    }

    public string Currency
    {
        get
        {
            return Match(
                incrementLedgerEntry: (x) => x.Currency,
                decrementLedgerEntry: (x) => x.Currency,
                expirationChangeLedgerEntry: (x) => x.Currency,
                creditBlockExpiryLedgerEntry: (x) => x.Currency,
                voidLedgerEntry: (x) => x.Currency,
                voidInitiatedLedgerEntry: (x) => x.Currency,
                amendmentLedgerEntry: (x) => x.Currency
            );
        }
    }

    public CustomerMinified Customer
    {
        get
        {
            return Match(
                incrementLedgerEntry: (x) => x.Customer,
                decrementLedgerEntry: (x) => x.Customer,
                expirationChangeLedgerEntry: (x) => x.Customer,
                creditBlockExpiryLedgerEntry: (x) => x.Customer,
                voidLedgerEntry: (x) => x.Customer,
                voidInitiatedLedgerEntry: (x) => x.Customer,
                amendmentLedgerEntry: (x) => x.Customer
            );
        }
    }

    public string? Description
    {
        get
        {
            return Match<string?>(
                incrementLedgerEntry: (x) => x.Description,
                decrementLedgerEntry: (x) => x.Description,
                expirationChangeLedgerEntry: (x) => x.Description,
                creditBlockExpiryLedgerEntry: (x) => x.Description,
                voidLedgerEntry: (x) => x.Description,
                voidInitiatedLedgerEntry: (x) => x.Description,
                amendmentLedgerEntry: (x) => x.Description
            );
        }
    }

    public double EndingBalance
    {
        get
        {
            return Match(
                incrementLedgerEntry: (x) => x.EndingBalance,
                decrementLedgerEntry: (x) => x.EndingBalance,
                expirationChangeLedgerEntry: (x) => x.EndingBalance,
                creditBlockExpiryLedgerEntry: (x) => x.EndingBalance,
                voidLedgerEntry: (x) => x.EndingBalance,
                voidInitiatedLedgerEntry: (x) => x.EndingBalance,
                amendmentLedgerEntry: (x) => x.EndingBalance
            );
        }
    }

    public long LedgerSequenceNumber
    {
        get
        {
            return Match(
                incrementLedgerEntry: (x) => x.LedgerSequenceNumber,
                decrementLedgerEntry: (x) => x.LedgerSequenceNumber,
                expirationChangeLedgerEntry: (x) => x.LedgerSequenceNumber,
                creditBlockExpiryLedgerEntry: (x) => x.LedgerSequenceNumber,
                voidLedgerEntry: (x) => x.LedgerSequenceNumber,
                voidInitiatedLedgerEntry: (x) => x.LedgerSequenceNumber,
                amendmentLedgerEntry: (x) => x.LedgerSequenceNumber
            );
        }
    }

    public double StartingBalance
    {
        get
        {
            return Match(
                incrementLedgerEntry: (x) => x.StartingBalance,
                decrementLedgerEntry: (x) => x.StartingBalance,
                expirationChangeLedgerEntry: (x) => x.StartingBalance,
                creditBlockExpiryLedgerEntry: (x) => x.StartingBalance,
                voidLedgerEntry: (x) => x.StartingBalance,
                voidInitiatedLedgerEntry: (x) => x.StartingBalance,
                amendmentLedgerEntry: (x) => x.StartingBalance
            );
        }
    }

    public System::DateTime? NewBlockExpiryDate
    {
        get
        {
            return Match<System::DateTime?>(
                incrementLedgerEntry: (_) => null,
                decrementLedgerEntry: (_) => null,
                expirationChangeLedgerEntry: (x) => x.NewBlockExpiryDate,
                creditBlockExpiryLedgerEntry: (_) => null,
                voidLedgerEntry: (_) => null,
                voidInitiatedLedgerEntry: (x) => x.NewBlockExpiryDate,
                amendmentLedgerEntry: (_) => null
            );
        }
    }

    public double? VoidAmount
    {
        get
        {
            return Match<double?>(
                incrementLedgerEntry: (_) => null,
                decrementLedgerEntry: (_) => null,
                expirationChangeLedgerEntry: (_) => null,
                creditBlockExpiryLedgerEntry: (_) => null,
                voidLedgerEntry: (x) => x.VoidAmount,
                voidInitiatedLedgerEntry: (x) => x.VoidAmount,
                amendmentLedgerEntry: (_) => null
            );
        }
    }

    public string? VoidReason
    {
        get
        {
            return Match<string?>(
                incrementLedgerEntry: (_) => null,
                decrementLedgerEntry: (_) => null,
                expirationChangeLedgerEntry: (_) => null,
                creditBlockExpiryLedgerEntry: (_) => null,
                voidLedgerEntry: (x) => x.VoidReason,
                voidInitiatedLedgerEntry: (x) => x.VoidReason,
                amendmentLedgerEntry: (_) => null
            );
        }
    }

    public LedgerCreateEntryResponse(IncrementLedgerEntry value)
    {
        Value = value;
    }

    public LedgerCreateEntryResponse(DecrementLedgerEntry value)
    {
        Value = value;
    }

    public LedgerCreateEntryResponse(ExpirationChangeLedgerEntry value)
    {
        Value = value;
    }

    public LedgerCreateEntryResponse(CreditBlockExpiryLedgerEntry value)
    {
        Value = value;
    }

    public LedgerCreateEntryResponse(VoidLedgerEntry value)
    {
        Value = value;
    }

    public LedgerCreateEntryResponse(VoidInitiatedLedgerEntry value)
    {
        Value = value;
    }

    public LedgerCreateEntryResponse(AmendmentLedgerEntry value)
    {
        Value = value;
    }

    LedgerCreateEntryResponse(UnknownVariant value)
    {
        Value = value;
    }

    public static LedgerCreateEntryResponse CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickIncrementLedgerEntry([NotNullWhen(true)] out IncrementLedgerEntry? value)
    {
        value = this.Value as IncrementLedgerEntry;
        return value != null;
    }

    public bool TryPickDecrementLedgerEntry([NotNullWhen(true)] out DecrementLedgerEntry? value)
    {
        value = this.Value as DecrementLedgerEntry;
        return value != null;
    }

    public bool TryPickExpirationChangeLedgerEntry(
        [NotNullWhen(true)] out ExpirationChangeLedgerEntry? value
    )
    {
        value = this.Value as ExpirationChangeLedgerEntry;
        return value != null;
    }

    public bool TryPickCreditBlockExpiryLedgerEntry(
        [NotNullWhen(true)] out CreditBlockExpiryLedgerEntry? value
    )
    {
        value = this.Value as CreditBlockExpiryLedgerEntry;
        return value != null;
    }

    public bool TryPickVoidLedgerEntry([NotNullWhen(true)] out VoidLedgerEntry? value)
    {
        value = this.Value as VoidLedgerEntry;
        return value != null;
    }

    public bool TryPickVoidInitiatedLedgerEntry(
        [NotNullWhen(true)] out VoidInitiatedLedgerEntry? value
    )
    {
        value = this.Value as VoidInitiatedLedgerEntry;
        return value != null;
    }

    public bool TryPickAmendmentLedgerEntry([NotNullWhen(true)] out AmendmentLedgerEntry? value)
    {
        value = this.Value as AmendmentLedgerEntry;
        return value != null;
    }

    public void Switch(
        System::Action<IncrementLedgerEntry> incrementLedgerEntry,
        System::Action<DecrementLedgerEntry> decrementLedgerEntry,
        System::Action<ExpirationChangeLedgerEntry> expirationChangeLedgerEntry,
        System::Action<CreditBlockExpiryLedgerEntry> creditBlockExpiryLedgerEntry,
        System::Action<VoidLedgerEntry> voidLedgerEntry,
        System::Action<VoidInitiatedLedgerEntry> voidInitiatedLedgerEntry,
        System::Action<AmendmentLedgerEntry> amendmentLedgerEntry
    )
    {
        switch (this.Value)
        {
            case IncrementLedgerEntry value:
                incrementLedgerEntry(value);
                break;
            case DecrementLedgerEntry value:
                decrementLedgerEntry(value);
                break;
            case ExpirationChangeLedgerEntry value:
                expirationChangeLedgerEntry(value);
                break;
            case CreditBlockExpiryLedgerEntry value:
                creditBlockExpiryLedgerEntry(value);
                break;
            case VoidLedgerEntry value:
                voidLedgerEntry(value);
                break;
            case VoidInitiatedLedgerEntry value:
                voidInitiatedLedgerEntry(value);
                break;
            case AmendmentLedgerEntry value:
                amendmentLedgerEntry(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of LedgerCreateEntryResponse"
                );
        }
    }

    public T Match<T>(
        System::Func<IncrementLedgerEntry, T> incrementLedgerEntry,
        System::Func<DecrementLedgerEntry, T> decrementLedgerEntry,
        System::Func<ExpirationChangeLedgerEntry, T> expirationChangeLedgerEntry,
        System::Func<CreditBlockExpiryLedgerEntry, T> creditBlockExpiryLedgerEntry,
        System::Func<VoidLedgerEntry, T> voidLedgerEntry,
        System::Func<VoidInitiatedLedgerEntry, T> voidInitiatedLedgerEntry,
        System::Func<AmendmentLedgerEntry, T> amendmentLedgerEntry
    )
    {
        return this.Value switch
        {
            IncrementLedgerEntry value => incrementLedgerEntry(value),
            DecrementLedgerEntry value => decrementLedgerEntry(value),
            ExpirationChangeLedgerEntry value => expirationChangeLedgerEntry(value),
            CreditBlockExpiryLedgerEntry value => creditBlockExpiryLedgerEntry(value),
            VoidLedgerEntry value => voidLedgerEntry(value),
            VoidInitiatedLedgerEntry value => voidInitiatedLedgerEntry(value),
            AmendmentLedgerEntry value => amendmentLedgerEntry(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of LedgerCreateEntryResponse"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of LedgerCreateEntryResponse"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class LedgerCreateEntryResponseConverter : JsonConverter<LedgerCreateEntryResponse>
{
    public override LedgerCreateEntryResponse? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
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
                    var deserialized = JsonSerializer.Deserialize<IncrementLedgerEntry>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new LedgerCreateEntryResponse(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'IncrementLedgerEntry'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "decrement":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<DecrementLedgerEntry>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new LedgerCreateEntryResponse(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'DecrementLedgerEntry'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "expiration_change":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ExpirationChangeLedgerEntry>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new LedgerCreateEntryResponse(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'ExpirationChangeLedgerEntry'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "credit_block_expiry":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<CreditBlockExpiryLedgerEntry>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new LedgerCreateEntryResponse(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'CreditBlockExpiryLedgerEntry'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "void":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<VoidLedgerEntry>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new LedgerCreateEntryResponse(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'VoidLedgerEntry'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "void_initiated":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<VoidInitiatedLedgerEntry>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new LedgerCreateEntryResponse(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'VoidInitiatedLedgerEntry'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            case "amendment":
            {
                List<OrbInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<AmendmentLedgerEntry>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new LedgerCreateEntryResponse(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'AmendmentLedgerEntry'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new OrbInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        LedgerCreateEntryResponse value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
