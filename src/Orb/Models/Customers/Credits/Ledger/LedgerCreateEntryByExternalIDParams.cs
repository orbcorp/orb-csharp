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
/// ## Effects of adding a ledger entry 1. After calling this endpoint, [Fetch Credit
/// Balance](fetch-customer-credits) will return a credit block that   represents
/// the changes (i.e. balance changes or transfers). 2. A ledger entry will be added
/// to the credits ledger for this customer, and therefore returned in the   [View
/// Credits Ledger](fetch-customer-credits-ledger) response as well as serialized
/// in the response to this request. In   the case of deductions without a specified
/// block, multiple ledger entries may be created if the deduction spans   credit
/// blocks. 3. If `invoice_settings` is specified, an invoice will be created that
/// reflects the cost of the credits (based on   `amount` and `per_unit_cost_basis`).
///
/// ## Adding credits   Adding credits is done by creating an entry of type `increment`.
/// This requires the caller to specify a number of   credits as well as an optional
/// expiry date in `YYYY-MM-DD` format. Orb also recommends specifying a description
///   to assist with auditing. When adding credits, the caller can also specify a
/// cost basis per-credit, to indicate   how much in USD a customer paid for a single
/// credit in a block. This can later be used for revenue recognition.
///
/// The following snippet illustrates a sample request body to increment credits
/// which will expire in January of 2022.
///
/// ```json {   "entry_type": "increment",   "amount": 100,   "expiry_date": "2022-12-28",
///   "per_unit_cost_basis": "0.20",   "description": "Purchased 100 credits" } ```
///
/// Note that by default, Orb will always first increment any _negative_ balance in
/// existing blocks before adding the remaining amount to the desired credit block.
///
/// ### Invoicing for credits By default, Orb manipulates the credit ledger but does
/// not charge for credits. However, if you pass `invoice_settings` in the body of
/// this request, Orb will also generate a one-off invoice for the customer for the
/// credits pre-purchase. Note that you _must_ provide the `per_unit_cost_basis`,
/// since the total charges on the invoice are calculated by multiplying the cost
/// basis with the number of credit units added.
///
/// ## Deducting Credits Orb allows you to deduct credits from a customer by creating
/// an entry of type `decrement`. Orb matches the algorithm for automatic deductions
/// for determining which credit blocks to decrement from. In the case that the deduction
/// leads to multiple ledger entries, the response from this endpoint will be the
/// final deduction. Orb also optionally allows specifying a description to assist
/// with auditing.
///
/// The following snippet illustrates a sample request body to decrement credits.
///
/// ```json {   "entry_type": "decrement",   "amount": 20,   "description": "Removing
/// excess credits" } ```
///
/// ## Changing credits expiry If you'd like to change when existing credits expire,
/// you should create a ledger entry of type `expiration_change`. For this entry,
/// the required parameter `expiry_date` identifies the _originating_ block, and the
/// required parameter `target_expiry_date` identifies when the transferred credits
/// should now expire. A new credit block will be created with expiry date `target_expiry_date`,
/// with the same cost basis data as the original credit block, if present.
///
/// Note that the balance of the block with the given `expiry_date` must be at least
/// equal to the desired transfer amount determined by the `amount` parameter.
///
/// The following snippet illustrates a sample request body to extend the expiration
/// date of credits by one year:
///
/// ```json {   "entry_type": "expiration_change",   "amount": 10,   "expiry_date":
/// "2022-12-28",   "block_id": "UiUhFWeLHPrBY4Ad",   "target_expiry_date": "2023-12-28",
///   "description": "Extending credit validity" } ```
///
/// ## Voiding credits
///
/// If you'd like to void a credit block, create a ledger entry of type `void`. For
/// this entry, `block_id` is required to identify the block, and `amount` indicates
/// how many credits to void, up to the block's initial balance. Pass in a `void_reason`
/// of `refund` if the void is due to a refund.
///
/// ## Amendment
///
/// If you'd like to undo a decrement on a credit block, create a ledger entry of
/// type `amendment`. For this entry, `block_id` is required to identify the block
/// that was originally decremented from, and `amount` indicates how many credits
/// to return to the customer, up to the block's initial balance.
/// </summary>
public sealed record class LedgerCreateEntryByExternalIDParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    public required string ExternalCustomerID { get; init; }

    public required BodyModel Body
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("body", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'body' cannot be null",
                    new System::ArgumentOutOfRangeException("body", "Missing required argument")
                );

            return JsonSerializer.Deserialize<BodyModel>(element, ModelBase.SerializerOptions)
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

    public LedgerCreateEntryByExternalIDParams() { }

    public LedgerCreateEntryByExternalIDParams(
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
    LedgerCreateEntryByExternalIDParams(
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

    public static LedgerCreateEntryByExternalIDParams FromRawUnchecked(
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

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/customers/external_customer_id/{0}/credits/ledger_entry",
                    this.ExternalCustomerID
                )
        )
        {
            Query = this.QueryString(client),
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

    internal override void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(BodyModelConverter))]
