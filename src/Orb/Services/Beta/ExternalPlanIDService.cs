using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Beta;
using Orb.Models.Beta.ExternalPlanID;
using Orb.Models.Plans;

namespace Orb.Services.Beta;

public sealed class ExternalPlanIDService : IExternalPlanIDService
{
    public IExternalPlanIDService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExternalPlanIDService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public ExternalPlanIDService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<PlanVersion> CreatePlanVersion(
        ExternalPlanIDCreatePlanVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExternalPlanIDCreatePlanVersionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var planVersion = await response
            .Deserialize<PlanVersion>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            planVersion.Validate();
        }
        return planVersion;
    }

    public async Task<PlanVersion> FetchPlanVersion(
        ExternalPlanIDFetchPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExternalPlanIDFetchPlanVersionParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var planVersion = await response
            .Deserialize<PlanVersion>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            planVersion.Validate();
        }
        return planVersion;
    }

    public async Task<Plan> SetDefaultPlanVersion(
        ExternalPlanIDSetDefaultPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExternalPlanIDSetDefaultPlanVersionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var plan = await response.Deserialize<Plan>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            plan.Validate();
        }
        return plan;
    }
}
