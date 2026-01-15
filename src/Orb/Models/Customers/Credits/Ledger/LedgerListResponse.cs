using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers.Credits.Ledger;

/// <summary>
/// The [Credit Ledger Entry resource](/product-catalog/prepurchase) models prepaid
/// credits within Orb.
/// </summary>
[JsonConverter(typeof(LedgerListResponseConverter))]
public record class LedgerListResponse : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public System::DateTimeOffset CreatedAt
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

    public System::DateTimeOffset? NewBlockExpiryDate
    {
        get
        {
            return Match<System::DateTimeOffset?>(
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

    public LedgerListResponse(IncrementLedgerEntry value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public LedgerListResponse(DecrementLedgerEntry value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public LedgerListResponse(ExpirationChangeLedgerEntry value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public LedgerListResponse(CreditBlockExpiryLedgerEntry value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public LedgerListResponse(VoidLedgerEntry value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public LedgerListResponse(VoidInitiatedLedgerEntry value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public LedgerListResponse(AmendmentLedgerEntry value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public LedgerListResponse(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IncrementLedgerEntry"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickIncrementLedgerEntry(out var value)) {
    ///     // `value` is of type `IncrementLedgerEntry`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickIncrementLedgerEntry([NotNullWhen(true)] out IncrementLedgerEntry? value)
    {
        value = this.Value as IncrementLedgerEntry;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DecrementLedgerEntry"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDecrementLedgerEntry(out var value)) {
    ///     // `value` is of type `DecrementLedgerEntry`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDecrementLedgerEntry([NotNullWhen(true)] out DecrementLedgerEntry? value)
    {
        value = this.Value as DecrementLedgerEntry;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ExpirationChangeLedgerEntry"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExpirationChangeLedgerEntry(out var value)) {
    ///     // `value` is of type `ExpirationChangeLedgerEntry`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExpirationChangeLedgerEntry(
        [NotNullWhen(true)] out ExpirationChangeLedgerEntry? value
    )
    {
        value = this.Value as ExpirationChangeLedgerEntry;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CreditBlockExpiryLedgerEntry"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCreditBlockExpiryLedgerEntry(out var value)) {
    ///     // `value` is of type `CreditBlockExpiryLedgerEntry`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCreditBlockExpiryLedgerEntry(
        [NotNullWhen(true)] out CreditBlockExpiryLedgerEntry? value
    )
    {
        value = this.Value as CreditBlockExpiryLedgerEntry;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="VoidLedgerEntry"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVoidLedgerEntry(out var value)) {
    ///     // `value` is of type `VoidLedgerEntry`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVoidLedgerEntry([NotNullWhen(true)] out VoidLedgerEntry? value)
    {
        value = this.Value as VoidLedgerEntry;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="VoidInitiatedLedgerEntry"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVoidInitiatedLedgerEntry(out var value)) {
    ///     // `value` is of type `VoidInitiatedLedgerEntry`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVoidInitiatedLedgerEntry(
        [NotNullWhen(true)] out VoidInitiatedLedgerEntry? value
    )
    {
        value = this.Value as VoidInitiatedLedgerEntry;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AmendmentLedgerEntry"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAmendmentLedgerEntry(out var value)) {
    ///     // `value` is of type `AmendmentLedgerEntry`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAmendmentLedgerEntry([NotNullWhen(true)] out AmendmentLedgerEntry? value)
    {
        value = this.Value as AmendmentLedgerEntry;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (IncrementLedgerEntry value) => {...},
    ///     (DecrementLedgerEntry value) => {...},
    ///     (ExpirationChangeLedgerEntry value) => {...},
    ///     (CreditBlockExpiryLedgerEntry value) => {...},
    ///     (VoidLedgerEntry value) => {...},
    ///     (VoidInitiatedLedgerEntry value) => {...},
    ///     (AmendmentLedgerEntry value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                    "Data did not match any variant of LedgerListResponse"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (IncrementLedgerEntry value) => {...},
    ///     (DecrementLedgerEntry value) => {...},
    ///     (ExpirationChangeLedgerEntry value) => {...},
    ///     (CreditBlockExpiryLedgerEntry value) => {...},
    ///     (VoidLedgerEntry value) => {...},
    ///     (VoidInitiatedLedgerEntry value) => {...},
    ///     (AmendmentLedgerEntry value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
                "Data did not match any variant of LedgerListResponse"
            ),
        };
    }

    public static implicit operator LedgerListResponse(IncrementLedgerEntry value) => new(value);

    public static implicit operator LedgerListResponse(DecrementLedgerEntry value) => new(value);

    public static implicit operator LedgerListResponse(ExpirationChangeLedgerEntry value) =>
        new(value);

    public static implicit operator LedgerListResponse(CreditBlockExpiryLedgerEntry value) =>
        new(value);

    public static implicit operator LedgerListResponse(VoidLedgerEntry value) => new(value);

    public static implicit operator LedgerListResponse(VoidInitiatedLedgerEntry value) =>
        new(value);

    public static implicit operator LedgerListResponse(AmendmentLedgerEntry value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="OrbInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of LedgerListResponse"
            );
        }
        this.Switch(
            (incrementLedgerEntry) => incrementLedgerEntry.Validate(),
            (decrementLedgerEntry) => decrementLedgerEntry.Validate(),
            (expirationChangeLedgerEntry) => expirationChangeLedgerEntry.Validate(),
            (creditBlockExpiryLedgerEntry) => creditBlockExpiryLedgerEntry.Validate(),
            (voidLedgerEntry) => voidLedgerEntry.Validate(),
            (voidInitiatedLedgerEntry) => voidInitiatedLedgerEntry.Validate(),
            (amendmentLedgerEntry) => amendmentLedgerEntry.Validate()
        );
    }

    public virtual bool Equals(LedgerListResponse? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class LedgerListResponseConverter : JsonConverter<LedgerListResponse>
{
    public override LedgerListResponse? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? entryType;
        try
        {
            entryType = element.GetProperty("entry_type").GetString();
        }
        catch
        {
            entryType = null;
        }

        switch (entryType)
        {
            case "increment":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<IncrementLedgerEntry>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "decrement":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<DecrementLedgerEntry>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "expiration_change":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ExpirationChangeLedgerEntry>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "credit_block_expiry":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CreditBlockExpiryLedgerEntry>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "void":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<VoidLedgerEntry>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "void_initiated":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<VoidInitiatedLedgerEntry>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "amendment":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<AmendmentLedgerEntry>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new LedgerListResponse(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        LedgerListResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
