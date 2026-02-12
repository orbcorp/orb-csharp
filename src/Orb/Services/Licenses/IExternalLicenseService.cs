using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Licenses.ExternalLicenses;

namespace Orb.Services.Licenses;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IExternalLicenseService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IExternalLicenseServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExternalLicenseService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns usage and remaining credits for a license identified by its external
    /// license ID.
    ///
    /// <para>Date range defaults to the current billing period if not specified.</para>
    /// </summary>
    Task<ExternalLicenseGetUsageResponse> GetUsage(
        ExternalLicenseGetUsageParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetUsage(ExternalLicenseGetUsageParams, CancellationToken)"/>
    Task<ExternalLicenseGetUsageResponse> GetUsage(
        string externalLicenseID,
        ExternalLicenseGetUsageParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IExternalLicenseService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IExternalLicenseServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExternalLicenseServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /licenses/external_licenses/{external_license_id}/usage`, but is otherwise the
    /// same as <see cref="IExternalLicenseService.GetUsage(ExternalLicenseGetUsageParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExternalLicenseGetUsageResponse>> GetUsage(
        ExternalLicenseGetUsageParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetUsage(ExternalLicenseGetUsageParams, CancellationToken)"/>
    Task<HttpResponse<ExternalLicenseGetUsageResponse>> GetUsage(
        string externalLicenseID,
        ExternalLicenseGetUsageParams parameters,
        CancellationToken cancellationToken = default
    );
}
