using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Items;

namespace Orb.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IItemService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IItemServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IItemService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint is used to create an [Item](/core-concepts#item).
    /// </summary>
    Task<Item> Create(ItemCreateParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// This endpoint can be used to update properties on the Item.
    /// </summary>
    Task<Item> Update(ItemUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(ItemUpdateParams, CancellationToken)"/>
    Task<Item> Update(
        string itemID,
        ItemUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint returns a list of all Items, ordered in descending order by
    /// creation time.
    /// </summary>
    Task<ItemListPage> List(
        ItemListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive item
    /// </summary>
    Task<Item> Archive(ItemArchiveParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Archive(ItemArchiveParams, CancellationToken)"/>
    Task<Item> Archive(
        string itemID,
        ItemArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint returns an item identified by its item_id.
    /// </summary>
    Task<Item> Fetch(ItemFetchParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Fetch(ItemFetchParams, CancellationToken)"/>
    Task<Item> Fetch(
        string itemID,
        ItemFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IItemService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IItemServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IItemServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /items`, but is otherwise the
    /// same as <see cref="IItemService.Create(ItemCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Item>> Create(
        ItemCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /items/{item_id}`, but is otherwise the
    /// same as <see cref="IItemService.Update(ItemUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Item>> Update(
        ItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ItemUpdateParams, CancellationToken)"/>
    Task<HttpResponse<Item>> Update(
        string itemID,
        ItemUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /items`, but is otherwise the
    /// same as <see cref="IItemService.List(ItemListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ItemListPage>> List(
        ItemListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /items/{item_id}/archive`, but is otherwise the
    /// same as <see cref="IItemService.Archive(ItemArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Item>> Archive(
        ItemArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(ItemArchiveParams, CancellationToken)"/>
    Task<HttpResponse<Item>> Archive(
        string itemID,
        ItemArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /items/{item_id}`, but is otherwise the
    /// same as <see cref="IItemService.Fetch(ItemFetchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Item>> Fetch(
        ItemFetchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Fetch(ItemFetchParams, CancellationToken)"/>
    Task<HttpResponse<Item>> Fetch(
        string itemID,
        ItemFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
