using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.CreditBlocks;

namespace Orb.Services;

/// <inheritdoc/>
public sealed class CreditBlockService : ICreditBlockService
{
    readonly Lazy<ICreditBlockServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICreditBlockServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public ICreditBlockService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CreditBlockService(this._client.WithOptions(modifier));
    }

    public CreditBlockService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CreditBlockServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<CreditBlockRetrieveResponse> Retrieve(
        CreditBlockRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CreditBlockRetrieveResponse> Retrieve(
        string blockID,
        CreditBlockRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { BlockID = blockID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        CreditBlockDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string blockID,
        CreditBlockDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { BlockID = blockID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class CreditBlockServiceWithRawResponse : ICreditBlockServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICreditBlockServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new CreditBlockServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CreditBlockServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CreditBlockRetrieveResponse>> Retrieve(
        CreditBlockRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BlockID == null)
        {
            throw new OrbInvalidDataException("'parameters.BlockID' cannot be null");
        }

        HttpRequest<CreditBlockRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var creditBlock = await response
                    .Deserialize<CreditBlockRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    creditBlock.Validate();
                }
                return creditBlock;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CreditBlockRetrieveResponse>> Retrieve(
        string blockID,
        CreditBlockRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { BlockID = blockID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        CreditBlockDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BlockID == null)
        {
            throw new OrbInvalidDataException("'parameters.BlockID' cannot be null");
        }

        HttpRequest<CreditBlockDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string blockID,
        CreditBlockDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { BlockID = blockID }, cancellationToken);
    }
}
