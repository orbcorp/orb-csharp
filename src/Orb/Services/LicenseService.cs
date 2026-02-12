using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Licenses;
using Orb.Services.Licenses;

namespace Orb.Services;

/// <inheritdoc/>
public sealed class LicenseService : ILicenseService
{
    readonly Lazy<ILicenseServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILicenseServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public ILicenseService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LicenseService(this._client.WithOptions(modifier));
    }

    public LicenseService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() => new LicenseServiceWithRawResponse(client.WithRawResponse));
        _externalLicenses = new(() => new ExternalLicenseService(client));
        _usage = new(() => new UsageService(client));
    }

    readonly Lazy<IExternalLicenseService> _externalLicenses;
    public IExternalLicenseService ExternalLicenses
    {
        get { return _externalLicenses.Value; }
    }

    readonly Lazy<IUsageService> _usage;
    public IUsageService Usage
    {
        get { return _usage.Value; }
    }

    /// <inheritdoc/>
    public async Task<LicenseCreateResponse> Create(
        LicenseCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<LicenseRetrieveResponse> Retrieve(
        LicenseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LicenseRetrieveResponse> Retrieve(
        string licenseID,
        LicenseRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { LicenseID = licenseID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<LicenseListPage> List(
        LicenseListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<LicenseDeactivateResponse> Deactivate(
        LicenseDeactivateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Deactivate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LicenseDeactivateResponse> Deactivate(
        string licenseID,
        LicenseDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Deactivate(parameters with { LicenseID = licenseID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<LicenseRetrieveByExternalIDResponse> RetrieveByExternalID(
        LicenseRetrieveByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveByExternalID(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LicenseRetrieveByExternalIDResponse> RetrieveByExternalID(
        string externalLicenseID,
        LicenseRetrieveByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveByExternalID(
            parameters with
            {
                ExternalLicenseID = externalLicenseID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class LicenseServiceWithRawResponse : ILicenseServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILicenseServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LicenseServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LicenseServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;

        _externalLicenses = new(() => new ExternalLicenseServiceWithRawResponse(client));
        _usage = new(() => new UsageServiceWithRawResponse(client));
    }

    readonly Lazy<IExternalLicenseServiceWithRawResponse> _externalLicenses;
    public IExternalLicenseServiceWithRawResponse ExternalLicenses
    {
        get { return _externalLicenses.Value; }
    }

    readonly Lazy<IUsageServiceWithRawResponse> _usage;
    public IUsageServiceWithRawResponse Usage
    {
        get { return _usage.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LicenseCreateResponse>> Create(
        LicenseCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<LicenseCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var license = await response
                    .Deserialize<LicenseCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    license.Validate();
                }
                return license;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LicenseRetrieveResponse>> Retrieve(
        LicenseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.LicenseID == null)
        {
            throw new OrbInvalidDataException("'parameters.LicenseID' cannot be null");
        }

        HttpRequest<LicenseRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var license = await response
                    .Deserialize<LicenseRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    license.Validate();
                }
                return license;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<LicenseRetrieveResponse>> Retrieve(
        string licenseID,
        LicenseRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { LicenseID = licenseID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LicenseListPage>> List(
        LicenseListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<LicenseListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<LicenseListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new LicenseListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LicenseDeactivateResponse>> Deactivate(
        LicenseDeactivateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.LicenseID == null)
        {
            throw new OrbInvalidDataException("'parameters.LicenseID' cannot be null");
        }

        HttpRequest<LicenseDeactivateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<LicenseDeactivateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<LicenseDeactivateResponse>> Deactivate(
        string licenseID,
        LicenseDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Deactivate(parameters with { LicenseID = licenseID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LicenseRetrieveByExternalIDResponse>> RetrieveByExternalID(
        LicenseRetrieveByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalLicenseID == null)
        {
            throw new OrbInvalidDataException("'parameters.ExternalLicenseID' cannot be null");
        }

        HttpRequest<LicenseRetrieveByExternalIDParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<LicenseRetrieveByExternalIDResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<LicenseRetrieveByExternalIDResponse>> RetrieveByExternalID(
        string externalLicenseID,
        LicenseRetrieveByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveByExternalID(
            parameters with
            {
                ExternalLicenseID = externalLicenseID,
            },
            cancellationToken
        );
    }
}
