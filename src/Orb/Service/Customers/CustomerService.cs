using BalanceTransactions = Orb.Service.Customers.BalanceTransactions;
using Costs = Orb.Service.Customers.Costs;
using Credits = Orb.Service.Customers.Credits;
using Customers = Orb.Models.Customers;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Orb = Orb;
using System = System;
using Tasks = System.Threading.Tasks;

namespace Orb.Service.Customers;

public sealed class CustomerService : ICustomerService
{
    readonly Orb::IOrbClient _client;

    public CustomerService(Orb::IOrbClient client)
    {
        _client = client;
        _costs = new(() => new Costs::CostService(client));
        _credits = new(() => new Credits::CreditService(client));
        _balanceTransactions = new(() => new BalanceTransactions::BalanceTransactionService(client)
        );
    }

    readonly System::Lazy<Costs::ICostService> _costs;
    public Costs::ICostService Costs
    {
        get { return _costs.Value; }
    }

    readonly System::Lazy<Credits::ICreditService> _credits;
    public Credits::ICreditService Credits
    {
        get { return _credits.Value; }
    }

    readonly System::Lazy<BalanceTransactions::IBalanceTransactionService> _balanceTransactions;
    public BalanceTransactions::IBalanceTransactionService BalanceTransactions
    {
        get { return _balanceTransactions.Value; }
    }

    public async Tasks::Task<Customers::Customer> Create(Customers::CustomerCreateParams @params)
    {
        Http::HttpRequestMessage webRequest = new(Http::HttpMethod.Post, @params.Url(this._client))
        {
            Content = @params.BodyContent(),
        };
        @params.AddHeadersToRequest(webRequest, this._client);
        using Http::HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (Http::HttpRequestException e)
        {
            throw new Orb::HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
        return Json::JsonSerializer.Deserialize<Customers::Customer>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }

    public async Tasks::Task<Customers::Customer> Update(Customers::CustomerUpdateParams @params)
    {
        Http::HttpRequestMessage webRequest = new(Http::HttpMethod.Put, @params.Url(this._client))
        {
            Content = @params.BodyContent(),
        };
        @params.AddHeadersToRequest(webRequest, this._client);
        using Http::HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (Http::HttpRequestException e)
        {
            throw new Orb::HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
        return Json::JsonSerializer.Deserialize<Customers::Customer>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }

    public async Tasks::Task<Customers::CustomerListPageResponse> List(
        Customers::CustomerListParams @params
    )
    {
        Http::HttpRequestMessage webRequest = new(Http::HttpMethod.Get, @params.Url(this._client));
        @params.AddHeadersToRequest(webRequest, this._client);
        using Http::HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (Http::HttpRequestException e)
        {
            throw new Orb::HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
        return Json::JsonSerializer.Deserialize<Customers::CustomerListPageResponse>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }

    public async Tasks::Task Delete(Customers::CustomerDeleteParams @params)
    {
        Http::HttpRequestMessage webRequest = new(
            Http::HttpMethod.Delete,
            @params.Url(this._client)
        );
        @params.AddHeadersToRequest(webRequest, this._client);
        using Http::HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (Http::HttpRequestException e)
        {
            throw new Orb::HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
    }

    public async Tasks::Task<Customers::Customer> Fetch(Customers::CustomerFetchParams @params)
    {
        Http::HttpRequestMessage webRequest = new(Http::HttpMethod.Get, @params.Url(this._client));
        @params.AddHeadersToRequest(webRequest, this._client);
        using Http::HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (Http::HttpRequestException e)
        {
            throw new Orb::HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
        return Json::JsonSerializer.Deserialize<Customers::Customer>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }

    public async Tasks::Task<Customers::Customer> FetchByExternalID(
        Customers::CustomerFetchByExternalIDParams @params
    )
    {
        Http::HttpRequestMessage webRequest = new(Http::HttpMethod.Get, @params.Url(this._client));
        @params.AddHeadersToRequest(webRequest, this._client);
        using Http::HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (Http::HttpRequestException e)
        {
            throw new Orb::HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
        return Json::JsonSerializer.Deserialize<Customers::Customer>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }

    public async Tasks::Task SyncPaymentMethodsFromGateway(
        Customers::CustomerSyncPaymentMethodsFromGatewayParams @params
    )
    {
        Http::HttpRequestMessage webRequest = new(Http::HttpMethod.Post, @params.Url(this._client));
        @params.AddHeadersToRequest(webRequest, this._client);
        using Http::HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (Http::HttpRequestException e)
        {
            throw new Orb::HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
    }

    public async Tasks::Task SyncPaymentMethodsFromGatewayByExternalCustomerID(
        Customers::CustomerSyncPaymentMethodsFromGatewayByExternalCustomerIDParams @params
    )
    {
        Http::HttpRequestMessage webRequest = new(Http::HttpMethod.Post, @params.Url(this._client));
        @params.AddHeadersToRequest(webRequest, this._client);
        using Http::HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (Http::HttpRequestException e)
        {
            throw new Orb::HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
    }

    public async Tasks::Task<Customers::Customer> UpdateByExternalID(
        Customers::CustomerUpdateByExternalIDParams @params
    )
    {
        Http::HttpRequestMessage webRequest = new(Http::HttpMethod.Put, @params.Url(this._client))
        {
            Content = @params.BodyContent(),
        };
        @params.AddHeadersToRequest(webRequest, this._client);
        using Http::HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (Http::HttpRequestException e)
        {
            throw new Orb::HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
        return Json::JsonSerializer.Deserialize<Customers::Customer>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }
}
