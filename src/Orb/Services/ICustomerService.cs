using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Customers;
using Orb.Services.Customers;

namespace Orb.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICustomerService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICustomerServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICustomerService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICostService Costs { get; }

    ICreditService Credits { get; }

    IBalanceTransactionService BalanceTransactions { get; }

    /// <summary>
    /// This operation is used to create an Orb customer, who is party to the core
    /// billing relationship. See [Customer](/core-concepts##customer) for an overview
    /// of the customer resource.
    ///
    /// <para>This endpoint is critical in the following Orb functionality: * Automated
    /// charges can be configured by setting `payment_provider` and `payment_provider_id`
    /// to automatically   issue invoices * [Customer ID Aliases](/events-and-metrics/customer-aliases)
    /// can be configured by setting   `external_customer_id` * [Timezone localization](/essentials/timezones)
    /// can be configured on a per-customer basis by   setting the `timezone` parameter</para>
    /// </summary>
    Task<Customer> Create(
        CustomerCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint can be used to update the `payment_provider`, `payment_provider_id`,
    /// `name`, `email`, `email_delivery`, `tax_id`, `auto_collection`, `metadata`,
    /// `shipping_address`, `billing_address`, and `additional_emails` of an existing
    /// customer. Other fields on a customer are currently immutable.
    /// </summary>
    Task<Customer> Update(
        CustomerUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CustomerUpdateParams, CancellationToken)"/>
    Task<Customer> Update(
        string customerID,
        CustomerUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint returns a list of all customers for an account. The list of
    /// customers is ordered starting from the most recently created customer. This
    /// endpoint follows Orb's [standardized pagination format](/api-reference/pagination).
    ///
    /// <para>See [Customer](/core-concepts##customer) for an overview of the customer model.</para>
    /// </summary>
    Task<CustomerListPage> List(
        CustomerListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This performs a deletion of this customer, its subscriptions, and its invoices,
    /// provided the customer does not have any issued invoices. Customers with issued
    /// invoices cannot be deleted. This operation is irreversible. Note that this
    /// is a _soft_ deletion, but the data will be inaccessible through the API and
    /// Orb dashboard.
    ///
    /// <para>For a hard-deletion, please reach out to the Orb team directly.</para>
    ///
    /// <para>**Note**: This operation happens asynchronously and can be expected
    /// to take a few minutes to propagate to related resources. However, querying
    /// for the customer on subsequent GET requests while deletion is in process will
    /// reflect its deletion.</para>
    /// </summary>
    Task Delete(CustomerDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(CustomerDeleteParams, CancellationToken)"/>
    Task Delete(
        string customerID,
        CustomerDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint is used to fetch customer details given an identifier. If the
    /// `Customer` is in the process of being deleted, only the properties `id` and
    /// `deleted: true` will be returned.
    ///
    /// <para>See the [Customer resource](/core-concepts#customer) for a full discussion
    /// of the Customer model.</para>
    /// </summary>
    Task<Customer> Fetch(
        CustomerFetchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Fetch(CustomerFetchParams, CancellationToken)"/>
    Task<Customer> Fetch(
        string customerID,
        CustomerFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint is used to fetch customer details given an `external_customer_id`
    /// (see [Customer ID Aliases](/events-and-metrics/customer-aliases)).
    ///
    /// <para>Note that the resource and semantics of this endpoint exactly mirror
    /// [Get Customer](fetch-customer).</para>
    /// </summary>
    Task<Customer> FetchByExternalID(
        CustomerFetchByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="FetchByExternalID(CustomerFetchByExternalIDParams, CancellationToken)"/>
    Task<Customer> FetchByExternalID(
        string externalCustomerID,
        CustomerFetchByExternalIDParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sync Orb's payment methods for the customer with their gateway.
    ///
    /// <para>This method can be called before taking an action that may cause the
    /// customer to be charged, ensuring that the most up-to-date payment method
    /// is charged.</para>
    ///
    /// <para>**Note**: This functionality is currently only available for Stripe.</para>
    /// </summary>
    Task SyncPaymentMethodsFromGateway(
        CustomerSyncPaymentMethodsFromGatewayParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SyncPaymentMethodsFromGateway(CustomerSyncPaymentMethodsFromGatewayParams, CancellationToken)"/>
    Task SyncPaymentMethodsFromGateway(
        string customerID,
        CustomerSyncPaymentMethodsFromGatewayParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sync Orb's payment methods for the customer with their gateway.
    ///
    /// <para>This method can be called before taking an action that may cause the
    /// customer to be charged, ensuring that the most up-to-date payment method
    /// is charged.</para>
    ///
    /// <para>**Note**: This functionality is currently only available for Stripe.</para>
    /// </summary>
    Task SyncPaymentMethodsFromGatewayByExternalCustomerID(
        CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SyncPaymentMethodsFromGatewayByExternalCustomerID(CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams, CancellationToken)"/>
    Task SyncPaymentMethodsFromGatewayByExternalCustomerID(
        string externalCustomerID,
        CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint is used to update customer details given an `external_customer_id`
    /// (see [Customer ID Aliases](/events-and-metrics/customer-aliases)). Note that
    /// the resource and semantics of this endpoint exactly mirror [Update Customer](update-customer).
    /// </summary>
    Task<Customer> UpdateByExternalID(
        CustomerUpdateByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateByExternalID(CustomerUpdateByExternalIDParams, CancellationToken)"/>
    Task<Customer> UpdateByExternalID(
        string id,
        CustomerUpdateByExternalIDParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICustomerService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICustomerServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICustomerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICostServiceWithRawResponse Costs { get; }

    ICreditServiceWithRawResponse Credits { get; }

    IBalanceTransactionServiceWithRawResponse BalanceTransactions { get; }

    /// <summary>
    /// Returns a raw HTTP response for `post /customers`, but is otherwise the
    /// same as <see cref="ICustomerService.Create(CustomerCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Customer>> Create(
        CustomerCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /customers/{customer_id}`, but is otherwise the
    /// same as <see cref="ICustomerService.Update(CustomerUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Customer>> Update(
        CustomerUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CustomerUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Customer>> Update(
        string customerID,
        CustomerUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /customers`, but is otherwise the
    /// same as <see cref="ICustomerService.List(CustomerListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CustomerListPage>> List(
        CustomerListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /customers/{customer_id}`, but is otherwise the
    /// same as <see cref="ICustomerService.Delete(CustomerDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        CustomerDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(CustomerDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string customerID,
        CustomerDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /customers/{customer_id}`, but is otherwise the
    /// same as <see cref="ICustomerService.Fetch(CustomerFetchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Customer>> Fetch(
        CustomerFetchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Fetch(CustomerFetchParams, CancellationToken)"/>
    Task<HttpResponse<Customer>> Fetch(
        string customerID,
        CustomerFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /customers/external_customer_id/{external_customer_id}`, but is otherwise the
    /// same as <see cref="ICustomerService.FetchByExternalID(CustomerFetchByExternalIDParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Customer>> FetchByExternalID(
        CustomerFetchByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="FetchByExternalID(CustomerFetchByExternalIDParams, CancellationToken)"/>
    Task<HttpResponse<Customer>> FetchByExternalID(
        string externalCustomerID,
        CustomerFetchByExternalIDParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /customers/{customer_id}/sync_payment_methods_from_gateway`, but is otherwise the
    /// same as <see cref="ICustomerService.SyncPaymentMethodsFromGateway(CustomerSyncPaymentMethodsFromGatewayParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> SyncPaymentMethodsFromGateway(
        CustomerSyncPaymentMethodsFromGatewayParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SyncPaymentMethodsFromGateway(CustomerSyncPaymentMethodsFromGatewayParams, CancellationToken)"/>
    Task<HttpResponse> SyncPaymentMethodsFromGateway(
        string customerID,
        CustomerSyncPaymentMethodsFromGatewayParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /customers/external_customer_id/{external_customer_id}/sync_payment_methods_from_gateway`, but is otherwise the
    /// same as <see cref="ICustomerService.SyncPaymentMethodsFromGatewayByExternalCustomerID(CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> SyncPaymentMethodsFromGatewayByExternalCustomerID(
        CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SyncPaymentMethodsFromGatewayByExternalCustomerID(CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams, CancellationToken)"/>
    Task<HttpResponse> SyncPaymentMethodsFromGatewayByExternalCustomerID(
        string externalCustomerID,
        CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /customers/external_customer_id/{external_customer_id}`, but is otherwise the
    /// same as <see cref="ICustomerService.UpdateByExternalID(CustomerUpdateByExternalIDParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Customer>> UpdateByExternalID(
        CustomerUpdateByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateByExternalID(CustomerUpdateByExternalIDParams, CancellationToken)"/>
    Task<HttpResponse<Customer>> UpdateByExternalID(
        string id,
        CustomerUpdateByExternalIDParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
