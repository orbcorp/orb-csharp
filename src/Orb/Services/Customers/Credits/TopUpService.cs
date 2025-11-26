using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers.Credits.TopUps;

namespace Orb.Services.Customers.Credits;

/// <inheritdoc />
public sealed class TopUpService : ITopUpService
{
    /// <inheritdoc/>
    public ITopUpService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TopUpService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public TopUpService(IOrbClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<TopUpCreateResponse> Create(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var topUp = await response
            .Deserialize<TopUpCreateResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            topUp.Validate();
        }
        return topUp;
    }

    /// <inheritdoc/>
    public async Task<TopUpCreateResponse> Create(
        string customerID,
        TopUpCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Create(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TopUpListPageResponse> List(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<TopUpListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    /// <inheritdoc/>
    public async Task<TopUpListPageResponse> List(
        string customerID,
        TopUpListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.List(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string topUpID,
        TopUpDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with { TopUpID = topUpID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TopUpCreateByExternalIDResponse> CreateByExternalID(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<TopUpCreateByExternalIDResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<TopUpCreateByExternalIDResponse> CreateByExternalID(
        string externalCustomerID,
        TopUpCreateByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.CreateByExternalID(
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
        if (parameters.TopUpID == null)
        {
            throw new OrbInvalidDataException("'parameters.TopUpID' cannot be null");
        }

        HttpRequest<TopUpDeleteByExternalIDParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task DeleteByExternalID(
        string topUpID,
        TopUpDeleteByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.DeleteByExternalID(parameters with { TopUpID = topUpID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TopUpListByExternalIDPageResponse> ListByExternalID(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<TopUpListByExternalIDPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    /// <inheritdoc/>
    public async Task<TopUpListByExternalIDPageResponse> ListByExternalID(
        string externalCustomerID,
        TopUpListByExternalIDParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.ListByExternalID(
            parameters with
            {
                ExternalCustomerID = externalCustomerID,
            },
            cancellationToken
        );
    }
}
