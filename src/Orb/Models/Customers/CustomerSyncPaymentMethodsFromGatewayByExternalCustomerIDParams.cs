using System.Net.Http;
using System = System;

namespace Orb.Models.Customers;

/// <summary>
/// Sync Orb's payment methods for the customer with their gateway.
///
/// This method can be called before taking an action that may cause the customer
/// to be charged, ensuring that the most up-to-date payment method is charged.
///
/// **Note**: This functionality is currently only available for Stripe.
/// </summary>
public sealed record class CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams
    : ParamsBase
{
    public required string ExternalCustomerID;

    public override System::Uri Url(IOrbClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/customers/external_customer_id/{0}/sync_payment_methods_from_gateway",
                    this.ExternalCustomerID
                )
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
