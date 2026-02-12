using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Licenses.Usage;

namespace Orb.Services.Licenses;

/// <inheritdoc/>
public sealed class UsageService : IUsageService
{
    readonly Lazy<IUsageServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUsageServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public IUsageService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UsageService(this._client.WithOptions(modifier));
    }

    public UsageService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() => new UsageServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<UsageGetAllUsageResponse> GetAllUsage(
        UsageGetAllUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetAllUsage(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<UsageGetUsageResponse> GetUsage(
        UsageGetUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetUsage(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<UsageGetUsageResponse> GetUsage(
        string licenseID,
        UsageGetUsageParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetUsage(parameters with { LicenseID = licenseID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class UsageServiceWithRawResponse : IUsageServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUsageServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UsageServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UsageServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UsageGetAllUsageResponse>> GetAllUsage(
        UsageGetAllUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<UsageGetAllUsageParams> request = new()
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
                    .Deserialize<UsageGetAllUsageResponse>(token)
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
    public async Task<HttpResponse<UsageGetUsageResponse>> GetUsage(
        UsageGetUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.LicenseID == null)
        {
            throw new OrbInvalidDataException("'parameters.LicenseID' cannot be null");
        }

        HttpRequest<UsageGetUsageParams> request = new()
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
                    .Deserialize<UsageGetUsageResponse>(token)
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
    public Task<HttpResponse<UsageGetUsageResponse>> GetUsage(
        string licenseID,
        UsageGetUsageParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetUsage(parameters with { LicenseID = licenseID }, cancellationToken);
    }
}
