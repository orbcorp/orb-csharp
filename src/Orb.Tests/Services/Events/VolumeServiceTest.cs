using System;
using System.Threading.Tasks;

namespace Orb.Tests.Services.Events;

public class VolumeServiceTest : TestBase
{
    [Fact]
    public async Task List_Works()
    {
        var eventVolumes = await this.client.Events.Volume.List(
            new() { TimeframeStart = DateTime.Parse("2019-12-27T18:11:19.117Z") }
        );
        eventVolumes.Validate();
    }
}
