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

/// <inheritdoc />
public sealed class BetaService : IBetaService
{
    /// <inheritdoc/>
    public IBetaService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BetaService(this._client.WithOptions(modifier));
    }

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

    /// <inheritdoc/>
    public async Task<PlanVersion> CreatePlanVersion(
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

    /// <inheritdoc/>
    public async Task<PlanVersion> CreatePlanVersion(
        string planID,
        BetaCreatePlanVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.CreatePlanVersion(parameters with { PlanID = planID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PlanVersion> FetchPlanVersion(
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

    /// <inheritdoc/>
    public async Task<PlanVersion> FetchPlanVersion(
        string version,
        BetaFetchPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.FetchPlanVersion(
            parameters with
            {
                Version = version,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<Plan> SetDefaultPlanVersion(
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
    public async Task<Plan> SetDefaultPlanVersion(
        string planID,
        BetaSetDefaultPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.SetDefaultPlanVersion(
            parameters with
            {
                PlanID = planID,
            },
            cancellationToken
        );
    }
}
