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
/// This endpoint allows you to update the `metadata`, `net_terms`, `due_date`, and
/// `invoice_date` properties on an invoice. If you pass null for the metadata value,
/// it will clear any existing metadata for that invoice.
///
/// <para>`metadata` can be modified regardless of invoice state. `net_terms`, `due_date`,
/// and `invoice_date` can only be modified if the invoice is in a `draft` state.
/// `invoice_date` can only be modified for non-subscription invoices.</para>
/// </summary>
public sealed record class InvoiceUpdateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? InvoiceID { get; init; }

    /// <summary>
    /// An optional custom due date for the invoice. If not set, the due date will
    /// be calculated based on the `net_terms` value.
    /// </summary>
    public DueDateModel? DueDate
    {
        get { return ModelBase.GetNullableClass<DueDateModel>(this.RawBodyData, "due_date"); }
        init { ModelBase.Set(this._rawBodyData, "due_date", value); }
    }

    /// <summary>
    /// The date of the invoice. Can only be modified for one-off draft invoices.
    /// </summary>
    public InvoiceDate? InvoiceDate
    {
        get { return ModelBase.GetNullableClass<InvoiceDate>(this.RawBodyData, "invoice_date"); }
        init { ModelBase.Set(this._rawBodyData, "invoice_date", value); }
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
                this.RawBodyData,
                "metadata"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "metadata", value); }
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
        get { return ModelBase.GetNullableStruct<long>(this.RawBodyData, "net_terms"); }
        init { ModelBase.Set(this._rawBodyData, "net_terms", value); }
    }

    public InvoiceUpdateParams() { }

    public InvoiceUpdateParams(
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
    InvoiceUpdateParams(
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

    public static InvoiceUpdateParams FromRawUnchecked(
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/invoices/{0}", this.InvoiceID)
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

/// <summary>
/// An optional custom due date for the invoice. If not set, the due date will be
/// calculated based on the `net_terms` value.
/// </summary>
[JsonConverter(typeof(DueDateModelConverter))]
public record class DueDateModel
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public DueDateModel(
#if NET
        System::DateOnly
#else
        System::DateTimeOffset
#endif
        value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public DueDateModel(System::DateTimeOffset value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public DueDateModel(JsonElement json)
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
                throw new OrbInvalidDataException("Data did not match any variant of DueDateModel");
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
                "Data did not match any variant of DueDateModel"
            ),
        };
    }

    public static implicit operator DueDateModel(
#if NET
        System::DateOnly
#else
        System::DateTimeOffset
#endif
        value) => new(value);

    public static implicit operator DueDateModel(System::DateTimeOffset value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of DueDateModel");
        }
    }

    public virtual bool Equals(DueDateModel? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class DueDateModelConverter : JsonConverter<DueDateModel?>
{
    public override DueDateModel? Read(
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
        DueDateModel? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// The date of the invoice. Can only be modified for one-off draft invoices.
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

    public InvoiceDate(
#if NET
        System::DateOnly
#else
        System::DateTimeOffset
#endif
        value, JsonElement? json = null)
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
                throw new OrbInvalidDataException("Data did not match any variant of InvoiceDate");
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
            _ => throw new OrbInvalidDataException("Data did not match any variant of InvoiceDate"),
        };
    }

    public static implicit operator InvoiceDate(
#if NET
        System::DateOnly
#else
        System::DateTimeOffset
#endif
        value) => new(value);

    public static implicit operator InvoiceDate(System::DateTimeOffset value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new OrbInvalidDataException("Data did not match any variant of InvoiceDate");
        }
    }

    public virtual bool Equals(InvoiceDate? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
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
        InvoiceDate? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}
