using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Items;

namespace Orb.Services.Items;

public sealed class ItemService : IItemService
{
    public IItemService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ItemService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public ItemService(IOrbClient client)
    {
        _client = client;
    }

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

    public async Task<Item> Update(
        ItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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

    public async Task<Item> Archive(
        ItemArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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

    public async Task<Item> Fetch(
        ItemFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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
}
