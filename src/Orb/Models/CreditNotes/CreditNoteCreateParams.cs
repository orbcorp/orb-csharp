using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Orb.Core;
using Orb.Exceptions;
using System = System;

namespace Orb.Models.CreditNotes;

/// <summary>
/// This endpoint is used to create a single [`Credit Note`](/invoicing/credit-notes).
///
/// The credit note service period configuration supports two explicit modes:
///
/// 1. Global service periods: Specify start_date and end_date at the credit note
/// level.    These dates will be applied to all line items uniformly.
///
/// 2. Individual service periods: Specify start_date and end_date for each line
/// item.    When using this mode, ALL line items must have individual periods specified.
///
/// 3. Default behavior: If no service periods are specified (neither global nor individual),
///    the original invoice line item service periods will be used.
///
/// Note: Mixing global and individual service periods in the same request is not
/// allowed to prevent confusion.
///
/// Service period dates are normalized to the start of the day in the customer's
/// timezone to ensure consistent handling across different timezones.
///
/// Date Format: Use start_date and end_date with format "YYYY-MM-DD" (e.g., "2023-09-22")
/// to match other Orb APIs like /v1/invoice_line_items.
///
/// Note: Both start_date and end_date are inclusive - the service period will cover
/// both the start date and end date completely (from start of start_date to end
/// of end_date).
/// </summary>
public sealed record class CreditNoteCreateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required List<global::Orb.Models.CreditNotes.LineItem> LineItems
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

            return JsonSerializer.Deserialize<List<global::Orb.Models.CreditNotes.LineItem>>(
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
    /// An optional reason for the credit note.
    /// </summary>
    public required ApiEnum<string, global::Orb.Models.CreditNotes.Reason> Reason
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("reason", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'reason' cannot be null",
                    new System::ArgumentOutOfRangeException("reason", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Orb.Models.CreditNotes.Reason>
            >(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["reason"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A date string to specify the global credit note service period end date in
    /// the customer's timezone. This will be applied to all line items that don't
    /// have their own individual service periods specified. If not provided, line
    /// items will use their original invoice line item service periods. This date
    /// is inclusive.
    /// </summary>
    public System::DateOnly? EndDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("end_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateOnly?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["end_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An optional memo to attach to the credit note.
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
    /// A date string to specify the global credit note service period start date
    /// in the customer's timezone. This will be applied to all line items that don't
    /// have their own individual service periods specified. If not provided, line
    /// items will use their original invoice line item service periods. This date
    /// is inclusive.
    /// </summary>
    public System::DateOnly? StartDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("start_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateOnly?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["start_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/credit_notes")
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

[JsonConverter(typeof(ModelConverter<global::Orb.Models.CreditNotes.LineItem>))]
public sealed record class LineItem : ModelBase, IFromRaw<global::Orb.Models.CreditNotes.LineItem>
{
    /// <summary>
    /// The total amount in the invoice's currency to credit this line item.
    /// </summary>
    public required string Amount
    {
        get
        {
            if (!this.Properties.TryGetValue("amount", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new System::ArgumentOutOfRangeException("amount", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'amount' cannot be null",
                    new System::ArgumentNullException("amount")
                );
        }
        set
        {
            this.Properties["amount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The ID of the line item to credit.
    /// </summary>
    public required string InvoiceLineItemID
    {
        get
        {
            if (!this.Properties.TryGetValue("invoice_line_item_id", out JsonElement element))
                throw new OrbInvalidDataException(
                    "'invoice_line_item_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "invoice_line_item_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new OrbInvalidDataException(
                    "'invoice_line_item_id' cannot be null",
                    new System::ArgumentNullException("invoice_line_item_id")
                );
        }
        set
        {
            this.Properties["invoice_line_item_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A date string to specify this line item's credit note service period end
    /// date in the customer's timezone. If provided, this will be used for this specific
    /// line item. If not provided, will use the global end_date if available, otherwise
    /// defaults to the original invoice line item's end date. This date is inclusive.
    /// </summary>
    public System::DateOnly? EndDate
    {
        get
        {
            if (!this.Properties.TryGetValue("end_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateOnly?>(
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

    /// <summary>
    /// A date string to specify this line item's credit note service period start
    /// date in the customer's timezone. If provided, this will be used for this specific
    /// line item. If not provided, will use the global start_date if available,
    /// otherwise defaults to the original invoice line item's start date. This date
    /// is inclusive.
    /// </summary>
    public System::DateOnly? StartDate
    {
        get
        {
            if (!this.Properties.TryGetValue("start_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<System::DateOnly?>(
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

    public override void Validate()
    {
        _ = this.Amount;
        _ = this.InvoiceLineItemID;
        _ = this.EndDate;
        _ = this.StartDate;
    }

    public LineItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LineItem(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static global::Orb.Models.CreditNotes.LineItem FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

/// <summary>
/// An optional reason for the credit note.
/// </summary>
[JsonConverter(typeof(global::Orb.Models.CreditNotes.ReasonConverter))]
public enum Reason
{
    Duplicate,
    Fraudulent,
    OrderChange,
    ProductUnsatisfactory,
}

sealed class ReasonConverter : JsonConverter<global::Orb.Models.CreditNotes.Reason>
{
    public override global::Orb.Models.CreditNotes.Reason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "duplicate" => global::Orb.Models.CreditNotes.Reason.Duplicate,
            "fraudulent" => global::Orb.Models.CreditNotes.Reason.Fraudulent,
            "order_change" => global::Orb.Models.CreditNotes.Reason.OrderChange,
            "product_unsatisfactory" => global::Orb.Models.CreditNotes.Reason.ProductUnsatisfactory,
            _ => (global::Orb.Models.CreditNotes.Reason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Orb.Models.CreditNotes.Reason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Orb.Models.CreditNotes.Reason.Duplicate => "duplicate",
                global::Orb.Models.CreditNotes.Reason.Fraudulent => "fraudulent",
                global::Orb.Models.CreditNotes.Reason.OrderChange => "order_change",
                global::Orb.Models.CreditNotes.Reason.ProductUnsatisfactory =>
                    "product_unsatisfactory",
                _ => throw new OrbInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
