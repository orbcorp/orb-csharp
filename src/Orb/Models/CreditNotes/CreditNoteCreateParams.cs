using CreditNoteCreateParamsProperties = Orb.Models.CreditNotes.CreditNoteCreateParamsProperties;
using Generic = System.Collections.Generic;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;
using Text = System.Text;

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
public sealed record class CreditNoteCreateParams : Orb::ParamsBase
{
    public Generic::Dictionary<string, Json::JsonElement> BodyProperties { get; set; } = [];

    public required Generic::List<CreditNoteCreateParamsProperties::LineItem> LineItems
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("line_items", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "line_items",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Generic::List<CreditNoteCreateParamsProperties::LineItem>>(
                    element
                ) ?? throw new System::ArgumentNullException("line_items");
        }
        set { this.BodyProperties["line_items"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An optional reason for the credit note.
    /// </summary>
    public required CreditNoteCreateParamsProperties::Reason Reason
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("reason", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "reason",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<CreditNoteCreateParamsProperties::Reason>(
                    element
                ) ?? throw new System::ArgumentNullException("reason");
        }
        set { this.BodyProperties["reason"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A date string to specify the global credit note service period end date in the
    /// customer's timezone. This will be applied to all line items that don't have
    /// their own individual service periods specified. If not provided, line items
    /// will use their original invoice line item service periods. This date is inclusive.
    /// </summary>
    public System::DateOnly? EndDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("end_date", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateOnly?>(element);
        }
        set { this.BodyProperties["end_date"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// An optional memo to attach to the credit note.
    /// </summary>
    public string? Memo
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("memo", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.BodyProperties["memo"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// A date string to specify the global credit note service period start date in
    /// the customer's timezone. This will be applied to all line items that don't
    /// have their own individual service periods specified. If not provided, line items
    /// will use their original invoice line item service periods. This date is inclusive.
    /// </summary>
    public System::DateOnly? StartDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("start_date", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateOnly?>(element);
        }
        set { this.BodyProperties["start_date"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/credit_notes")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public Http::StringContent BodyContent()
    {
        return new Http::StringContent(
            Json::JsonSerializer.Serialize(this.BodyProperties),
            Text::Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(Http::HttpRequestMessage request, Orb::IOrbClient client)
    {
        Orb::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            Orb::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
