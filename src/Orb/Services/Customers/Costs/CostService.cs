using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Customers.Costs;

namespace Orb.Services.Customers.Costs;

public sealed class CostService : ICostService
{
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
        return await response.Deserialize<CostListResponse>().ConfigureAwait(false);
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
        return await response.Deserialize<CostListByExternalIDResponse>().ConfigureAwait(false);
    }
}
