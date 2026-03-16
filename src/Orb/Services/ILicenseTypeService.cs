using System;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.LicenseTypes;

namespace Orb.Services;

/// <summary>
/// The LicenseType resource represents a type of license that can be assigned to
/// users. License types are used during billing by grouping metrics on the configured
/// grouping key.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ILicenseTypeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ILicenseTypeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILicenseTypeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// This endpoint is used to create a new license type.
    ///
    /// <para>License types are used to group licenses and define billing behavior. Each
    /// license type has a name and a grouping key that determines how metrics are
    /// aggregated for billing purposes.</para>
    /// </summary>
    Task<LicenseTypeCreateResponse> Create(
        LicenseTypeCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint returns a license type identified by its license_type_id.
    ///
    /// <para>Use this endpoint to retrieve details about a specific license type,
    /// including its name and grouping key.</para>
    /// </summary>
    Task<LicenseTypeRetrieveResponse> Retrieve(
        LicenseTypeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(LicenseTypeRetrieveParams, CancellationToken)"/>
    Task<LicenseTypeRetrieveResponse> Retrieve(
        string licenseTypeID,
        LicenseTypeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint returns a list of all license types configured for the account,
    /// ordered in ascending order by creation time.
    ///
    /// <para>License types are used to group licenses and define billing behavior. Each
    /// license type has a name and a grouping key that determines how metrics are
    /// aggregated for billing purposes.</para>
    /// </summary>
    Task<LicenseTypeListPage> List(
        LicenseTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ILicenseTypeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ILicenseTypeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILicenseTypeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /license_types</c>, but is otherwise the
    /// same as <see cref="ILicenseTypeService.Create(LicenseTypeCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LicenseTypeCreateResponse>> Create(
        LicenseTypeCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /license_types/{license_type_id}</c>, but is otherwise the
    /// same as <see cref="ILicenseTypeService.Retrieve(LicenseTypeRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LicenseTypeRetrieveResponse>> Retrieve(
        LicenseTypeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(LicenseTypeRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<LicenseTypeRetrieveResponse>> Retrieve(
        string licenseTypeID,
        LicenseTypeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /license_types</c>, but is otherwise the
    /// same as <see cref="ILicenseTypeService.List(LicenseTypeListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<LicenseTypeListPage>> List(
        LicenseTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
