using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.SubscriptionChanges;

namespace Orb.Services;

/// <inheritdoc />
public sealed class SubscriptionChangeService : ISubscriptionChangeService
{
    /// <inheritdoc/>
    public ISubscriptionChangeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SubscriptionChangeService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public SubscriptionChangeService(IOrbClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<SubscriptionChangeRetrieveResponse> Retrieve(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var subscriptionChange = await response
            .Deserialize<SubscriptionChangeRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            subscriptionChange.Validate();
        }
        return subscriptionChange;
    }

    /// <inheritdoc/>
    public async Task<SubscriptionChangeRetrieveResponse> Retrieve(
        string subscriptionChangeID,
        SubscriptionChangeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(
            parameters with
            {
                SubscriptionChangeID = subscriptionChangeID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<SubscriptionChangeApplyResponse> Apply(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<SubscriptionChangeApplyResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<SubscriptionChangeApplyResponse> Apply(
        string subscriptionChangeID,
        SubscriptionChangeApplyParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Apply(
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
        if (parameters.SubscriptionChangeID == null)
        {
            throw new OrbInvalidDataException("'parameters.SubscriptionChangeID' cannot be null");
        }

        HttpRequest<SubscriptionChangeCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<SubscriptionChangeCancelResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<SubscriptionChangeCancelResponse> Cancel(
        string subscriptionChangeID,
        SubscriptionChangeCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Cancel(
            parameters with
            {
                SubscriptionChangeID = subscriptionChangeID,
            },
            cancellationToken
        );
    }
}
