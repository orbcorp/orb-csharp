using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Plans;
using Orb.Models.Plans.ExternalPlanID;

namespace Orb.Services.Plans;

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
    public async Task<Plan> Update(
        ExternalPlanIDUpdateParams parameters,
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
        string otherExternalPlanID,
        ExternalPlanIDUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                OtherExternalPlanID = otherExternalPlanID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<Plan> Fetch(
        ExternalPlanIDFetchParams parameters,
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
        string externalPlanID,
        ExternalPlanIDFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Fetch(parameters with { ExternalPlanID = externalPlanID }, cancellationToken);
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
    public async Task<HttpResponse<Plan>> Update(
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
        string otherExternalPlanID,
        ExternalPlanIDUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                OtherExternalPlanID = otherExternalPlanID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Plan>> Fetch(
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
        string externalPlanID,
        ExternalPlanIDFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Fetch(parameters with { ExternalPlanID = externalPlanID }, cancellationToken);
    }
}
