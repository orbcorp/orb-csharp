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
    /// <inheritdoc/>
    public IMigrationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MigrationService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public MigrationService(IOrbClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<MigrationRetrieveResponse> Retrieve(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var migration = await response
            .Deserialize<MigrationRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            migration.Validate();
        }
        return migration;
    }

    /// <inheritdoc/>
    public async Task<MigrationRetrieveResponse> Retrieve(
        string migrationID,
        MigrationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Retrieve(
            parameters with
            {
                MigrationID = migrationID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<MigrationListPage> List(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<MigrationListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return new MigrationListPage(this, parameters, page);
    }

    /// <inheritdoc/>
    public async Task<MigrationListPage> List(
        string planID,
        MigrationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.List(parameters with { PlanID = planID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<MigrationCancelResponse> Cancel(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<MigrationCancelResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<MigrationCancelResponse> Cancel(
        string migrationID,
        MigrationCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Cancel(parameters with { MigrationID = migrationID }, cancellationToken);
    }
}
