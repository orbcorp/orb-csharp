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
    readonly Lazy<ICustomerServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICustomerServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public ICustomerService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CustomerService(this._client.WithOptions(modifier));
    }

    public CustomerService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CustomerServiceWithRawResponse(client.WithRawResponse));
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
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Customer> Update(
        CustomerUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Customer> Update(
        string customerID,
        CustomerUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CustomerListPage> List(
        CustomerListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        CustomerDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string customerID,
        CustomerDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { CustomerID = customerID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Customer> Fetch(
        CustomerFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Fetch(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Customer> Fetch(
        string customerID,
        CustomerFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Fetch(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Customer> FetchByExternalID(
        CustomerFetchByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.FetchByExternalID(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Customer> FetchByExternalID(
        string externalCustomerID,
        CustomerFetchByExternalIDParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.FetchByExternalID(
            parameters with
            {
                ExternalCustomerID = externalCustomerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public Task SyncPaymentMethodsFromGateway(
        CustomerSyncPaymentMethodsFromGatewayParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.SyncPaymentMethodsFromGateway(parameters, cancellationToken);
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
            )
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task SyncPaymentMethodsFromGatewayByExternalCustomerID(
        CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.SyncPaymentMethodsFromGatewayByExternalCustomerID(
            parameters,
            cancellationToken
        );
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
            )
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Customer> UpdateByExternalID(
        CustomerUpdateByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdateByExternalID(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Customer> UpdateByExternalID(
        string id,
        CustomerUpdateByExternalIDParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateByExternalID(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CustomerServiceWithRawResponse : ICustomerServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICustomerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CustomerServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CustomerServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;

        _costs = new(() => new CostServiceWithRawResponse(client));
        _credits = new(() => new CreditServiceWithRawResponse(client));
        _balanceTransactions = new(() => new BalanceTransactionServiceWithRawResponse(client));
    }

    readonly Lazy<ICostServiceWithRawResponse> _costs;
    public ICostServiceWithRawResponse Costs
    {
        get { return _costs.Value; }
    }

    readonly Lazy<ICreditServiceWithRawResponse> _credits;
    public ICreditServiceWithRawResponse Credits
    {
        get { return _credits.Value; }
    }

    readonly Lazy<IBalanceTransactionServiceWithRawResponse> _balanceTransactions;
    public IBalanceTransactionServiceWithRawResponse BalanceTransactions
    {
        get { return _balanceTransactions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Customer>> Create(
        CustomerCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CustomerCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var customer = await response.Deserialize<Customer>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    customer.Validate();
                }
                return customer;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Customer>> Update(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var customer = await response.Deserialize<Customer>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    customer.Validate();
                }
                return customer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Customer>> Update(
        string customerID,
        CustomerUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomerListPage>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<CustomerListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CustomerListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
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
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string customerID,
        CustomerDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Customer>> Fetch(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var customer = await response.Deserialize<Customer>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    customer.Validate();
                }
                return customer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Customer>> Fetch(
        string customerID,
        CustomerFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Fetch(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Customer>> FetchByExternalID(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var customer = await response.Deserialize<Customer>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    customer.Validate();
                }
                return customer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Customer>> FetchByExternalID(
        string externalCustomerID,
        CustomerFetchByExternalIDParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.FetchByExternalID(
            parameters with
            {
                ExternalCustomerID = externalCustomerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> SyncPaymentMethodsFromGateway(
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
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> SyncPaymentMethodsFromGateway(
        string customerID,
        CustomerSyncPaymentMethodsFromGatewayParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.SyncPaymentMethodsFromGateway(
            parameters with
            {
                CustomerID = customerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> SyncPaymentMethodsFromGatewayByExternalCustomerID(
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
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> SyncPaymentMethodsFromGatewayByExternalCustomerID(
        string externalCustomerID,
        CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.SyncPaymentMethodsFromGatewayByExternalCustomerID(
            parameters with
            {
                ExternalCustomerID = externalCustomerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Customer>> UpdateByExternalID(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var customer = await response.Deserialize<Customer>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    customer.Validate();
                }
                return customer;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Customer>> UpdateByExternalID(
        string id,
        CustomerUpdateByExternalIDParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateByExternalID(parameters with { ID = id }, cancellationToken);
    }
}
