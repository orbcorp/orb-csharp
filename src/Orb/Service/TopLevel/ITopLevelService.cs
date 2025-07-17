using Tasks = System.Threading.Tasks;
using TopLevel = Orb.Models.TopLevel;

namespace Orb.Service.TopLevel;

public interface ITopLevelService
{
    /// <summary>
    /// This endpoint allows you to test your connection to the Orb API and check the
    /// validity of your API key, passed in the Authorization header. This is particularly
    /// useful for checking that your environment is set up properly, and is a great
    /// choice for connectors and integrations.
    ///
    /// This API does not have any side-effects or return any Orb resources.
    /// </summary>
    Tasks::Task<TopLevel::TopLevelPingResponse> Ping(TopLevel::TopLevelPingParams @params);
}
