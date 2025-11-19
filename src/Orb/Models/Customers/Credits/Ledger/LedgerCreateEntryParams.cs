using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Customers.Credits.Ledger;

/// <summary>
/// This endpoint allows you to create a new ledger entry for a specified customer's
/// balance. This can be used to increment balance, deduct credits, and change the
/// expiry date of existing credits.
///
/// <para>## Effects of adding a ledger entry 1. After calling this endpoint, [Fetch
/// Credit Balance](fetch-customer-credits) will return a credit block that   represents
/// the changes (i.e. balance changes or transfers). 2. A ledger entry will be added
/// to the credits ledger for this customer, and therefore returned in the   [View
/// Credits Ledger](fetch-customer-credits-ledger) response as well as serialized
/// in the response to this request. In   the case of deductions without a specified
/// block, multiple ledger entries may be created if the deduction spans   credit
/// blocks. 3. If `invoice_settings` is specified, an invoice will be created that
/// reflects the cost of the credits (based on   `amount` and `per_unit_cost_basis`).</para>
///
/// <para>## Adding credits   Adding credits is done by creating an entry of type
/// `increment`. This requires the caller to specify a number of   credits as well
/// as an optional expiry date in `YYYY-MM-DD` format. Orb also recommends specifying
/// a description   to assist with auditing. When adding credits, the caller can
/// also specify a cost basis per-credit, to indicate   how much in USD a customer
/// paid for a single credit in a block. This can later be used for revenue recognition.</para>
///
/// <para>The following snippet illustrates a sample request body to increment credits
/// which will expire in January of 2022.</para>
///
/// <para>```json {   "entry_type": "increment",   "amount": 100,   "expiry_date":
/// "2022-12-28",   "per_unit_cost_basis": "0.20",   "description": "Purchased 100
/// credits" } ```</para>
///
/// <para>Note that by default, Orb will always first increment any _negative_ balance
/// in existing blocks before adding the remaining amount to the desired credit block.</para>
///
/// <para>### Invoicing for credits By default, Orb manipulates the credit ledger
/// but does not charge for credits. However, if you pass `invoice_settings` in the
/// body of this request, Orb will also generate a one-off invoice for the customer
/// for the credits pre-purchase. Note that you _must_ provide the `per_unit_cost_basis`,
/// since the total charges on the invoice are calculated by multiplying the cost
/// basis with the number of credit units added.</para>
///
/// <para>## Deducting Credits Orb allows you to deduct credits from a customer by
/// creating an entry of type `decrement`. Orb matches the algorithm for automatic
/// deductions for determining which credit blocks to decrement from. In the case
/// that the deduction leads to multiple ledger entries, the response from this endpoint
/// will be the final deduction. Orb also optionally allows specifying a description
/// to assist with auditing.</para>
///
/// <para>The following snippet illustrates a sample request body to decrement credits.</para>
///
/// <para>```json {   "entry_type": "decrement",   "amount": 20,   "description":
/// "Removing excess credits" } ```</para>
///
/// <para>## Changing credits expiry If you'd like to change when existing credits
/// expire, you should create a ledger entry of type `expiration_change`. For this
/// entry, the required parameter `expiry_date` identifies the _originating_ block,
/// and the required parameter `target_expiry_date` identifies when the transferred
/// credits should now expire. A new credit block will be created with expiry date
/// `target_expiry_date`, with the same cost basis data as the original credit block,
/// if present.</para>
///
/// <para>Note that the balance of the block with the given `expiry_date` must be
/// at least equal to the desired transfer amount determined by the `amount` parameter.</para>
///
/// <para>The following snippet illustrates a sample request body to extend the expiration
/// date of credits by one year:</para>
///
/// <para>```json {   "entry_type": "expiration_change",   "amount": 10,   "expiry_date":
/// "2022-12-28",   "block_id": "UiUhFWeLHPrBY4Ad",   "target_expiry_date": "2023-12-28",
///   "description": "Extending credit validity" } ```</para>
///
/// <para>## Voiding credits</para>
///
/// <para>If you'd like to void a credit block, create a ledger entry of type `void`.
/// For this entry, `block_id` is required to identify the block, and `amount` indicates
/// how many credits to void, up to the block's initial balance. Pass in a `void_reason`
/// of `refund` if the void is due to a refund.</para>
///
/// <para>## Amendment</para>
///
/// <para>If you'd like to undo a decrement on a credit block, create a ledger entry
/// of type `amendment`. For this entry, `block_id` is required to identify the block
/// that was originally decremented from, and `amount` indicates how many credits
/// to return to the customer, up to the block's initial balance.</para>
/// </summary>
public sealed record class LedgerCreateEntryParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    public string? CustomerID { get; init; }

    public required Body Body
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("body", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'body' cannot be null",
                    new System::ArgumentOutOfRangeException("body", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'body' cannot be null",
                    new System::ArgumentNullException("body")
                );
        }
        init
        {
            this._bodyProperties["body"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public LedgerCreateEntryParams() { }

    public LedgerCreateEntryParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LedgerCreateEntryParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties,
        FrozenDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }
#pragma warning restore CS8618

    public static LedgerCreateEntryParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties),
            FrozenDictionary.ToFrozenDictionary(bodyProperties)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/customers/{0}/credits/ledger_entry", this.CustomerID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(BodyConverter))]
