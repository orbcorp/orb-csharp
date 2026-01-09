using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models.Alerts;

namespace Orb.Services;

/// <inheritdoc/>
public sealed class AlertService : IAlertService
{
    readonly Lazy<IAlertServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAlertServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public IAlertService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AlertService(this._client.WithOptions(modifier));
    }

    public AlertService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AlertServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Alert> Retrieve(
        AlertRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Alert> Retrieve(
        string alertID,
        AlertRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { AlertID = alertID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Alert> Update(
        AlertUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Alert> Update(
        string alertConfigurationID,
        AlertUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(
            parameters with
            {
                AlertConfigurationID = alertConfigurationID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<AlertListPage> List(
        AlertListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Alert> CreateForCustomer(
        AlertCreateForCustomerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateForCustomer(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Alert> CreateForCustomer(
        string customerID,
        AlertCreateForCustomerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreateForCustomer(
            parameters with
            {
                CustomerID = customerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<Alert> CreateForExternalCustomer(
        AlertCreateForExternalCustomerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateForExternalCustomer(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Alert> CreateForExternalCustomer(
        string externalCustomerID,
        AlertCreateForExternalCustomerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreateForExternalCustomer(
            parameters with
            {
                ExternalCustomerID = externalCustomerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<Alert> CreateForSubscription(
        AlertCreateForSubscriptionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateForSubscription(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Alert> CreateForSubscription(
        string subscriptionID,
        AlertCreateForSubscriptionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreateForSubscription(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<Alert> Disable(
        AlertDisableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Disable(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Alert> Disable(
        string alertConfigurationID,
        AlertDisableParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Disable(
            parameters with
            {
                AlertConfigurationID = alertConfigurationID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<Alert> Enable(
        AlertEnableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Enable(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Alert> Enable(
        string alertConfigurationID,
        AlertEnableParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Enable(
            parameters with
            {
                AlertConfigurationID = alertConfigurationID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class AlertServiceWithRawResponse : IAlertServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAlertServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AlertServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AlertServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Alert>> Retrieve(
        AlertRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AlertID == null)
        {
            throw new OrbInvalidDataException("'parameters.AlertID' cannot be null");
        }

        HttpRequest<AlertRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var alert = await response.Deserialize<Alert>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    alert.Validate();
                }
                return alert;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Alert>> Retrieve(
        string alertID,
        AlertRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { AlertID = alertID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Alert>> Update(
        AlertUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AlertConfigurationID == null)
        {
            throw new OrbInvalidDataException("'parameters.AlertConfigurationID' cannot be null");
        }

        HttpRequest<AlertUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var alert = await response.Deserialize<Alert>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    alert.Validate();
                }
                return alert;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Alert>> Update(
        string alertConfigurationID,
        AlertUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(
            parameters with
            {
                AlertConfigurationID = alertConfigurationID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AlertListPage>> List(
        AlertListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AlertListParams> request = new()
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
                    .Deserialize<AlertListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new AlertListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Alert>> CreateForCustomer(
        AlertCreateForCustomerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CustomerID == null)
        {
            throw new OrbInvalidDataException("'parameters.CustomerID' cannot be null");
        }

        HttpRequest<AlertCreateForCustomerParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var alert = await response.Deserialize<Alert>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    alert.Validate();
                }
                return alert;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Alert>> CreateForCustomer(
        string customerID,
        AlertCreateForCustomerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreateForCustomer(
            parameters with
            {
                CustomerID = customerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Alert>> CreateForExternalCustomer(
        AlertCreateForExternalCustomerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExternalCustomerID == null)
        {
            throw new OrbInvalidDataException("'parameters.ExternalCustomerID' cannot be null");
        }

        HttpRequest<AlertCreateForExternalCustomerParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var alert = await response.Deserialize<Alert>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    alert.Validate();
                }
                return alert;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Alert>> CreateForExternalCustomer(
        string externalCustomerID,
        AlertCreateForExternalCustomerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreateForExternalCustomer(
            parameters with
            {
                ExternalCustomerID = externalCustomerID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Alert>> CreateForSubscription(
        AlertCreateForSubscriptionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SubscriptionID == null)
        {
            throw new OrbInvalidDataException("'parameters.SubscriptionID' cannot be null");
        }

        HttpRequest<AlertCreateForSubscriptionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var alert = await response.Deserialize<Alert>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    alert.Validate();
                }
                return alert;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Alert>> CreateForSubscription(
        string subscriptionID,
        AlertCreateForSubscriptionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.CreateForSubscription(
            parameters with
            {
                SubscriptionID = subscriptionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Alert>> Disable(
        AlertDisableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AlertConfigurationID == null)
        {
            throw new OrbInvalidDataException("'parameters.AlertConfigurationID' cannot be null");
        }

        HttpRequest<AlertDisableParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var alert = await response.Deserialize<Alert>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    alert.Validate();
                }
                return alert;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Alert>> Disable(
        string alertConfigurationID,
        AlertDisableParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Disable(
            parameters with
            {
                AlertConfigurationID = alertConfigurationID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Alert>> Enable(
        AlertEnableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AlertConfigurationID == null)
        {
            throw new OrbInvalidDataException("'parameters.AlertConfigurationID' cannot be null");
        }

        HttpRequest<AlertEnableParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var alert = await response.Deserialize<Alert>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    alert.Validate();
                }
                return alert;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Alert>> Enable(
        string alertConfigurationID,
        AlertEnableParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Enable(
            parameters with
            {
                AlertConfigurationID = alertConfigurationID,
            },
            cancellationToken
        );
    }
}
