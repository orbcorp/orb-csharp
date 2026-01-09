using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Customers.Credits.Ledger;

namespace Orb.Services.Customers.Credits;

/// <inheritdoc/>
public sealed class LedgerService : ILedgerService
{
    readonly Lazy<ILedgerServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILedgerServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public ILedgerService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LedgerService(this._client.WithOptions(modifier));
    }

    public LedgerService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() => new LedgerServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<LedgerListPage> List(
        LedgerListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LedgerListPage> List(
        string customerID,
        LedgerListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<LedgerCreateEntryResponse> CreateEntry(
        LedgerCreateEntryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateEntry(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LedgerCreateEntryResponse> CreateEntry(
        string customerID,
        LedgerCreateEntryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreateEntry(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<LedgerCreateEntryByExternalIDResponse> CreateEntryByExternalID(
        LedgerCreateEntryByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateEntryByExternalID(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LedgerCreateEntryByExternalIDResponse> CreateEntryByExternalID(
        string externalCustomerID,
        LedgerCreateEntryByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreateEntryByExternalID(
            parameters with
            {
                ExternalCustomerID = externalCustomerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<LedgerListByExternalIDPage> ListByExternalID(
        LedgerListByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListByExternalID(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<LedgerListByExternalIDPage> ListByExternalID(
        string externalCustomerID,
        LedgerListByExternalIDParams? parameters = null,
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
public sealed class LedgerServiceWithRawResponse : ILedgerServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public ILedgerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LedgerServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public LedgerServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LedgerListPage>> List(
        LedgerListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new OrbInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<LedgerListParams> request = new()
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
                    .Deserialize<LedgerListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new LedgerListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<LedgerListPage>> List(
        string customerID,
        LedgerListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LedgerCreateEntryResponse>> CreateEntry(
        LedgerCreateEntryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new OrbInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<LedgerCreateEntryParams> request = new()
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
                    .Deserialize<LedgerCreateEntryResponse>(token)
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
    public Task<HttpResponse<LedgerCreateEntryResponse>> CreateEntry(
        string customerID,
        LedgerCreateEntryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreateEntry(parameters with { CustomerID = customerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LedgerCreateEntryByExternalIDResponse>> CreateEntryByExternalID(
        LedgerCreateEntryByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalCustomerID == null)
        {
            throw new OrbInvalidDataException("'parameters.ExternalCustomerID' cannot be null");
        }

        HttpRequest<LedgerCreateEntryByExternalIDParams> request = new()
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
                    .Deserialize<LedgerCreateEntryByExternalIDResponse>(token)
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
    public Task<HttpResponse<LedgerCreateEntryByExternalIDResponse>> CreateEntryByExternalID(
        string externalCustomerID,
        LedgerCreateEntryByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreateEntryByExternalID(
            parameters with
            {
                ExternalCustomerID = externalCustomerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<LedgerListByExternalIDPage>> ListByExternalID(
        LedgerListByExternalIDParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalCustomerID == null)
        {
            throw new OrbInvalidDataException("'parameters.ExternalCustomerID' cannot be null");
        }

        HttpRequest<LedgerListByExternalIDParams> request = new()
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
                    .Deserialize<LedgerListByExternalIDPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new LedgerListByExternalIDPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<LedgerListByExternalIDPage>> ListByExternalID(
        string externalCustomerID,
        LedgerListByExternalIDParams? parameters = null,
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
