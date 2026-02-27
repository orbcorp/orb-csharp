using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models;
using Orb.Models.Prices.ExternalPriceID;

namespace Orb.Services.Prices;

/// <summary>
/// The Price resource represents a price that can be billed on a subscription, resulting
/// in a charge on an invoice in the form of an invoice line item. Prices take a quantity
/// and determine an amount to bill.
///
/// <para>Orb supports a few different pricing models out of the box. Each of these
/// models is serialized differently in a given Price object. The model_type field
/// determines the key for the configuration object that is present.</para>
///
/// <para>For more on the types of prices, see [the core concepts documentation](/core-concepts#plan-and-price)</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IExternalPriceIDService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IExternalPriceIDServiceWithRawResponse WithRawResponse { get; }

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

/// <summary>
/// A view of <see cref="IExternalPriceIDService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IExternalPriceIDServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExternalPriceIDServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `put /prices/external_price_id/{external_price_id}`, but is otherwise the
    /// same as <see cref="IExternalPriceIDService.Update(ExternalPriceIDUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Price>> Update(
        ExternalPriceIDUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ExternalPriceIDUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Price>> Update(
        string externalPriceID,
        ExternalPriceIDUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /prices/external_price_id/{external_price_id}`, but is otherwise the
    /// same as <see cref="IExternalPriceIDService.Fetch(ExternalPriceIDFetchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Price>> Fetch(
        ExternalPriceIDFetchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Fetch(ExternalPriceIDFetchParams, CancellationToken)"/>
    Task<HttpResponse<Price>> Fetch(
        string externalPriceID,
        ExternalPriceIDFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
