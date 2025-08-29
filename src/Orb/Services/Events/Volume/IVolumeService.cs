using System.Threading.Tasks;
using Orb.Models.Events.Volume;

namespace Orb.Services.Events.Volume;

public interface IVolumeService
{
    /// <summary>
    /// This endpoint returns the event volume for an account in a [paginated list format](/api-reference/pagination).
    ///
    /// The event volume is aggregated by the hour and the [timestamp](/api-reference/event/ingest-events)
    /// field is used to determine which hour an event is associated with. Note, this
    /// means that late-arriving events increment the volume count for the hour window
    /// the timestamp is in, not the latest hour window.
    ///
    /// Each item in the response contains the count of events aggregated by the
    /// hour where the start and end time are hour-aligned and in UTC. When a specific
    /// timestamp is passed in for either start or end time, the response includes
    /// the hours the timestamp falls in.
    /// </summary>
    Task<EventVolumes> List(VolumeListParams parameters);
}
