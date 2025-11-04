using System;
using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.TopLevel;

namespace Orb.Services.TopLevel;

public sealed class TopLevelService : ITopLevelService
{
    public ITopLevelService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TopLevelService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public TopLevelService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<TopLevelPingResponse> Ping(TopLevelPingParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<TopLevelPingParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<TopLevelPingResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
