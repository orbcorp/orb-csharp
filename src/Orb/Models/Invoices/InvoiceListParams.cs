using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Invoices;

/// <summary>
/// This endpoint returns a list of all [`Invoice`](/core-concepts#invoice)s for an
/// account in a list format.
///
/// <para>The list of invoices is ordered starting from the most recently issued
/// invoice date. The response also includes [`pagination_metadata`](/api-reference/pagination),
/// which lets the caller retrieve the next page of results if they exist.</para>
///
/// <para>By default, this only returns invoices that are `issued`, `paid`, or `synced`.</para>
///
/// <para>When fetching any `draft` invoices, this returns the last-computed invoice
/// values for each draft invoice, which may not always be up-to-date since Orb regularly
/// refreshes invoices asynchronously.</para>
/// </summary>
public sealed record class InvoiceListParams : ParamsBase
{
    public string? Amount
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "amount"); }
        init { ModelBase.Set(this._rawQueryData, "amount", value); }
    }

    public string? AmountGt
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "amount[gt]"); }
        init { ModelBase.Set(this._rawQueryData, "amount[gt]", value); }
    }

    public string? AmountLt
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "amount[lt]"); }
        init { ModelBase.Set(this._rawQueryData, "amount[lt]", value); }
    }

    /// <summary>
    /// Cursor for pagination. This can be populated by the `next_cursor` value returned
    /// from the initial request.
    /// </summary>
    public string? Cursor
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "cursor"); }
        init { ModelBase.Set(this._rawQueryData, "cursor", value); }
    }

    public string? CustomerID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "customer_id"); }
        init { ModelBase.Set(this._rawQueryData, "customer_id", value); }
    }

    public ApiEnum<string, DateType>? DateType
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, DateType>>(
                this.RawQueryData,
                "date_type"
            );
        }
        init { ModelBase.Set(this._rawQueryData, "date_type", value); }
    }

    public
#if NET
    System::DateOnly
#else
    System::DateTimeOffset
#endif
    ? DueDate
    {
        get { return ModelBase.GetNullableStruct<
#if NET
            System::DateOnly
#else
            System::DateTimeOffset
#endif
            >(this.RawQueryData, "due_date"); }
        init { ModelBase.Set(this._rawQueryData, "due_date", value); }
    }

    /// <summary>
    /// Filters invoices by their due dates within a specific time range in the past.
    /// Specify the range as a number followed by 'd' (days) or 'm' (months). For
    /// example, '7d' filters invoices due in the last 7 days, and '2m' filters those
    /// due in the last 2 months.
    /// </summary>
    public string? DueDateWindow
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "due_date_window"); }
        init { ModelBase.Set(this._rawQueryData, "due_date_window", value); }
    }

    public
#if NET
    System::DateOnly
#else
    System::DateTimeOffset
#endif
    ? DueDateGt
    {
        get
        {
            return ModelBase.GetNullableStruct<
#if NET
            System::DateOnly
#else
            System::DateTimeOffset
#endif
            >(this.RawQueryData, "due_date[gt]");
        }
        init { ModelBase.Set(this._rawQueryData, "due_date[gt]", value); }
    }

    public
#if NET
    System::DateOnly
#else
    System::DateTimeOffset
#endif
    ? DueDateLt
    {
        get
        {
            return ModelBase.GetNullableStruct<
#if NET
            System::DateOnly
#else
            System::DateTimeOffset
#endif
            >(this.RawQueryData, "due_date[lt]");
        }
        init { ModelBase.Set(this._rawQueryData, "due_date[lt]", value); }
    }

    public string? ExternalCustomerID
    {
        get
        {
            return ModelBase.GetNullableClass<string>(this.RawQueryData, "external_customer_id");
        }
        init { ModelBase.Set(this._rawQueryData, "external_customer_id", value); }
    }

    public System::DateTimeOffset? InvoiceDateGt
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(
                this.RawQueryData,
                "invoice_date[gt]"
            );
        }
        init { ModelBase.Set(this._rawQueryData, "invoice_date[gt]", value); }
    }

    public System::DateTimeOffset? InvoiceDateGte
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(
                this.RawQueryData,
                "invoice_date[gte]"
            );
        }
        init { ModelBase.Set(this._rawQueryData, "invoice_date[gte]", value); }
    }

    public System::DateTimeOffset? InvoiceDateLt
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(
                this.RawQueryData,
                "invoice_date[lt]"
            );
        }
        init { ModelBase.Set(this._rawQueryData, "invoice_date[lt]", value); }
    }

    public System::DateTimeOffset? InvoiceDateLte
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(
                this.RawQueryData,
                "invoice_date[lte]"
            );
        }
        init { ModelBase.Set(this._rawQueryData, "invoice_date[lte]", value); }
    }

    public bool? IsRecurring
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawQueryData, "is_recurring"); }
        init { ModelBase.Set(this._rawQueryData, "is_recurring", value); }
    }

    /// <summary>
    /// The number of items to fetch. Defaults to 20.
    /// </summary>
    public long? Limit
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "limit"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "limit", value);
        }
    }

    public IReadOnlyList<ApiEnum<string, global::Orb.Models.Invoices.Status>>? Status
    {
        get
        {
            return ModelBase.GetNullableClass<
                List<ApiEnum<string, global::Orb.Models.Invoices.Status>>
            >(this.RawQueryData, "status");
        }
        init { ModelBase.Set(this._rawQueryData, "status", value); }
    }

    public string? SubscriptionID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "subscription_id"); }
        init { ModelBase.Set(this._rawQueryData, "subscription_id", value); }
    }

    public InvoiceListParams() { }

    public InvoiceListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    public static InvoiceListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/invoices")
        {
            Query = this.QueryString(options),
        }.Uri;
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

[JsonConverter(typeof(DateTypeConverter))]
public enum DateType
{
    DueDate,
    InvoiceDate,
}

sealed class DateTypeConverter : JsonConverter<DateType>
{
    public override DateType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "due_date" => DateType.DueDate,
            "invoice_date" => DateType.InvoiceDate,
            _ => (DateType)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, DateType value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DateType.DueDate => "due_date",
                DateType.InvoiceDate => "invoice_date",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(global::Orb.Models.Invoices.StatusConverter))]
public enum Status
{
    Draft,
    Issued,
    Paid,
    Synced,
    Void,
}

sealed class StatusConverter : JsonConverter<global::Orb.Models.Invoices.Status>
{
    public override global::Orb.Models.Invoices.Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "draft" => global::Orb.Models.Invoices.Status.Draft,
            "issued" => global::Orb.Models.Invoices.Status.Issued,
            "paid" => global::Orb.Models.Invoices.Status.Paid,
            "synced" => global::Orb.Models.Invoices.Status.Synced,
            "void" => global::Orb.Models.Invoices.Status.Void,
            _ => (global::Orb.Models.Invoices.Status)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.Invoices.Status value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.Invoices.Status.Draft => "draft",
                global::Orb.Models.Invoices.Status.Issued => "issued",
                global::Orb.Models.Invoices.Status.Paid => "paid",
                global::Orb.Models.Invoices.Status.Synced => "synced",
                global::Orb.Models.Invoices.Status.Void => "void",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
