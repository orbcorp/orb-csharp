using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.SubscriptionChanges;

namespace Orb.Services;

/// <inheritdoc/>
public sealed class SubscriptionChangeService : ISubscriptionChangeService
{
    readonly Lazy<ISubscriptionChangeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISubscriptionChangeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public ISubscriptionChangeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SubscriptionChangeService(this._client.WithOptions(modifier));
    }

    public SubscriptionChangeService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new SubscriptionChangeServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<SubscriptionChangeRetrieveResponse> Retrieve(
        SubscriptionChangeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SubscriptionChangeRetrieveResponse> Retrieve(
        string subscriptionChangeID,
        SubscriptionChangeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                SubscriptionChangeID = subscriptionChangeID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<SubscriptionChangeListPage> List(
        SubscriptionChangeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionChangeApplyResponse> Apply(
        SubscriptionChangeApplyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Apply(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SubscriptionChangeApplyResponse> Apply(
        string subscriptionChangeID,
        SubscriptionChangeApplyParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Apply(
            parameters with
            {
                SubscriptionChangeID = subscriptionChangeID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<SubscriptionChangeCancelResponse> Cancel(
        SubscriptionChangeCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SubscriptionChangeCancelResponse> Cancel(
        string subscriptionChangeID,
        SubscriptionChangeCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(
            parameters with
            {
                SubscriptionChangeID = subscriptionChangeID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class SubscriptionChangeServiceWithRawResponse
    : ISubscriptionChangeServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISubscriptionChangeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SubscriptionChangeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SubscriptionChangeServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubscriptionChangeRetrieveResponse>> Retrieve(
        SubscriptionChangeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionChangeID == null)
        {
            throw new OrbInvalidDataException("'parameters.SubscriptionChangeID' cannot be null");
        }

        HttpRequest<SubscriptionChangeRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var subscriptionChange = await response
                    .Deserialize<SubscriptionChangeRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    subscriptionChange.Validate();
                }
                return subscriptionChange;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SubscriptionChangeRetrieveResponse>> Retrieve(
        string subscriptionChangeID,
        SubscriptionChangeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                SubscriptionChangeID = subscriptionChangeID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubscriptionChangeListPage>> List(
        SubscriptionChangeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SubscriptionChangeListParams> request = new()
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
                    .Deserialize<SubscriptionChangeListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new SubscriptionChangeListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubscriptionChangeApplyResponse>> Apply(
        SubscriptionChangeApplyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionChangeID == null)
        {
            throw new OrbInvalidDataException("'parameters.SubscriptionChangeID' cannot be null");
        }

        HttpRequest<SubscriptionChangeApplyParams> request = new()
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
                    .Deserialize<SubscriptionChangeApplyResponse>(token)
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
    public Task<HttpResponse<SubscriptionChangeApplyResponse>> Apply(
        string subscriptionChangeID,
        SubscriptionChangeApplyParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Apply(
            parameters with
            {
                SubscriptionChangeID = subscriptionChangeID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubscriptionChangeCancelResponse>> Cancel(
        SubscriptionChangeCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionChangeID == null)
        {
            throw new OrbInvalidDataException("'parameters.SubscriptionChangeID' cannot be null");
        }

        HttpRequest<SubscriptionChangeCancelParams> request = new()
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
                    .Deserialize<SubscriptionChangeCancelResponse>(token)
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
    public Task<HttpResponse<SubscriptionChangeCancelResponse>> Cancel(
        string subscriptionChangeID,
        SubscriptionChangeCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(
            parameters with
            {
                SubscriptionChangeID = subscriptionChangeID,
            },
            cancellationToken
        );
    }
}
