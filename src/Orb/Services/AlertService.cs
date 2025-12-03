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
    /// <inheritdoc/>
    public IAlertService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AlertService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public AlertService(IOrbClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<Alert> Retrieve(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var alert = await response.Deserialize<Alert>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }

    /// <inheritdoc/>
    public async Task<Alert> Retrieve(
        string alertID,
        AlertRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { AlertID = alertID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Alert> Update(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var alert = await response.Deserialize<Alert>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }

    /// <inheritdoc/>
    public async Task<Alert> Update(
        string alertConfigurationID,
        AlertUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Update(
            parameters with
            {
                AlertConfigurationID = alertConfigurationID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<AlertListPageResponse> List(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<AlertListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    /// <inheritdoc/>
    public async Task<Alert> CreateForCustomer(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var alert = await response.Deserialize<Alert>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }

    /// <inheritdoc/>
    public async Task<Alert> CreateForCustomer(
        string customerID,
        AlertCreateForCustomerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.CreateForCustomer(
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
        if (parameters.ExternalCustomerID == null)
        {
            throw new OrbInvalidDataException("'parameters.ExternalCustomerID' cannot be null");
        }

        HttpRequest<AlertCreateForExternalCustomerParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var alert = await response.Deserialize<Alert>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }

    /// <inheritdoc/>
    public async Task<Alert> CreateForExternalCustomer(
        string externalCustomerID,
        AlertCreateForExternalCustomerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.CreateForExternalCustomer(
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
        if (parameters.SubscriptionID == null)
        {
            throw new OrbInvalidDataException("'parameters.SubscriptionID' cannot be null");
        }

        HttpRequest<AlertCreateForSubscriptionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var alert = await response.Deserialize<Alert>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }

    /// <inheritdoc/>
    public async Task<Alert> CreateForSubscription(
        string subscriptionID,
        AlertCreateForSubscriptionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.CreateForSubscription(
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
        if (parameters.AlertConfigurationID == null)
        {
            throw new OrbInvalidDataException("'parameters.AlertConfigurationID' cannot be null");
        }

        HttpRequest<AlertDisableParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var alert = await response.Deserialize<Alert>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }

    /// <inheritdoc/>
    public async Task<Alert> Disable(
        string alertConfigurationID,
        AlertDisableParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Disable(
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
        if (parameters.AlertConfigurationID == null)
        {
            throw new OrbInvalidDataException("'parameters.AlertConfigurationID' cannot be null");
        }

        HttpRequest<AlertEnableParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var alert = await response.Deserialize<Alert>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }

    /// <inheritdoc/>
    public async Task<Alert> Enable(
        string alertConfigurationID,
        AlertEnableParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Enable(
            parameters with
            {
                AlertConfigurationID = alertConfigurationID,
            },
            cancellationToken
        );
    }
}
