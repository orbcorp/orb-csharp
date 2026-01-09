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
    readonly Lazy<IPlanServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPlanServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public IPlanService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PlanService(this._client.WithOptions(modifier));
    }

    public PlanService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PlanServiceWithRawResponse(client.WithRawResponse));
        _externalPlanID = new(() => new ExternalPlanIDService(client));
        _migrations = new(() => new MigrationService(client));
    }

    readonly Lazy<IExternalPlanIDService> _externalPlanID;
    public IExternalPlanIDService ExternalPlanID
    {
        get { return _externalPlanID.Value; }
    }

    readonly Lazy<IMigrationService> _migrations;
    public IMigrationService Migrations
    {
        get { return _migrations.Value; }
    }

    /// <inheritdoc/>
    public async Task<Plan> Create(
        PlanCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Plan> Update(
        PlanUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Plan> Update(
        string planID,
        PlanUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { PlanID = planID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PlanListPage> List(
        PlanListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Plan> Fetch(
        PlanFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Fetch(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Plan> Fetch(
        string planID,
        PlanFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Fetch(parameters with { PlanID = planID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PlanServiceWithRawResponse : IPlanServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPlanServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PlanServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PlanServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;

        _externalPlanID = new(() => new ExternalPlanIDServiceWithRawResponse(client));
        _migrations = new(() => new MigrationServiceWithRawResponse(client));
    }

    readonly Lazy<IExternalPlanIDServiceWithRawResponse> _externalPlanID;
    public IExternalPlanIDServiceWithRawResponse ExternalPlanID
    {
        get { return _externalPlanID.Value; }
    }

    readonly Lazy<IMigrationServiceWithRawResponse> _migrations;
    public IMigrationServiceWithRawResponse Migrations
    {
        get { return _migrations.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Plan>> Create(
        PlanCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PlanCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var plan = await response.Deserialize<Plan>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    plan.Validate();
                }
                return plan;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Plan>> Update(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var plan = await response.Deserialize<Plan>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    plan.Validate();
                }
                return plan;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Plan>> Update(
        string planID,
        PlanUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { PlanID = planID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PlanListPage>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<PlanListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new PlanListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Plan>> Fetch(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var plan = await response.Deserialize<Plan>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    plan.Validate();
                }
                return plan;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Plan>> Fetch(
        string planID,
        PlanFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Fetch(parameters with { PlanID = planID }, cancellationToken);
    }
}
