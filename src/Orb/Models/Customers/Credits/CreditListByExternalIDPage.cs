using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Services.Customers;

namespace Orb.Models.Customers.Credits;

public sealed class CreditListByExternalIDPage(
    ICreditService service,
    CreditListByExternalIDParams parameters,
    CreditListByExternalIDPageResponse response
) : IPage<CreditListByExternalIDResponse>
{
    /// <inheritdoc/>
    public IReadOnlyList<CreditListByExternalIDResponse> Items
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
    async Task<IPage<CreditListByExternalIDResponse>> IPage<CreditListByExternalIDResponse>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<CreditListByExternalIDPage> Next(
        CancellationToken cancellationToken = default
    )
    {
        var nextCursor =
            response.PaginationMetadata.NextCursor
            ?? throw new InvalidOperationException("Cannot request next page");
        return await service
            .ListByExternalID(parameters with { Cursor = nextCursor }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }
}
