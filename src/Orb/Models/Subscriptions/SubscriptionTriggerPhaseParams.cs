using Generic = System.Collections.Generic;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;
using Text = System.Text;

namespace Orb.Models.Subscriptions;

/// <summary>
/// Manually trigger a phase, effective the given date (or the current time, if not specified).
/// </summary>
public sealed record class SubscriptionTriggerPhaseParams : Orb::ParamsBase
{
    public Generic::Dictionary<string, Json::JsonElement> BodyProperties { get; set; } = [];

    public required string SubscriptionID;

    /// <summary>
    /// If false, this request will fail if it would void an issued invoice or create
    /// a credit note. Consider using this as a safety mechanism if you do not expect
    /// existing invoices to be changed.
    /// </summary>
    public bool? AllowInvoiceCreditOrVoid
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue(
                    "allow_invoice_credit_or_void",
                    out Json::JsonElement element
                )
            )
                return null;

            return Json::JsonSerializer.Deserialize<bool?>(element);
        }
        set
        {
            this.BodyProperties["allow_invoice_credit_or_void"] =
                Json::JsonSerializer.SerializeToElement(value);
        }
    }

    /// <summary>
    /// The date on which the phase change should take effect. If not provided, defaults
    /// to today in the customer's timezone.
    /// </summary>
    public System::DateOnly? EffectiveDate
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("effective_date", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<System::DateOnly?>(element);
        }
        set
        {
            this.BodyProperties["effective_date"] = Json::JsonSerializer.SerializeToElement(value);
        }
    }

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/subscriptions/{0}/trigger_phase", this.SubscriptionID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public Http::StringContent BodyContent()
    {
        return new(
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
