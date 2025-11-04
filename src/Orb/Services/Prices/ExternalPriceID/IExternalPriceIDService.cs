using System;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models;
using Orb.Models.Prices.ExternalPriceID;

namespace Orb.Services.Prices.ExternalPriceID;

public interface IExternalPriceIDService
{
    IExternalPriceIDService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint allows you to update the `metadata` property on a price. If
    /// you pass null for the metadata value, it will clear any existing metadata
    /// for that price.
    /// </summary>
    Task<Price> Update(ExternalPriceIDUpdateParams parameters);

    /// <summary>
    /// This endpoint returns a price given an external price id. See the [price
    /// creation API](/api-reference/price/create-price) for more information about
    /// external price aliases.
    /// </summary>
    Task<Price> Fetch(ExternalPriceIDFetchParams parameters);
}
