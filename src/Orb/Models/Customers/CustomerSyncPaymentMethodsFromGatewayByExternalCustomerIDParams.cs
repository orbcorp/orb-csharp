using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Orb.Core;

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
    public required string ExternalCustomerID { get; init; }

    public CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams() { }

    public CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
    }
#pragma warning restore CS8618

    public static CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties)
        );
    }

    public override Uri Url(IOrbClient client)
    {
        return new UriBuilder(
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

    internal override void AddHeadersToRequest(HttpRequestMessage request, IOrbClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
