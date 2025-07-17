using Beta = Orb.Models.Beta;
using ExternalPlanID = Orb.Models.Beta.ExternalPlanID;
using Plans = Orb.Models.Plans;
using Tasks = System.Threading.Tasks;

namespace Orb.Service.Beta.ExternalPlanID;

public interface IExternalPlanIDService
{
    /// <summary>
    /// This API endpoint is in beta and its interface may change. It is recommended
    /// for use only in test mode.
    ///
    /// This endpoint allows the creation of a new plan version for an existing plan.
    /// </summary>
    Tasks::Task<Beta::PlanVersion> CreatePlanVersion(
        ExternalPlanID::ExternalPlanIDCreatePlanVersionParams @params
    );

    /// <summary>
    /// This API endpoint is in beta and its interface may change. It is recommended
    /// for use only in test mode.
    ///
    /// This endpoint is used to fetch a plan version. It returns the phases, prices,
    /// and adjustments present on this version of the plan.
    /// </summary>
    Tasks::Task<Beta::PlanVersion> FetchPlanVersion(
        ExternalPlanID::ExternalPlanIDFetchPlanVersionParams @params
    );

    /// <summary>
    /// This API endpoint is in beta and its interface may change. It is recommended
    /// for use only in test mode.
    ///
    /// This endpoint allows setting the default version of a plan.
    /// </summary>
    Tasks::Task<Plans::Plan> SetDefaultPlanVersion(
        ExternalPlanID::ExternalPlanIDSetDefaultPlanVersionParams @params
    );
}
