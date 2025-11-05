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
/// This endpoint allows you to update the `metadata`, `net_terms`, `due_date`, and
/// `invoice_date` properties on an invoice. If you pass null for the metadata value,
/// it will clear any existing metadata for that invoice.
///
/// `metadata` can be modified regardless of invoice state. `net_terms`, `due_date`,
/// and `invoice_date` can only be modified if the invoice is in a `draft` state.
/// `invoice_date` can only be modified for non-subscription invoices.
/// </summary>
public sealed record class InvoiceUpdateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string InvoiceID;

    /// <summary>
    /// An optional custom due date for the invoice. If not set, the due date will
    /// be calculated based on the `net_terms` value.
    /// </summary>
    public DueDateModel? DueDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("due_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DueDateModel?>(element, ModelBase.SerializerOptions);
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
    /// The date of the invoice. Can only be modified for one-off draft invoices.
    /// </summary>
    public InvoiceDate? InvoiceDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("invoice_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<InvoiceDate?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["invoice_date"] = JsonSerializer.SerializeToElement(
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

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/invoices/{0}", this.InvoiceID)
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

/// <summary>
/// An optional custom due date for the invoice. If not set, the due date will be
/// calculated based on the `net_terms` value.
/// </summary>
[JsonConverter(typeof(DueDateModelConverter))]
public record class DueDateModel
{
    public object Value { get; private init; }

    public DueDateModel(System::DateOnly value)
    {
        Value = value;
    }

    public DueDateModel(System::DateTime value)
    {
        Value = value;
    }

    DueDateModel(UnknownVariant value)
    {
        Value = value;
    }

    public static DueDateModel CreateUnknownVariant(JsonElement value)
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
                throw new OrbInvalidDataException("Data did not match any variant of DueDateModel");
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
                "Data did not match any variant of DueDateModel"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of DueDateModel");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class DueDateModelConverter : JsonConverter<DueDateModel?>
{
    public override DueDateModel? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<OrbInvalidDataException> exceptions = [];

        try
        {
            return new DueDateModel(
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
            return new DueDateModel(
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
        DueDateModel? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

/// <summary>
/// The date of the invoice. Can only be modified for one-off draft invoices.
/// </summary>
[JsonConverter(typeof(InvoiceDateConverter))]
public record class InvoiceDate
{
    public object Value { get; private init; }

    public InvoiceDate(System::DateOnly value)
    {
        Value = value;
    }

    public InvoiceDate(System::DateTime value)
    {
        Value = value;
    }

    InvoiceDate(UnknownVariant value)
    {
        Value = value;
    }

    public static InvoiceDate CreateUnknownVariant(JsonElement value)
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
                throw new OrbInvalidDataException("Data did not match any variant of InvoiceDate");
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
            _ => throw new OrbInvalidDataException("Data did not match any variant of InvoiceDate"),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new OrbInvalidDataException("Data did not match any variant of InvoiceDate");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class InvoiceDateConverter : JsonConverter<InvoiceDate?>
{
    public override InvoiceDate? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<OrbInvalidDataException> exceptions = [];

        try
        {
            return new InvoiceDate(
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
            return new InvoiceDate(
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
        InvoiceDate? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
