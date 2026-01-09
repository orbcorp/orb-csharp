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
    readonly Lazy<IPriceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPriceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public IPriceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PriceService(this._client.WithOptions(modifier));
    }

    public PriceService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PriceServiceWithRawResponse(client.WithRawResponse));
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
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Models::Price> Update(
        PriceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::Price> Update(
        string priceID,
        PriceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { PriceID = priceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PriceListPage> List(
        PriceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PriceEvaluateResponse> Evaluate(
        PriceEvaluateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Evaluate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PriceEvaluateResponse> Evaluate(
        string priceID,
        PriceEvaluateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Evaluate(parameters with { PriceID = priceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PriceEvaluateMultipleResponse> EvaluateMultiple(
        PriceEvaluateMultipleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.EvaluateMultiple(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PriceEvaluatePreviewEventsResponse> EvaluatePreviewEvents(
        PriceEvaluatePreviewEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.EvaluatePreviewEvents(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Models::Price> Fetch(
        PriceFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Fetch(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Models::Price> Fetch(
        string priceID,
        PriceFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Fetch(parameters with { PriceID = priceID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PriceServiceWithRawResponse : IPriceServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPriceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PriceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PriceServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;

        _externalPriceID = new(() => new ExternalPriceIDServiceWithRawResponse(client));
    }

    readonly Lazy<IExternalPriceIDServiceWithRawResponse> _externalPriceID;
    public IExternalPriceIDServiceWithRawResponse ExternalPriceID
    {
        get { return _externalPriceID.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::Price>> Create(
        PriceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PriceCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var price = await response.Deserialize<Models::Price>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    price.Validate();
                }
                return price;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::Price>> Update(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var price = await response.Deserialize<Models::Price>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    price.Validate();
                }
                return price;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Models::Price>> Update(
        string priceID,
        PriceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { PriceID = priceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PriceListPage>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<PriceListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new PriceListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PriceEvaluateResponse>> Evaluate(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<PriceEvaluateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PriceEvaluateResponse>> Evaluate(
        string priceID,
        PriceEvaluateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Evaluate(parameters with { PriceID = priceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PriceEvaluateMultipleResponse>> EvaluateMultiple(
        PriceEvaluateMultipleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PriceEvaluateMultipleParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<PriceEvaluateMultipleResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PriceEvaluatePreviewEventsResponse>> EvaluatePreviewEvents(
        PriceEvaluatePreviewEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PriceEvaluatePreviewEventsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<PriceEvaluatePreviewEventsResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Models::Price>> Fetch(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var price = await response.Deserialize<Models::Price>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    price.Validate();
                }
                return price;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Models::Price>> Fetch(
        string priceID,
        PriceFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Fetch(parameters with { PriceID = priceID }, cancellationToken);
    }
}
