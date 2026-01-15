using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Beta;
using Orb.Models.Beta.ExternalPlanID;
using Orb.Models.Plans;

namespace Orb.Services.Beta;

/// <inheritdoc/>
public sealed class ExternalPlanIDService : IExternalPlanIDService
{
    readonly Lazy<IExternalPlanIDServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IExternalPlanIDServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public IExternalPlanIDService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExternalPlanIDService(this._client.WithOptions(modifier));
    }

    public ExternalPlanIDService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new ExternalPlanIDServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<PlanVersion> CreatePlanVersion(
        ExternalPlanIDCreatePlanVersionParams parameters,
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
        string externalPlanID,
        ExternalPlanIDCreatePlanVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreatePlanVersion(
            parameters with
            {
                ExternalPlanID = externalPlanID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<PlanVersion> FetchPlanVersion(
        ExternalPlanIDFetchPlanVersionParams parameters,
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
        ExternalPlanIDFetchPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.FetchPlanVersion(parameters with { Version = version }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Plan> SetDefaultPlanVersion(
        ExternalPlanIDSetDefaultPlanVersionParams parameters,
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
        string externalPlanID,
        ExternalPlanIDSetDefaultPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SetDefaultPlanVersion(
            parameters with
            {
                ExternalPlanID = externalPlanID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class ExternalPlanIDServiceWithRawResponse : IExternalPlanIDServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public IExternalPlanIDServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ExternalPlanIDServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ExternalPlanIDServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PlanVersion>> CreatePlanVersion(
        ExternalPlanIDCreatePlanVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalPlanID == null)
        {
            throw new OrbInvalidDataException("'parameters.ExternalPlanID' cannot be null");
        }

        HttpRequest<ExternalPlanIDCreatePlanVersionParams> request = new()
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
        string externalPlanID,
        ExternalPlanIDCreatePlanVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreatePlanVersion(
            parameters with
            {
                ExternalPlanID = externalPlanID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PlanVersion>> FetchPlanVersion(
        ExternalPlanIDFetchPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Version == null)
        {
            throw new OrbInvalidDataException("'parameters.Version' cannot be null");
        }

        HttpRequest<ExternalPlanIDFetchPlanVersionParams> request = new()
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
        ExternalPlanIDFetchPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.FetchPlanVersion(parameters with { Version = version }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Plan>> SetDefaultPlanVersion(
        ExternalPlanIDSetDefaultPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalPlanID == null)
        {
            throw new OrbInvalidDataException("'parameters.ExternalPlanID' cannot be null");
        }

        HttpRequest<ExternalPlanIDSetDefaultPlanVersionParams> request = new()
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
        string externalPlanID,
        ExternalPlanIDSetDefaultPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SetDefaultPlanVersion(
            parameters with
            {
                ExternalPlanID = externalPlanID,
            },
            cancellationToken
        );
    }
}
