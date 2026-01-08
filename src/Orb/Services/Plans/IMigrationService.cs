using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Plans.Migrations;

namespace Orb.Services.Plans;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMigrationService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMigrationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Fetch migration
    /// </summary>
    Task<MigrationRetrieveResponse> Retrieve(
        MigrationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(MigrationRetrieveParams, CancellationToken)"/>
    Task<MigrationRetrieveResponse> Retrieve(
        string migrationID,
        MigrationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint returns a list of all migrations for a plan. The list of migrations
    /// is ordered starting from the most recently created migration. The response
    /// also includes pagination_metadata, which lets the caller retrieve the next
    /// page of results if they exist.
    /// </summary>
    Task<MigrationListPage> List(
        MigrationListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(MigrationListParams, CancellationToken)"/>
    Task<MigrationListPage> List(
        string planID,
        MigrationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint cancels a migration.
    /// </summary>
    Task<MigrationCancelResponse> Cancel(
        MigrationCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(MigrationCancelParams, CancellationToken)"/>
    Task<MigrationCancelResponse> Cancel(
        string migrationID,
        MigrationCancelParams parameters,
        CancellationToken cancellationToken = default
    );
}
