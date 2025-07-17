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
}
