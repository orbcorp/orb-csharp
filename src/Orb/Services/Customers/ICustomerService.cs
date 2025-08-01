using System.Threading.Tasks;
using Orb.Models.Customers;
using BalanceTransactions = Orb.Services.Customers.BalanceTransactions;
using Costs = Orb.Services.Customers.Costs;
using Credits = Orb.Services.Customers.Credits;

namespace Orb.Services.Customers;

public interface ICustomerService
{
    Costs::ICostService Costs { get; }

    Credits::ICreditService Credits { get; }

    BalanceTransactions::IBalanceTransactionService BalanceTransactions { get; }

    /// <summary>
    /// This operation is used to create an Orb customer, who is party to the core
    /// billing relationship. See [Customer](/core-concepts##customer) for an overview
    /// of the customer resource.
    ///
    /// This endpoint is critical in the following Orb functionality: * Automated charges
    /// can be configured by setting `payment_provider` and `payment_provider_id` to
    /// automatically   issue invoices * [Customer ID Aliases](/events-and-metrics/customer-aliases)
    /// can be configured by setting   `external_customer_id` * [Timezone localization](/essentials/timezones)
    /// can be configured on a per-customer basis by   setting the `timezone` parameter
    /// </summary>
    Task<Customer> Create(CustomerCreateParams @params);

    /// <summary>
    /// This endpoint can be used to update the `payment_provider`, `payment_provider_id`,
    /// `name`, `email`, `email_delivery`, `tax_id`, `auto_collection`, `metadata`,
    /// `shipping_address`, `billing_address`, and `additional_emails` of an existing
    /// customer. Other fields on a customer are currently immutable.
    /// </summary>
    Task<Customer> Update(CustomerUpdateParams @params);

    /// <summary>
    /// This endpoint returns a list of all customers for an account. The list of customers
    /// is ordered starting from the most recently created customer. This endpoint follows
    /// Orb's [standardized pagination format](/api-reference/pagination).
    ///
    /// See [Customer](/core-concepts##customer) for an overview of the customer model.
    /// </summary>
    Task<CustomerListPageResponse> List(CustomerListParams @params);

    /// <summary>
    /// This performs a deletion of this customer, its subscriptions, and its invoices,
    /// provided the customer does not have any issued invoices. Customers with issued
    /// invoices cannot be deleted. This operation is irreversible. Note that this
    /// is a _soft_ deletion, but the data will be inaccessible through the API and
    /// Orb dashboard.
    ///
    /// For a hard-deletion, please reach out to the Orb team directly.
    ///
    /// **Note**: This operation happens asynchronously and can be expected to take
    /// a few minutes to propagate to related resources. However, querying for the
    /// customer on subsequent GET requests while deletion is in process will reflect
    /// its deletion.
    /// </summary>
    Task Delete(CustomerDeleteParams @params);

    /// <summary>
    /// This endpoint is used to fetch customer details given an identifier. If the
    /// `Customer` is in the process of being deleted, only the properties `id` and
    /// `deleted: true` will be returned.
    ///
    /// See the [Customer resource](/core-concepts#customer) for a full discussion of
    /// the Customer model.
    /// </summary>
    Task<Customer> Fetch(CustomerFetchParams @params);

    /// <summary>
    /// This endpoint is used to fetch customer details given an `external_customer_id`
    /// (see [Customer ID Aliases](/events-and-metrics/customer-aliases)).
    ///
    /// Note that the resource and semantics of this endpoint exactly mirror [Get Customer](fetch-customer).
    /// </summary>
    Task<Customer> FetchByExternalID(CustomerFetchByExternalIDParams @params);

    /// <summary>
    /// Sync Orb's payment methods for the customer with their gateway.
    ///
    /// This method can be called before taking an action that may cause the customer
    /// to be charged, ensuring that the most up-to-date payment method is charged.
    ///
    /// **Note**: This functionality is currently only available for Stripe.
    /// </summary>
    Task SyncPaymentMethodsFromGateway(CustomerSyncPaymentMethodsFromGatewayParams @params);

    /// <summary>
    /// Sync Orb's payment methods for the customer with their gateway.
    ///
    /// This method can be called before taking an action that may cause the customer
    /// to be charged, ensuring that the most up-to-date payment method is charged.
    ///
    /// **Note**: This functionality is currently only available for Stripe.
    /// </summary>
    Task SyncPaymentMethodsFromGatewayByExternalCustomerID(
        CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams @params
    );

    /// <summary>
    /// This endpoint is used to update customer details given an `external_customer_id`
    /// (see [Customer ID Aliases](/events-and-metrics/customer-aliases)). Note that
    /// the resource and semantics of this endpoint exactly mirror [Update Customer](update-customer).
    /// </summary>
    Task<Customer> UpdateByExternalID(CustomerUpdateByExternalIDParams @params);
}
