using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Plans.Migrations;

namespace Orb.Services.Plans;

/// <inheritdoc/>
public sealed class MigrationService : IMigrationService
{
    readonly Lazy<IMigrationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMigrationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public IMigrationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MigrationService(this._client.WithOptions(modifier));
    }

    public MigrationService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MigrationServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<MigrationRetrieveResponse> Retrieve(
        MigrationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MigrationRetrieveResponse> Retrieve(
        string migrationID,
        MigrationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { MigrationID = migrationID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MigrationListPage> List(
        MigrationListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MigrationListPage> List(
        string planID,
        MigrationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { PlanID = planID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MigrationCancelResponse> Cancel(
        MigrationCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<MigrationCancelResponse> Cancel(
        string migrationID,
        MigrationCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Cancel(parameters with { MigrationID = migrationID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class MigrationServiceWithRawResponse : IMigrationServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMigrationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MigrationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MigrationServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MigrationRetrieveResponse>> Retrieve(
        MigrationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MigrationID == null)
        {
            throw new OrbInvalidDataException("'parameters.MigrationID' cannot be null");
        }

        HttpRequest<MigrationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var migration = await response
                    .Deserialize<MigrationRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    migration.Validate();
                }
                return migration;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<MigrationRetrieveResponse>> Retrieve(
        string migrationID,
        MigrationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { MigrationID = migrationID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MigrationListPage>> List(
        MigrationListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PlanID == null)
        {
            throw new OrbInvalidDataException("'parameters.PlanID' cannot be null");
        }

        HttpRequest<MigrationListParams> request = new()
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
                    .Deserialize<MigrationListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new MigrationListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<MigrationListPage>> List(
        string planID,
        MigrationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { PlanID = planID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MigrationCancelResponse>> Cancel(
        MigrationCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.MigrationID == null)
        {
            throw new OrbInvalidDataException("'parameters.MigrationID' cannot be null");
        }

        HttpRequest<MigrationCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<MigrationCancelResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<MigrationCancelResponse>> Cancel(
        string migrationID,
        MigrationCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Cancel(parameters with { MigrationID = migrationID }, cancellationToken);
    }
}
