using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models;
using Orb.Services.Prices.ExternalPriceID;
using Prices = Orb.Models.Prices;

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

    public async Task<Price> Create(
        Prices::PriceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Prices::PriceCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var price = await response.Deserialize<Price>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            price.Validate();
        }
        return price;
    }

    public async Task<Price> Update(
        Prices::PriceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Prices::PriceUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var price = await response.Deserialize<Price>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            price.Validate();
        }
        return price;
    }

    public async Task<Prices::PriceListPageResponse> List(
        Prices::PriceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<Prices::PriceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<Prices::PriceListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<Prices::PriceEvaluateResponse> Evaluate(
        Prices::PriceEvaluateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Prices::PriceEvaluateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<Prices::PriceEvaluateResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<Prices::PriceEvaluateMultipleResponse> EvaluateMultiple(
        Prices::PriceEvaluateMultipleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Prices::PriceEvaluateMultipleParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<Prices::PriceEvaluateMultipleResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<Prices::PriceEvaluatePreviewEventsResponse> EvaluatePreviewEvents(
        Prices::PriceEvaluatePreviewEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Prices::PriceEvaluatePreviewEventsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<Prices::PriceEvaluatePreviewEventsResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<Price> Fetch(
        Prices::PriceFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Prices::PriceFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var price = await response.Deserialize<Price>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            price.Validate();
        }
        return price;
    }
}
