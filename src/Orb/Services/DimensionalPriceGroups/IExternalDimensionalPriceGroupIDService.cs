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
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IExternalDimensionalPriceGroupIDServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
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

    /// <inheritdoc cref="Retrieve(ExternalDimensionalPriceGroupIDRetrieveParams, CancellationToken)"/>
    Task<DimensionalPriceGroup> Retrieve(
        string externalDimensionalPriceGroupID,
        ExternalDimensionalPriceGroupIDRetrieveParams? parameters = null,
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

    /// <inheritdoc cref="Update(ExternalDimensionalPriceGroupIDUpdateParams, CancellationToken)"/>
    Task<DimensionalPriceGroup> Update(
        string externalDimensionalPriceGroupID,
        ExternalDimensionalPriceGroupIDUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IExternalDimensionalPriceGroupIDService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IExternalDimensionalPriceGroupIDServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExternalDimensionalPriceGroupIDServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /dimensional_price_groups/external_dimensional_price_group_id/{external_dimensional_price_group_id}`, but is otherwise the
    /// same as <see cref="IExternalDimensionalPriceGroupIDService.Retrieve(ExternalDimensionalPriceGroupIDRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DimensionalPriceGroup>> Retrieve(
        ExternalDimensionalPriceGroupIDRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ExternalDimensionalPriceGroupIDRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<DimensionalPriceGroup>> Retrieve(
        string externalDimensionalPriceGroupID,
        ExternalDimensionalPriceGroupIDRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /dimensional_price_groups/external_dimensional_price_group_id/{external_dimensional_price_group_id}`, but is otherwise the
    /// same as <see cref="IExternalDimensionalPriceGroupIDService.Update(ExternalDimensionalPriceGroupIDUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DimensionalPriceGroup>> Update(
        ExternalDimensionalPriceGroupIDUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ExternalDimensionalPriceGroupIDUpdateParams, CancellationToken)"/>
    Task<HttpResponse<DimensionalPriceGroup>> Update(
        string externalDimensionalPriceGroupID,
        ExternalDimensionalPriceGroupIDUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
