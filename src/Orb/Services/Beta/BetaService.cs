using System;
using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Beta;
using Orb.Models.Plans;
using Orb.Services.Beta.ExternalPlanID;

namespace Orb.Services.Beta;

public sealed class BetaService : IBetaService
{
    readonly IOrbClient _client;

    public BetaService(IOrbClient client)
    {
        _client = client;
        _externalPlanID = new(() => new ExternalPlanIDService(client));
    }

    readonly Lazy<IExternalPlanIDService> _externalPlanID;
    public IExternalPlanIDService ExternalPlanID
    {
        get { return _externalPlanID.Value; }
    }

    public async Task<PlanVersion> CreatePlanVersion(BetaCreatePlanVersionParams parameters)
    {
        HttpRequest<BetaCreatePlanVersionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<PlanVersion>().ConfigureAwait(false);
    }

    public async Task<PlanVersion> FetchPlanVersion(BetaFetchPlanVersionParams parameters)
    {
        HttpRequest<BetaFetchPlanVersionParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<PlanVersion>().ConfigureAwait(false);
    }

    public async Task<Plan> SetDefaultPlanVersion(BetaSetDefaultPlanVersionParams parameters)
    {
        HttpRequest<BetaSetDefaultPlanVersionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Plan>().ConfigureAwait(false);
    }
}
