using System = System;
using Tasks = System.Threading.Tasks;
using Tests = Orb.Tests;
using Volume = Orb.Models.Events.Volume;

namespace Orb.Tests.Service.Events.Volume;

public class VolumeServiceTest : Tests::TestBase
{
    [Fact]
    public async Tasks::Task List_Works()
    {
        var eventVolumes = await this.client.Events.Volume.List(
            new Volume::VolumeListParams()
            {
                TimeframeStart = System::DateTime.Parse("2019-12-27T18:11:19.117Z"),
                Cursor = "cursor",
                Limit = 1,
                TimeframeEnd = System::DateTime.Parse("2024-10-11T06:00:00Z"),
            }
        );
        eventVolumes.Validate();
    }
}
