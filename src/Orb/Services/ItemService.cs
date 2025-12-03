using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Items;

namespace Orb.Services;

/// <inheritdoc/>
public sealed class ItemService : IItemService
{
    /// <inheritdoc/>
    public IItemService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ItemService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public ItemService(IOrbClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<Item> Create(
        ItemCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ItemCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var item = await response.Deserialize<Item>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            item.Validate();
        }
        return item;
    }

    /// <inheritdoc/>
    public async Task<Item> Update(
        ItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ItemID == null)
        {
            throw new OrbInvalidDataException("'parameters.ItemID' cannot be null");
        }

        HttpRequest<ItemUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var item = await response.Deserialize<Item>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            item.Validate();
        }
        return item;
    }

    /// <inheritdoc/>
    public async Task<Item> Update(
        string itemID,
        ItemUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Update(parameters with { ItemID = itemID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ItemListPageResponse> List(
        ItemListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ItemListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<ItemListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    /// <inheritdoc/>
    public async Task<Item> Archive(
        ItemArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ItemID == null)
        {
            throw new OrbInvalidDataException("'parameters.ItemID' cannot be null");
        }

        HttpRequest<ItemArchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var item = await response.Deserialize<Item>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            item.Validate();
        }
        return item;
    }

    /// <inheritdoc/>
    public async Task<Item> Archive(
        string itemID,
        ItemArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Archive(parameters with { ItemID = itemID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Item> Fetch(
        ItemFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ItemID == null)
        {
            throw new OrbInvalidDataException("'parameters.ItemID' cannot be null");
        }

        HttpRequest<ItemFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var item = await response.Deserialize<Item>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            item.Validate();
        }
        return item;
    }

    /// <inheritdoc/>
    public async Task<Item> Fetch(
        string itemID,
        ItemFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Fetch(parameters with { ItemID = itemID }, cancellationToken);
    }
}
