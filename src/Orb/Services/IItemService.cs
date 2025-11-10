using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Items;

namespace Orb.Services;

public interface IItemService
{
    IItemService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint is used to create an [Item](/core-concepts#item).
    /// </summary>
    Task<Item> Create(ItemCreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// This endpoint can be used to update properties on the Item.
    /// </summary>
    Task<Item> Update(ItemUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// This endpoint returns a list of all Items, ordered in descending order by
    /// creation time.
    /// </summary>
    Task<ItemListPageResponse> List(
        ItemListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive item
    /// </summary>
    Task<Item> Archive(ItemArchiveParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// This endpoint returns an item identified by its item_id.
    /// </summary>
    Task<Item> Fetch(ItemFetchParams parameters, CancellationToken cancellationToken = default);
}
