using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Services;

namespace Orb.Models.Subscriptions;

/// <summary>
/// A single page from the paginated endpoint that <see cref="ISubscriptionService.FetchSchedule(SubscriptionFetchScheduleParams, CancellationToken)"/> queries.
/// </summary>
public sealed class SubscriptionFetchSchedulePage(
    ISubscriptionServiceWithRawResponse service,
    SubscriptionFetchScheduleParams parameters,
    SubscriptionFetchSchedulePageResponse response
) : IPage<SubscriptionFetchScheduleResponse>
{
    /// <inheritdoc/>
    public IReadOnlyList<SubscriptionFetchScheduleResponse> Items
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
    async Task<
        IPage<SubscriptionFetchScheduleResponse>
    > IPage<SubscriptionFetchScheduleResponse>.Next(CancellationToken cancellationToken) =>
        await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<SubscriptionFetchSchedulePage> Next(
        CancellationToken cancellationToken = default
    )
    {
        var nextCursor =
            response.PaginationMetadata.NextCursor
            ?? throw new InvalidOperationException("Cannot request next page");
        using var nextResponse = await service
            .FetchSchedule(parameters with { Cursor = nextCursor }, cancellationToken)
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

    public override bool Equals(object? obj)
    {
        if (obj is not SubscriptionFetchSchedulePage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
