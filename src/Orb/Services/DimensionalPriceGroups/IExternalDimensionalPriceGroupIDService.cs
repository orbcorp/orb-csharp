using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.DimensionalPriceGroups;
using Orb.Models.DimensionalPriceGroups.ExternalDimensionalPriceGroupID;

namespace Orb.Services.DimensionalPriceGroups;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IExternalDimensionalPriceGroupIDService
{
    IExternalDimensionalPriceGroupIDService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Fetch dimensional price group by external ID
    /// </summary>
    Task<DimensionalPriceGroup> Retrieve(
        ExternalDimensionalPriceGroupIDRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint can be used to update the `external_dimensional_price_group_id`
    /// and `metadata` of an existing dimensional price group. Other fields on a dimensional
    /// price group are currently immutable.
    /// </summary>
    Task<DimensionalPriceGroup> Update(
        ExternalDimensionalPriceGroupIDUpdateParams parameters,
        CancellationToken cancellationToken = default
    );
}
