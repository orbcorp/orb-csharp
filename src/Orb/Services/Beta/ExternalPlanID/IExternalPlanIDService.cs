using System;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Beta.ExternalPlanID;
using Beta = Orb.Models.Beta;
using Plans = Orb.Models.Plans;

namespace Orb.Services.Beta.ExternalPlanID;

public interface IExternalPlanIDService
{
    IExternalPlanIDService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint allows the creation of a new plan version for an existing plan.
    /// </summary>
    Task<Beta::PlanVersion> CreatePlanVersion(ExternalPlanIDCreatePlanVersionParams parameters);

    /// <summary>
    /// This endpoint is used to fetch a plan version. It returns the phases, prices,
    /// and adjustments present on this version of the plan.
    /// </summary>
    Task<Beta::PlanVersion> FetchPlanVersion(ExternalPlanIDFetchPlanVersionParams parameters);

    /// <summary>
    /// This endpoint allows setting the default version of a plan.
    /// </summary>
    Task<Plans::Plan> SetDefaultPlanVersion(ExternalPlanIDSetDefaultPlanVersionParams parameters);
}
