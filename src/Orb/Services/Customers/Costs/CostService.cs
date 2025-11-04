using System;
using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Customers.Costs;

namespace Orb.Services.Customers.Costs;

public sealed class CostService : ICostService
{
    public ICostService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CostService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public CostService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<CostListResponse> List(CostListParams parameters)
    {
        HttpRequest<CostListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var costs = await response.Deserialize<CostListResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            costs.Validate();
        }
        return costs;
    }

    public async Task<CostListByExternalIDResponse> ListByExternalID(
        CostListByExternalIDParams parameters
    )
    {
        HttpRequest<CostListByExternalIDParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<CostListByExternalIDResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
