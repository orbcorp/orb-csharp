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
/// <para>This method can be called before taking an action that may cause the customer
/// to be charged, ensuring that the most up-to-date payment method is charged.</para>
///
/// <para>**Note**: This functionality is currently only available for Stripe.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams : ParamsBase
{
    public string? ExternalCustomerID { get; init; }

    public CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams(
        CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams customerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams
    )
        : base(customerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams)
    {
        this.ExternalCustomerID =
            customerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams.ExternalCustomerID;
    }
#pragma warning restore CS8618

    public CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["ExternalCustomerID"] = this.ExternalCustomerID,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(
        CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams? other
    )
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.ExternalCustomerID?.Equals(other.ExternalCustomerID)
                ?? other.ExternalCustomerID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/customers/external_customer_id/{0}/sync_payment_methods_from_gateway",
                    this.ExternalCustomerID
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
