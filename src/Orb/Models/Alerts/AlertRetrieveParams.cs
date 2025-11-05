using System.Net.Http;
using Orb.Core;
using System = System;

namespace Orb.Models.Alerts;

/// <summary>
/// This endpoint retrieves an alert by its ID.
/// </summary>
public sealed record class AlertRetrieveParams : ParamsBase
{
    public required string AlertID;

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/alerts/{0}", this.AlertID)
        )
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
