using System;
using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Plans;
using Orb.Services.Plans.ExternalPlanID;

namespace Orb.Services.Plans;

public sealed class PlanService : IPlanService
{
    public IPlanService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PlanService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public PlanService(IOrbClient client)
    {
        _client = client;
        _externalPlanID = new(() => new ExternalPlanIDService(client));
    }

    readonly Lazy<IExternalPlanIDService> _externalPlanID;
    public IExternalPlanIDService ExternalPlanID
    {
        get { return _externalPlanID.Value; }
    }

    public async Task<Plan> Create(PlanCreateParams parameters)
    {
        HttpRequest<PlanCreateParams> request = new()
        {
            Method = HttpMethod.Post,
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

    public async Task<Plan> Update(PlanUpdateParams parameters)
    {
        HttpRequest<PlanUpdateParams> request = new()
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

    public async Task<PlanListPageResponse> List(PlanListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<PlanListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var page = await response.Deserialize<PlanListPageResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<Plan> Fetch(PlanFetchParams parameters)
    {
        HttpRequest<PlanFetchParams> request = new()
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
