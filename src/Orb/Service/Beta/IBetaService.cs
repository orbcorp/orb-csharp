using Beta = Orb.Models.Beta;
using ExternalPlanID = Orb.Service.Beta.ExternalPlanID;
using Plans = Orb.Models.Plans;
using Tasks = System.Threading.Tasks;

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
    Tasks::Task<Beta::PlanVersion> CreatePlanVersion(Beta::BetaCreatePlanVersionParams @params);

    /// <summary>
    /// This API endpoint is in beta and its interface may change. It is recommended
    /// for use only in test mode.
    ///
    /// This endpoint is used to fetch a plan version. It returns the phases, prices,
    /// and adjustments present on this version of the plan.
    /// </summary>
    Tasks::Task<Beta::PlanVersion> FetchPlanVersion(Beta::BetaFetchPlanVersionParams @params);

    /// <summary>
    /// This API endpoint is in beta and its interface may change. It is recommended
    /// for use only in test mode.
    ///
    /// This endpoint allows setting the default version of a plan.
    /// </summary>
    Tasks::Task<Plans::Plan> SetDefaultPlanVersion(Beta::BetaSetDefaultPlanVersionParams @params);
}
