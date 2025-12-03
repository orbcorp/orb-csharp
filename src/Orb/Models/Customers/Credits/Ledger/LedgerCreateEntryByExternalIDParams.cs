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
public sealed record class LedgerCreateEntryByExternalIDParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ExternalCustomerID { get; init; }

    public required LedgerCreateEntryByExternalIDParamsBody Body
    {
        get
        {
            return ModelBase.GetNotNullClass<LedgerCreateEntryByExternalIDParamsBody>(
                this.RawBodyData,
                "body"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "body", value); }
    }

    public LedgerCreateEntryByExternalIDParams() { }

    public LedgerCreateEntryByExternalIDParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LedgerCreateEntryByExternalIDParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    public static LedgerCreateEntryByExternalIDParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/customers/external_customer_id/{0}/credits/ledger_entry",
                    this.ExternalCustomerID
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(LedgerCreateEntryByExternalIDParamsBodyConverter))]
public record class LedgerCreateEntryByExternalIDParamsBody
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

    public JsonElement EntryType
    {
        get
        {
            return Match(
                increment: (x) => x.EntryType,
                decrement: (x) => x.EntryType,
                expirationChange: (x) => x.EntryType,
                void1: (x) => x.EntryType,
                amendment: (x) => x.EntryType
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

    public LedgerCreateEntryByExternalIDParamsBody(
        LedgerCreateEntryByExternalIDParamsBodyIncrement value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public LedgerCreateEntryByExternalIDParamsBody(
        LedgerCreateEntryByExternalIDParamsBodyDecrement value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public LedgerCreateEntryByExternalIDParamsBody(
        LedgerCreateEntryByExternalIDParamsBodyExpirationChange value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public LedgerCreateEntryByExternalIDParamsBody(
        LedgerCreateEntryByExternalIDParamsBodyVoid value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public LedgerCreateEntryByExternalIDParamsBody(
        LedgerCreateEntryByExternalIDParamsBodyAmendment value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public LedgerCreateEntryByExternalIDParamsBody(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickIncrement(
        [NotNullWhen(true)] out LedgerCreateEntryByExternalIDParamsBodyIncrement? value
    )
    {
        value = this.Value as LedgerCreateEntryByExternalIDParamsBodyIncrement;
        return value != null;
    }

    public bool TryPickDecrement(
        [NotNullWhen(true)] out LedgerCreateEntryByExternalIDParamsBodyDecrement? value
    )
    {
        value = this.Value as LedgerCreateEntryByExternalIDParamsBodyDecrement;
        return value != null;
    }

    public bool TryPickExpirationChange(
        [NotNullWhen(true)] out LedgerCreateEntryByExternalIDParamsBodyExpirationChange? value
    )
    {
        value = this.Value as LedgerCreateEntryByExternalIDParamsBodyExpirationChange;
        return value != null;
    }

    public bool TryPickVoid(
        [NotNullWhen(true)] out LedgerCreateEntryByExternalIDParamsBodyVoid? value
    )
    {
        value = this.Value as LedgerCreateEntryByExternalIDParamsBodyVoid;
        return value != null;
    }

    public bool TryPickAmendment(
        [NotNullWhen(true)] out LedgerCreateEntryByExternalIDParamsBodyAmendment? value
    )
    {
        value = this.Value as LedgerCreateEntryByExternalIDParamsBodyAmendment;
        return value != null;
    }

    public void Switch(
        System::Action<LedgerCreateEntryByExternalIDParamsBodyIncrement> increment,
        System::Action<LedgerCreateEntryByExternalIDParamsBodyDecrement> decrement,
        System::Action<LedgerCreateEntryByExternalIDParamsBodyExpirationChange> expirationChange,
        System::Action<LedgerCreateEntryByExternalIDParamsBodyVoid> void1,
        System::Action<LedgerCreateEntryByExternalIDParamsBodyAmendment> amendment
    )
    {
        switch (this.Value)
        {
            case LedgerCreateEntryByExternalIDParamsBodyIncrement value:
                increment(value);
                break;
            case LedgerCreateEntryByExternalIDParamsBodyDecrement value:
                decrement(value);
                break;
            case LedgerCreateEntryByExternalIDParamsBodyExpirationChange value:
                expirationChange(value);
                break;
            case LedgerCreateEntryByExternalIDParamsBodyVoid value:
                void1(value);
                break;
            case LedgerCreateEntryByExternalIDParamsBodyAmendment value:
                amendment(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of LedgerCreateEntryByExternalIDParamsBody"
                );
        }
    }

    public T Match<T>(
        System::Func<LedgerCreateEntryByExternalIDParamsBodyIncrement, T> increment,
        System::Func<LedgerCreateEntryByExternalIDParamsBodyDecrement, T> decrement,
        System::Func<LedgerCreateEntryByExternalIDParamsBodyExpirationChange, T> expirationChange,
        System::Func<LedgerCreateEntryByExternalIDParamsBodyVoid, T> void1,
        System::Func<LedgerCreateEntryByExternalIDParamsBodyAmendment, T> amendment
    )
    {
        return this.Value switch
        {
            LedgerCreateEntryByExternalIDParamsBodyIncrement value => increment(value),
            LedgerCreateEntryByExternalIDParamsBodyDecrement value => decrement(value),
            LedgerCreateEntryByExternalIDParamsBodyExpirationChange value => expirationChange(
                value
            ),
            LedgerCreateEntryByExternalIDParamsBodyVoid value => void1(value),
            LedgerCreateEntryByExternalIDParamsBodyAmendment value => amendment(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of LedgerCreateEntryByExternalIDParamsBody"
            ),
        };
    }

    public static implicit operator LedgerCreateEntryByExternalIDParamsBody(
        LedgerCreateEntryByExternalIDParamsBodyIncrement value
    ) => new(value);

    public static implicit operator LedgerCreateEntryByExternalIDParamsBody(
        LedgerCreateEntryByExternalIDParamsBodyDecrement value
    ) => new(value);

    public static implicit operator LedgerCreateEntryByExternalIDParamsBody(
        LedgerCreateEntryByExternalIDParamsBodyExpirationChange value
    ) => new(value);

    public static implicit operator LedgerCreateEntryByExternalIDParamsBody(
        LedgerCreateEntryByExternalIDParamsBodyVoid value
    ) => new(value);

    public static implicit operator LedgerCreateEntryByExternalIDParamsBody(
        LedgerCreateEntryByExternalIDParamsBodyAmendment value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of LedgerCreateEntryByExternalIDParamsBody"
            );
        }
    }

    public virtual bool Equals(LedgerCreateEntryByExternalIDParamsBody? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class LedgerCreateEntryByExternalIDParamsBodyConverter
    : JsonConverter<LedgerCreateEntryByExternalIDParamsBody>
{
    public override LedgerCreateEntryByExternalIDParamsBody? Read(
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
                    var deserialized =
                        JsonSerializer.Deserialize<LedgerCreateEntryByExternalIDParamsBodyIncrement>(
                            json,
                            options
                        );
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
                    var deserialized =
                        JsonSerializer.Deserialize<LedgerCreateEntryByExternalIDParamsBodyDecrement>(
                            json,
                            options
                        );
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
                    var deserialized =
                        JsonSerializer.Deserialize<LedgerCreateEntryByExternalIDParamsBodyExpirationChange>(
                            json,
                            options
                        );
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
                    var deserialized =
                        JsonSerializer.Deserialize<LedgerCreateEntryByExternalIDParamsBodyVoid>(
                            json,
                            options
                        );
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
                    var deserialized =
                        JsonSerializer.Deserialize<LedgerCreateEntryByExternalIDParamsBodyAmendment>(
                            json,
                            options
                        );
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
                return new LedgerCreateEntryByExternalIDParamsBody(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        LedgerCreateEntryByExternalIDParamsBody value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        LedgerCreateEntryByExternalIDParamsBodyIncrement,
        LedgerCreateEntryByExternalIDParamsBodyIncrementFromRaw
    >)
)]
public sealed record class LedgerCreateEntryByExternalIDParamsBodyIncrement : ModelBase
{
    /// <summary>
    /// The number of credits to effect. Note that this is required for increment,
    /// decrement, void, or undo operations.
    /// </summary>
    public required double Amount
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "amount"); }
        init { ModelBase.Set(this._rawData, "amount", value); }
    }

    public JsonElement EntryType
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "entry_type"); }
        init { ModelBase.Set(this._rawData, "entry_type", value); }
    }

    /// <summary>
    /// The currency or custom pricing unit to use for this ledger entry. If this
    /// is a real-world currency, it must match the customer's invoicing currency.
    /// </summary>
    public string? Currency
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// Optional metadata that can be specified when adding ledger results via the
    /// API. For example, this can be used to note an increment refers to trial credits,
    /// or for noting corrections as a result of an incident, etc.
    /// </summary>
    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "description"); }
        init { ModelBase.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// An ISO 8601 format date that denotes when this credit balance should become
    /// available for use.
    /// </summary>
    public System::DateTimeOffset? EffectiveDate
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(
                this.RawData,
                "effective_date"
            );
        }
        init { ModelBase.Set(this._rawData, "effective_date", value); }
    }

    /// <summary>
    /// An ISO 8601 format date that denotes when this credit balance should expire.
    /// </summary>
    public System::DateTimeOffset? ExpiryDate
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(this.RawData, "expiry_date");
        }
        init { ModelBase.Set(this._rawData, "expiry_date", value); }
    }

    /// <summary>
    /// Optional filter to specify which items this credit block applies to. If not
    /// specified, the block will apply to all items for the pricing unit.
    /// </summary>
    public IReadOnlyList<LedgerCreateEntryByExternalIDParamsBodyIncrementFilter>? Filters
    {
        get
        {
            return ModelBase.GetNullableClass<
                List<LedgerCreateEntryByExternalIDParamsBodyIncrementFilter>
            >(this.RawData, "filters");
        }
        init { ModelBase.Set(this._rawData, "filters", value); }
    }

    /// <summary>
    /// Passing `invoice_settings` automatically generates an invoice for the newly
    /// added credits. If `invoice_settings` is passed, you must specify per_unit_cost_basis,
    /// as the calculation of the invoice total is done on that basis.
    /// </summary>
    public LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings? InvoiceSettings
    {
        get
        {
            return ModelBase.GetNullableClass<LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings>(
                this.RawData,
                "invoice_settings"
            );
        }
        init { ModelBase.Set(this._rawData, "invoice_settings", value); }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// Can only be specified when entry_type=increment. How much, in the customer's
    /// currency, a customer paid for a single credit in this block
    /// </summary>
    public string? PerUnitCostBasis
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "per_unit_cost_basis"); }
        init { ModelBase.Set(this._rawData, "per_unit_cost_basis", value); }
    }

    public override void Validate()
    {
        _ = this.Amount;
        if (
            !JsonElement.DeepEquals(
                this.EntryType,
                JsonSerializer.Deserialize<JsonElement>("\"increment\"")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
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

    public LedgerCreateEntryByExternalIDParamsBodyIncrement()
    {
        this.EntryType = JsonSerializer.Deserialize<JsonElement>("\"increment\"");
    }

    public LedgerCreateEntryByExternalIDParamsBodyIncrement(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.EntryType = JsonSerializer.Deserialize<JsonElement>("\"increment\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LedgerCreateEntryByExternalIDParamsBodyIncrement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static LedgerCreateEntryByExternalIDParamsBodyIncrement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public LedgerCreateEntryByExternalIDParamsBodyIncrement(double amount)
        : this()
    {
        this.Amount = amount;
    }
}

class LedgerCreateEntryByExternalIDParamsBodyIncrementFromRaw
    : IFromRaw<LedgerCreateEntryByExternalIDParamsBodyIncrement>
{
    public LedgerCreateEntryByExternalIDParamsBodyIncrement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LedgerCreateEntryByExternalIDParamsBodyIncrement.FromRawUnchecked(rawData);
}

/// <summary>
/// A PriceFilter that only allows item_id field for block filters.
/// </summary>
[JsonConverter(
    typeof(ModelConverter<
        LedgerCreateEntryByExternalIDParamsBodyIncrementFilter,
        LedgerCreateEntryByExternalIDParamsBodyIncrementFilterFromRaw
    >)
)]
public sealed record class LedgerCreateEntryByExternalIDParamsBodyIncrementFilter : ModelBase
{
    /// <summary>
    /// The property of the price the block applies to. Only item_id is supported.
    /// </summary>
    public required ApiEnum<
        string,
        LedgerCreateEntryByExternalIDParamsBodyIncrementFilterField
    > Field
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, LedgerCreateEntryByExternalIDParamsBodyIncrementFilterField>
            >(this.RawData, "field");
        }
        init { ModelBase.Set(this._rawData, "field", value); }
    }

    /// <summary>
    /// Should prices that match the filter be included or excluded.
    /// </summary>
    public required ApiEnum<
        string,
        LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperator
    > Operator
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperator>
            >(this.RawData, "operator");
        }
        init { ModelBase.Set(this._rawData, "operator", value); }
    }

    /// <summary>
    /// The IDs or values that match this filter.
    /// </summary>
    public required IReadOnlyList<string> Values
    {
        get { return ModelBase.GetNotNullClass<List<string>>(this.RawData, "values"); }
        init { ModelBase.Set(this._rawData, "values", value); }
    }

    public override void Validate()
    {
        this.Field.Validate();
        this.Operator.Validate();
        _ = this.Values;
    }

    public LedgerCreateEntryByExternalIDParamsBodyIncrementFilter() { }

    public LedgerCreateEntryByExternalIDParamsBodyIncrementFilter(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LedgerCreateEntryByExternalIDParamsBodyIncrementFilter(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static LedgerCreateEntryByExternalIDParamsBodyIncrementFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LedgerCreateEntryByExternalIDParamsBodyIncrementFilterFromRaw
    : IFromRaw<LedgerCreateEntryByExternalIDParamsBodyIncrementFilter>
{
    public LedgerCreateEntryByExternalIDParamsBodyIncrementFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LedgerCreateEntryByExternalIDParamsBodyIncrementFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// The property of the price the block applies to. Only item_id is supported.
/// </summary>
[JsonConverter(typeof(LedgerCreateEntryByExternalIDParamsBodyIncrementFilterFieldConverter))]
public enum LedgerCreateEntryByExternalIDParamsBodyIncrementFilterField
{
    ItemID,
}

sealed class LedgerCreateEntryByExternalIDParamsBodyIncrementFilterFieldConverter
    : JsonConverter<LedgerCreateEntryByExternalIDParamsBodyIncrementFilterField>
{
    public override LedgerCreateEntryByExternalIDParamsBodyIncrementFilterField Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "item_id" => LedgerCreateEntryByExternalIDParamsBodyIncrementFilterField.ItemID,
            _ => (LedgerCreateEntryByExternalIDParamsBodyIncrementFilterField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LedgerCreateEntryByExternalIDParamsBodyIncrementFilterField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LedgerCreateEntryByExternalIDParamsBodyIncrementFilterField.ItemID => "item_id",
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
[JsonConverter(typeof(LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperatorConverter))]
public enum LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperator
{
    Includes,
    Excludes,
}

sealed class LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperatorConverter
    : JsonConverter<LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperator>
{
    public override LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperator.Includes,
            "excludes" => LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperator.Excludes,
            _ => (LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperator.Includes =>
                    "includes",
                LedgerCreateEntryByExternalIDParamsBodyIncrementFilterOperator.Excludes =>
                    "excludes",
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
[JsonConverter(
    typeof(ModelConverter<
        LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings,
        LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsFromRaw
    >)
)]
public sealed record class LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings
    : ModelBase
{
    /// <summary>
    /// Whether the credits purchase invoice should auto collect with the customer's
    /// saved payment method.
    /// </summary>
    public required bool AutoCollection
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "auto_collection"); }
        init { ModelBase.Set(this._rawData, "auto_collection", value); }
    }

    /// <summary>
    /// An optional custom due date for the invoice. If not set, the due date will
    /// be calculated based on the `net_terms` value.
    /// </summary>
    public LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsCustomDueDate? CustomDueDate
    {
        get
        {
            return ModelBase.GetNullableClass<LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsCustomDueDate>(
                this.RawData,
                "custom_due_date"
            );
        }
        init { ModelBase.Set(this._rawData, "custom_due_date", value); }
    }

    /// <summary>
    /// An ISO 8601 format date that denotes when this invoice should be dated in
    /// the customer's timezone. If not provided, the invoice date will default to
    /// the credit block's effective date.
    /// </summary>
    public LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsInvoiceDate? InvoiceDate
    {
        get
        {
            return ModelBase.GetNullableClass<LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsInvoiceDate>(
                this.RawData,
                "invoice_date"
            );
        }
        init { ModelBase.Set(this._rawData, "invoice_date", value); }
    }

    /// <summary>
    /// The ID of the Item to be used for the invoice line item. If not provided,
    /// a default 'Credits' item will be used.
    /// </summary>
    public string? ItemID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "item_id"); }
        init { ModelBase.Set(this._rawData, "item_id", value); }
    }

    /// <summary>
    /// An optional memo to display on the invoice.
    /// </summary>
    public string? Memo
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "memo"); }
        init { ModelBase.Set(this._rawData, "memo", value); }
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
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "net_terms"); }
        init { ModelBase.Set(this._rawData, "net_terms", value); }
    }

    /// <summary>
    /// If true, the new credit block will require that the corresponding invoice
    /// is paid before it can be drawn down from.
    /// </summary>
    public bool? RequireSuccessfulPayment
    {
        get
        {
            return ModelBase.GetNullableStruct<bool>(this.RawData, "require_successful_payment");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "require_successful_payment", value);
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

    public LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings() { }

    public LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings(bool autoCollection)
        : this()
    {
        this.AutoCollection = autoCollection;
    }
}

class LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsFromRaw
    : IFromRaw<LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings>
{
    public LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// An optional custom due date for the invoice. If not set, the due date will be
/// calculated based on the `net_terms` value.
/// </summary>
[JsonConverter(
    typeof(LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsCustomDueDateConverter)
)]
public record class LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsCustomDueDate
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsCustomDueDate(
#if NET
        System::DateOnly
#else
        System::DateTimeOffset
#endif
        value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsCustomDueDate(
        System::DateTimeOffset value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsCustomDueDate(
        JsonElement json
    )
    {
        this._json = json;
    }

    public bool TryPickDate([NotNullWhen(true)] out
#if NET
        System::DateOnly
#else
        System::DateTimeOffset
#endif
        ? value)
    {
        value = this.Value as
#if NET
            System::DateOnly
#else
            System::DateTimeOffset
#endif
            ?;
        return value != null;
    }

    public bool TryPickDateTime([NotNullWhen(true)] out System::DateTimeOffset? value)
    {
        value = this.Value as System::DateTimeOffset?;
        return value != null;
    }

    public void Switch(
        System::Action<
#if NET
        System::DateOnly
#else
        System::DateTimeOffset
#endif
        > @date,
        System::Action<System::DateTimeOffset> @dateTime
    )
    {
        switch (this.Value)
        {
            case
#if NET
            System::DateOnly
#else
            System::DateTimeOffset
#endif
            value:
                @date(value);
                break;
            case System::DateTimeOffset value:
                @dateTime(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsCustomDueDate"
                );
        }
    }

    public T Match<T>(
        System::Func<
#if NET
            System::DateOnly
#else
            System::DateTimeOffset
#endif
            , T> @date,
        System::Func<System::DateTimeOffset, T> @dateTime
    )
    {
        return this.Value switch
        {
#if NET
            System::DateOnly
#else
            System::DateTimeOffset
#endif
            value => @date(value),
            System::DateTimeOffset value => @dateTime(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsCustomDueDate"
            ),
        };
    }

    public static implicit operator LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsCustomDueDate(
#if NET
        System::DateOnly
#else
        System::DateTimeOffset
#endif
        value
    ) => new(value);

    public static implicit operator LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsCustomDueDate(
        System::DateTimeOffset value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsCustomDueDate"
            );
        }
    }

    public virtual bool Equals(
        LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsCustomDueDate? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsCustomDueDateConverter
    : JsonConverter<LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsCustomDueDate?>
{
    public override LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsCustomDueDate? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<
#if NET
                System::DateOnly
#else
                System::DateTimeOffset
#endif
                >(json, options));
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
        LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsCustomDueDate? value,
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
[JsonConverter(
    typeof(LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsInvoiceDateConverter)
)]
public record class LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsInvoiceDate
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsInvoiceDate(
#if NET
        System::DateOnly
#else
        System::DateTimeOffset
#endif
        value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsInvoiceDate(
        System::DateTimeOffset value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsInvoiceDate(
        JsonElement json
    )
    {
        this._json = json;
    }

    public bool TryPickDate([NotNullWhen(true)] out
#if NET
        System::DateOnly
#else
        System::DateTimeOffset
#endif
        ? value)
    {
        value = this.Value as
#if NET
            System::DateOnly
#else
            System::DateTimeOffset
#endif
            ?;
        return value != null;
    }

    public bool TryPickDateTime([NotNullWhen(true)] out System::DateTimeOffset? value)
    {
        value = this.Value as System::DateTimeOffset?;
        return value != null;
    }

    public void Switch(
        System::Action<
#if NET
        System::DateOnly
#else
        System::DateTimeOffset
#endif
        > @date,
        System::Action<System::DateTimeOffset> @dateTime
    )
    {
        switch (this.Value)
        {
            case
#if NET
            System::DateOnly
#else
            System::DateTimeOffset
#endif
            value:
                @date(value);
                break;
            case System::DateTimeOffset value:
                @dateTime(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsInvoiceDate"
                );
        }
    }

    public T Match<T>(
        System::Func<
#if NET
            System::DateOnly
#else
            System::DateTimeOffset
#endif
            , T> @date,
        System::Func<System::DateTimeOffset, T> @dateTime
    )
    {
        return this.Value switch
        {
#if NET
            System::DateOnly
#else
            System::DateTimeOffset
#endif
            value => @date(value),
            System::DateTimeOffset value => @dateTime(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsInvoiceDate"
            ),
        };
    }

    public static implicit operator LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsInvoiceDate(
#if NET
        System::DateOnly
#else
        System::DateTimeOffset
#endif
        value
    ) => new(value);

    public static implicit operator LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsInvoiceDate(
        System::DateTimeOffset value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsInvoiceDate"
            );
        }
    }

    public virtual bool Equals(
        LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsInvoiceDate? other
    )
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsInvoiceDateConverter
    : JsonConverter<LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsInvoiceDate?>
{
    public override LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsInvoiceDate? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<
#if NET
                System::DateOnly
#else
                System::DateTimeOffset
#endif
                >(json, options));
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
        LedgerCreateEntryByExternalIDParamsBodyIncrementInvoiceSettingsInvoiceDate? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        LedgerCreateEntryByExternalIDParamsBodyDecrement,
        LedgerCreateEntryByExternalIDParamsBodyDecrementFromRaw
    >)
)]
public sealed record class LedgerCreateEntryByExternalIDParamsBodyDecrement : ModelBase
{
    /// <summary>
    /// The number of credits to effect. Note that this is required for increment,
    /// decrement, void, or undo operations.
    /// </summary>
    public required double Amount
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "amount"); }
        init { ModelBase.Set(this._rawData, "amount", value); }
    }

    public JsonElement EntryType
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "entry_type"); }
        init { ModelBase.Set(this._rawData, "entry_type", value); }
    }

    /// <summary>
    /// The currency or custom pricing unit to use for this ledger entry. If this
    /// is a real-world currency, it must match the customer's invoicing currency.
    /// </summary>
    public string? Currency
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// Optional metadata that can be specified when adding ledger results via the
    /// API. For example, this can be used to note an increment refers to trial credits,
    /// or for noting corrections as a result of an incident, etc.
    /// </summary>
    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "description"); }
        init { ModelBase.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    public override void Validate()
    {
        _ = this.Amount;
        if (
            !JsonElement.DeepEquals(
                this.EntryType,
                JsonSerializer.Deserialize<JsonElement>("\"decrement\"")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
        _ = this.Currency;
        _ = this.Description;
        _ = this.Metadata;
    }

    public LedgerCreateEntryByExternalIDParamsBodyDecrement()
    {
        this.EntryType = JsonSerializer.Deserialize<JsonElement>("\"decrement\"");
    }

    public LedgerCreateEntryByExternalIDParamsBodyDecrement(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.EntryType = JsonSerializer.Deserialize<JsonElement>("\"decrement\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LedgerCreateEntryByExternalIDParamsBodyDecrement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static LedgerCreateEntryByExternalIDParamsBodyDecrement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public LedgerCreateEntryByExternalIDParamsBodyDecrement(double amount)
        : this()
    {
        this.Amount = amount;
    }
}

class LedgerCreateEntryByExternalIDParamsBodyDecrementFromRaw
    : IFromRaw<LedgerCreateEntryByExternalIDParamsBodyDecrement>
{
    public LedgerCreateEntryByExternalIDParamsBodyDecrement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LedgerCreateEntryByExternalIDParamsBodyDecrement.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        LedgerCreateEntryByExternalIDParamsBodyExpirationChange,
        LedgerCreateEntryByExternalIDParamsBodyExpirationChangeFromRaw
    >)
)]
public sealed record class LedgerCreateEntryByExternalIDParamsBodyExpirationChange : ModelBase
{
    public JsonElement EntryType
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "entry_type"); }
        init { ModelBase.Set(this._rawData, "entry_type", value); }
    }

    /// <summary>
    /// A future date (specified in YYYY-MM-DD format) used for expiration change,
    /// denoting when credits transferred (as part of a partial block expiration)
    /// should expire.
    /// </summary>
    public required
