using System;
using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models;
using Orb.Models.Prices;
using Orb.Services.Prices.ExternalPriceID;

namespace Orb.Services.Prices;

public sealed class PriceService : IPriceService
{
    readonly IOrbClient _client;

    public PriceService(IOrbClient client)
    {
        _client = client;
        _externalPriceID = new(() => new ExternalPriceIDService(client));
    }

    readonly Lazy<IExternalPriceIDService> _externalPriceID;
    public IExternalPriceIDService ExternalPriceID
    {
        get { return _externalPriceID.Value; }
    }

    public async Task<Price> Create(PriceCreateParams parameters)
    {
        HttpRequest<PriceCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Price>().ConfigureAwait(false);
    }

    public async Task<Price> Update(PriceUpdateParams parameters)
    {
        HttpRequest<PriceUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Price>().ConfigureAwait(false);
    }

    public async Task<PriceListPageResponse> List(PriceListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<PriceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<PriceListPageResponse>().ConfigureAwait(false);
    }

    public async Task<PriceEvaluateResponse> Evaluate(PriceEvaluateParams parameters)
    {
        HttpRequest<PriceEvaluateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<PriceEvaluateResponse>().ConfigureAwait(false);
    }

    public async Task<PriceEvaluateMultipleResponse> EvaluateMultiple(
        PriceEvaluateMultipleParams parameters
    )
    {
        HttpRequest<PriceEvaluateMultipleParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<PriceEvaluateMultipleResponse>().ConfigureAwait(false);
    }

    public async Task<PriceEvaluatePreviewEventsResponse> EvaluatePreviewEvents(
        PriceEvaluatePreviewEventsParams parameters
    )
    {
        HttpRequest<PriceEvaluatePreviewEventsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response
            .Deserialize<PriceEvaluatePreviewEventsResponse>()
            .ConfigureAwait(false);
    }

    public async Task<Price> Fetch(PriceFetchParams parameters)
    {
        HttpRequest<PriceFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Price>().ConfigureAwait(false);
    }
}
