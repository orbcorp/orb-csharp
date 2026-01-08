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
    /// <inheritdoc/>
    public ICreditBlockService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CreditBlockService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public CreditBlockService(IOrbClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<CreditBlockRetrieveResponse> Retrieve(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var creditBlock = await response
            .Deserialize<CreditBlockRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            creditBlock.Validate();
        }
        return creditBlock;
    }

    /// <inheritdoc/>
    public async Task<CreditBlockRetrieveResponse> Retrieve(
        string blockID,
        CreditBlockRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { BlockID = blockID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string blockID,
        CreditBlockDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { BlockID = blockID }, cancellationToken);
    }
}
