using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;
using Orb.Models.Prices.ExternalPriceID;

namespace Orb.Services.Prices;

/// <inheritdoc/>
public sealed class ExternalPriceIDService : IExternalPriceIDService
{
    readonly Lazy<IExternalPriceIDServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IExternalPriceIDServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public IExternalPriceIDService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExternalPriceIDService(this._client.WithOptions(modifier));
    }

    public ExternalPriceIDService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new ExternalPriceIDServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<Price> Update(
        ExternalPriceIDUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Price> Update(
        string externalPriceID,
        ExternalPriceIDUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                ExternalPriceID = externalPriceID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<Price> Fetch(
        ExternalPriceIDFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Fetch(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Price> Fetch(
        string externalPriceID,
        ExternalPriceIDFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Fetch(parameters with { ExternalPriceID = externalPriceID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ExternalPriceIDServiceWithRawResponse : IExternalPriceIDServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public IExternalPriceIDServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ExternalPriceIDServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ExternalPriceIDServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Price>> Update(
        ExternalPriceIDUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalPriceID == null)
        {
            throw new OrbInvalidDataException("'parameters.ExternalPriceID' cannot be null");
        }

        HttpRequest<ExternalPriceIDUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var price = await response.Deserialize<Price>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    price.Validate();
                }
                return price;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Price>> Update(
        string externalPriceID,
        ExternalPriceIDUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                ExternalPriceID = externalPriceID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Price>> Fetch(
        ExternalPriceIDFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalPriceID == null)
        {
            throw new OrbInvalidDataException("'parameters.ExternalPriceID' cannot be null");
        }

        HttpRequest<ExternalPriceIDFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var price = await response.Deserialize<Price>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    price.Validate();
                }
                return price;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Price>> Fetch(
        string externalPriceID,
        ExternalPriceIDFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Fetch(parameters with { ExternalPriceID = externalPriceID }, cancellationToken);
    }
}
