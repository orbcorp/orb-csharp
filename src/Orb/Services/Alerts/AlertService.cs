using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Alerts = Orb.Models.Alerts;

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

    public async Task<Alerts::Alert> Retrieve(
        Alerts::AlertRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Alerts::AlertRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var alert = await response
            .Deserialize<Alerts::Alert>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }

    public async Task<Alerts::Alert> Update(
        Alerts::AlertUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Alerts::AlertUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var alert = await response
            .Deserialize<Alerts::Alert>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }

    public async Task<Alerts::AlertListPageResponse> List(
        Alerts::AlertListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<Alerts::AlertListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<Alerts::AlertListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<Alerts::Alert> CreateForCustomer(
        Alerts::AlertCreateForCustomerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Alerts::AlertCreateForCustomerParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var alert = await response
            .Deserialize<Alerts::Alert>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }

    public async Task<Alerts::Alert> CreateForExternalCustomer(
        Alerts::AlertCreateForExternalCustomerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Alerts::AlertCreateForExternalCustomerParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var alert = await response
            .Deserialize<Alerts::Alert>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }

    public async Task<Alerts::Alert> CreateForSubscription(
        Alerts::AlertCreateForSubscriptionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Alerts::AlertCreateForSubscriptionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var alert = await response
            .Deserialize<Alerts::Alert>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }

    public async Task<Alerts::Alert> Disable(
        Alerts::AlertDisableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Alerts::AlertDisableParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var alert = await response
            .Deserialize<Alerts::Alert>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }

    public async Task<Alerts::Alert> Enable(
        Alerts::AlertEnableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Alerts::AlertEnableParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var alert = await response
            .Deserialize<Alerts::Alert>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }
}
