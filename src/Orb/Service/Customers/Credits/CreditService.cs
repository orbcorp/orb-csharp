using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Orb.Models.Customers.Credits;
using Ledger = Orb.Service.Customers.Credits.Ledger;
using TopUps = Orb.Service.Customers.Credits.TopUps;

namespace Orb.Service.Customers.Credits;

public sealed class CreditService : ICreditService
{
    readonly IOrbClient _client;

    public CreditService(IOrbClient client)
    {
        _client = client;
        _ledger = new(() => new Ledger::LedgerService(client));
        _topUps = new(() => new TopUps::TopUpService(client));
    }

    readonly Lazy<Ledger::ILedgerService> _ledger;
    public Ledger::ILedgerService Ledger
    {
        get { return _ledger.Value; }
    }

    readonly Lazy<TopUps::ITopUpService> _topUps;
    public TopUps::ITopUpService TopUps
    {
        get { return _topUps.Value; }
    }

    public async Task<CreditListPageResponse> List(CreditListParams @params)
    {
        using HttpRequestMessage webRequest = new(HttpMethod.Get, @params.Url(this._client));
        @params.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client
            .HttpClient.SendAsync(webRequest)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }
        return JsonSerializer.Deserialize<CreditListPageResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }

    public async Task<CreditListByExternalIDPageResponse> ListByExternalID(
        CreditListByExternalIDParams @params
    )
    {
        using HttpRequestMessage webRequest = new(HttpMethod.Get, @params.Url(this._client));
        @params.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client
            .HttpClient.SendAsync(webRequest)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }
        return JsonSerializer.Deserialize<CreditListByExternalIDPageResponse>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
