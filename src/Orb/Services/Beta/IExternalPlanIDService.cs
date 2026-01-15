using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Beta;
using Orb.Models.Beta.ExternalPlanID;
using Orb.Models.Plans;

namespace Orb.Services.Beta;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IExternalPlanIDService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IExternalPlanIDServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExternalPlanIDService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint allows the creation of a new plan version for an existing plan.
    /// </summary>
    Task<PlanVersion> CreatePlanVersion(
        ExternalPlanIDCreatePlanVersionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreatePlanVersion(ExternalPlanIDCreatePlanVersionParams, CancellationToken)"/>
    Task<PlanVersion> CreatePlanVersion(
        string externalPlanID,
        ExternalPlanIDCreatePlanVersionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint is used to fetch a plan version. It returns the phases, prices,
    /// and adjustments present on this version of the plan.
    /// </summary>
    Task<PlanVersion> FetchPlanVersion(
        ExternalPlanIDFetchPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="FetchPlanVersion(ExternalPlanIDFetchPlanVersionParams, CancellationToken)"/>
    Task<PlanVersion> FetchPlanVersion(
        string version,
        ExternalPlanIDFetchPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint allows setting the default version of a plan.
    /// </summary>
    Task<Plan> SetDefaultPlanVersion(
        ExternalPlanIDSetDefaultPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SetDefaultPlanVersion(ExternalPlanIDSetDefaultPlanVersionParams, CancellationToken)"/>
    Task<Plan> SetDefaultPlanVersion(
        string externalPlanID,
        ExternalPlanIDSetDefaultPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IExternalPlanIDService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IExternalPlanIDServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExternalPlanIDServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /plans/external_plan_id/{external_plan_id}/versions`, but is otherwise the
    /// same as <see cref="IExternalPlanIDService.CreatePlanVersion(ExternalPlanIDCreatePlanVersionParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PlanVersion>> CreatePlanVersion(
        ExternalPlanIDCreatePlanVersionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreatePlanVersion(ExternalPlanIDCreatePlanVersionParams, CancellationToken)"/>
    Task<HttpResponse<PlanVersion>> CreatePlanVersion(
        string externalPlanID,
        ExternalPlanIDCreatePlanVersionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /plans/external_plan_id/{external_plan_id}/versions/{version}`, but is otherwise the
    /// same as <see cref="IExternalPlanIDService.FetchPlanVersion(ExternalPlanIDFetchPlanVersionParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PlanVersion>> FetchPlanVersion(
        ExternalPlanIDFetchPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="FetchPlanVersion(ExternalPlanIDFetchPlanVersionParams, CancellationToken)"/>
    Task<HttpResponse<PlanVersion>> FetchPlanVersion(
        string version,
        ExternalPlanIDFetchPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /plans/external_plan_id/{external_plan_id}/set_default_version`, but is otherwise the
    /// same as <see cref="IExternalPlanIDService.SetDefaultPlanVersion(ExternalPlanIDSetDefaultPlanVersionParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Plan>> SetDefaultPlanVersion(
        ExternalPlanIDSetDefaultPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SetDefaultPlanVersion(ExternalPlanIDSetDefaultPlanVersionParams, CancellationToken)"/>
    Task<HttpResponse<Plan>> SetDefaultPlanVersion(
        string externalPlanID,
        ExternalPlanIDSetDefaultPlanVersionParams parameters,
        CancellationToken cancellationToken = default
    );
}
