using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers;
using Orb.Services.Customers;

namespace Orb.Services;

/// <inheritdoc/>
public sealed class CustomerService : ICustomerService
{
    /// <inheritdoc/>
    public ICustomerService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CustomerService(this._client.WithOptions(modifier));
    }

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

    /// <inheritdoc/>
    public async Task<Customer> Create(
        CustomerCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CustomerCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var customer = await response
            .Deserialize<Customer>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            customer.Validate();
        }
        return customer;
    }

    /// <inheritdoc/>
    public async Task<Customer> Update(
        CustomerUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new OrbInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<CustomerUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var customer = await response
            .Deserialize<Customer>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            customer.Validate();
        }
        return customer;
    }

    /// <inheritdoc/>
    public async Task<Customer> Update(
        string customerID,
        CustomerUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Update(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CustomerListPage> List(
        CustomerListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CustomerListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<CustomerListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return new CustomerListPage(this, parameters, page);
    }

    /// <inheritdoc/>
    public async Task Delete(
        CustomerDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new OrbInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<CustomerDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string customerID,
        CustomerDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Customer> Fetch(
        CustomerFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new OrbInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<CustomerFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var customer = await response
            .Deserialize<Customer>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            customer.Validate();
        }
        return customer;
    }

    /// <inheritdoc/>
    public async Task<Customer> Fetch(
        string customerID,
        CustomerFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Fetch(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Customer> FetchByExternalID(
        CustomerFetchByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalCustomerID == null)
        {
            throw new OrbInvalidDataException("'parameters.ExternalCustomerID' cannot be null");
        }

        HttpRequest<CustomerFetchByExternalIDParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var customer = await response
            .Deserialize<Customer>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            customer.Validate();
        }
        return customer;
    }

    /// <inheritdoc/>
    public async Task<Customer> FetchByExternalID(
        string externalCustomerID,
        CustomerFetchByExternalIDParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.FetchByExternalID(
            parameters with
            {
                ExternalCustomerID = externalCustomerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task SyncPaymentMethodsFromGateway(
        CustomerSyncPaymentMethodsFromGatewayParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new OrbInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<CustomerSyncPaymentMethodsFromGatewayParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task SyncPaymentMethodsFromGateway(
        string customerID,
        CustomerSyncPaymentMethodsFromGatewayParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.SyncPaymentMethodsFromGateway(
            parameters with
            {
                CustomerID = customerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task SyncPaymentMethodsFromGatewayByExternalCustomerID(
        CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalCustomerID == null)
        {
            throw new OrbInvalidDataException("'parameters.ExternalCustomerID' cannot be null");
        }

        HttpRequest<CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task SyncPaymentMethodsFromGatewayByExternalCustomerID(
        string externalCustomerID,
        CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.SyncPaymentMethodsFromGatewayByExternalCustomerID(
            parameters with
            {
                ExternalCustomerID = externalCustomerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<Customer> UpdateByExternalID(
        CustomerUpdateByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new OrbInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CustomerUpdateByExternalIDParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var customer = await response
            .Deserialize<Customer>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            customer.Validate();
        }
        return customer;
    }

    /// <inheritdoc/>
    public async Task<Customer> UpdateByExternalID(
        string id,
        CustomerUpdateByExternalIDParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.UpdateByExternalID(parameters with { ID = id }, cancellationToken);
    }
}
