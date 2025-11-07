using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.TopLevel;

namespace Orb.Services.TopLevel;

public interface ITopLevelService
{
    ITopLevelService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint allows you to test your connection to the Orb API and check
    /// the validity of your API key, passed in the Authorization header. This is
    /// particularly useful for checking that your environment is set up properly,
    /// and is a great choice for connectors and integrations.
    ///
    /// This API does not have any side-effects or return any Orb resources.
    /// </summary>
    Task<TopLevelPingResponse> Ping(
        TopLevelPingParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
