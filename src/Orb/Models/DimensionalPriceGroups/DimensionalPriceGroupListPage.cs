using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Services;

namespace Orb.Models.DimensionalPriceGroups;

public sealed class DimensionalPriceGroupListPage(
    IDimensionalPriceGroupServiceWithRawResponse service,
    DimensionalPriceGroupListParams parameters,
    DimensionalPriceGroupDimensionalPriceGroups response
) : IPage<DimensionalPriceGroup>
{
    /// <inheritdoc/>
    public IReadOnlyList<DimensionalPriceGroup> Items
    {
        get { return response.Data; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        try
        {
            return this.Items.Count > 0 && response.PaginationMetadata.NextCursor != null;
        }
        catch (OrbInvalidDataException)
        {
            // If accessing the response data to determine if there's a next page failed, then just
            // assume there's no next page.
            return false;
        }
    }

    /// <inheritdoc/>
    async Task<IPage<DimensionalPriceGroup>> IPage<DimensionalPriceGroup>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<DimensionalPriceGroupListPage> Next(
        CancellationToken cancellationToken = default
    )
    {
        var nextCursor =
            response.PaginationMetadata.NextCursor
            ?? throw new InvalidOperationException("Cannot request next page");
        using var nextResponse = await service
            .List(parameters with { Cursor = nextCursor }, cancellationToken)
            .ConfigureAwait(false);
        return await nextResponse.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }
}
