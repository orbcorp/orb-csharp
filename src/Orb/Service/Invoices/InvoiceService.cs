using Http = System.Net.Http;
using Invoices = Orb.Models.Invoices;
using Json = System.Text.Json;
using Models = Orb.Models;
using Orb = Orb;
using System = System;
using Tasks = System.Threading.Tasks;

namespace Orb.Service.Invoices;

public sealed class InvoiceService : IInvoiceService
{
    readonly Orb::IOrbClient _client;

    public InvoiceService(Orb::IOrbClient client)
    {
        _client = client;
    }

    public async Tasks::Task<Models::Invoice> Create(Invoices::InvoiceCreateParams @params)
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
        return Json::JsonSerializer.Deserialize<Models::Invoice>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }

    public async Tasks::Task<Models::Invoice> Update(Invoices::InvoiceUpdateParams @params)
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
        return Json::JsonSerializer.Deserialize<Models::Invoice>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }

    public async Tasks::Task<Invoices::InvoiceListPageResponse> List(
        Invoices::InvoiceListParams @params
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
        return Json::JsonSerializer.Deserialize<Invoices::InvoiceListPageResponse>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }

    public async Tasks::Task<Models::Invoice> Fetch(Invoices::InvoiceFetchParams @params)
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
        return Json::JsonSerializer.Deserialize<Models::Invoice>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }

    public async Tasks::Task<Invoices::InvoiceFetchUpcomingResponse> FetchUpcoming(
        Invoices::InvoiceFetchUpcomingParams @params
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
        return Json::JsonSerializer.Deserialize<Invoices::InvoiceFetchUpcomingResponse>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }

    public async Tasks::Task<Models::Invoice> Issue(Invoices::InvoiceIssueParams @params)
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
        return Json::JsonSerializer.Deserialize<Models::Invoice>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }

    public async Tasks::Task<Models::Invoice> MarkPaid(Invoices::InvoiceMarkPaidParams @params)
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
        return Json::JsonSerializer.Deserialize<Models::Invoice>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }

    public async Tasks::Task<Models::Invoice> Pay(Invoices::InvoicePayParams @params)
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
        return Json::JsonSerializer.Deserialize<Models::Invoice>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }

    public async Tasks::Task<Models::Invoice> Void(Invoices::InvoiceVoidParams @params)
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
        return Json::JsonSerializer.Deserialize<Models::Invoice>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }
}
