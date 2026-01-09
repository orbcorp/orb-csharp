using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.DimensionalPriceGroups;
using Orb.Services.DimensionalPriceGroups;

namespace Orb.Services;

/// <inheritdoc/>
public sealed class DimensionalPriceGroupService : IDimensionalPriceGroupService
{
    readonly Lazy<IDimensionalPriceGroupServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDimensionalPriceGroupServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public IDimensionalPriceGroupService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DimensionalPriceGroupService(this._client.WithOptions(modifier));
    }

    public DimensionalPriceGroupService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new DimensionalPriceGroupServiceWithRawResponse(client.WithRawResponse)
        );
        _externalDimensionalPriceGroupID = new(() =>
            new ExternalDimensionalPriceGroupIDService(client)
        );
    }

    readonly Lazy<IExternalDimensionalPriceGroupIDService> _externalDimensionalPriceGroupID;
    public IExternalDimensionalPriceGroupIDService ExternalDimensionalPriceGroupID
    {
        get { return _externalDimensionalPriceGroupID.Value; }
    }

    /// <inheritdoc/>
    public async Task<DimensionalPriceGroup> Create(
        DimensionalPriceGroupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<DimensionalPriceGroup> Retrieve(
        DimensionalPriceGroupRetrieveParams parameters,
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
        string dimensionalPriceGroupID,
        DimensionalPriceGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                DimensionalPriceGroupID = dimensionalPriceGroupID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<DimensionalPriceGroup> Update(
        DimensionalPriceGroupUpdateParams parameters,
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
        string dimensionalPriceGroupID,
        DimensionalPriceGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                DimensionalPriceGroupID = dimensionalPriceGroupID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<DimensionalPriceGroupListPage> List(
        DimensionalPriceGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class DimensionalPriceGroupServiceWithRawResponse
    : IDimensionalPriceGroupServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDimensionalPriceGroupServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new DimensionalPriceGroupServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DimensionalPriceGroupServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;

        _externalDimensionalPriceGroupID = new(() =>
            new ExternalDimensionalPriceGroupIDServiceWithRawResponse(client)
        );
    }

    readonly Lazy<IExternalDimensionalPriceGroupIDServiceWithRawResponse> _externalDimensionalPriceGroupID;
    public IExternalDimensionalPriceGroupIDServiceWithRawResponse ExternalDimensionalPriceGroupID
    {
        get { return _externalDimensionalPriceGroupID.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DimensionalPriceGroup>> Create(
        DimensionalPriceGroupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<DimensionalPriceGroupCreateParams> request = new()
        {
            Method = HttpMethod.Post,
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
    public async Task<HttpResponse<DimensionalPriceGroup>> Retrieve(
        DimensionalPriceGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DimensionalPriceGroupID == null)
        {
            throw new OrbInvalidDataException(
                "'parameters.DimensionalPriceGroupID' cannot be null"
            );
        }

        HttpRequest<DimensionalPriceGroupRetrieveParams> request = new()
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
        string dimensionalPriceGroupID,
        DimensionalPriceGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                DimensionalPriceGroupID = dimensionalPriceGroupID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DimensionalPriceGroup>> Update(
        DimensionalPriceGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DimensionalPriceGroupID == null)
        {
            throw new OrbInvalidDataException(
                "'parameters.DimensionalPriceGroupID' cannot be null"
            );
        }

        HttpRequest<DimensionalPriceGroupUpdateParams> request = new()
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
        string dimensionalPriceGroupID,
        DimensionalPriceGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                DimensionalPriceGroupID = dimensionalPriceGroupID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DimensionalPriceGroupListPage>> List(
        DimensionalPriceGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DimensionalPriceGroupListParams> request = new()
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
                    .Deserialize<DimensionalPriceGroupDimensionalPriceGroups>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new DimensionalPriceGroupListPage(this, parameters, page);
            }
        );
    }
}
