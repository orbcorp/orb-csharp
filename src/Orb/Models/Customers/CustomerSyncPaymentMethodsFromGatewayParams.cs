using System;
using System.Net.Http;

namespace Orb.Models.Customers;

/// <summary>
/// Sync Orb's payment methods for the customer with their gateway.
///
/// This method can be called before taking an action that may cause the customer
/// to be charged, ensuring that the most up-to-date payment method is charged.
///
/// **Note**: This functionality is currently only available for Stripe.
/// </summary>
public sealed record class CustomerSyncPaymentMethodsFromGatewayParams : ParamsBase
{
    public required string CustomerID;

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/customers/{0}/sync_payment_methods_from_gateway", this.CustomerID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
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