#if NET
    System::DateOnly
#else
    System::DateTimeOffset
#endif
    TargetExpiryDate
    {
        get
        {
            return ModelBase.GetNotNullStruct<
#if NET
            System::DateOnly
#else
            System::DateTimeOffset
#endif
            >(this.RawData, "target_expiry_date");
        }
        init { ModelBase.Set(this._rawData, "target_expiry_date", value); }
    }

    /// <summary>
    /// The number of credits to effect. Note that this is required for increment,
    /// decrement, void, or undo operations.
    /// </summary>
    public double? Amount
    {
        get { return ModelBase.GetNullableStruct<double>(this.RawData, "amount"); }
        init { ModelBase.Set(this._rawData, "amount", value); }
    }

    /// <summary>
    /// The ID of the block affected by an expiration_change, used to differentiate
    /// between multiple blocks with the same `expiry_date`.
    /// </summary>
    public string? BlockID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "block_id"); }
        init { ModelBase.Set(this._rawData, "block_id", value); }
    }

    /// <summary>
    /// The currency or custom pricing unit to use for this ledger entry. If this
    /// is a real-world currency, it must match the customer's invoicing currency.
    /// </summary>
    public string? Currency
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// Optional metadata that can be specified when adding ledger results via the
    /// API. For example, this can be used to note an increment refers to trial credits,
    /// or for noting corrections as a result of an incident, etc.
    /// </summary>
    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "description"); }
        init { ModelBase.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// An ISO 8601 format date that identifies the origination credit block to expire
    /// </summary>
    public System::DateTimeOffset? ExpiryDate
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(this.RawData, "expiry_date");
        }
        init { ModelBase.Set(this._rawData, "expiry_date", value); }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.EntryType,
                JsonSerializer.Deserialize<JsonElement>("\"expiration_change\"")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
        _ = this.TargetExpiryDate;
        _ = this.Amount;
        _ = this.BlockID;
        _ = this.Currency;
        _ = this.Description;
        _ = this.ExpiryDate;
        _ = this.Metadata;
    }

    public LedgerCreateEntryByExternalIDParamsBodyExpirationChange()
    {
        this.EntryType = JsonSerializer.Deserialize<JsonElement>("\"expiration_change\"");
    }

    public LedgerCreateEntryByExternalIDParamsBodyExpirationChange(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.EntryType = JsonSerializer.Deserialize<JsonElement>("\"expiration_change\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LedgerCreateEntryByExternalIDParamsBodyExpirationChange(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static LedgerCreateEntryByExternalIDParamsBodyExpirationChange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public LedgerCreateEntryByExternalIDParamsBodyExpirationChange(
#if NET
        System::DateOnly
#else
        System::DateTimeOffset
#endif
        targetExpiryDate
    )
        : this()
    {
        this.TargetExpiryDate = targetExpiryDate;
    }
}

