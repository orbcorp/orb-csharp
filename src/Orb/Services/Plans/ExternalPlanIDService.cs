using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Plans;
using Orb.Models.Plans.ExternalPlanID;

namespace Orb.Services.Plans;

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

    public async Task<Plan> Update(
        ExternalPlanIDUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExternalPlanIDUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
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

    public async Task<Plan> Fetch(
        ExternalPlanIDFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExternalPlanIDFetchParams> request = new()
        {
            Method = HttpMethod.Get,
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
