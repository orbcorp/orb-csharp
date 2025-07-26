using DimensionalPriceGroups = Orb.Models.DimensionalPriceGroups;
using ExternalDimensionalPriceGroupID = Orb.Models.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;
using Tasks = System.Threading.Tasks;

namespace Orb.Service.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;

public interface IExternalDimensionalPriceGroupIDService
{
    /// <summary>
    /// Fetch dimensional price group by external ID
    /// </summary>
    Tasks::Task<DimensionalPriceGroups::DimensionalPriceGroup> Retrieve(
        ExternalDimensionalPriceGroupID::ExternalDimensionalPriceGroupIDRetrieveParams @params
    );

    /// <summary>
    /// This endpoint can be used to update the `external_dimensional_price_group_id`
    /// and `metadata` of an existing dimensional price group. Other fields on a dimensional
    /// price group are currently immutable.
    /// </summary>
    Tasks::Task<DimensionalPriceGroups::DimensionalPriceGroup> Update(
        ExternalDimensionalPriceGroupID::ExternalDimensionalPriceGroupIDUpdateParams @params
    );
}
