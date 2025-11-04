using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Plans;
using Orb.Models.Plans.ExternalPlanID;

namespace Orb.Services.Plans.ExternalPlanID;

public sealed class ExternalPlanIDService : IExternalPlanIDService
{
    readonly IOrbClient _client;

    public ExternalPlanIDService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<Plan> Update(ExternalPlanIDUpdateParams parameters)
    {
        HttpRequest<ExternalPlanIDUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var plan = await response.Deserialize<Plan>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            plan.Validate();
        }
        return plan;
    }

    public async Task<Plan> Fetch(ExternalPlanIDFetchParams parameters)
    {
        HttpRequest<ExternalPlanIDFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var plan = await response.Deserialize<Plan>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            plan.Validate();
        }
        return plan;
    }
}
