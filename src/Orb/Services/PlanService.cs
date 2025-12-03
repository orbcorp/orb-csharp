using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Plans;
using Orb.Services.Plans;

namespace Orb.Services;

/// <inheritdoc/>
public sealed class PlanService : IPlanService
{
    /// <inheritdoc/>
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

    /// <inheritdoc/>
    public async Task<Plan> Create(
        PlanCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PlanCreateParams> request = new()
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

    /// <inheritdoc/>
    public async Task<Plan> Update(
        PlanUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PlanID == null)
        {
            throw new OrbInvalidDataException("'parameters.PlanID' cannot be null");
        }

        HttpRequest<PlanUpdateParams> request = new()
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

    /// <inheritdoc/>
    public async Task<Plan> Update(
        string planID,
        PlanUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Update(parameters with { PlanID = planID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PlanListPageResponse> List(
        PlanListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PlanListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<PlanListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    /// <inheritdoc/>
    public async Task<Plan> Fetch(
        PlanFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PlanID == null)
        {
            throw new OrbInvalidDataException("'parameters.PlanID' cannot be null");
        }

        HttpRequest<PlanFetchParams> request = new()
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

    /// <inheritdoc/>
    public async Task<Plan> Fetch(
        string planID,
        PlanFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Fetch(parameters with { PlanID = planID }, cancellationToken);
    }
}
