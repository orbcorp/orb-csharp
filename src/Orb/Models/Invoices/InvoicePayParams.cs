using Http = System.Net.Http;
using Orb = Orb;
using System = System;

namespace Orb.Models.Invoices;

/// <summary>
/// This endpoint collects payment for an invoice using the customer's default payment
/// method. This action can only be taken on invoices with status "issued".
/// </summary>
public sealed record class InvoicePayParams : Orb::ParamsBase
{
    public required string InvoiceID;

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/invoices/{0}/pay", this.InvoiceID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
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
