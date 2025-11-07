using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.DimensionalPriceGroups;
using Orb.Services.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;

namespace Orb.Services.DimensionalPriceGroups;

public sealed class DimensionalPriceGroupService : IDimensionalPriceGroupService
{
    public IDimensionalPriceGroupService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DimensionalPriceGroupService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public DimensionalPriceGroupService(IOrbClient client)
    {
        _client = client;
        _externalDimensionalPriceGroupID = new(() =>
            new ExternalDimensionalPriceGroupIDService(client)
        );
    }

    readonly Lazy<IExternalDimensionalPriceGroupIDService> _externalDimensionalPriceGroupID;
    public IExternalDimensionalPriceGroupIDService ExternalDimensionalPriceGroupID
    {
        get { return _externalDimensionalPriceGroupID.Value; }
    }

    public async Task<DimensionalPriceGroup> Create(
        DimensionalPriceGroupCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<DimensionalPriceGroupCreateParams> request = new()
        {
            Method = HttpMethod.Post,
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

    public async Task<DimensionalPriceGroup> Retrieve(
        DimensionalPriceGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<DimensionalPriceGroupRetrieveParams> request = new()
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

    public async Task<DimensionalPriceGroup> Update(
        DimensionalPriceGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<DimensionalPriceGroupUpdateParams> request = new()
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

    public async Task<DimensionalPriceGroupsModel> List(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<DimensionalPriceGroupsModel>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }
}
