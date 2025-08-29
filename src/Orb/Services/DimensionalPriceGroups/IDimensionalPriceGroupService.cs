using System.Threading.Tasks;
using Orb.Models.DimensionalPriceGroups;
using Orb.Services.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;

namespace Orb.Services.DimensionalPriceGroups;

public interface IDimensionalPriceGroupService
{
    IExternalDimensionalPriceGroupIDService ExternalDimensionalPriceGroupID { get; }

    /// <summary>
    /// A dimensional price group is used to partition the result of a billable metric
    /// by a set of dimensions. Prices in a price group must specify the parition
    /// used to derive their usage.
    ///
    /// For example, suppose we have a billable metric that measures the number of
    /// widgets used and we want to charge differently depending on the color of the
    /// widget. We can create a price group with a dimension "color" and two prices:
    /// one that charges \$10 per red widget and one that charges \$20 per blue widget.
    /// </summary>
    Task<DimensionalPriceGroup> Create(DimensionalPriceGroupCreateParams parameters);

    /// <summary>
    /// Fetch dimensional price group
    /// </summary>
    Task<DimensionalPriceGroup> Retrieve(DimensionalPriceGroupRetrieveParams parameters);

    /// <summary>
    /// This endpoint can be used to update the `external_dimensional_price_group_id`
    /// and `metadata` of an existing dimensional price group. Other fields on a
    /// dimensional price group are currently immutable.
    /// </summary>
    Task<DimensionalPriceGroup> Update(DimensionalPriceGroupUpdateParams parameters);

    /// <summary>
    /// List dimensional price groups
    /// </summary>
    Task<DimensionalPriceGroupsModel> List(DimensionalPriceGroupListParams? parameters = null);
}
