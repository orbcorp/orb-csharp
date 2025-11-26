using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.TopLevel;

namespace Orb.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITopLevelService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITopLevelService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint allows you to test your connection to the Orb API and check
    /// the validity of your API key, passed in the Authorization header. This is
    /// particularly useful for checking that your environment is set up properly,
    /// and is a great choice for connectors and integrations.
    ///
    /// <para>This API does not have any side-effects or return any Orb resources.</para>
    /// </summary>
    Task<TopLevelPingResponse> Ping(
        TopLevelPingParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
