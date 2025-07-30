using System.Threading.Tasks;
using Orb.Models.Beta;
using Orb.Models.Plans;
using ExternalPlanID = Orb.Service.Beta.ExternalPlanID;

namespace Orb.Service.Beta;

public interface IBetaService
{
    ExternalPlanID::IExternalPlanIDService ExternalPlanID { get; }

    /// <summary>
    /// This API endpoint is in beta and its interface may change. It is recommended
    /// for use only in test mode.
    ///
    /// This endpoint allows the creation of a new plan version for an existing plan.
    /// </summary>
    Task<PlanVersion> CreatePlanVersion(BetaCreatePlanVersionParams @params);

    /// <summary>
    /// This API endpoint is in beta and its interface may change. It is recommended
    /// for use only in test mode.
    ///
    /// This endpoint is used to fetch a plan version. It returns the phases, prices,
    /// and adjustments present on this version of the plan.
    /// </summary>
    Task<PlanVersion> FetchPlanVersion(BetaFetchPlanVersionParams @params);

    /// <summary>
    /// This API endpoint is in beta and its interface may change. It is recommended
    /// for use only in test mode.
    ///
    /// This endpoint allows setting the default version of a plan.
    /// </summary>
    Task<Plan> SetDefaultPlanVersion(BetaSetDefaultPlanVersionParams @params);
}
