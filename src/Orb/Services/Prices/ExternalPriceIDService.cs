using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;
using Orb.Models.Prices.ExternalPriceID;

namespace Orb.Services.Prices;

/// <inheritdoc />
public sealed class ExternalPriceIDService : IExternalPriceIDService
{
    /// <inheritdoc/>
    public IExternalPriceIDService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExternalPriceIDService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public ExternalPriceIDService(IOrbClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<Price> Update(
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

    /// <inheritdoc/>
    public async Task<Price> Update(
        string externalPriceID,
        ExternalPriceIDUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Update(
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
        if (parameters.ExternalPriceID == null)
        {
            throw new OrbInvalidDataException("'parameters.ExternalPriceID' cannot be null");
        }

        HttpRequest<ExternalPriceIDFetchParams> request = new()
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

    /// <inheritdoc/>
    public async Task<Price> Fetch(
        string externalPriceID,
        ExternalPriceIDFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Fetch(
            parameters with
            {
                ExternalPriceID = externalPriceID,
            },
            cancellationToken
        );
    }
}
