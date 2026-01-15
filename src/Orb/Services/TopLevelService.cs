using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.TopLevel;

namespace Orb.Services;

/// <inheritdoc/>
public sealed class TopLevelService : ITopLevelService
{
    readonly Lazy<ITopLevelServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITopLevelServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public ITopLevelService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TopLevelService(this._client.WithOptions(modifier));
    }

    public TopLevelService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TopLevelServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<TopLevelPingResponse> Ping(
        TopLevelPingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Ping(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class TopLevelServiceWithRawResponse : ITopLevelServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITopLevelServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TopLevelServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TopLevelServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TopLevelPingResponse>> Ping(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<TopLevelPingResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
