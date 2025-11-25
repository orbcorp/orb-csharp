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
        get
        {
            if (!this._rawBodyData.TryGetValue("currency", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentOutOfRangeException("currency", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'currency' cannot be null",
                    new System::ArgumentNullException("currency")
                );
        }
        init
        {
            this._rawBodyData["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional invoice date to set. Must be in the past, if not set, `invoice_date`
    /// is set to the current time in the customer's timezone.
    /// </summary>
    public required System::DateTimeOffset InvoiceDate
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("invoice_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'invoice_date' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "invoice_date",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTimeOffset>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["invoice_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required List<global::Orb.Models.Invoices.LineItem> LineItems
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("line_items", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'line_items' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "line_items",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<List<global::Orb.Models.Invoices.LineItem>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new OrbInvalidDataException(
                    "'line_items' cannot be null",
                    new System::ArgumentNullException("line_items")
                );
        }
        init
        {
            this._rawBodyData["line_items"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the `Customer` to create this invoice for. One of `customer_id`
    /// and `external_customer_id` are required.
    /// </summary>
    public string? CustomerID
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["customer_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An optional discount to attach to the invoice.
    /// </summary>
    public SharedDiscount? Discount
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("discount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<SharedDiscount?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["discount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An optional custom due date for the invoice. If not set, the due date will
    /// be calculated based on the `net_terms` value.
    /// </summary>
    public DueDate? DueDate
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("due_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DueDate?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["due_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The `external_customer_id` of the `Customer` to create this invoice for.
    /// One of `customer_id` and `external_customer_id` are required.
    /// </summary>
    public string? ExternalCustomerID
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("external_customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["external_customer_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An optional memo to attach to the invoice. If no memo is provided, we will
    /// attach the default memo
    /// </summary>
    public string? Memo
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("memo", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["memo"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawBodyData.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawBodyData["metadata"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawBodyData.TryGetValue("net_terms", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawBodyData["net_terms"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// When true, this invoice will be submitted for issuance upon creation. When
    /// false, the resulting invoice will require manual review to issue. Defaulted
    /// to false.
    /// </summary>
    public bool? WillAutoIssue
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("will_auto_issue", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["will_auto_issue"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public InvoiceCreateParams() { }

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

[JsonConverter(
    typeof(ModelConverter<
        global::Orb.Models.Invoices.LineItem,
        global::Orb.Models.Invoices.LineItemFromRaw
    >)
)]
public sealed record class LineItem : ModelBase
{
    /// <summary>
    /// A date string to specify the line item's end date in the customer's timezone.
    /// </summary>
    public required System::DateOnly EndDate
    {
        get
        {
            if (!this._rawData.TryGetValue("end_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'end_date' cannot be null",
                    new System::ArgumentOutOfRangeException("end_date", "Missing required argument")
                );

            return JsonSerializer.Deserialize<System::DateOnly>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string ItemID
    {
        get
        {
            if (!this._rawData.TryGetValue("item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentOutOfRangeException("item_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'item_id' cannot be null",
                    new System::ArgumentNullException("item_id")
                );
        }
        init
        {
            this._rawData["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, global::Orb.Models.Invoices.ModelType> ModelType
    {
        get
        {
            if (!this._rawData.TryGetValue("model_type", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'model_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "model_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.Invoices.ModelType>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["model_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name of the line item.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._rawData.TryGetValue("name", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentNullException("name")
                );
        }
        init
        {
            this._rawData["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of units on the line item
    /// </summary>
    public required double Quantity
    {
        get
        {
            if (!this._rawData.TryGetValue("quantity", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'quantity' cannot be null",
                    new System::ArgumentOutOfRangeException("quantity", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["quantity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A date string to specify the line item's start date in the customer's timezone.
    /// </summary>
    public required System::DateOnly StartDate
    {
        get
        {
            if (!this._rawData.TryGetValue("start_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'start_date' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "start_date",
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
            this._rawData["start_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for unit pricing
    /// </summary>
    public required UnitConfig UnitConfig
    {
        get
        {
            if (!this._rawData.TryGetValue("unit_config", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'unit_config' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "unit_config",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<UnitConfig>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'unit_config' cannot be null",
                    new System::ArgumentNullException("unit_config")
                );
        }
        init
        {
            this._rawData["unit_config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public static global::Orb.Models.Invoices.LineItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LineItemFromRaw : IFromRaw<global::Orb.Models.Invoices.LineItem>
{
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

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public DueDate(System::DateOnly value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public DueDate(System::DateTimeOffset value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public DueDate(JsonElement json)
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
                throw new OrbInvalidDataException("Data did not match any variant of DueDate");
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
            _ => throw new OrbInvalidDataException("Data did not match any variant of DueDate"),
        };
    }

    public static implicit operator DueDate(System::DateOnly value) => new(value);

    public static implicit operator DueDate(System::DateTimeOffset value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of DueDate");
        }
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

    public override void Write(Utf8JsonWriter writer, DueDate? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}
