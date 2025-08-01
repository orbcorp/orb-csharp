using System.Threading.Tasks;
using Orb.Models.DimensionalPriceGroups;
using Orb.Models.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;

namespace Orb.Services.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;

public interface IExternalDimensionalPriceGroupIDService
{
    /// <summary>
    /// Fetch dimensional price group by external ID
    /// </summary>
    Task<DimensionalPriceGroup> Retrieve(ExternalDimensionalPriceGroupIDRetrieveParams @params);

    /// <summary>
    /// This endpoint can be used to update the `external_dimensional_price_group_id`
    /// and `metadata` of an existing dimensional price group. Other fields on a
    /// dimensional price group are currently immutable.
    /// </summary>
    Task<DimensionalPriceGroup> Update(ExternalDimensionalPriceGroupIDUpdateParams @params);
}
