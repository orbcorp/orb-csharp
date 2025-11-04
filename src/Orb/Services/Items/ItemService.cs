using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Items;

namespace Orb.Services.Items;

public sealed class ItemService : IItemService
{
    readonly IOrbClient _client;

    public ItemService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<Item> Create(ItemCreateParams parameters)
    {
        HttpRequest<ItemCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var item = await response.Deserialize<Item>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            item.Validate();
        }
        return item;
    }

    public async Task<Item> Update(ItemUpdateParams parameters)
    {
        HttpRequest<ItemUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var item = await response.Deserialize<Item>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            item.Validate();
        }
        return item;
    }

    public async Task<ItemListPageResponse> List(ItemListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<ItemListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var page = await response.Deserialize<ItemListPageResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<Item> Archive(ItemArchiveParams parameters)
    {
        HttpRequest<ItemArchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var item = await response.Deserialize<Item>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            item.Validate();
        }
        return item;
    }

    public async Task<Item> Fetch(ItemFetchParams parameters)
    {
        HttpRequest<ItemFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var item = await response.Deserialize<Item>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            item.Validate();
        }
        return item;
    }
}
