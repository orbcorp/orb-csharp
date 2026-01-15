using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Events.Volume;

namespace Orb.Services.Events;

/// <inheritdoc/>
public sealed class VolumeService : IVolumeService
{
    readonly Lazy<IVolumeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IVolumeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public IVolumeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VolumeService(this._client.WithOptions(modifier));
    }

    public VolumeService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() => new VolumeServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<EventVolumes> List(
        VolumeListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class VolumeServiceWithRawResponse : IVolumeServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public IVolumeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VolumeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public VolumeServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EventVolumes>> List(
        VolumeListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<VolumeListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var eventVolumes = await response
                    .Deserialize<EventVolumes>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    eventVolumes.Validate();
                }
                return eventVolumes;
            }
        );
    }
}
