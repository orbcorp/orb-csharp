using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Services.Coupons;
using Subscriptions = Orb.Models.Subscriptions;

namespace Orb.Models.Coupons.Subscriptions;

/// <summary>
/// A single page from the paginated endpoint that <see cref="ISubscriptionService.List(SubscriptionListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class SubscriptionListPage(
    ISubscriptionServiceWithRawResponse service,
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

    public override string ToString() =>
        JsonSerializer.Serialize(this.Items, ModelBase.ToStringSerializerOptions);
}
