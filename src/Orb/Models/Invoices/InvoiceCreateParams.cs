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

namespace Orb.Models.Invoices;

/// <summary>
/// This endpoint is used to create a one-off invoice for a customer.
/// </summary>
public sealed record class InvoiceCreateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// An ISO 4217 currency string. Must be the same as the customer's currency if
    /// it is set.
    /// </summary>
    public required string Currency
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawBodyData, "currency"); }
        init { JsonModel.Set(this._rawBodyData, "currency", value); }
    }

    /// <summary>
    /// Optional invoice date to set. Must be in the past, if not set, `invoice_date`
    /// is set to the current time in the customer's timezone.
    /// </summary>
    public required System::DateTimeOffset InvoiceDate
    {
        get
        {
            return JsonModel.GetNotNullStruct<System::DateTimeOffset>(
                this.RawBodyData,
                "invoice_date"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "invoice_date", value); }
    }

    public required IReadOnlyList<global::Orb.Models.Invoices.LineItem> LineItems
    {
        get
        {
            return JsonModel.GetNotNullClass<List<global::Orb.Models.Invoices.LineItem>>(
                this.RawBodyData,
                "line_items"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "line_items", value); }
    }

    /// <summary>
    /// The id of the `Customer` to create this invoice for. One of `customer_id`
    /// and `external_customer_id` are required.
    /// </summary>
    public string? CustomerID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "customer_id"); }
        init { JsonModel.Set(this._rawBodyData, "customer_id", value); }
    }

    /// <summary>
    /// An optional discount to attach to the invoice.
    /// </summary>
    public SharedDiscount? Discount
    {
        get { return JsonModel.GetNullableClass<SharedDiscount>(this.RawBodyData, "discount"); }
        init { JsonModel.Set(this._rawBodyData, "discount", value); }
    }

    /// <summary>
    /// An optional custom due date for the invoice. If not set, the due date will
    /// be calculated based on the `net_terms` value.
    /// </summary>
    public DueDate? DueDate
    {
        get { return JsonModel.GetNullableClass<DueDate>(this.RawBodyData, "due_date"); }
        init { JsonModel.Set(this._rawBodyData, "due_date", value); }
    }

    /// <summary>
    /// The `external_customer_id` of the `Customer` to create this invoice for.
    /// One of `customer_id` and `external_customer_id` are required.
    /// </summary>
    public string? ExternalCustomerID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "external_customer_id"); }
        init { JsonModel.Set(this._rawBodyData, "external_customer_id", value); }
    }

    /// <summary>
    /// An optional memo to attach to the invoice. If no memo is provided, we will
    /// attach the default memo
    /// </summary>
    public string? Memo
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "memo"); }
        init { JsonModel.Set(this._rawBodyData, "memo", value); }
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
            return JsonModel.GetNullableClass<Dictionary<string, string?>>(
                this.RawBodyData,
                "metadata"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "metadata", value); }
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
        get { return JsonModel.GetNullableStruct<long>(this.RawBodyData, "net_terms"); }
        init { JsonModel.Set(this._rawBodyData, "net_terms", value); }
    }

    /// <summary>
    /// When true, this invoice will be submitted for issuance upon creation. When
    /// false, the resulting invoice will require manual review to issue. Defaulted
    /// to false.
    /// </summary>
    public bool? WillAutoIssue
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "will_auto_issue"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "will_auto_issue", value);
        }
    }

    public InvoiceCreateParams() { }

    public InvoiceCreateParams(InvoiceCreateParams invoiceCreateParams)
        : base(invoiceCreateParams)
    {
        this._rawBodyData = [.. invoiceCreateParams._rawBodyData];
    }

    public InvoiceCreateParams(
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
    InvoiceCreateParams(
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

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static InvoiceCreateParams FromRawUnchecked(
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
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/invoices")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData),
            Encoding.UTF8,
            "application/json"
        );
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

[JsonConverter(
    typeof(JsonModelConverter<
        global::Orb.Models.Invoices.LineItem,
        global::Orb.Models.Invoices.LineItemFromRaw
    >)
)]
public sealed record class LineItem : JsonModel
{
    /// <summary>
    /// A date string to specify the line item's end date in the customer's timezone.
    /// </summary>
    public required string EndDate
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "end_date"); }
        init { JsonModel.Set(this._rawData, "end_date", value); }
    }

    public required string ItemID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "item_id"); }
        init { JsonModel.Set(this._rawData, "item_id", value); }
    }

    public required ApiEnum<string, global::Orb.Models.Invoices.ModelType> ModelType
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, global::Orb.Models.Invoices.ModelType>
            >(this.RawData, "model_type");
        }
        init { JsonModel.Set(this._rawData, "model_type", value); }
    }

    /// <summary>
    /// The name of the line item.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The number of units on the line item
    /// </summary>
    public required double Quantity
    {
        get { return JsonModel.GetNotNullStruct<double>(this.RawData, "quantity"); }
        init { JsonModel.Set(this._rawData, "quantity", value); }
    }

    /// <summary>
    /// A date string to specify the line item's start date in the customer's timezone.
    /// </summary>
    public required string StartDate
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "start_date"); }
        init { JsonModel.Set(this._rawData, "start_date", value); }
    }

    /// <summary>
    /// Configuration for unit pricing
    /// </summary>
    public required UnitConfig UnitConfig
    {
        get { return JsonModel.GetNotNullClass<UnitConfig>(this.RawData, "unit_config"); }
        init { JsonModel.Set(this._rawData, "unit_config", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EndDate;
        _ = this.ItemID;
        this.ModelType.Validate();
        _ = this.Name;
        _ = this.Quantity;
        _ = this.StartDate;
        this.UnitConfig.Validate();
    }

    public LineItem() { }

    public LineItem(global::Orb.Models.Invoices.LineItem lineItem)
        : base(lineItem) { }

    public LineItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LineItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Orb.Models.Invoices.LineItemFromRaw.FromRawUnchecked"/>
    public static global::Orb.Models.Invoices.LineItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LineItemFromRaw : IFromRawJson<global::Orb.Models.Invoices.LineItem>
{
    /// <inheritdoc/>
    public global::Orb.Models.Invoices.LineItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Orb.Models.Invoices.LineItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(global::Orb.Models.Invoices.ModelTypeConverter))]
public enum ModelType
{
    Unit,
}

sealed class ModelTypeConverter : JsonConverter<global::Orb.Models.Invoices.ModelType>
{
    public override global::Orb.Models.Invoices.ModelType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unit" => global::Orb.Models.Invoices.ModelType.Unit,
            _ => (global::Orb.Models.Invoices.ModelType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Invoices.ModelType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Invoices.ModelType.Unit => "unit",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// An optional custom due date for the invoice. If not set, the due date will be
/// calculated based on the `net_terms` value.
/// </summary>
[JsonConverter(typeof(DueDateConverter))]
public record class DueDate
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public DueDate(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public DueDate(System::DateTimeOffset value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public DueDate(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDate(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDate([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="System::DateTimeOffset"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDateTime(out var value)) {
    ///     // `value` is of type `System::DateTimeOffset`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDateTime([NotNullWhen(true)] out System::DateTimeOffset? value)
    {
        value = this.Value as System::DateTimeOffset?;
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
    ///     (string value) => {...},
    ///     (System::DateTimeOffset value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @date,
        System::Action<System::DateTimeOffset> @dateTime
    )
    {
        switch (this.Value)
        {
            case string value:
                @date(value);
                break;
            case System::DateTimeOffset value:
                @dateTime(value);
                break;
            default:
                throw new OrbInvalidDataException("Data did not match any variant of DueDate");
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
    ///     (string value) => {...},
    ///     (System::DateTimeOffset value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @date,
        System::Func<System::DateTimeOffset, T> @dateTime
    )
    {
        return this.Value switch
        {
            string value => @date(value),
            System::DateTimeOffset value => @dateTime(value),
            _ => throw new OrbInvalidDataException("Data did not match any variant of DueDate"),
        };
    }

    public static implicit operator DueDate(string value) => new(value);

    public static implicit operator DueDate(System::DateTimeOffset value) => new(value);

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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of DueDate");
        }
    }

    public virtual bool Equals(DueDate? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class DueDateConverter : JsonConverter<DueDate?>
{
    public override DueDate? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<System::DateTimeOffset>(element, options));
        }
        catch (System::Exception e) when (e is JsonException || e is OrbInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, DueDate? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}
