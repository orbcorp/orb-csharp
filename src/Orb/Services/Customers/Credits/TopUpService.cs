using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers.Credits.TopUps;

namespace Orb.Services.Customers.Credits;

/// <inheritdoc/>
public sealed class TopUpService : ITopUpService
{
    readonly Lazy<ITopUpServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITopUpServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public ITopUpService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TopUpService(this._client.WithOptions(modifier));
    }

    public TopUpService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TopUpServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<TopUpCreateResponse> Create(
        TopUpCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TopUpCreateResponse> Create(
        string customerID,
        TopUpCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TopUpListPage> List(
        TopUpListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TopUpListPage> List(
        string customerID,
        TopUpListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        TopUpDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string topUpID,
        TopUpDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with { TopUpID = topUpID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TopUpCreateByExternalIDResponse> CreateByExternalID(
        TopUpCreateByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateByExternalID(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TopUpCreateByExternalIDResponse> CreateByExternalID(
        string externalCustomerID,
        TopUpCreateByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreateByExternalID(
            parameters with
            {
                ExternalCustomerID = externalCustomerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task DeleteByExternalID(
        TopUpDeleteByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.DeleteByExternalID(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task DeleteByExternalID(
        string topUpID,
        TopUpDeleteByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.DeleteByExternalID(parameters with { TopUpID = topUpID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<TopUpListByExternalIDPage> ListByExternalID(
        TopUpListByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListByExternalID(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TopUpListByExternalIDPage> ListByExternalID(
        string externalCustomerID,
        TopUpListByExternalIDParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListByExternalID(
            parameters with
            {
                ExternalCustomerID = externalCustomerID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class TopUpServiceWithRawResponse : ITopUpServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITopUpServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TopUpServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TopUpServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TopUpCreateResponse>> Create(
        TopUpCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new OrbInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<TopUpCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var topUp = await response
                    .Deserialize<TopUpCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    topUp.Validate();
                }
                return topUp;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TopUpCreateResponse>> Create(
        string customerID,
        TopUpCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TopUpListPage>> List(
        TopUpListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new OrbInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<TopUpListParams> request = new()
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
                    .Deserialize<TopUpListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new TopUpListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TopUpListPage>> List(
        string customerID,
        TopUpListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        TopUpDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TopUpID == null)
        {
            throw new OrbInvalidDataException("'parameters.TopUpID' cannot be null");
        }

        HttpRequest<TopUpDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string topUpID,
        TopUpDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { TopUpID = topUpID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TopUpCreateByExternalIDResponse>> CreateByExternalID(
        TopUpCreateByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalCustomerID == null)
        {
            throw new OrbInvalidDataException("'parameters.ExternalCustomerID' cannot be null");
        }

        HttpRequest<TopUpCreateByExternalIDParams> request = new()
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
                    .Deserialize<TopUpCreateByExternalIDResponse>(token)
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
    public Task<HttpResponse<TopUpCreateByExternalIDResponse>> CreateByExternalID(
        string externalCustomerID,
        TopUpCreateByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreateByExternalID(
            parameters with
            {
                ExternalCustomerID = externalCustomerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> DeleteByExternalID(
        TopUpDeleteByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TopUpID == null)
        {
            throw new OrbInvalidDataException("'parameters.TopUpID' cannot be null");
        }

        HttpRequest<TopUpDeleteByExternalIDParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> DeleteByExternalID(
        string topUpID,
        TopUpDeleteByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.DeleteByExternalID(parameters with { TopUpID = topUpID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TopUpListByExternalIDPage>> ListByExternalID(
        TopUpListByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalCustomerID == null)
        {
            throw new OrbInvalidDataException("'parameters.ExternalCustomerID' cannot be null");
        }

        HttpRequest<TopUpListByExternalIDParams> request = new()
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
                    .Deserialize<TopUpListByExternalIDPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new TopUpListByExternalIDPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TopUpListByExternalIDPage>> ListByExternalID(
        string externalCustomerID,
        TopUpListByExternalIDParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListByExternalID(
            parameters with
            {
                ExternalCustomerID = externalCustomerID,
            },
            cancellationToken
        );
    }
}
