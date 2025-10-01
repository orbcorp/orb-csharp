using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Beta;
using Orb.Models.Beta.ExternalPlanID;
using Orb.Models.Plans;

namespace Orb.Services.Beta.ExternalPlanID;

public sealed class ExternalPlanIDService : IExternalPlanIDService
{
    readonly IOrbClient _client;

    public ExternalPlanIDService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<PlanVersion> CreatePlanVersion(
        ExternalPlanIDCreatePlanVersionParams parameters
    )
    {
        HttpRequest<ExternalPlanIDCreatePlanVersionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<PlanVersion>().ConfigureAwait(false);
    }

    public async Task<PlanVersion> FetchPlanVersion(ExternalPlanIDFetchPlanVersionParams parameters)
    {
        HttpRequest<ExternalPlanIDFetchPlanVersionParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<PlanVersion>().ConfigureAwait(false);
    }

    public async Task<Plan> SetDefaultPlanVersion(
        ExternalPlanIDSetDefaultPlanVersionParams parameters
    )
    {
        HttpRequest<ExternalPlanIDSetDefaultPlanVersionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<Plan>().ConfigureAwait(false);
    }
}
