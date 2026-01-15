using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Beta;
using Orb.Models.Plans;
using Orb.Services.Beta;

namespace Orb.Services;

/// <inheritdoc/>
public sealed class BetaService : IBetaService
{
    readonly Lazy<IBetaServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBetaServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public IBetaService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BetaService(this._client.WithOptions(modifier));
    }

    public BetaService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BetaServiceWithRawResponse(client.WithRawResponse));
        _externalPlanID = new(() => new ExternalPlanIDService(client));
    }

    readonly Lazy<IExternalPlanIDService> _externalPlanID;
    public IExternalPlanIDService ExternalPlanID
    {
        get { return _externalPlanID.Value; }
    }

    /// <inheritdoc/>
    public async Task<PlanVersion> CreatePlanVersion(
        BetaCreatePlanVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreatePlanVersion(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PlanVersion> CreatePlanVersion(
        string planID,
        BetaCreatePlanVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreatePlanVersion(parameters with { PlanID = planID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PlanVersion> FetchPlanVersion(
        BetaFetchPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.FetchPlanVersion(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PlanVersion> FetchPlanVersion(
        string version,
        BetaFetchPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.FetchPlanVersion(parameters with { Version = version }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Plan> SetDefaultPlanVersion(
        BetaSetDefaultPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.SetDefaultPlanVersion(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Plan> SetDefaultPlanVersion(
        string planID,
        BetaSetDefaultPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SetDefaultPlanVersion(parameters with { PlanID = planID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class BetaServiceWithRawResponse : IBetaServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBetaServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BetaServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BetaServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;

        _externalPlanID = new(() => new ExternalPlanIDServiceWithRawResponse(client));
    }

    readonly Lazy<IExternalPlanIDServiceWithRawResponse> _externalPlanID;
    public IExternalPlanIDServiceWithRawResponse ExternalPlanID
    {
        get { return _externalPlanID.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PlanVersion>> CreatePlanVersion(
        BetaCreatePlanVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PlanID == null)
        {
            throw new OrbInvalidDataException("'parameters.PlanID' cannot be null");
        }

        HttpRequest<BetaCreatePlanVersionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var planVersion = await response
                    .Deserialize<PlanVersion>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    planVersion.Validate();
                }
                return planVersion;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PlanVersion>> CreatePlanVersion(
        string planID,
        BetaCreatePlanVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreatePlanVersion(parameters with { PlanID = planID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PlanVersion>> FetchPlanVersion(
        BetaFetchPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Version == null)
        {
            throw new OrbInvalidDataException("'parameters.Version' cannot be null");
        }

        HttpRequest<BetaFetchPlanVersionParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var planVersion = await response
                    .Deserialize<PlanVersion>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    planVersion.Validate();
                }
                return planVersion;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PlanVersion>> FetchPlanVersion(
        string version,
        BetaFetchPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.FetchPlanVersion(parameters with { Version = version }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Plan>> SetDefaultPlanVersion(
        BetaSetDefaultPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PlanID == null)
        {
            throw new OrbInvalidDataException("'parameters.PlanID' cannot be null");
        }

        HttpRequest<BetaSetDefaultPlanVersionParams> request = new()
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
    public Task<HttpResponse<Plan>> SetDefaultPlanVersion(
        string planID,
        BetaSetDefaultPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SetDefaultPlanVersion(parameters with { PlanID = planID }, cancellationToken);
    }
}