class LedgerCreateEntryByExternalIDParamsBodyExpirationChangeFromRaw
    : IFromRaw<LedgerCreateEntryByExternalIDParamsBodyExpirationChange>
{
    public LedgerCreateEntryByExternalIDParamsBodyExpirationChange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LedgerCreateEntryByExternalIDParamsBodyExpirationChange.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        LedgerCreateEntryByExternalIDParamsBodyVoid,
        LedgerCreateEntryByExternalIDParamsBodyVoidFromRaw
    >)
)]
public sealed record class LedgerCreateEntryByExternalIDParamsBodyVoid : ModelBase
{
    /// <summary>
    /// The number of credits to effect. Note that this is required for increment,
    /// decrement, void, or undo operations.
    /// </summary>
    public required double Amount
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "amount"); }
        init { ModelBase.Set(this._rawData, "amount", value); }
    }

    /// <summary>
    /// The ID of the block to void.
    /// </summary>
    public required string BlockID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "block_id"); }
        init { ModelBase.Set(this._rawData, "block_id", value); }
    }

    public JsonElement EntryType
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "entry_type"); }
        init { ModelBase.Set(this._rawData, "entry_type", value); }
    }

    /// <summary>
    /// The currency or custom pricing unit to use for this ledger entry. If this
    /// is a real-world currency, it must match the customer's invoicing currency.
    /// </summary>
    public string? Currency
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// Optional metadata that can be specified when adding ledger results via the
    /// API. For example, this can be used to note an increment refers to trial credits,
    /// or for noting corrections as a result of an incident, etc.
    /// </summary>
    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "description"); }
        init { ModelBase.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// Can only be specified when `entry_type=void`. The reason for the void.
    /// </summary>
    public ApiEnum<string, LedgerCreateEntryByExternalIDParamsBodyVoidVoidReason>? VoidReason
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, LedgerCreateEntryByExternalIDParamsBodyVoidVoidReason>
            >(this.RawData, "void_reason");
        }
        init { ModelBase.Set(this._rawData, "void_reason", value); }
    }

    public override void Validate()
    {
        _ = this.Amount;
        _ = this.BlockID;
        if (
            !JsonElement.DeepEquals(
                this.EntryType,
                JsonSerializer.Deserialize<JsonElement>("\"void\"")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
        _ = this.Currency;
        _ = this.Description;
        _ = this.Metadata;
        this.VoidReason?.Validate();
    }

    public LedgerCreateEntryByExternalIDParamsBodyVoid()
    {
        this.EntryType = JsonSerializer.Deserialize<JsonElement>("\"void\"");
    }

    public LedgerCreateEntryByExternalIDParamsBodyVoid(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.EntryType = JsonSerializer.Deserialize<JsonElement>("\"void\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LedgerCreateEntryByExternalIDParamsBodyVoid(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static LedgerCreateEntryByExternalIDParamsBodyVoid FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LedgerCreateEntryByExternalIDParamsBodyVoidFromRaw
    : IFromRaw<LedgerCreateEntryByExternalIDParamsBodyVoid>
{
    public LedgerCreateEntryByExternalIDParamsBodyVoid FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LedgerCreateEntryByExternalIDParamsBodyVoid.FromRawUnchecked(rawData);
}

/// <summary>
/// Can only be specified when `entry_type=void`. The reason for the void.
/// </summary>
[JsonConverter(typeof(LedgerCreateEntryByExternalIDParamsBodyVoidVoidReasonConverter))]
public enum LedgerCreateEntryByExternalIDParamsBodyVoidVoidReason
{
    Refund,
}

sealed class LedgerCreateEntryByExternalIDParamsBodyVoidVoidReasonConverter
    : JsonConverter<LedgerCreateEntryByExternalIDParamsBodyVoidVoidReason>
{
    public override LedgerCreateEntryByExternalIDParamsBodyVoidVoidReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "refund" => LedgerCreateEntryByExternalIDParamsBodyVoidVoidReason.Refund,
            _ => (LedgerCreateEntryByExternalIDParamsBodyVoidVoidReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LedgerCreateEntryByExternalIDParamsBodyVoidVoidReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LedgerCreateEntryByExternalIDParamsBodyVoidVoidReason.Refund => "refund",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(ModelConverter<
        LedgerCreateEntryByExternalIDParamsBodyAmendment,
        LedgerCreateEntryByExternalIDParamsBodyAmendmentFromRaw
    >)
)]
public sealed record class LedgerCreateEntryByExternalIDParamsBodyAmendment : ModelBase
{
    /// <summary>
    /// The number of credits to effect. Note that this is required for increment,
    /// decrement or void operations.
    /// </summary>
    public required double Amount
    {
        get { return ModelBase.GetNotNullStruct<double>(this.RawData, "amount"); }
        init { ModelBase.Set(this._rawData, "amount", value); }
    }

    /// <summary>
    /// The ID of the block to reverse a decrement from.
    /// </summary>
    public required string BlockID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "block_id"); }
        init { ModelBase.Set(this._rawData, "block_id", value); }
    }

    public JsonElement EntryType
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "entry_type"); }
        init { ModelBase.Set(this._rawData, "entry_type", value); }
    }

    /// <summary>
    /// The currency or custom pricing unit to use for this ledger entry. If this
    /// is a real-world currency, it must match the customer's invoicing currency.
    /// </summary>
    public string? Currency
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "currency"); }
        init { ModelBase.Set(this._rawData, "currency", value); }
    }

    /// <summary>
    /// Optional metadata that can be specified when adding ledger results via the
    /// API. For example, this can be used to note an increment refers to trial credits,
    /// or for noting corrections as a result of an incident, etc.
    /// </summary>
    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "description"); }
        init { ModelBase.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// User-specified key/value pairs for the resource. Individual keys can be removed
    /// by setting the value to `null`, and the entire metadata mapping can be cleared
    /// by setting `metadata` to `null`.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, string?>>(
                this.RawData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    public override void Validate()
    {
        _ = this.Amount;
        _ = this.BlockID;
        if (
            !JsonElement.DeepEquals(
                this.EntryType,
                JsonSerializer.Deserialize<JsonElement>("\"amendment\"")
            )
        )
        {
            throw new OrbInvalidDataException("Invalid value given for constant");
        }
        _ = this.Currency;
        _ = this.Description;
        _ = this.Metadata;
    }

    public LedgerCreateEntryByExternalIDParamsBodyAmendment()
    {
        this.EntryType = JsonSerializer.Deserialize<JsonElement>("\"amendment\"");
    }

    public LedgerCreateEntryByExternalIDParamsBodyAmendment(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.EntryType = JsonSerializer.Deserialize<JsonElement>("\"amendment\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LedgerCreateEntryByExternalIDParamsBodyAmendment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static LedgerCreateEntryByExternalIDParamsBodyAmendment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LedgerCreateEntryByExternalIDParamsBodyAmendmentFromRaw
    : IFromRaw<LedgerCreateEntryByExternalIDParamsBodyAmendment>
{
    public LedgerCreateEntryByExternalIDParamsBodyAmendment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LedgerCreateEntryByExternalIDParamsBodyAmendment.FromRawUnchecked(rawData);
}
