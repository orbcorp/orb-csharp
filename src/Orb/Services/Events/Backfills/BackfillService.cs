using System;
using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Events.Backfills;

namespace Orb.Services.Events.Backfills;

public sealed class BackfillService : IBackfillService
{
    public IBackfillService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BackfillService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public BackfillService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<BackfillCreateResponse> Create(BackfillCreateParams parameters)
    {
        HttpRequest<BackfillCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var backfill = await response.Deserialize<BackfillCreateResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            backfill.Validate();
        }
        return backfill;
    }

    public async Task<BackfillListPageResponse> List(BackfillListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<BackfillListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var page = await response.Deserialize<BackfillListPageResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<BackfillCloseResponse> Close(BackfillCloseParams parameters)
    {
        HttpRequest<BackfillCloseParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<BackfillCloseResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<BackfillFetchResponse> Fetch(BackfillFetchParams parameters)
    {
        HttpRequest<BackfillFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<BackfillFetchResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<BackfillRevertResponse> Revert(BackfillRevertParams parameters)
    {
        HttpRequest<BackfillRevertParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<BackfillRevertResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
