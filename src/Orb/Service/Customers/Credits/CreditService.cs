using Credits = Orb.Models.Customers.Credits;
using Http = System.Net.Http;
using Json = System.Text.Json;
using Ledger = Orb.Service.Customers.Credits.Ledger;
using Orb = Orb;
using System = System;
using Tasks = System.Threading.Tasks;
using TopUps = Orb.Service.Customers.Credits.TopUps;

namespace Orb.Service.Customers.Credits;

public sealed class CreditService : ICreditService
{
    readonly Orb::IOrbClient _client;

    public CreditService(Orb::IOrbClient client)
    {
        _client = client;
        _ledger = new(() => new Ledger::LedgerService(client));
        _topUps = new(() => new TopUps::TopUpService(client));
    }

    readonly System::Lazy<Ledger::ILedgerService> _ledger;
    public Ledger::ILedgerService Ledger
    {
        get { return _ledger.Value; }
    }

    readonly System::Lazy<TopUps::ITopUpService> _topUps;
    public TopUps::ITopUpService TopUps
    {
        get { return _topUps.Value; }
    }

    public async Tasks::Task<Credits::CreditListPageResponse> List(
        Credits::CreditListParams @params
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
        return Json::JsonSerializer.Deserialize<Credits::CreditListPageResponse>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }

    public async Tasks::Task<Credits::CreditListByExternalIDPageResponse> ListByExternalID(
        Credits::CreditListByExternalIDParams @params
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
        return Json::JsonSerializer.Deserialize<Credits::CreditListByExternalIDPageResponse>(
                await response.Content.ReadAsStringAsync()
            ) ?? throw new System::NullReferenceException();
    }
}
