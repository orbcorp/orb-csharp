using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.DimensionalPriceGroups;
using Orb.Models.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;

namespace Orb.Services.DimensionalPriceGroups;

/// <inheritdoc/>
public sealed class ExternalDimensionalPriceGroupIDService : IExternalDimensionalPriceGroupIDService
{
    readonly Lazy<IExternalDimensionalPriceGroupIDServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IExternalDimensionalPriceGroupIDServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public IExternalDimensionalPriceGroupIDService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ExternalDimensionalPriceGroupIDService(this._client.WithOptions(modifier));
    }

    public ExternalDimensionalPriceGroupIDService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new ExternalDimensionalPriceGroupIDServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<DimensionalPriceGroup> Retrieve(
        ExternalDimensionalPriceGroupIDRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DimensionalPriceGroup> Retrieve(
        string externalDimensionalPriceGroupID,
        ExternalDimensionalPriceGroupIDRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                ExternalDimensionalPriceGroupID = externalDimensionalPriceGroupID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<DimensionalPriceGroup> Update(
        ExternalDimensionalPriceGroupIDUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DimensionalPriceGroup> Update(
        string externalDimensionalPriceGroupID,
        ExternalDimensionalPriceGroupIDUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                ExternalDimensionalPriceGroupID = externalDimensionalPriceGroupID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class ExternalDimensionalPriceGroupIDServiceWithRawResponse
    : IExternalDimensionalPriceGroupIDServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public IExternalDimensionalPriceGroupIDServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ExternalDimensionalPriceGroupIDServiceWithRawResponse(
            this._client.WithOptions(modifier)
        );
    }

    public ExternalDimensionalPriceGroupIDServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DimensionalPriceGroup>> Retrieve(
        ExternalDimensionalPriceGroupIDRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalDimensionalPriceGroupID == null)
        {
            throw new OrbInvalidDataException(
                "'parameters.ExternalDimensionalPriceGroupID' cannot be null"
            );
        }

        HttpRequest<ExternalDimensionalPriceGroupIDRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var dimensionalPriceGroup = await response
                    .Deserialize<DimensionalPriceGroup>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    dimensionalPriceGroup.Validate();
                }
                return dimensionalPriceGroup;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DimensionalPriceGroup>> Retrieve(
        string externalDimensionalPriceGroupID,
        ExternalDimensionalPriceGroupIDRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                ExternalDimensionalPriceGroupID = externalDimensionalPriceGroupID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DimensionalPriceGroup>> Update(
        ExternalDimensionalPriceGroupIDUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalDimensionalPriceGroupID == null)
        {
            throw new OrbInvalidDataException(
                "'parameters.ExternalDimensionalPriceGroupID' cannot be null"
            );
        }

        HttpRequest<ExternalDimensionalPriceGroupIDUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var dimensionalPriceGroup = await response
                    .Deserialize<DimensionalPriceGroup>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    dimensionalPriceGroup.Validate();
                }
                return dimensionalPriceGroup;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DimensionalPriceGroup>> Update(
        string externalDimensionalPriceGroupID,
        ExternalDimensionalPriceGroupIDUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                ExternalDimensionalPriceGroupID = externalDimensionalPriceGroupID,
            },
            cancellationToken
        );
    }
}
