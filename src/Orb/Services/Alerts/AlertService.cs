using System;
using System.Net.Http;
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

    public async Task<Alerts::Alert> Retrieve(Alerts::AlertRetrieveParams parameters)
    {
        HttpRequest<Alerts::AlertRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var alert = await response.Deserialize<Alerts::Alert>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }

    public async Task<Alerts::Alert> Update(Alerts::AlertUpdateParams parameters)
    {
        HttpRequest<Alerts::AlertUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var alert = await response.Deserialize<Alerts::Alert>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }

    public async Task<Alerts::AlertListPageResponse> List(
        Alerts::AlertListParams? parameters = null
    )
    {
        parameters ??= new();

        HttpRequest<Alerts::AlertListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var page = await response
            .Deserialize<Alerts::AlertListPageResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<Alerts::Alert> CreateForCustomer(
        Alerts::AlertCreateForCustomerParams parameters
    )
    {
        HttpRequest<Alerts::AlertCreateForCustomerParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var alert = await response.Deserialize<Alerts::Alert>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }

    public async Task<Alerts::Alert> CreateForExternalCustomer(
        Alerts::AlertCreateForExternalCustomerParams parameters
    )
    {
        HttpRequest<Alerts::AlertCreateForExternalCustomerParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var alert = await response.Deserialize<Alerts::Alert>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }

    public async Task<Alerts::Alert> CreateForSubscription(
        Alerts::AlertCreateForSubscriptionParams parameters
    )
    {
        HttpRequest<Alerts::AlertCreateForSubscriptionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var alert = await response.Deserialize<Alerts::Alert>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }

    public async Task<Alerts::Alert> Disable(Alerts::AlertDisableParams parameters)
    {
        HttpRequest<Alerts::AlertDisableParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var alert = await response.Deserialize<Alerts::Alert>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }

    public async Task<Alerts::Alert> Enable(Alerts::AlertEnableParams parameters)
    {
        HttpRequest<Alerts::AlertEnableParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var alert = await response.Deserialize<Alerts::Alert>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }
}
