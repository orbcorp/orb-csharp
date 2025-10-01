using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Events.Volume;

namespace Orb.Services.Events.Volume;

public sealed class VolumeService : IVolumeService
{
    readonly IOrbClient _client;

    public VolumeService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<EventVolumes> List(VolumeListParams parameters)
    {
        HttpRequest<VolumeListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<EventVolumes>().ConfigureAwait(false);
    }
}
