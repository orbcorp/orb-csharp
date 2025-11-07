using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Events.Volume;

namespace Orb.Services.Events.Volume;

public sealed class VolumeService : IVolumeService
{
    public IVolumeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new VolumeService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public VolumeService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<EventVolumes> List(
        VolumeListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<VolumeListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var eventVolumes = await response
            .Deserialize<EventVolumes>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            eventVolumes.Validate();
        }
        return eventVolumes;
    }
}
