using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
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
        if (parameters.OtherExternalPlanID == null)
        {
            throw new OrbInvalidDataException("'parameters.OtherExternalPlanID' cannot be null");
        }

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

    public async Task<Plan> Update(
        string otherExternalPlanID,
        ExternalPlanIDUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Update(
            parameters with
            {
                OtherExternalPlanID = otherExternalPlanID,
            },
            cancellationToken
        );
    }

    public async Task<Plan> Fetch(
        ExternalPlanIDFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalPlanID == null)
        {
            throw new OrbInvalidDataException("'parameters.ExternalPlanID' cannot be null");
        }

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

    public async Task<Plan> Fetch(
        string externalPlanID,
        ExternalPlanIDFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Fetch(
            parameters with
            {
                ExternalPlanID = externalPlanID,
            },
            cancellationToken
        );
    }
}
