using ExternalPriceID = Orb.Models.Prices.ExternalPriceID;
using Models = Orb.Models;
using Tasks = System.Threading.Tasks;

namespace Orb.Service.Prices.ExternalPriceID;

public interface IExternalPriceIDService
{
    /// <summary>
    /// This endpoint allows you to update the `metadata` property on a price. If you
    /// pass null for the metadata value, it will clear any existing metadata for that price.
    /// </summary>
    Tasks::Task<Models::Price> Update(ExternalPriceID::ExternalPriceIDUpdateParams @params);

    /// <summary>
    /// This endpoint returns a price given an external price id. See the [price creation
    /// API](/api-reference/price/create-price) for more information about external
    /// price aliases.
    /// </summary>
    Tasks::Task<Models::Price> Fetch(ExternalPriceID::ExternalPriceIDFetchParams @params);
}
