using Http = System.Net.Http;
using Orb = Orb;
using System = System;

namespace Orb.Models.Alerts;

/// <summary>
/// This endpoint retrieves an alert by its ID.
/// </summary>
public sealed record class AlertRetrieveParams : Orb::ParamsBase
{
    public required string AlertID;

    public override System::Uri Url(Orb::IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/alerts/{0}", this.AlertID)
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
