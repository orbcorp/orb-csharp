using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Licenses;
using Orb.Services.Licenses;

namespace Orb.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ILicenseService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ILicenseServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILicenseService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IExternalLicenseService ExternalLicenses { get; }

    IUsageService Usage { get; }

    /// <summary>
    /// This endpoint is used to create a new license for a user.
    ///
    /// <para>If a start date is provided, the license will be activated at the
    /// **start** of the specified date in the customer's timezone. Otherwise, the
    /// activation time will default to the **start** of the current day in the
    /// customer's timezone.</para>
    /// </summary>
    Task<LicenseCreateResponse> Create(
        LicenseCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint is used to fetch a license given an identifier.
    /// </summary>
    Task<LicenseRetrieveResponse> Retrieve(
        LicenseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(LicenseRetrieveParams, CancellationToken)"/>
    Task<LicenseRetrieveResponse> Retrieve(
        string licenseID,
        LicenseRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint returns a list of all licenses for a subscription.
    /// </summary>
    Task<LicenseListPage> List(
        LicenseListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint is used to deactivate an existing license.
    ///
    /// <para>If an end date is provided, the license will be deactivated at the
    /// **start** of the specified date in the customer's timezone. Otherwise, the
    /// deactivation time will default to the **end** of the current day in the
    /// customer's timezone.</para>
    /// </summary>
    Task<LicenseDeactivateResponse> Deactivate(
        LicenseDeactivateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Deactivate(LicenseDeactivateParams, CancellationToken)"/>
    Task<LicenseDeactivateResponse> Deactivate(
        string licenseID,
        LicenseDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint is used to fetch a license given an external license identifier.
    /// </summary>
    Task<LicenseRetrieveByExternalIDResponse> RetrieveByExternalID(
        LicenseRetrieveByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveByExternalID(LicenseRetrieveByExternalIDParams, CancellationToken)"/>
    Task<LicenseRetrieveByExternalIDResponse> RetrieveByExternalID(
        string externalLicenseID,
        LicenseRetrieveByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ILicenseService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ILicenseServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILicenseServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IExternalLicenseServiceWithRawResponse ExternalLicenses { get; }

    IUsageServiceWithRawResponse Usage { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /licenses</c>, but is otherwise the
    /// same as <see cref="ILicenseService.Create(LicenseCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LicenseCreateResponse>> Create(
        LicenseCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /licenses/{license_id}</c>, but is otherwise the
    /// same as <see cref="ILicenseService.Retrieve(LicenseRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LicenseRetrieveResponse>> Retrieve(
        LicenseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(LicenseRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<LicenseRetrieveResponse>> Retrieve(
        string licenseID,
        LicenseRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /licenses</c>, but is otherwise the
    /// same as <see cref="ILicenseService.List(LicenseListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LicenseListPage>> List(
        LicenseListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /licenses/{license_id}/deactivate</c>, but is otherwise the
    /// same as <see cref="ILicenseService.Deactivate(LicenseDeactivateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LicenseDeactivateResponse>> Deactivate(
        LicenseDeactivateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Deactivate(LicenseDeactivateParams, CancellationToken)"/>
    Task<HttpResponse<LicenseDeactivateResponse>> Deactivate(
        string licenseID,
        LicenseDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /licenses/external_license_id/{external_license_id}</c>, but is otherwise the
    /// same as <see cref="ILicenseService.RetrieveByExternalID(LicenseRetrieveByExternalIDParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LicenseRetrieveByExternalIDResponse>> RetrieveByExternalID(
        LicenseRetrieveByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveByExternalID(LicenseRetrieveByExternalIDParams, CancellationToken)"/>
    Task<HttpResponse<LicenseRetrieveByExternalIDResponse>> RetrieveByExternalID(
        string externalLicenseID,
        LicenseRetrieveByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    );
}
