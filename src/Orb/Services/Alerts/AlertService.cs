using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Alerts;

namespace Orb.Services.Alerts;

public sealed class AlertService : IAlertService
{
    public IAlertService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AlertService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public AlertService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<Alert> Retrieve(
        AlertRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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

    public async Task<Alert> Update(
        AlertUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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

    public async Task<Alert> CreateForCustomer(
        AlertCreateForCustomerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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

    public async Task<Alert> CreateForExternalCustomer(
        AlertCreateForExternalCustomerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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

    public async Task<Alert> CreateForSubscription(
        AlertCreateForSubscriptionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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

    public async Task<Alert> Disable(
        AlertDisableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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

    public async Task<Alert> Enable(
        AlertEnableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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
}
