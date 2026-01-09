using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Beta;
using Orb.Models.Plans;
using Orb.Services.Beta;

namespace Orb.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBetaService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBetaServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBetaService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IExternalPlanIDService ExternalPlanID { get; }

    /// <summary>
    /// This endpoint allows the creation of a new plan version for an existing plan.
    /// </summary>
    Task<PlanVersion> CreatePlanVersion(
        BetaCreatePlanVersionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreatePlanVersion(BetaCreatePlanVersionParams, CancellationToken)"/>
    Task<PlanVersion> CreatePlanVersion(
        string planID,
        BetaCreatePlanVersionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint is used to fetch a plan version. It returns the phases, prices,
    /// and adjustments present on this version of the plan.
    /// </summary>
    Task<PlanVersion> FetchPlanVersion(
        BetaFetchPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="FetchPlanVersion(BetaFetchPlanVersionParams, CancellationToken)"/>
    Task<PlanVersion> FetchPlanVersion(
        string version,
        BetaFetchPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint allows setting the default version of a plan.
    /// </summary>
    Task<Plan> SetDefaultPlanVersion(
        BetaSetDefaultPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SetDefaultPlanVersion(BetaSetDefaultPlanVersionParams, CancellationToken)"/>
    Task<Plan> SetDefaultPlanVersion(
        string planID,
        BetaSetDefaultPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBetaService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBetaServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBetaServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IExternalPlanIDServiceWithRawResponse ExternalPlanID { get; }

    /// <summary>
    /// Returns a raw HTTP response for `post /plans/{plan_id}/versions`, but is otherwise the
    /// same as <see cref="IBetaService.CreatePlanVersion(BetaCreatePlanVersionParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PlanVersion>> CreatePlanVersion(
        BetaCreatePlanVersionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreatePlanVersion(BetaCreatePlanVersionParams, CancellationToken)"/>
    Task<HttpResponse<PlanVersion>> CreatePlanVersion(
        string planID,
        BetaCreatePlanVersionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /plans/{plan_id}/versions/{version}`, but is otherwise the
    /// same as <see cref="IBetaService.FetchPlanVersion(BetaFetchPlanVersionParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PlanVersion>> FetchPlanVersion(
        BetaFetchPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="FetchPlanVersion(BetaFetchPlanVersionParams, CancellationToken)"/>
    Task<HttpResponse<PlanVersion>> FetchPlanVersion(
        string version,
        BetaFetchPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /plans/{plan_id}/set_default_version`, but is otherwise the
    /// same as <see cref="IBetaService.SetDefaultPlanVersion(BetaSetDefaultPlanVersionParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Plan>> SetDefaultPlanVersion(
        BetaSetDefaultPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SetDefaultPlanVersion(BetaSetDefaultPlanVersionParams, CancellationToken)"/>
    Task<HttpResponse<Plan>> SetDefaultPlanVersion(
        string planID,
        BetaSetDefaultPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    );
}
