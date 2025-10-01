using System;
using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.DimensionalPriceGroups;
using Orb.Services.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;

namespace Orb.Services.DimensionalPriceGroups;

public sealed class DimensionalPriceGroupService : IDimensionalPriceGroupService
{
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

    public async Task<DimensionalPriceGroup> Create(DimensionalPriceGroupCreateParams parameters)
    {
        HttpRequest<DimensionalPriceGroupCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<DimensionalPriceGroup>().ConfigureAwait(false);
    }

    public async Task<DimensionalPriceGroup> Retrieve(
        DimensionalPriceGroupRetrieveParams parameters
    )
    {
        HttpRequest<DimensionalPriceGroupRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<DimensionalPriceGroup>().ConfigureAwait(false);
    }

    public async Task<DimensionalPriceGroup> Update(DimensionalPriceGroupUpdateParams parameters)
    {
        HttpRequest<DimensionalPriceGroupUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<DimensionalPriceGroup>().ConfigureAwait(false);
    }

    public async Task<DimensionalPriceGroupsModel> List(
        DimensionalPriceGroupListParams? parameters = null
    )
    {
        parameters ??= new();

        HttpRequest<DimensionalPriceGroupListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<DimensionalPriceGroupsModel>().ConfigureAwait(false);
    }
}
