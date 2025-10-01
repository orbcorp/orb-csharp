using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Events.Backfills;

namespace Orb.Services.Events.Backfills;

public sealed class BackfillService : IBackfillService
{
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
        return await response.Deserialize<BackfillCreateResponse>().ConfigureAwait(false);
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
        return await response.Deserialize<BackfillListPageResponse>().ConfigureAwait(false);
    }

    public async Task<BackfillCloseResponse> Close(BackfillCloseParams parameters)
    {
        HttpRequest<BackfillCloseParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<BackfillCloseResponse>().ConfigureAwait(false);
    }

    public async Task<BackfillFetchResponse> Fetch(BackfillFetchParams parameters)
    {
        HttpRequest<BackfillFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<BackfillFetchResponse>().ConfigureAwait(false);
    }

    public async Task<BackfillRevertResponse> Revert(BackfillRevertParams parameters)
    {
        HttpRequest<BackfillRevertParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<BackfillRevertResponse>().ConfigureAwait(false);
    }
}
