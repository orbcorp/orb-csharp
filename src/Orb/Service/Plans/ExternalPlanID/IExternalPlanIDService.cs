using System.Threading.Tasks;
using Orb.Models.Plans;
using Orb.Models.Plans.ExternalPlanID;

namespace Orb.Service.Plans.ExternalPlanID;

public interface IExternalPlanIDService
{
    /// <summary>
    /// This endpoint can be used to update the `external_plan_id`, and `metadata`
    /// of an existing plan.
    ///
    /// Other fields on a plan are currently immutable.
    /// </summary>
    Task<Plan> Update(ExternalPlanIDUpdateParams @params);

    /// <summary>
    /// This endpoint is used to fetch [plan](/core-concepts##plan-and-price) details
    /// given an external_plan_id identifier. It returns information about the prices
    /// included in the plan and their configuration, as well as the product that the
    /// plan is attached to.
    ///
    /// If multiple plans are found to contain the specified external_plan_id, the
    /// active plans will take priority over archived ones, and among those, the endpoint
    /// will return the most recently created plan.
    ///
    /// ## Serialized prices Orb supports a few different pricing models out of the
    /// box. Each of these models is serialized differently in a given [Price](/core-concepts#plan-and-price)
    /// object. The `model_type` field determines the key for the configuration object
    /// that is present. A detailed explanation of price types can be found in the [Price
    /// schema](/core-concepts#plan-and-price). "
    /// </summary>
    Task<Plan> Fetch(ExternalPlanIDFetchParams @params);
}
