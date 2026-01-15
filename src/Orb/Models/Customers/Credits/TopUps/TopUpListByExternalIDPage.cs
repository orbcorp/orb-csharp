using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Services.Customers.Credits;

namespace Orb.Models.Customers.Credits.TopUps;

/// <summary>
/// A single page from the paginated endpoint that <see cref="ITopUpService.ListByExternalID(TopUpListByExternalIDParams, CancellationToken)"/> queries.
/// </summary>
public sealed class TopUpListByExternalIDPage(
    ITopUpServiceWithRawResponse service,
    TopUpListByExternalIDParams parameters,
    TopUpListByExternalIDPageResponse response
) : IPage<TopUpListByExternalIDResponse>
{
    /// <inheritdoc/>
    public IReadOnlyList<TopUpListByExternalIDResponse> Items
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
    async Task<IPage<TopUpListByExternalIDResponse>> IPage<TopUpListByExternalIDResponse>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<TopUpListByExternalIDPage> Next(CancellationToken cancellationToken = default)
    {
        var nextCursor =
            response.PaginationMetadata.NextCursor
            ?? throw new InvalidOperationException("Cannot request next page");
        using var nextResponse = await service
            .ListByExternalID(parameters with { Cursor = nextCursor }, cancellationToken)
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
