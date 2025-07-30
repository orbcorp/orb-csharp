using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Orb.Models.Customers;
using BalanceTransactions = Orb.Service.Customers.BalanceTransactions;
using Costs = Orb.Service.Customers.Costs;
using Credits = Orb.Service.Customers.Credits;

namespace Orb.Service.Customers;

public sealed class CustomerService : ICustomerService
{
    readonly IOrbClient _client;

    public CustomerService(IOrbClient client)
    {
        _client = client;
        _costs = new(() => new Costs::CostService(client));
        _credits = new(() => new Credits::CreditService(client));
        _balanceTransactions = new(() => new BalanceTransactions::BalanceTransactionService(client)
        );
    }

    readonly Lazy<Costs::ICostService> _costs;
    public Costs::ICostService Costs
    {
        get { return _costs.Value; }
    }

    readonly Lazy<Credits::ICreditService> _credits;
    public Credits::ICreditService Credits
    {
        get { return _credits.Value; }
    }

    readonly Lazy<BalanceTransactions::IBalanceTransactionService> _balanceTransactions;
    public BalanceTransactions::IBalanceTransactionService BalanceTransactions
    {
        get { return _balanceTransactions.Value; }
    }

    public async Task<Customer> Create(CustomerCreateParams @params)
    {
        HttpRequestMessage webRequest = new(HttpMethod.Post, @params.Url(this._client))
        {
            Content = @params.BodyContent(),
        };
        @params.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            throw new HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
        return JsonSerializer.Deserialize<Customer>(await response.Content.ReadAsStringAsync())
            ?? throw new NullReferenceException();
    }

    public async Task<Customer> Update(CustomerUpdateParams @params)
    {
        HttpRequestMessage webRequest = new(HttpMethod.Put, @params.Url(this._client))
        {
            Content = @params.BodyContent(),
        };
        @params.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            throw new HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
        return JsonSerializer.Deserialize<Customer>(await response.Content.ReadAsStringAsync())
            ?? throw new NullReferenceException();
    }

    public async Task<CustomerListPageResponse> List(CustomerListParams @params)
    {
        HttpRequestMessage webRequest = new(HttpMethod.Get, @params.Url(this._client));
        @params.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            throw new HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
        return JsonSerializer.Deserialize<CustomerListPageResponse>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new NullReferenceException();
    }

    public async Task Delete(CustomerDeleteParams @params)
    {
        HttpRequestMessage webRequest = new(HttpMethod.Delete, @params.Url(this._client));
        @params.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            throw new HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
    }

    public async Task<Customer> Fetch(CustomerFetchParams @params)
    {
        HttpRequestMessage webRequest = new(HttpMethod.Get, @params.Url(this._client));
        @params.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            throw new HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
        return JsonSerializer.Deserialize<Customer>(await response.Content.ReadAsStringAsync())
            ?? throw new NullReferenceException();
    }

    public async Task<Customer> FetchByExternalID(CustomerFetchByExternalIDParams @params)
    {
        HttpRequestMessage webRequest = new(HttpMethod.Get, @params.Url(this._client));
        @params.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            throw new HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
        return JsonSerializer.Deserialize<Customer>(await response.Content.ReadAsStringAsync())
            ?? throw new NullReferenceException();
    }

    public async Task SyncPaymentMethodsFromGateway(
        CustomerSyncPaymentMethodsFromGatewayParams @params
    )
    {
        HttpRequestMessage webRequest = new(HttpMethod.Post, @params.Url(this._client));
        @params.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            throw new HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
    }

    public async Task SyncPaymentMethodsFromGatewayByExternalCustomerID(
        CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams @params
    )
    {
        HttpRequestMessage webRequest = new(HttpMethod.Post, @params.Url(this._client));
        @params.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            throw new HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
    }

    public async Task<Customer> UpdateByExternalID(CustomerUpdateByExternalIDParams @params)
    {
        HttpRequestMessage webRequest = new(HttpMethod.Put, @params.Url(this._client))
        {
            Content = @params.BodyContent(),
        };
        @params.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            throw new HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
        return JsonSerializer.Deserialize<Customer>(await response.Content.ReadAsStringAsync())
            ?? throw new NullReferenceException();
    }
}
