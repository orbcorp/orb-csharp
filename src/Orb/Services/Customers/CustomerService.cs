using System;
using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Customers;
using Orb.Services.Customers.BalanceTransactions;
using Orb.Services.Customers.Costs;
using Orb.Services.Customers.Credits;

namespace Orb.Services.Customers;

public sealed class CustomerService : ICustomerService
{
    readonly IOrbClient _client;

    public CustomerService(IOrbClient client)
    {
        _client = client;
        _costs = new(() => new CostService(client));
        _credits = new(() => new CreditService(client));
        _balanceTransactions = new(() => new BalanceTransactionService(client));
    }

    readonly Lazy<ICostService> _costs;
    public ICostService Costs
    {
        get { return _costs.Value; }
    }

    readonly Lazy<ICreditService> _credits;
    public ICreditService Credits
    {
        get { return _credits.Value; }
    }

    readonly Lazy<IBalanceTransactionService> _balanceTransactions;
    public IBalanceTransactionService BalanceTransactions
    {
        get { return _balanceTransactions.Value; }
    }

    public async Task<Customer> Create(CustomerCreateParams parameters)
    {
        HttpRequest<CustomerCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var customer = await response.Deserialize<Customer>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            customer.Validate();
        }
        return customer;
    }

    public async Task<Customer> Update(CustomerUpdateParams parameters)
    {
        HttpRequest<CustomerUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var customer = await response.Deserialize<Customer>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            customer.Validate();
        }
        return customer;
    }

    public async Task<CustomerListPageResponse> List(CustomerListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<CustomerListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var page = await response.Deserialize<CustomerListPageResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task Delete(CustomerDeleteParams parameters)
    {
        HttpRequest<CustomerDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }

    public async Task<Customer> Fetch(CustomerFetchParams parameters)
    {
        HttpRequest<CustomerFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var customer = await response.Deserialize<Customer>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            customer.Validate();
        }
        return customer;
    }

    public async Task<Customer> FetchByExternalID(CustomerFetchByExternalIDParams parameters)
    {
        HttpRequest<CustomerFetchByExternalIDParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var customer = await response.Deserialize<Customer>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            customer.Validate();
        }
        return customer;
    }

    public async Task SyncPaymentMethodsFromGateway(
        CustomerSyncPaymentMethodsFromGatewayParams parameters
    )
    {
        HttpRequest<CustomerSyncPaymentMethodsFromGatewayParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }

    public async Task SyncPaymentMethodsFromGatewayByExternalCustomerID(
        CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams parameters
    )
    {
        HttpRequest<CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
    }

    public async Task<Customer> UpdateByExternalID(CustomerUpdateByExternalIDParams parameters)
    {
        HttpRequest<CustomerUpdateByExternalIDParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var customer = await response.Deserialize<Customer>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            customer.Validate();
        }
        return customer;
    }
}
