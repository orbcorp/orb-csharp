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
/// This is a lighter-weight endpoint that returns a list of all [`Invoice`](/core-concepts#invoice)
/// summaries for an account in a list format.
///
/// <para>These invoice summaries do not include line item details, minimums, maximums,
/// and discounts, making this endpoint more efficient.</para>
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
public sealed record class InvoiceListSummaryParams : ParamsBase
{
    public string? Amount
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "amount"); }
        init { JsonModel.Set(this._rawQueryData, "amount", value); }
    }

    public string? AmountGt
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "amount[gt]"); }
        init { JsonModel.Set(this._rawQueryData, "amount[gt]", value); }
    }

    public string? AmountLt
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "amount[lt]"); }
        init { JsonModel.Set(this._rawQueryData, "amount[lt]", value); }
    }

    /// <summary>
    /// Cursor for pagination. This can be populated by the `next_cursor` value returned
    /// from the initial request.
    /// </summary>
    public string? Cursor
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "cursor"); }
        init { JsonModel.Set(this._rawQueryData, "cursor", value); }
    }

    public string? CustomerID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "customer_id"); }
        init { JsonModel.Set(this._rawQueryData, "customer_id", value); }
    }

    public ApiEnum<string, InvoiceListSummaryParamsDateType>? DateType
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, InvoiceListSummaryParamsDateType>>(
                this.RawQueryData,
                "date_type"
            );
        }
        init { JsonModel.Set(this._rawQueryData, "date_type", value); }
    }

    public string? DueDate
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "due_date"); }
        init { JsonModel.Set(this._rawQueryData, "due_date", value); }
    }

    /// <summary>
    /// Filters invoices by their due dates within a specific time range in the past.
    /// Specify the range as a number followed by 'd' (days) or 'm' (months). For
    /// example, '7d' filters invoices due in the last 7 days, and '2m' filters those
    /// due in the last 2 months.
    /// </summary>
    public string? DueDateWindow
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "due_date_window"); }
        init { JsonModel.Set(this._rawQueryData, "due_date_window", value); }
    }

    public string? DueDateGt
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "due_date[gt]"); }
        init { JsonModel.Set(this._rawQueryData, "due_date[gt]", value); }
    }

    public string? DueDateLt
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "due_date[lt]"); }
        init { JsonModel.Set(this._rawQueryData, "due_date[lt]", value); }
    }

    public string? ExternalCustomerID
    {
        get
        {
            return JsonModel.GetNullableClass<string>(this.RawQueryData, "external_customer_id");
        }
        init { JsonModel.Set(this._rawQueryData, "external_customer_id", value); }
    }

    public System::DateTimeOffset? InvoiceDateGt
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(
                this.RawQueryData,
                "invoice_date[gt]"
            );
        }
        init { JsonModel.Set(this._rawQueryData, "invoice_date[gt]", value); }
    }

    public System::DateTimeOffset? InvoiceDateGte
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(
                this.RawQueryData,
                "invoice_date[gte]"
            );
        }
        init { JsonModel.Set(this._rawQueryData, "invoice_date[gte]", value); }
    }

    public System::DateTimeOffset? InvoiceDateLt
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(
                this.RawQueryData,
                "invoice_date[lt]"
            );
        }
        init { JsonModel.Set(this._rawQueryData, "invoice_date[lt]", value); }
    }

    public System::DateTimeOffset? InvoiceDateLte
    {
        get
        {
            return JsonModel.GetNullableStruct<System::DateTimeOffset>(
                this.RawQueryData,
                "invoice_date[lte]"
            );
        }
        init { JsonModel.Set(this._rawQueryData, "invoice_date[lte]", value); }
    }

    public bool? IsRecurring
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawQueryData, "is_recurring"); }
        init { JsonModel.Set(this._rawQueryData, "is_recurring", value); }
    }

    /// <summary>
    /// The number of items to fetch. Defaults to 20.
    /// </summary>
    public long? Limit
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawQueryData, "limit"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawQueryData, "limit", value);
        }
    }

    public ApiEnum<string, InvoiceListSummaryParamsStatus>? Status
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, InvoiceListSummaryParamsStatus>>(
                this.RawQueryData,
                "status"
            );
        }
        init { JsonModel.Set(this._rawQueryData, "status", value); }
    }

    public string? SubscriptionID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "subscription_id"); }
        init { JsonModel.Set(this._rawQueryData, "subscription_id", value); }
    }

    public InvoiceListSummaryParams() { }

    public InvoiceListSummaryParams(InvoiceListSummaryParams invoiceListSummaryParams)
        : base(invoiceListSummaryParams) { }

    public InvoiceListSummaryParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceListSummaryParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static InvoiceListSummaryParams FromRawUnchecked(
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
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/invoices/summary")
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

[JsonConverter(typeof(InvoiceListSummaryParamsDateTypeConverter))]
public enum InvoiceListSummaryParamsDateType
{
    DueDate,
    InvoiceDate,
}

sealed class InvoiceListSummaryParamsDateTypeConverter
    : JsonConverter<InvoiceListSummaryParamsDateType>
{
    public override InvoiceListSummaryParamsDateType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "due_date" => InvoiceListSummaryParamsDateType.DueDate,
            "invoice_date" => InvoiceListSummaryParamsDateType.InvoiceDate,
            _ => (InvoiceListSummaryParamsDateType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceListSummaryParamsDateType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvoiceListSummaryParamsDateType.DueDate => "due_date",
                InvoiceListSummaryParamsDateType.InvoiceDate => "invoice_date",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(InvoiceListSummaryParamsStatusConverter))]
public enum InvoiceListSummaryParamsStatus
{
    Draft,
    Issued,
    Paid,
    Synced,
    Void,
}

sealed class InvoiceListSummaryParamsStatusConverter : JsonConverter<InvoiceListSummaryParamsStatus>
{
    public override InvoiceListSummaryParamsStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "draft" => InvoiceListSummaryParamsStatus.Draft,
            "issued" => InvoiceListSummaryParamsStatus.Issued,
            "paid" => InvoiceListSummaryParamsStatus.Paid,
            "synced" => InvoiceListSummaryParamsStatus.Synced,
            "void" => InvoiceListSummaryParamsStatus.Void,
            _ => (InvoiceListSummaryParamsStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InvoiceListSummaryParamsStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InvoiceListSummaryParamsStatus.Draft => "draft",
                InvoiceListSummaryParamsStatus.Issued => "issued",
                InvoiceListSummaryParamsStatus.Paid => "paid",
                InvoiceListSummaryParamsStatus.Synced => "synced",
                InvoiceListSummaryParamsStatus.Void => "void",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
