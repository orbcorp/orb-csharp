using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System = System;

namespace Orb.Models.Invoices;

/// <summary>
/// This endpoint allows an eligible invoice to be issued manually. This is only
/// possible with invoices where status is `draft`, `will_auto_issue` is false, and
/// an `eligible_to_issue_at` is a time in the past. Issuing an invoice could possibly
/// trigger side effects, some of which could be customer-visible (e.g. sending emails,
/// auto-collecting payment, syncing the invoice to external providers, etc).
/// </summary>
public sealed record class InvoiceIssueParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string InvoiceID;

    /// <summary>
    /// If true, the invoice will be issued synchronously. If false, the invoice will
    /// be issued asynchronously. The synchronous option is only available for invoices
    /// that have no usage fees. If the invoice is configured to sync to an external
    /// provider, a successful response from this endpoint guarantees the invoice is
    /// present in the provider.
    /// </summary>
    public bool? Synchronous
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("synchronous", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set { this.BodyProperties["synchronous"] = JsonSerializer.SerializeToElement(value); }
    }

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/invoices/{0}/issue", this.InvoiceID)
        )
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
