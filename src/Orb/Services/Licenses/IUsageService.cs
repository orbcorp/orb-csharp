using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Licenses.Usage;

namespace Orb.Services.Licenses;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IUsageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUsageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUsageService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns usage and remaining credits for all licenses of a given type on a
    /// subscription.
    ///
    /// <para>Date range defaults to the current billing period if not specified.</para>
    /// </summary>
    Task<UsageGetAllUsageResponse> GetAllUsage(
        UsageGetAllUsageParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns usage and remaining credits for a specific license over a date range.
    ///
    /// <para>Date range defaults to the current billing period if not specified.</para>
    /// </summary>
    Task<UsageGetUsageResponse> GetUsage(
        UsageGetUsageParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetUsage(UsageGetUsageParams, CancellationToken)"/>
    Task<UsageGetUsageResponse> GetUsage(
        string licenseID,
        UsageGetUsageParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IUsageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUsageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUsageServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /licenses/usage</c>, but is otherwise the
    /// same as <see cref="IUsageService.GetAllUsage(UsageGetAllUsageParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UsageGetAllUsageResponse>> GetAllUsage(
        UsageGetAllUsageParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /licenses/{license_id}/usage</c>, but is otherwise the
    /// same as <see cref="IUsageService.GetUsage(UsageGetUsageParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UsageGetUsageResponse>> GetUsage(
        UsageGetUsageParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetUsage(UsageGetUsageParams, CancellationToken)"/>
    Task<HttpResponse<UsageGetUsageResponse>> GetUsage(
        string licenseID,
        UsageGetUsageParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
