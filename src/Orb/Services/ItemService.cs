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
    readonly Lazy<IItemServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IItemServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public IItemService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ItemService(this._client.WithOptions(modifier));
    }

    public ItemService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ItemServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Item> Create(
        ItemCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Item> Update(
        ItemUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Item> Update(
        string itemID,
        ItemUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ItemID = itemID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ItemListPage> List(
        ItemListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Item> Archive(
        ItemArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Item> Archive(
        string itemID,
        ItemArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { ItemID = itemID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Item> Fetch(
        ItemFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Fetch(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Item> Fetch(
        string itemID,
        ItemFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Fetch(parameters with { ItemID = itemID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ItemServiceWithRawResponse : IItemServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public IItemServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ItemServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ItemServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Item>> Create(
        ItemCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ItemCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var item = await response.Deserialize<Item>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    item.Validate();
                }
                return item;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Item>> Update(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var item = await response.Deserialize<Item>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    item.Validate();
                }
                return item;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Item>> Update(
        string itemID,
        ItemUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ItemID = itemID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ItemListPage>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<ItemListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ItemListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Item>> Archive(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var item = await response.Deserialize<Item>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    item.Validate();
                }
                return item;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Item>> Archive(
        string itemID,
        ItemArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { ItemID = itemID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Item>> Fetch(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var item = await response.Deserialize<Item>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    item.Validate();
                }
                return item;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Item>> Fetch(
        string itemID,
        ItemFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Fetch(parameters with { ItemID = itemID }, cancellationToken);
    }
}
