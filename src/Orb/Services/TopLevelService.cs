using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.TopLevel;

namespace Orb.Services;

/// <inheritdoc />
public sealed class TopLevelService : ITopLevelService
{
    /// <inheritdoc/>
    public ITopLevelService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TopLevelService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public TopLevelService(IOrbClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<TopLevelPingResponse> Ping(
        TopLevelPingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TopLevelPingParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<TopLevelPingResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