public record class BodyModel
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

    public System::DateTime? ExpiryDate
    {
        get
        {
            return Match<System::DateTime?>(
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

    public BodyModel(IncrementModel value)
    {
        Value = value;
    }

    public BodyModel(DecrementModel value)
    {
        Value = value;
    }

    public BodyModel(ExpirationChangeModel value)
    {
        Value = value;
    }

    public BodyModel(VoidModel value)
    {
        Value = value;
    }

    public BodyModel(AmendmentModel value)
    {
        Value = value;
    }

    BodyModel(UnknownVariant value)
    {
        Value = value;
    }

    public static BodyModel CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickIncrement([NotNullWhen(true)] out IncrementModel? value)
    {
        value = this.Value as IncrementModel;
        return value != null;
    }

    public bool TryPickDecrement([NotNullWhen(true)] out DecrementModel? value)
    {
        value = this.Value as DecrementModel;
        return value != null;
    }

    public bool TryPickExpirationChange([NotNullWhen(true)] out ExpirationChangeModel? value)
    {
        value = this.Value as ExpirationChangeModel;
        return value != null;
    }

    public bool TryPickVoid([NotNullWhen(true)] out VoidModel? value)
    {
        value = this.Value as VoidModel;
        return value != null;
    }

    public bool TryPickAmendment([NotNullWhen(true)] out AmendmentModel? value)
    {
        value = this.Value as AmendmentModel;
        return value != null;
    }

    public void Switch(
        System::Action<IncrementModel> increment,
        System::Action<DecrementModel> decrement,
        System::Action<ExpirationChangeModel> expirationChange,
        System::Action<VoidModel> void1,
        System::Action<AmendmentModel> amendment
    )
    {
        switch (this.Value)
        {
            case IncrementModel value:
                increment(value);
                break;
            case DecrementModel value:
                decrement(value);
                break;
            case ExpirationChangeModel value:
                expirationChange(value);
                break;
            case VoidModel value:
                void1(value);
                break;
            case AmendmentModel value:
                amendment(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of BodyModel");
        }
    }

    public T Match<T>(
        System::Func<IncrementModel, T> increment,
        System::Func<DecrementModel, T> decrement,
        System::Func<ExpirationChangeModel, T> expirationChange,
        System::Func<VoidModel, T> void1,
        System::Func<AmendmentModel, T> amendment
    )
    {
        return this.Value switch
        {
            IncrementModel value => increment(value),
            DecrementModel value => decrement(value),
            ExpirationChangeModel value => expirationChange(value),
            VoidModel value => void1(value),
            AmendmentModel value => amendment(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of BodyModel"),
        };
    }

    public static implicit operator BodyModel(IncrementModel value) => new(value);

    public static implicit operator BodyModel(DecrementModel value) => new(value);

    public static implicit operator BodyModel(ExpirationChangeModel value) => new(value);

    public static implicit operator BodyModel(VoidModel value) => new(value);

    public static implicit operator BodyModel(AmendmentModel value) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of BodyModel");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class BodyModelConverter : JsonConverter<BodyModel>
{
    public override BodyModel? Read(
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
                    var deserialized = JsonSerializer.Deserialize<IncrementModel>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BodyModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'IncrementModel'",
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
                    var deserialized = JsonSerializer.Deserialize<DecrementModel>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BodyModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'DecrementModel'",
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
                    var deserialized = JsonSerializer.Deserialize<ExpirationChangeModel>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BodyModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'ExpirationChangeModel'",
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
                    var deserialized = JsonSerializer.Deserialize<VoidModel>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BodyModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'VoidModel'",
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
                    var deserialized = JsonSerializer.Deserialize<AmendmentModel>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BodyModel(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is OrbInvalidDataException)
                {
                    exceptions.Add(
                        new OrbInvalidDataException(
                            "Data does not match union variant 'AmendmentModel'",
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
        BodyModel value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<IncrementModel>))]
public sealed record class IncrementModel : ModelBase, IFromRaw<IncrementModel>
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

    public EntryType5 EntryType
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

            return JsonSerializer.Deserialize<EntryType5>(element, ModelBase.SerializerOptions)
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
    public System::DateTime? EffectiveDate
    {
        get
        {
            if (!this._properties.TryGetValue("effective_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
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
    public System::DateTime? ExpiryDate
    {
        get
        {
            if (!this._properties.TryGetValue("expiry_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
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
    public List<global::Orb.Models.Customers.Credits.Ledger.FilterModel>? Filters
    {
        get
        {
            if (!this._properties.TryGetValue("filters", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<global::Orb.Models.Customers.Credits.Ledger.FilterModel>?>(
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
    public InvoiceSettingsModel? InvoiceSettings
    {
        get
        {
            if (!this._properties.TryGetValue("invoice_settings", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<InvoiceSettingsModel?>(
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

    public IncrementModel()
    {
        this.EntryType = new();
    }

    public IncrementModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.EntryType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IncrementModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static IncrementModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public IncrementModel(double amount)
        : this()
    {
        this.Amount = amount;
    }
}

[JsonConverter(typeof(Converter))]
public class EntryType5
{
    public JsonElement Json { get; private init; }

    public EntryType5()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"increment\"");
    }

    EntryType5(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new EntryType5().Json))
        {
            throw new OrbInvalidDataException("Invalid constant given for 'EntryType5'");
        }
    }

    class Converter : JsonConverter<EntryType5>
    {
        public override EntryType5? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            EntryType5 value,
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
[JsonConverter(typeof(ModelConverter<global::Orb.Models.Customers.Credits.Ledger.FilterModel>))]
public sealed record class FilterModel
    : ModelBase,
        IFromRaw<global::Orb.Models.Customers.Credits.Ledger.FilterModel>
{
    /// <summary>
    /// The property of the price the block applies to. Only item_id is supported.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.Customers.Credits.Ledger.FieldModel> Field
    {
        get
        {
            if (!this._properties.TryGetValue("field", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'field' cannot be null",
                    new System::ArgumentOutOfRangeException("field", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Customers.Credits.Ledger.FieldModel>
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
    public required ApiEnum<
        string,
        global::Orb.Models.Customers.Credits.Ledger.OperatorModel
    > Operator
    {
        get
        {
            if (!this._properties.TryGetValue("operator", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Customers.Credits.Ledger.OperatorModel>
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

    public FilterModel() { }

    public FilterModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FilterModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Customers.Credits.Ledger.FilterModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The property of the price the block applies to. Only item_id is supported.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.Customers.Credits.Ledger.FieldModelConverter))]
public enum FieldModel
{
    ItemID,
}

sealed class FieldModelConverter
    : JsonConverter<global::Orb.Models.Customers.Credits.Ledger.FieldModel>
{
    public override global::Orb.Models.Customers.Credits.Ledger.FieldModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "item_id" => global::Orb.Models.Customers.Credits.Ledger.FieldModel.ItemID,
            _ => (global::Orb.Models.Customers.Credits.Ledger.FieldModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Customers.Credits.Ledger.FieldModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Customers.Credits.Ledger.FieldModel.ItemID => "item_id",
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
[JsonConverter(typeof(global::Orb.Models.Customers.Credits.Ledger.OperatorModelConverter))]
public enum OperatorModel
{
    Includes,
    Excludes,
}

sealed class OperatorModelConverter
    : JsonConverter<global::Orb.Models.Customers.Credits.Ledger.OperatorModel>
{
    public override global::Orb.Models.Customers.Credits.Ledger.OperatorModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "includes" => global::Orb.Models.Customers.Credits.Ledger.OperatorModel.Includes,
            "excludes" => global::Orb.Models.Customers.Credits.Ledger.OperatorModel.Excludes,
            _ => (global::Orb.Models.Customers.Credits.Ledger.OperatorModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Customers.Credits.Ledger.OperatorModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Customers.Credits.Ledger.OperatorModel.Includes => "includes",
                global::Orb.Models.Customers.Credits.Ledger.OperatorModel.Excludes => "excludes",
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
[JsonConverter(typeof(ModelConverter<InvoiceSettingsModel>))]
public sealed record class InvoiceSettingsModel : ModelBase, IFromRaw<InvoiceSettingsModel>
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
    public CustomDueDateModel? CustomDueDate
    {
        get
        {
            if (!this._properties.TryGetValue("custom_due_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CustomDueDateModel?>(
                element,
                ModelBase.SerializerOptions
            );
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
    public InvoiceDateModel? InvoiceDate
    {
        get
        {
            if (!this._properties.TryGetValue("invoice_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<InvoiceDateModel?>(
                element,
                ModelBase.SerializerOptions
            );
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

    public InvoiceSettingsModel() { }

    public InvoiceSettingsModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceSettingsModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static InvoiceSettingsModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public InvoiceSettingsModel(bool autoCollection)
        : this()
    {
        this.AutoCollection = autoCollection;
    }
}

/// <summary>
/// An optional custom due date for the invoice. If not set, the due date will be
/// calculated based on the `net_terms` value.
/// </summary>
[JsonConverter(typeof(CustomDueDateModelConverter))]
public record class CustomDueDateModel
{
    public object Value { get; private init; }

    public CustomDueDateModel(System::DateOnly value)
    {
        Value = value;
    }

    public CustomDueDateModel(System::DateTime value)
    {
        Value = value;
    }

    CustomDueDateModel(UnknownVariant value)
    {
        Value = value;
    }

    public static CustomDueDateModel CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickDate([NotNullWhen(true)] out System::DateOnly? value)
    {
        value = this.Value as System::DateOnly?;
        return value != null;
    }

    public bool TryPickDateTime([NotNullWhen(true)] out System::DateTime? value)
    {
        value = this.Value as System::DateTime?;
        return value != null;
    }

    public void Switch(
        System::Action<System::DateOnly> @date,
        System::Action<System::DateTime> @dateTime
    )
    {
        switch (this.Value)
        {
            case System::DateOnly value:
                @date(value);
                break;
            case System::DateTime value:
                @dateTime(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of CustomDueDateModel"
                );
        }
    }

    public T Match<T>(
        System::Func<System::DateOnly, T> @date,
        System::Func<System::DateTime, T> @dateTime
    )
    {
        return this.Value switch
        {
            System::DateOnly value => @date(value),
            System::DateTime value => @dateTime(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of CustomDueDateModel"
            ),
        };
    }

    public static implicit operator CustomDueDateModel(System::DateOnly value) => new(value);

    public static implicit operator CustomDueDateModel(System::DateTime value) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException(
                "Data did not match any variant of CustomDueDateModel"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class CustomDueDateModelConverter : JsonConverter<CustomDueDateModel?>
{
    public override CustomDueDateModel? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<OrbInvalidDataException> exceptions = [];

        try
        {
            return new CustomDueDateModel(
                JsonSerializer.Deserialize<System::DateOnly>(ref reader, options)
            );
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant 'System::DateOnly'",
                    e
                )
            );
        }

        try
        {
            return new CustomDueDateModel(
                JsonSerializer.Deserialize<System::DateTime>(ref reader, options)
            );
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant 'System::DateTime'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomDueDateModel? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

/// <summary>
/// An ISO 8601 format date that denotes when this invoice should be dated in the
/// customer's timezone. If not provided, the invoice date will default to the credit
/// block's effective date.
/// </summary>
[JsonConverter(typeof(InvoiceDateModelConverter))]
public record class InvoiceDateModel
{
    public object Value { get; private init; }

    public InvoiceDateModel(System::DateOnly value)
    {
        Value = value;
    }

    public InvoiceDateModel(System::DateTime value)
    {
        Value = value;
    }

    InvoiceDateModel(UnknownVariant value)
    {
        Value = value;
    }

    public static InvoiceDateModel CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickDate([NotNullWhen(true)] out System::DateOnly? value)
    {
        value = this.Value as System::DateOnly?;
        return value != null;
    }

    public bool TryPickDateTime([NotNullWhen(true)] out System::DateTime? value)
    {
        value = this.Value as System::DateTime?;
        return value != null;
    }

    public void Switch(
        System::Action<System::DateOnly> @date,
        System::Action<System::DateTime> @dateTime
    )
    {
        switch (this.Value)
        {
            case System::DateOnly value:
                @date(value);
                break;
            case System::DateTime value:
                @dateTime(value);
                break;
            default:
                throw new OrbInvalidDataException(
                    "Data did not match any variant of InvoiceDateModel"
                );
        }
    }

    public T Match<T>(
        System::Func<System::DateOnly, T> @date,
        System::Func<System::DateTime, T> @dateTime
    )
    {
        return this.Value switch
        {
            System::DateOnly value => @date(value),
            System::DateTime value => @dateTime(value),
            _ => throw new OrbInvalidDataException(
                "Data did not match any variant of InvoiceDateModel"
            ),
        };
    }

    public static implicit operator InvoiceDateModel(System::DateOnly value) => new(value);

    public static implicit operator InvoiceDateModel(System::DateTime value) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of InvoiceDateModel");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class InvoiceDateModelConverter : JsonConverter<InvoiceDateModel?>
{
    public override InvoiceDateModel? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<OrbInvalidDataException> exceptions = [];

        try
        {
            return new InvoiceDateModel(
                JsonSerializer.Deserialize<System::DateOnly>(ref reader, options)
            );
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant 'System::DateOnly'",
                    e
                )
            );
        }

        try
        {
            return new InvoiceDateModel(
                JsonSerializer.Deserialize<System::DateTime>(ref reader, options)
            );
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            exceptions.Add(
                new OrbInvalidDataException(
                    "Data does not match union variant 'System::DateTime'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceDateModel? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<DecrementModel>))]
public sealed record class DecrementModel : ModelBase, IFromRaw<DecrementModel>
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

    public EntryType6 EntryType
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

            return JsonSerializer.Deserialize<EntryType6>(element, ModelBase.SerializerOptions)
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

    public DecrementModel()
    {
        this.EntryType = new();
    }

    public DecrementModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.EntryType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DecrementModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static DecrementModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public DecrementModel(double amount)
        : this()
    {
        this.Amount = amount;
    }
}

[JsonConverter(typeof(Converter))]
public class EntryType6
{
    public JsonElement Json { get; private init; }

    public EntryType6()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"decrement\"");
    }

    EntryType6(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new EntryType6().Json))
        {
            throw new OrbInvalidDataException("Invalid constant given for 'EntryType6'");
        }
    }

    class Converter : JsonConverter<EntryType6>
    {
        public override EntryType6? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            EntryType6 value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(ModelConverter<ExpirationChangeModel>))]
public sealed record class ExpirationChangeModel : ModelBase, IFromRaw<ExpirationChangeModel>
{
    public EntryType7 EntryType
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

            return JsonSerializer.Deserialize<EntryType7>(element, ModelBase.SerializerOptions)
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
    public System::DateTime? ExpiryDate
    {
        get
        {
            if (!this._properties.TryGetValue("expiry_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
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

    public ExpirationChangeModel()
    {
        this.EntryType = new();
    }

    public ExpirationChangeModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.EntryType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExpirationChangeModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ExpirationChangeModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public ExpirationChangeModel(System::DateOnly targetExpiryDate)
        : this()
    {
        this.TargetExpiryDate = targetExpiryDate;
    }
}

[JsonConverter(typeof(Converter))]
public class EntryType7
{
    public JsonElement Json { get; private init; }

    public EntryType7()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"expiration_change\"");
    }

    EntryType7(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new EntryType7().Json))
        {
            throw new OrbInvalidDataException("Invalid constant given for 'EntryType7'");
        }
    }

    class Converter : JsonConverter<EntryType7>
    {
        public override EntryType7? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            EntryType7 value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}

[JsonConverter(typeof(ModelConverter<VoidModel>))]
public sealed record class VoidModel : ModelBase, IFromRaw<VoidModel>
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

    public EntryType8 EntryType
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

            return JsonSerializer.Deserialize<EntryType8>(element, ModelBase.SerializerOptions)
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
    public ApiEnum<string, VoidReasonModel>? VoidReason
    {
        get
        {
            if (!this._properties.TryGetValue("void_reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, VoidReasonModel>?>(
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

    public VoidModel()
    {
        this.EntryType = new();
    }

    public VoidModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.EntryType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VoidModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static VoidModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(Converter))]
public class EntryType8
{
    public JsonElement Json { get; private init; }

    public EntryType8()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"void\"");
    }

    EntryType8(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new EntryType8().Json))
        {
            throw new OrbInvalidDataException("Invalid constant given for 'EntryType8'");
        }
    }

    class Converter : JsonConverter<EntryType8>
    {
        public override EntryType8? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            EntryType8 value,
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
[JsonConverter(typeof(VoidReasonModelConverter))]
public enum VoidReasonModel
{
    Refund,
}

sealed class VoidReasonModelConverter : JsonConverter<VoidReasonModel>
{
    public override VoidReasonModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "refund" => VoidReasonModel.Refund,
            _ => (VoidReasonModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VoidReasonModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VoidReasonModel.Refund => "refund",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<AmendmentModel>))]
public sealed record class AmendmentModel : ModelBase, IFromRaw<AmendmentModel>
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

    public EntryType9 EntryType
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

            return JsonSerializer.Deserialize<EntryType9>(element, ModelBase.SerializerOptions)
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

    public AmendmentModel()
    {
        this.EntryType = new();
    }

    public AmendmentModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.EntryType = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AmendmentModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static AmendmentModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(Converter))]
public class EntryType9
{
    public JsonElement Json { get; private init; }

    public EntryType9()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"amendment\"");
    }

    EntryType9(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new EntryType9().Json))
        {
            throw new OrbInvalidDataException("Invalid constant given for 'EntryType9'");
        }
    }

    class Converter : JsonConverter<EntryType9>
    {
        public override EntryType9? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            EntryType9 value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}
