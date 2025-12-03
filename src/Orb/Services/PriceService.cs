using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Prices;
using Orb.Services.Prices;
using Models = Orb.Models;

namespace Orb.Services;

/// <inheritdoc/>
public sealed class PriceService : IPriceService
{
    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public async Task<Models::Price> Create(
        PriceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PriceCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var price = await response
            .Deserialize<Models::Price>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            price.Validate();
        }
        return price;
    }

    /// <inheritdoc/>
    public async Task<Models::Price> Update(
        PriceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PriceID == null)
        {
            throw new OrbInvalidDataException("'parameters.PriceID' cannot be null");
        }

        HttpRequest<PriceUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var price = await response
            .Deserialize<Models::Price>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            price.Validate();
        }
        return price;
    }

    /// <inheritdoc/>
    public async Task<Models::Price> Update(
        string priceID,
        PriceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Update(parameters with { PriceID = priceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PriceListPageResponse> List(
        PriceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PriceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<PriceListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    /// <inheritdoc/>
    public async Task<PriceEvaluateResponse> Evaluate(
        PriceEvaluateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PriceID == null)
        {
            throw new OrbInvalidDataException("'parameters.PriceID' cannot be null");
        }

        HttpRequest<PriceEvaluateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<PriceEvaluateResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<PriceEvaluateResponse> Evaluate(
        string priceID,
        PriceEvaluateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Evaluate(parameters with { PriceID = priceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PriceEvaluateMultipleResponse> EvaluateMultiple(
        PriceEvaluateMultipleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PriceEvaluateMultipleParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<PriceEvaluateMultipleResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<PriceEvaluatePreviewEventsResponse> EvaluatePreviewEvents(
        PriceEvaluatePreviewEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PriceEvaluatePreviewEventsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<PriceEvaluatePreviewEventsResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<Models::Price> Fetch(
        PriceFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PriceID == null)
        {
            throw new OrbInvalidDataException("'parameters.PriceID' cannot be null");
        }

        HttpRequest<PriceFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var price = await response
            .Deserialize<Models::Price>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            price.Validate();
        }
        return price;
    }

    /// <inheritdoc/>
    public async Task<Models::Price> Fetch(
        string priceID,
        PriceFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Fetch(parameters with { PriceID = priceID }, cancellationToken);
    }
}
