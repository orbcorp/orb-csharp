using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models;
using Orb.Models.Prices.ExternalPriceID;

namespace Orb.Services.Prices;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IExternalPriceIDService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExternalPriceIDService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint allows you to update the `metadata` property on a price. If
    /// you pass null for the metadata value, it will clear any existing metadata
    /// for that price.
    /// </summary>
    Task<Price> Update(
        ExternalPriceIDUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ExternalPriceIDUpdateParams, CancellationToken)"/>
    Task<Price> Update(
        string externalPriceID,
        ExternalPriceIDUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint returns a price given an external price id. See the [price creation
    /// API](/api-reference/price/create-price) for more information about external
    /// price aliases.
    /// </summary>
    Task<Price> Fetch(
        ExternalPriceIDFetchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Fetch(ExternalPriceIDFetchParams, CancellationToken)"/>
    Task<Price> Fetch(
        string externalPriceID,
        ExternalPriceIDFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
