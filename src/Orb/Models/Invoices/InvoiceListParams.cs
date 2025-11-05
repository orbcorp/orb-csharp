using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.Invoices;

/// <summary>
/// This endpoint returns a list of all [`Invoice`](/core-concepts#invoice)s for
/// an account in a list format.
///
/// The list of invoices is ordered starting from the most recently issued invoice
/// date. The response also includes [`pagination_metadata`](/api-reference/pagination),
/// which lets the caller retrieve the next page of results if they exist.
///
/// By default, this only returns invoices that are `issued`, `paid`, or `synced`.
///
/// When fetching any `draft` invoices, this returns the last-computed invoice values
/// for each draft invoice, which may not always be up-to-date since Orb regularly
/// refreshes invoices asynchronously.
/// </summary>
public sealed record class InvoiceListParams : ParamsBase
{
    public string? Amount
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("amount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? AmountGt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("amount[gt]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["amount[gt]"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? AmountLt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("amount[lt]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["amount[lt]"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Cursor for pagination. This can be populated by the `next_cursor` value returned
    /// from the initial request.
    /// </summary>
    public string? Cursor
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("cursor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["cursor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? CustomerID
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["customer_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, DateType>? DateType
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("date_type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, DateType>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.QueryProperties["date_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public System::DateOnly? DueDate
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("due_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateOnly?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.QueryProperties["due_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
            if (!this.QueryProperties.TryGetValue("due_date_window", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["due_date_window"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public System::DateOnly? DueDateGt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("due_date[gt]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateOnly?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.QueryProperties["due_date[gt]"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public System::DateOnly? DueDateLt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("due_date[lt]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateOnly?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.QueryProperties["due_date[lt]"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? ExternalCustomerID
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("external_customer_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["external_customer_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public System::DateTime? InvoiceDateGt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("invoice_date[gt]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.QueryProperties["invoice_date[gt]"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public System::DateTime? InvoiceDateGte
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("invoice_date[gte]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.QueryProperties["invoice_date[gte]"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public System::DateTime? InvoiceDateLt
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("invoice_date[lt]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.QueryProperties["invoice_date[lt]"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public System::DateTime? InvoiceDateLte
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("invoice_date[lte]", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateTime?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.QueryProperties["invoice_date[lte]"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? IsRecurring
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("is_recurring", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["is_recurring"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of items to fetch. Defaults to 20.
    /// </summary>
    public long? Limit
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("limit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["limit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public List<ApiEnum<string, global::Orb.Models.Invoices.Status>>? Status
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<
                ApiEnum<string, global::Orb.Models.Invoices.Status>
            >?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? SubscriptionID
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("subscription_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["subscription_id"] = JsonSerializer.SerializeToElement(
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

    internal override void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
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
