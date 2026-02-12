using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Licenses.ExternalLicenses;

namespace Orb.Services.Licenses;

/// <inheritdoc/>
public sealed class ExternalLicenseService : IExternalLicenseService
{
    readonly Lazy<IExternalLicenseServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IExternalLicenseServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public IExternalLicenseService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExternalLicenseService(this._client.WithOptions(modifier));
    }

    public ExternalLicenseService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new ExternalLicenseServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<ExternalLicenseGetUsageResponse> GetUsage(
        ExternalLicenseGetUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetUsage(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ExternalLicenseGetUsageResponse> GetUsage(
        string externalLicenseID,
        ExternalLicenseGetUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetUsage(
            parameters with
            {
                ExternalLicenseID = externalLicenseID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class ExternalLicenseServiceWithRawResponse : IExternalLicenseServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public IExternalLicenseServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ExternalLicenseServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ExternalLicenseServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExternalLicenseGetUsageResponse>> GetUsage(
        ExternalLicenseGetUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalLicenseID == null)
        {
            throw new OrbInvalidDataException("'parameters.ExternalLicenseID' cannot be null");
        }

        HttpRequest<ExternalLicenseGetUsageParams> request = new()
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
                    .Deserialize<ExternalLicenseGetUsageResponse>(token)
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
    public Task<HttpResponse<ExternalLicenseGetUsageResponse>> GetUsage(
        string externalLicenseID,
        ExternalLicenseGetUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetUsage(
            parameters with
            {
                ExternalLicenseID = externalLicenseID,
            },
            cancellationToken
        );
    }
}
