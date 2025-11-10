using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.DimensionalPriceGroups;
using Orb.Models.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;

namespace Orb.Services.DimensionalPriceGroups;

public sealed class ExternalDimensionalPriceGroupIDService : IExternalDimensionalPriceGroupIDService
{
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

    public async Task<DimensionalPriceGroup> Retrieve(
        ExternalDimensionalPriceGroupIDRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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

    public async Task<DimensionalPriceGroup> Update(
        ExternalDimensionalPriceGroupIDUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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
}
