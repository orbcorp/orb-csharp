using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Plans;
using Orb.Services.Plans;

namespace Orb.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPlanService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPlanService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IExternalPlanIDService ExternalPlanID { get; }

    IMigrationService Migrations { get; }

    /// <summary>
    /// This endpoint allows creation of plans including their prices.
    /// </summary>
    Task<Plan> Create(PlanCreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// This endpoint can be used to update the `external_plan_id`, and `metadata`
    /// of an existing plan.
    ///
    /// <para>Other fields on a plan are currently immutable.</para>
    /// </summary>
    Task<Plan> Update(PlanUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(PlanUpdateParams, CancellationToken)"/>
    Task<Plan> Update(
        string planID,
        PlanUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint returns a list of all [plans](/core-concepts#plan-and-price)
    /// for an account in a list format. The list of plans is ordered starting from
    /// the most recently created plan. The response also includes [`pagination_metadata`](/api-reference/pagination),
    /// which lets the caller retrieve the next page of results if they exist.
    /// </summary>
    Task<PlanListPage> List(
        PlanListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint is used to fetch [plan](/core-concepts#plan-and-price) details
    /// given a plan identifier. It returns information about the prices included
    /// in the plan and their configuration, as well as the product that the plan
    /// is attached to.
    ///
    /// <para>## Serialized prices Orb supports a few different pricing models out
    /// of the box. Each of these models is serialized differently in a given [Price](/core-concepts#plan-and-price)
    /// object. The `model_type` field determines the key for the configuration object
    /// that is present. A detailed explanation of price types can be found in the
    /// [Price schema](/core-concepts#plan-and-price).</para>
    ///
    /// <para>## Phases Orb supports plan phases, also known as contract ramps. For
    /// plans with phases, the serialized prices refer to all prices across all phases.</para>
    /// </summary>
    Task<Plan> Fetch(PlanFetchParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Fetch(PlanFetchParams, CancellationToken)"/>
    Task<Plan> Fetch(
        string planID,
        PlanFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
