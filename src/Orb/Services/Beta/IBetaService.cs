using System.Threading.Tasks;
using Orb.Models.Beta;
using Orb.Models.Plans;
using Orb.Services.Beta.ExternalPlanID;

namespace Orb.Services.Beta;

public interface IBetaService
{
    IExternalPlanIDService ExternalPlanID { get; }

    /// <summary>
    /// This endpoint allows the creation of a new plan version for an existing plan.
    /// </summary>
    Task<PlanVersion> CreatePlanVersion(BetaCreatePlanVersionParams parameters);

    /// <summary>
    /// This endpoint is used to fetch a plan version. It returns the phases, prices,
    /// and adjustments present on this version of the plan.
    /// </summary>
    Task<PlanVersion> FetchPlanVersion(BetaFetchPlanVersionParams parameters);

    /// <summary>
    /// This endpoint allows setting the default version of a plan.
    /// </summary>
    Task<Plan> SetDefaultPlanVersion(BetaSetDefaultPlanVersionParams parameters);
}