public record class Body
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

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

    public System::DateTimeOffset? ExpiryDate
    {
        get
        {
            return Match<System::DateTimeOffset?>(
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

    public Body(Increment value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(Decrement value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(ExpirationChange value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(Void value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(Amendment value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Body(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickIncrement([NotNullWhen(true)] out Increment? value)
    {
        value = this.Value as Increment;
        return value != null;
    }

    public bool TryPickDecrement([NotNullWhen(true)] out Decrement? value)
    {
        value = this.Value as Decrement;
        return value != null;
    }

    public bool TryPickExpirationChange([NotNullWhen(true)] out ExpirationChange? value)
    {
        value = this.Value as ExpirationChange;
        return value != null;
    }

    public bool TryPickVoid([NotNullWhen(true)] out Void? value)
    {
        value = this.Value as Void;
        return value != null;
    }

    public bool TryPickAmendment([NotNullWhen(true)] out Amendment? value)
    {
        value = this.Value as Amendment;
        return value != null;
    }

    public void Switch(
        System::Action<Increment> increment,
        System::Action<Decrement> decrement,
        System::Action<ExpirationChange> expirationChange,
        System::Action<Void> void1,
        System::Action<Amendment> amendment
    )
    {
        switch (this.Value)
        {
            case Increment value:
                increment(value);
                break;
            case Decrement value:
                decrement(value);
                break;
            case ExpirationChange value:
                expirationChange(value);
                break;
            case Void value:
                void1(value);
                break;
            case Amendment value:
                amendment(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of Body");
        }
    }

    public T Match<T>(
        System::Func<Increment, T> increment,
        System::Func<Decrement, T> decrement,
        System::Func<ExpirationChange, T> expirationChange,
        System::Func<Void, T> void1,
        System::Func<Amendment, T> amendment
    )
    {
        return this.Value switch
        {
            Increment value => increment(value),
            Decrement value => decrement(value),
            ExpirationChange value => expirationChange(value),
            Void value => void1(value),
            Amendment value => amendment(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of Body"),
        };
    }

    public static implicit operator Body(Increment value) => new(value);

    public static implicit operator Body(Decrement value) => new(value);

    public static implicit operator Body(ExpirationChange value) => new(value);

    public static implicit operator Body(Void value) => new(value);

    public static implicit operator Body(Amendment value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of Body");
        }
    }
}

sealed class BodyConverter : JsonConverter<Body>
{
    public override Body? Read(
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
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Increment>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "decrement":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Decrement>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "expiration_change":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ExpirationChange>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "void":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Void>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "amendment":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Amendment>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new Body(json);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Body value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ModelConverter<Increment>))]
public sealed record class Increment : ModelBase, IFromRaw<Increment>
{
    /// <summary>
    /// The number of credits to effect. Note that this is required for increment,
    /// decrement, void, or undo operations.
    /// </summary>
    public required double Amount
    {
        get
        {
            if (!this._properties.TryGetValue("amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new System::ArgumentOutOfRangeException("amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public IncrementEntryType EntryType
    {
        get
        {
            if (!this._properties.TryGetValue("entry_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'entry_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "entry_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<IncrementEntryType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'entry_type' cannot be null",
                    new System::ArgumentNullException("entry_type")
                );
        }
        init
        {
            this._properties["entry_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The currency or custom pricing unit to use for this ledger entry. If this
    /// is a real-world currency, it must match the customer's invoicing currency.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional metadata that can be specified when adding ledger results via the
    /// API. For example, this can be used to note an increment refers to trial credits,
    /// or for noting corrections as a result of an incident, etc.
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this._properties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 8601 format date that denotes when this credit balance should become
    /// available for use.
    /// </summary>
    public System::DateTimeOffset? EffectiveDate
    {
        get
        {
            if (!this._properties.TryGetValue("effective_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["effective_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 8601 format date that denotes when this credit balance should expire.
    /// </summary>
    public System::DateTimeOffset? ExpiryDate
    {
        get
        {
            if (!this._properties.TryGetValue("expiry_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["expiry_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional filter to specify which items this credit block applies to. If not
    /// specified, the block will apply to all items for the pricing unit.
    /// </summary>
    public List<global::Orb.Models.Customers.Credits.Ledger.Filter>? Filters
    {
        get
        {
            if (!this._properties.TryGetValue("filters", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<global::Orb.Models.Customers.Credits.Ledger.Filter>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["filters"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Passing `invoice_settings` automatically generates an invoice for the newly
    /// added credits. If `invoice_settings` is passed, you must specify per_unit_cost_basis,
    /// as the calculation of the invoice total is done on that basis.
    /// </summary>
    public InvoiceSettings? InvoiceSettings
    {
        get
        {
            if (!this._properties.TryGetValue("invoice_settings", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<InvoiceSettings?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["invoice_settings"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Can only be specified when entry_type=increment. How much, in the customer's
    /// currency, a customer paid for a single credit in this block
    /// </summary>
    public string? PerUnitCostBasis
    {
        get
        {
            if (!this._properties.TryGetValue("per_unit_cost_basis", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["per_unit_cost_basis"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Amount;
        this.EntryType.Validate();
        _ = this.Currency;
        _ = this.Description;
        _ = this.EffectiveDate;
        _ = this.ExpiryDate;
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
        this.InvoiceSettings?.Validate();
        _ = this.Metadata;
        _ = this.PerUnitCostBasis;
    }

    public Increment()
    {
        this.EntryType = new();
    }

    public Increment(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.EntryType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Increment(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Increment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public Increment(double amount)
        : this()
    {
        this.Amount = amount;
    }
}

[JsonConverter(typeof(Converter))]
public class IncrementEntryType
{
    public JsonElement Json { get; private init; }

    public IncrementEntryType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"increment\"");
    }

    IncrementEntryType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new IncrementEntryType().Json))
        {
            throw new OrbInvalidDataException("Invalid value given for 'IncrementEntryType'");
        }
    }

    class Converter : JsonConverter<IncrementEntryType>
    {
        public override IncrementEntryType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            IncrementEntryType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

/// <summary>
/// A PriceFilter that only allows item_id field for block filters.
/// </summary>
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Customers.Credits.Ledger.Filter>))]
public sealed record class Filter
    : ModelBase,
        IFromRaw<global::Orb.Models.Customers.Credits.Ledger.Filter>
{
    /// <summary>
    /// The property of the price the block applies to. Only item_id is supported.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Customers.Credits.Ledger.Field> Field
    {
        get
        {
            if (!this._properties.TryGetValue("field", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'field' cannot be null",
                    new System::ArgumentOutOfRangeException("field", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Customers.Credits.Ledger.Field>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["field"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Customers.Credits.Ledger.Operator> Operator
    {
        get
        {
            if (!this._properties.TryGetValue("operator", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Customers.Credits.Ledger.Operator>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["operator"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The IDs or values that match this filter.
    /// </summary>
    public required List<string> Values
    {
        get
        {
            if (!this._properties.TryGetValue("values", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'values' cannot be null",
                    new System::ArgumentOutOfRangeException("values", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'values' cannot be null",
                    new System::ArgumentNullException("values")
                );
        }
        init
        {
            this._properties["values"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Field.Validate();
        this.Operator.Validate();
        _ = this.Values;
    }

    public Filter() { }

    public Filter(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Customers.Credits.Ledger.Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The property of the price the block applies to. Only item_id is supported.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Customers.Credits.Ledger.FieldConverter))]
public enum Field
{
    ItemID,
}

sealed class FieldConverter : JsonConverter<global::Orb.Models.Customers.Credits.Ledger.Field>
{
    public override global::Orb.Models.Customers.Credits.Ledger.Field Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "item_id" => global::Orb.Models.Customers.Credits.Ledger.Field.ItemID,
            _ => (global::Orb.Models.Customers.Credits.Ledger.Field)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Customers.Credits.Ledger.Field value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Customers.Credits.Ledger.Field.ItemID => "item_id",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Should prices that match the filter be included or excluded.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Customers.Credits.Ledger.OperatorConverter))]
public enum Operator
{
    Includes,
    Excludes,
}

sealed class OperatorConverter : JsonConverter<global::Orb.Models.Customers.Credits.Ledger.Operator>
{
    public override global::Orb.Models.Customers.Credits.Ledger.Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => global::Orb.Models.Customers.Credits.Ledger.Operator.Includes,
            "excludes" => global::Orb.Models.Customers.Credits.Ledger.Operator.Excludes,
            _ => (global::Orb.Models.Customers.Credits.Ledger.Operator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Customers.Credits.Ledger.Operator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Customers.Credits.Ledger.Operator.Includes => "includes",
                global::Orb.Models.Customers.Credits.Ledger.Operator.Excludes => "excludes",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Passing `invoice_settings` automatically generates an invoice for the newly added
/// credits. If `invoice_settings` is passed, you must specify per_unit_cost_basis,
/// as the calculation of the invoice total is done on that basis.
/// </summary>
[JsonConverter(typeof(ModelConverter<InvoiceSettings>))]
public sealed record class InvoiceSettings : ModelBase, IFromRaw<InvoiceSettings>
{
    /// <summary>
    /// Whether the credits purchase invoice should auto collect with the customer's
    /// saved payment method.
    /// </summary>
    public required bool AutoCollection
    {
        get
        {
            if (!this._properties.TryGetValue("auto_collection", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'auto_collection' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "auto_collection",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["auto_collection"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An optional custom due date for the invoice. If not set, the due date will
    /// be calculated based on the `net_terms` value.
    /// </summary>
    public CustomDueDate? CustomDueDate
    {
        get
        {
            if (!this._properties.TryGetValue("custom_due_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CustomDueDate?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["custom_due_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 8601 format date that denotes when this invoice should be dated in
    /// the customer's timezone. If not provided, the invoice date will default to
    /// the credit block's effective date.
    /// </summary>
    public InvoiceDate? InvoiceDate
    {
        get
        {
            if (!this._properties.TryGetValue("invoice_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<InvoiceDate?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["invoice_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The ID of the Item to be used for the invoice line item. If not provided,
    /// a default 'Credits' item will be used.
    /// </summary>
    public string? ItemID
    {
        get
        {
            if (!this._properties.TryGetValue("item_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An optional memo to display on the invoice.
    /// </summary>
    public string? Memo
    {
        get
        {
            if (!this._properties.TryGetValue("memo", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["memo"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The net terms determines the due date of the invoice. Due date is calculated
    /// based on the invoice or issuance date, depending on the account's configured
    /// due date calculation method. A value of '0' here represents that the invoice
    /// is due on issue, whereas a value of '30' represents that the customer has
    /// 30 days to pay the invoice. Do not set this field if you want to set a custom
    /// due date.
    /// </summary>
    public long? NetTerms
    {
        get
        {
            if (!this._properties.TryGetValue("net_terms", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["net_terms"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If true, the new credit block will require that the corresponding invoice
    /// is paid before it can be drawn down from.
    /// </summary>
    public bool? RequireSuccessfulPayment
    {
        get
        {
            if (
                !this._properties.TryGetValue("require_successful_payment", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["require_successful_payment"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.AutoCollection;
        this.CustomDueDate?.Validate();
        this.InvoiceDate?.Validate();
        _ = this.ItemID;
        _ = this.Memo;
        _ = this.NetTerms;
        _ = this.RequireSuccessfulPayment;
    }

    public InvoiceSettings() { }

    public InvoiceSettings(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceSettings(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static InvoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public InvoiceSettings(bool autoCollection)
        : this()
    {
        this.AutoCollection = autoCollection;
    }
}

/// <summary>
/// An optional custom due date for the invoice. If not set, the due date will be
/// calculated based on the `net_terms` value.
/// </summary>
[JsonConverter(typeof(CustomDueDateConverter))]
public record class CustomDueDate
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public CustomDueDate(System::DateOnly value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public CustomDueDate(System::DateTimeOffset value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public CustomDueDate(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickDate([NotNullWhen(true)] out System::DateOnly? value)
    {
        value = this.Value as System::DateOnly?;
        return value != null;
    }

    public bool TryPickDateTime([NotNullWhen(true)] out System::DateTimeOffset? value)
    {
        value = this.Value as System::DateTimeOffset?;
        return value != null;
    }

    public void Switch(
        System::Action<System::DateOnly> @date,
        System::Action<System::DateTimeOffset> @dateTime
    )
    {
        switch (this.Value)
        {
            case System::DateOnly value:
                @date(value);
                break;
            case System::DateTimeOffset value:
                @dateTime(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of CustomDueDate"
                );
        }
    }

    public T Match<T>(
        System::Func<System::DateOnly, T> @date,
        System::Func<System::DateTimeOffset, T> @dateTime
    )
    {
        return this.Value switch
        {
            System::DateOnly value => @date(value),
            System::DateTimeOffset value => @dateTime(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of CustomDueDate"
            ),
        };
    }

    public static implicit operator CustomDueDate(System::DateOnly value) => new(value);

    public static implicit operator CustomDueDate(System::DateTimeOffset value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of CustomDueDate");
        }
    }
}

sealed class CustomDueDateConverter : JsonConverter<CustomDueDate?>
{
    public override CustomDueDate? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<System::DateOnly>(json, options));
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<System::DateTimeOffset>(json, options));
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomDueDate? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// An ISO 8601 format date that denotes when this invoice should be dated in the
/// customer's timezone. If not provided, the invoice date will default to the credit
/// block's effective date.
/// </summary>
[JsonConverter(typeof(InvoiceDateConverter))]
public record class InvoiceDate
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public InvoiceDate(System::DateOnly value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public InvoiceDate(System::DateTimeOffset value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public InvoiceDate(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickDate([NotNullWhen(true)] out System::DateOnly? value)
    {
        value = this.Value as System::DateOnly?;
        return value != null;
    }

    public bool TryPickDateTime([NotNullWhen(true)] out System::DateTimeOffset? value)
    {
        value = this.Value as System::DateTimeOffset?;
        return value != null;
    }

    public void Switch(
        System::Action<System::DateOnly> @date,
        System::Action<System::DateTimeOffset> @dateTime
    )
    {
        switch (this.Value)
        {
            case System::DateOnly value:
                @date(value);
                break;
            case System::DateTimeOffset value:
                @dateTime(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of InvoiceDate");
        }
    }

    public T Match<T>(
        System::Func<System::DateOnly, T> @date,
        System::Func<System::DateTimeOffset, T> @dateTime
    )
    {
        return this.Value switch
        {
            System::DateOnly value => @date(value),
            System::DateTimeOffset value => @dateTime(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of InvoiceDate"),
        };
    }

    public static implicit operator InvoiceDate(System::DateOnly value) => new(value);

    public static implicit operator InvoiceDate(System::DateTimeOffset value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of InvoiceDate");
        }
    }
}

sealed class InvoiceDateConverter : JsonConverter<InvoiceDate?>
{
    public override InvoiceDate? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<System::DateOnly>(json, options));
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<System::DateTimeOffset>(json, options));
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceDate? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(ModelConverter<Decrement>))]
public sealed record class Decrement : ModelBase, IFromRaw<Decrement>
{
    /// <summary>
    /// The number of credits to effect. Note that this is required for increment,
    /// decrement, void, or undo operations.
    /// </summary>
    public required double Amount
    {
        get
        {
            if (!this._properties.TryGetValue("amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new System::ArgumentOutOfRangeException("amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public DecrementEntryType EntryType
    {
        get
        {
            if (!this._properties.TryGetValue("entry_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'entry_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "entry_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<DecrementEntryType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'entry_type' cannot be null",
                    new System::ArgumentNullException("entry_type")
                );
        }
        init
        {
            this._properties["entry_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The currency or custom pricing unit to use for this ledger entry. If this
    /// is a real-world currency, it must match the customer's invoicing currency.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional metadata that can be specified when adding ledger results via the
    /// API. For example, this can be used to note an increment refers to trial credits,
    /// or for noting corrections as a result of an incident, etc.
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this._properties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Amount;
        this.EntryType.Validate();
        _ = this.Currency;
        _ = this.Description;
        _ = this.Metadata;
    }

    public Decrement()
    {
        this.EntryType = new();
    }

    public Decrement(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.EntryType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Decrement(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Decrement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public Decrement(double amount)
        : this()
    {
        this.Amount = amount;
    }
}

[JsonConverter(typeof(Converter))]
public class DecrementEntryType
{
    public JsonElement Json { get; private init; }

    public DecrementEntryType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"decrement\"");
    }

    DecrementEntryType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new DecrementEntryType().Json))
        {
            throw new OrbInvalidDataException("Invalid value given for 'DecrementEntryType'");
        }
    }

    class Converter : JsonConverter<DecrementEntryType>
    {
        public override DecrementEntryType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            DecrementEntryType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(ModelConverter<ExpirationChange>))]
public sealed record class ExpirationChange : ModelBase, IFromRaw<ExpirationChange>
{
    public ExpirationChangeEntryType EntryType
    {
        get
        {
            if (!this._properties.TryGetValue("entry_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'entry_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "entry_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ExpirationChangeEntryType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'entry_type' cannot be null",
                    new System::ArgumentNullException("entry_type")
                );
        }
        init
        {
            this._properties["entry_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A future date (specified in YYYY-MM-DD format) used for expiration change,
    /// denoting when credits transferred (as part of a partial block expiration)
    /// should expire.
    /// </summary>
    public required System::DateOnly TargetExpiryDate
    {
        get
        {
            if (!this._properties.TryGetValue("target_expiry_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'target_expiry_date' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "target_expiry_date",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateOnly>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["target_expiry_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of credits to effect. Note that this is required for increment,
    /// decrement, void, or undo operations.
    /// </summary>
    public double? Amount
    {
        get
        {
            if (!this._properties.TryGetValue("amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The ID of the block affected by an expiration_change, used to differentiate
    /// between multiple blocks with the same `expiry_date`.
    /// </summary>
    public string? BlockID
    {
        get
        {
            if (!this._properties.TryGetValue("block_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["block_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The currency or custom pricing unit to use for this ledger entry. If this
    /// is a real-world currency, it must match the customer's invoicing currency.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional metadata that can be specified when adding ledger results via the
    /// API. For example, this can be used to note an increment refers to trial credits,
    /// or for noting corrections as a result of an incident, etc.
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this._properties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An ISO 8601 format date that identifies the origination credit block to expire
    /// </summary>
    public System::DateTimeOffset? ExpiryDate
    {
        get
        {
            if (!this._properties.TryGetValue("expiry_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTimeOffset?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["expiry_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.EntryType.Validate();
        _ = this.TargetExpiryDate;
        _ = this.Amount;
        _ = this.BlockID;
        _ = this.Currency;
        _ = this.Description;
        _ = this.ExpiryDate;
        _ = this.Metadata;
    }

    public ExpirationChange()
    {
        this.EntryType = new();
    }

    public ExpirationChange(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.EntryType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExpirationChange(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ExpirationChange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public ExpirationChange(System::DateOnly targetExpiryDate)
        : this()
    {
        this.TargetExpiryDate = targetExpiryDate;
    }
}

[JsonConverter(typeof(Converter))]
public class ExpirationChangeEntryType
{
    public JsonElement Json { get; private init; }

    public ExpirationChangeEntryType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"expiration_change\"");
    }

    ExpirationChangeEntryType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new ExpirationChangeEntryType().Json))
        {
            throw new OrbInvalidDataException(
                "Invalid value given for 'ExpirationChangeEntryType'"
            );
        }
    }

    class Converter : JsonConverter<ExpirationChangeEntryType>
    {
        public override ExpirationChangeEntryType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            ExpirationChangeEntryType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(ModelConverter<Void>))]
public sealed record class Void : ModelBase, IFromRaw<Void>
{
    /// <summary>
    /// The number of credits to effect. Note that this is required for increment,
    /// decrement, void, or undo operations.
    /// </summary>
    public required double Amount
    {
        get
        {
            if (!this._properties.TryGetValue("amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new System::ArgumentOutOfRangeException("amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The ID of the block to void.
    /// </summary>
    public required string BlockID
    {
        get
        {
            if (!this._properties.TryGetValue("block_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'block_id' cannot be null",
                    new System::ArgumentOutOfRangeException("block_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'block_id' cannot be null",
                    new System::ArgumentNullException("block_id")
                );
        }
        init
        {
            this._properties["block_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public VoidEntryType EntryType
    {
        get
        {
            if (!this._properties.TryGetValue("entry_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'entry_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "entry_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<VoidEntryType>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'entry_type' cannot be null",
                    new System::ArgumentNullException("entry_type")
                );
        }
        init
        {
            this._properties["entry_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The currency or custom pricing unit to use for this ledger entry. If this
    /// is a real-world currency, it must match the customer's invoicing currency.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional metadata that can be specified when adding ledger results via the
    /// API. For example, this can be used to note an increment refers to trial credits,
    /// or for noting corrections as a result of an incident, etc.
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this._properties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Can only be specified when `entry_type=void`. The reason for the void.
    /// </summary>
    public ApiEnum<string, VoidReason>? VoidReason
    {
        get
        {
            if (!this._properties.TryGetValue("void_reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, VoidReason>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["void_reason"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Amount;
        _ = this.BlockID;
        this.EntryType.Validate();
        _ = this.Currency;
        _ = this.Description;
        _ = this.Metadata;
        this.VoidReason?.Validate();
    }

    public Void()
    {
        this.EntryType = new();
    }

    public Void(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.EntryType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Void(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Void FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(Converter))]
public class VoidEntryType
{
    public JsonElement Json { get; private init; }

    public VoidEntryType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"void\"");
    }

    VoidEntryType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new VoidEntryType().Json))
        {
            throw new OrbInvalidDataException("Invalid value given for 'VoidEntryType'");
        }
    }

    class Converter : JsonConverter<VoidEntryType>
    {
        public override VoidEntryType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            VoidEntryType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

/// <summary>
/// Can only be specified when `entry_type=void`. The reason for the void.
/// </summary>
[JsonConverter(typeof(VoidReasonConverter))]
public enum VoidReason
{
    Refund,
}

sealed class VoidReasonConverter : JsonConverter<VoidReason>
{
    public override VoidReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "refund" => VoidReason.Refund,
            _ => (VoidReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VoidReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VoidReason.Refund => "refund",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<Amendment>))]
public sealed record class Amendment : ModelBase, IFromRaw<Amendment>
{
    /// <summary>
    /// The number of credits to effect. Note that this is required for increment,
    /// decrement or void operations.
    /// </summary>
    public required double Amount
    {
        get
        {
            if (!this._properties.TryGetValue("amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new System::ArgumentOutOfRangeException("amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The ID of the block to reverse a decrement from.
    /// </summary>
    public required string BlockID
    {
        get
        {
            if (!this._properties.TryGetValue("block_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'block_id' cannot be null",
                    new System::ArgumentOutOfRangeException("block_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'block_id' cannot be null",
                    new System::ArgumentNullException("block_id")
                );
        }
        init
        {
            this._properties["block_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public AmendmentEntryType EntryType
    {
        get
        {
            if (!this._properties.TryGetValue("entry_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'entry_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "entry_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<AmendmentEntryType>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'entry_type' cannot be null",
                    new System::ArgumentNullException("entry_type")
                );
        }
        init
        {
            this._properties["entry_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The currency or custom pricing unit to use for this ledger entry. If this
    /// is a real-world currency, it must match the customer's invoicing currency.
    /// </summary>
    public string? Currency
    {
        get
        {
            if (!this._properties.TryGetValue("currency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional metadata that can be specified when adding ledger results via the
    /// API. For example, this can be used to note an increment refers to trial credits,
    /// or for noting corrections as a result of an incident, etc.
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this._properties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public Dictionary<string, string?>? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Amount;
        _ = this.BlockID;
        this.EntryType.Validate();
        _ = this.Currency;
        _ = this.Description;
        _ = this.Metadata;
    }

    public Amendment()
    {
        this.EntryType = new();
    }

    public Amendment(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.EntryType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Amendment(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Amendment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(Converter))]
public class AmendmentEntryType
{
    public JsonElement Json { get; private init; }

    public AmendmentEntryType()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"amendment\"");
    }

    AmendmentEntryType(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new AmendmentEntryType().Json))
        {
            throw new OrbInvalidDataException("Invalid value given for 'AmendmentEntryType'");
        }
    }

    class Converter : JsonConverter<AmendmentEntryType>
    {
        public override AmendmentEntryType? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            AmendmentEntryType value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}
