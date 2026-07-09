using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.LicenseTypes;

namespace Orb.Services;

/// <inheritdoc/>
public sealed class LicenseTypeService : ILicenseTypeService
{
    readonly Lazy<ILicenseTypeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILicenseTypeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public ILicenseTypeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LicenseTypeService(this._client.WithOptions(modifier));
    }

    public LicenseTypeService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() => new LicenseTypeServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<LicenseTypeCreateResponse> Create(
        LicenseTypeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<LicenseTypeRetrieveResponse> Retrieve(
        LicenseTypeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LicenseTypeRetrieveResponse> Retrieve(
        string licenseTypeID,
        LicenseTypeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { LicenseTypeID = licenseTypeID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<LicenseTypeListPage> List(
        LicenseTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class LicenseTypeServiceWithRawResponse : ILicenseTypeServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILicenseTypeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new LicenseTypeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LicenseTypeServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LicenseTypeCreateResponse>> Create(
        LicenseTypeCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<LicenseTypeCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var licenseType = await response
                    .Deserialize<LicenseTypeCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    licenseType.Validate();
                }
                return licenseType;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LicenseTypeRetrieveResponse>> Retrieve(
        LicenseTypeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.LicenseTypeID == null)
        {
            throw new OrbInvalidDataException("'parameters.LicenseTypeID' cannot be null");
        }

        HttpRequest<LicenseTypeRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var licenseType = await response
                    .Deserialize<LicenseTypeRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    licenseType.Validate();
                }
                return licenseType;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<LicenseTypeRetrieveResponse>> Retrieve(
        string licenseTypeID,
        LicenseTypeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { LicenseTypeID = licenseTypeID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LicenseTypeListPage>> List(
        LicenseTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<LicenseTypeListParams> request = new()
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
                    .Deserialize<LicenseTypeListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new LicenseTypeListPage(this, parameters, page);
            }
        );
    }
}
