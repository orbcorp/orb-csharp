using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Services.Coupons;
using Subscriptions = Orb.Models.Subscriptions;

namespace Orb.Models.Coupons.Subscriptions;

public sealed class SubscriptionListPage(
    ISubscriptionService service,
    SubscriptionListParams parameters,
    Subscriptions::SubscriptionSubscriptions response
) : IPage<Subscriptions::Subscription>
{
    /// <inheritdoc/>
    public IReadOnlyList<Subscriptions::Subscription> Items
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
    async Task<IPage<Subscriptions::Subscription>> IPage<Subscriptions::Subscription>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<SubscriptionListPage> Next(CancellationToken cancellationToken = default)
    {
        var nextCursor =
            response.PaginationMetadata.NextCursor
            ?? throw new InvalidOperationException("Cannot request next page");
        return await service
            .List(parameters with { Cursor = nextCursor }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }
}
