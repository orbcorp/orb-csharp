using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InvoiceListSummaryParams : ParamsBase
{
    public string? Amount
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("amount");
        }
        init { this._rawQueryData.Set("amount", value); }
    }

    public string? AmountGt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("amount[gt]");
        }
        init { this._rawQueryData.Set("amount[gt]", value); }
    }

    public string? AmountLt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("amount[lt]");
        }
        init { this._rawQueryData.Set("amount[lt]", value); }
    }

    /// <summary>
    /// Cursor for pagination. This can be populated by the `next_cursor` value returned
    /// from the initial request.
    /// </summary>
    public string? Cursor
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("cursor");
        }
        init { this._rawQueryData.Set("cursor", value); }
    }

    public string? CustomerID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("customer_id");
        }
        init { this._rawQueryData.Set("customer_id", value); }
    }

    public ApiEnum<string, InvoiceListSummaryParamsDateType>? DateType
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, InvoiceListSummaryParamsDateType>
            >("date_type");
        }
        init { this._rawQueryData.Set("date_type", value); }
    }

    public string? DueDate
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("due_date");
        }
        init { this._rawQueryData.Set("due_date", value); }
    }

    /// <summary>
    /// Filters invoices by their due dates within a specific time range in the past.
    /// Specify the range as a number followed by 'd' (days) or 'm' (months). For
    /// example, '7d' filters invoices due in the last 7 days, and '2m' filters those
    /// due in the last 2 months.
    /// </summary>
    public string? DueDateWindow
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("due_date_window");
        }
        init { this._rawQueryData.Set("due_date_window", value); }
    }

    public string? DueDateGt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("due_date[gt]");
        }
        init { this._rawQueryData.Set("due_date[gt]", value); }
    }

    public string? DueDateLt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("due_date[lt]");
        }
        init { this._rawQueryData.Set("due_date[lt]", value); }
    }

    public string? ExternalCustomerID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("external_customer_id");
        }
        init { this._rawQueryData.Set("external_customer_id", value); }
    }

    public System::DateTimeOffset? InvoiceDateGt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("invoice_date[gt]");
        }
        init { this._rawQueryData.Set("invoice_date[gt]", value); }
    }

    public System::DateTimeOffset? InvoiceDateGte
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>(
                "invoice_date[gte]"
            );
        }
        init { this._rawQueryData.Set("invoice_date[gte]", value); }
    }

    public System::DateTimeOffset? InvoiceDateLt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("invoice_date[lt]");
        }
        init { this._rawQueryData.Set("invoice_date[lt]", value); }
    }

    public System::DateTimeOffset? InvoiceDateLte
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>(
                "invoice_date[lte]"
            );
        }
        init { this._rawQueryData.Set("invoice_date[lte]", value); }
    }

    public bool? IsRecurring
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("is_recurring");
        }
        init { this._rawQueryData.Set("is_recurring", value); }
    }

    /// <summary>
    /// The number of items to fetch. Defaults to 20.
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    public IReadOnlyList<ApiEnum<string, InvoiceListSummaryParamsStatus>>? Status
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, InvoiceListSummaryParamsStatus>>
            >("status");
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<
                ApiEnum<string, InvoiceListSummaryParamsStatus>
            >?>("status", value == null ? null : ImmutableArray.ToImmutableArray(value));
        }
    }

    public string? SubscriptionID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("subscription_id");
        }
        init { this._rawQueryData.Set("subscription_id", value); }
    }

    public InvoiceListSummaryParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceListSummaryParams(InvoiceListSummaryParams invoiceListSummaryParams)
        : base(invoiceListSummaryParams) { }
#pragma warning restore CS8618

    public InvoiceListSummaryParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceListSummaryParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
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

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(InvoiceListSummaryParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
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

    public override int GetHashCode()
    {
        return 0;
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
