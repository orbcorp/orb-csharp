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
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// An ISO 4217 currency string. Must be the same as the customer's currency
    /// if it is set.
    /// </summary>
    public required string Currency
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("currency", out JsonElement element))
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
        set
        {
            this.BodyProperties["currency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional invoice date to set. Must be in the past, if not set, `invoice_date`
    /// is set to the current time in the customer's timezone.
    /// </summary>
    public required System::DateTime InvoiceDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("invoice_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'invoice_date' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "invoice_date",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["invoice_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required List<global::Orb.Models.Invoices.LineItem> LineItems
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("line_items", out JsonElement element))
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
        set
        {
            this.BodyProperties["line_items"] = JsonSerializer.SerializeToElement(
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
            if (!this.BodyProperties.TryGetValue("customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["customer_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An optional discount to attach to the invoice.
    /// </summary>
    public Discount1? Discount
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("discount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Discount1?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["discount"] = JsonSerializer.SerializeToElement(
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
            if (!this.BodyProperties.TryGetValue("due_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DueDate?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["due_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The `external_customer_id` of the `Customer` to create this invoice for. One
    /// of `customer_id` and `external_customer_id` are required.
    /// </summary>
    public string? ExternalCustomerID
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("external_customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["external_customer_id"] = JsonSerializer.SerializeToElement(
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
            if (!this.BodyProperties.TryGetValue("memo", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["memo"] = JsonSerializer.SerializeToElement(
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
            if (!this.BodyProperties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string?>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["metadata"] = JsonSerializer.SerializeToElement(
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
            if (!this.BodyProperties.TryGetValue("net_terms", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["net_terms"] = JsonSerializer.SerializeToElement(
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
            if (!this.BodyProperties.TryGetValue("will_auto_issue", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["will_auto_issue"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/invoices")
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

[JsonConverter(typeof(ModelConverter<global::Orb.Models.Invoices.LineItem>))]
public sealed record class LineItem : ModelBase, IFromRaw<global::Orb.Models.Invoices.LineItem>
{
    /// <summary>
    /// A date string to specify the line item's end date in the customer's timezone.
    /// </summary>
    public required System::DateOnly EndDate
    {
        get
        {
            if (!this.Properties.TryGetValue("end_date", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'end_date' cannot be null",
                    new System::ArgumentOutOfRangeException("end_date", "Missing required argument")
                );

            return JsonSerializer.Deserialize<System::DateOnly>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string ItemID
    {
        get
        {
            if (!this.Properties.TryGetValue("item_id", out JsonElement element))
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
        set
        {
            this.Properties["item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, global::Orb.Models.Invoices.ModelType> ModelType
    {
        get
        {
            if (!this.Properties.TryGetValue("model_type", out JsonElement element))
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
        set
        {
            this.Properties["model_type"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("name", out JsonElement element))
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
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("quantity", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'quantity' cannot be null",
                    new System::ArgumentOutOfRangeException("quantity", "Missing required argument")
                );

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["quantity"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("start_date", out JsonElement element))
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
        set
        {
            this.Properties["start_date"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("unit_config", out JsonElement element))
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
        set
        {
            this.Properties["unit_config"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LineItem(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static global::Orb.Models.Invoices.LineItem FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
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
    public object Value { get; private init; }

    public DueDate(System::DateOnly value)
    {
        Value = value;
    }

    public DueDate(System::DateTime value)
    {
        Value = value;
    }

    DueDate(UnknownVariant value)
    {
        Value = value;
    }

    public static DueDate CreateUnknownVariant(JsonElement value)
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
                throw new OrbInvalidDataException("Data did not match any variant of DueDate");
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
            _ => throw new OrbInvalidDataException("Data did not match any variant of DueDate"),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of DueDate");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class DueDateConverter : JsonConverter<DueDate?>
{
    public override DueDate? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<OrbInvalidDataException> exceptions = [];

        try
        {
            return new DueDate(JsonSerializer.Deserialize<System::DateOnly>(ref reader, options));
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
            return new DueDate(JsonSerializer.Deserialize<System::DateTime>(ref reader, options));
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

    public override void Write(Utf8JsonWriter writer, DueDate? value, JsonSerializerOptions options)
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
