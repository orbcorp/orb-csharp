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
    public IPriceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PriceService(this._client.WithOptions(modifier));
    }

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
        var price = await response.Deserialize<Price>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            price.Validate();
        }
        return price;
    }

    public async Task<Price> Update(PriceUpdateParams parameters)
    {
        HttpRequest<PriceUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var price = await response.Deserialize<Price>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            price.Validate();
        }
        return price;
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
        var page = await response.Deserialize<PriceListPageResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<PriceEvaluateResponse> Evaluate(PriceEvaluateParams parameters)
    {
        HttpRequest<PriceEvaluateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<PriceEvaluateResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
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
        var deserializedResponse = await response
            .Deserialize<PriceEvaluateMultipleResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
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
        var deserializedResponse = await response
            .Deserialize<PriceEvaluatePreviewEventsResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<Price> Fetch(PriceFetchParams parameters)
    {
        HttpRequest<PriceFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var price = await response.Deserialize<Price>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            price.Validate();
        }
        return price;
    }
}
