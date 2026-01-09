using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.DimensionalPriceGroups;
using Orb.Services.DimensionalPriceGroups;

namespace Orb.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDimensionalPriceGroupService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDimensionalPriceGroupServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDimensionalPriceGroupService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IExternalDimensionalPriceGroupIDService ExternalDimensionalPriceGroupID { get; }

    /// <summary>
    /// A dimensional price group is used to partition the result of a billable metric
    /// by a set of dimensions. Prices in a price group must specify the partition
    /// used to derive their usage.
    ///
    /// <para>For example, suppose we have a billable metric that measures the number
    /// of widgets used and we want to charge differently depending on the color of
    /// the widget. We can create a price group with a dimension "color" and two
    /// prices: one that charges \$10 per red widget and one that charges \$20 per
    /// blue widget.</para>
    /// </summary>
    Task<DimensionalPriceGroup> Create(
        DimensionalPriceGroupCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fetch dimensional price group
    /// </summary>
    Task<DimensionalPriceGroup> Retrieve(
        DimensionalPriceGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DimensionalPriceGroupRetrieveParams, CancellationToken)"/>
    Task<DimensionalPriceGroup> Retrieve(
        string dimensionalPriceGroupID,
        DimensionalPriceGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint can be used to update the `external_dimensional_price_group_id`
    /// and `metadata` of an existing dimensional price group. Other fields on a dimensional
    /// price group are currently immutable.
    /// </summary>
    Task<DimensionalPriceGroup> Update(
        DimensionalPriceGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(DimensionalPriceGroupUpdateParams, CancellationToken)"/>
    Task<DimensionalPriceGroup> Update(
        string dimensionalPriceGroupID,
        DimensionalPriceGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List dimensional price groups
    /// </summary>
    Task<DimensionalPriceGroupListPage> List(
        DimensionalPriceGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDimensionalPriceGroupService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDimensionalPriceGroupServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDimensionalPriceGroupServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    IExternalDimensionalPriceGroupIDServiceWithRawResponse ExternalDimensionalPriceGroupID { get; }

    /// <summary>
    /// Returns a raw HTTP response for `post /dimensional_price_groups`, but is otherwise the
    /// same as <see cref="IDimensionalPriceGroupService.Create(DimensionalPriceGroupCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DimensionalPriceGroup>> Create(
        DimensionalPriceGroupCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /dimensional_price_groups/{dimensional_price_group_id}`, but is otherwise the
    /// same as <see cref="IDimensionalPriceGroupService.Retrieve(DimensionalPriceGroupRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DimensionalPriceGroup>> Retrieve(
        DimensionalPriceGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DimensionalPriceGroupRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<DimensionalPriceGroup>> Retrieve(
        string dimensionalPriceGroupID,
        DimensionalPriceGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /dimensional_price_groups/{dimensional_price_group_id}`, but is otherwise the
    /// same as <see cref="IDimensionalPriceGroupService.Update(DimensionalPriceGroupUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DimensionalPriceGroup>> Update(
        DimensionalPriceGroupUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(DimensionalPriceGroupUpdateParams, CancellationToken)"/>
    Task<HttpResponse<DimensionalPriceGroup>> Update(
        string dimensionalPriceGroupID,
        DimensionalPriceGroupUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /dimensional_price_groups`, but is otherwise the
    /// same as <see cref="IDimensionalPriceGroupService.List(DimensionalPriceGroupListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DimensionalPriceGroupListPage>> List(
        DimensionalPriceGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
