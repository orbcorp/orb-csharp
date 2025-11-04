using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.DimensionalPriceGroups;
using Orb.Models.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;

namespace Orb.Services.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;

public sealed class ExternalDimensionalPriceGroupIDService : IExternalDimensionalPriceGroupIDService
{
    readonly IOrbClient _client;

    public ExternalDimensionalPriceGroupIDService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<DimensionalPriceGroup> Retrieve(
        ExternalDimensionalPriceGroupIDRetrieveParams parameters
    )
    {
        HttpRequest<ExternalDimensionalPriceGroupIDRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var dimensionalPriceGroup = await response
            .Deserialize<DimensionalPriceGroup>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            dimensionalPriceGroup.Validate();
        }
        return dimensionalPriceGroup;
    }

    public async Task<DimensionalPriceGroup> Update(
        ExternalDimensionalPriceGroupIDUpdateParams parameters
    )
    {
        HttpRequest<ExternalDimensionalPriceGroupIDUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var dimensionalPriceGroup = await response
            .Deserialize<DimensionalPriceGroup>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            dimensionalPriceGroup.Validate();
        }
        return dimensionalPriceGroup;
    }
}
