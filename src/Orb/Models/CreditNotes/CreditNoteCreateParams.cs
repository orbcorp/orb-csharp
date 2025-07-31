using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using CreditNoteCreateParamsProperties = Orb.Models.CreditNotes.CreditNoteCreateParamsProperties;

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

    public required List<CreditNoteCreateParamsProperties::LineItem> LineItems
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("line_items", out JsonElement element))
                throw new ArgumentOutOfRangeException("line_items", "Missing required argument");

            return JsonSerializer.Deserialize<List<CreditNoteCreateParamsProperties::LineItem>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("line_items");
        }
        set { this.BodyProperties["line_items"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An optional reason for the credit note.
    /// </summary>
    public required CreditNoteCreateParamsProperties::Reason Reason
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("reason", out JsonElement element))
                throw new ArgumentOutOfRangeException("reason", "Missing required argument");

            return JsonSerializer.Deserialize<CreditNoteCreateParamsProperties::Reason>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("reason");
        }
        set { this.BodyProperties["reason"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A date string to specify the global credit note service period end date in the
    /// customer's timezone. This will be applied to all line items that don't have
    /// their own individual service periods specified. If not provided, line items
    /// will use their original invoice line item service periods. This date is inclusive.
    /// </summary>
    public DateOnly? EndDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("end_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateOnly?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["end_date"] = JsonSerializer.SerializeToElement(value); }
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
        set { this.BodyProperties["memo"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A date string to specify the global credit note service period start date in
    /// the customer's timezone. This will be applied to all line items that don't
    /// have their own individual service periods specified. If not provided, line items
    /// will use their original invoice line item service periods. This date is inclusive.
    /// </summary>
    public DateOnly? StartDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("start_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateOnly?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["start_date"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/credit_notes")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public StringContent BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
