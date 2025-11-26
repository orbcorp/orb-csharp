using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.DimensionalPriceGroups;
using Orb.Models.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;

namespace Orb.Services.DimensionalPriceGroups;

/// <inheritdoc />
public sealed class ExternalDimensionalPriceGroupIDService : IExternalDimensionalPriceGroupIDService
{
    /// <inheritdoc/>
    public IExternalDimensionalPriceGroupIDService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ExternalDimensionalPriceGroupIDService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public ExternalDimensionalPriceGroupIDService(IOrbClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<DimensionalPriceGroup> Retrieve(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var dimensionalPriceGroup = await response
            .Deserialize<DimensionalPriceGroup>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            dimensionalPriceGroup.Validate();
        }
        return dimensionalPriceGroup;
    }

    /// <inheritdoc/>
    public async Task<DimensionalPriceGroup> Retrieve(
        string externalDimensionalPriceGroupID,
        ExternalDimensionalPriceGroupIDRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var dimensionalPriceGroup = await response
            .Deserialize<DimensionalPriceGroup>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            dimensionalPriceGroup.Validate();
        }
        return dimensionalPriceGroup;
    }

    /// <inheritdoc/>
    public async Task<DimensionalPriceGroup> Update(
        string externalDimensionalPriceGroupID,
        ExternalDimensionalPriceGroupIDUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Update(
            parameters with
            {
                ExternalDimensionalPriceGroupID = externalDimensionalPriceGroupID,
            },
            cancellationToken
        );
    }
}
