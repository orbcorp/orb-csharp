using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.Alerts;

namespace Orb.Services.Alerts;

public sealed class AlertService : IAlertService
{
    readonly IOrbClient _client;

    public AlertService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<Alert> Retrieve(AlertRetrieveParams parameters)
    {
        HttpRequest<AlertRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var alert = await response.Deserialize<Alert>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }

    public async Task<Alert> Update(AlertUpdateParams parameters)
    {
        HttpRequest<AlertUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var alert = await response.Deserialize<Alert>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }

    public async Task<AlertListPageResponse> List(AlertListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<AlertListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var page = await response.Deserialize<AlertListPageResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<Alert> CreateForCustomer(AlertCreateForCustomerParams parameters)
    {
        HttpRequest<AlertCreateForCustomerParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var alert = await response.Deserialize<Alert>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }

    public async Task<Alert> CreateForExternalCustomer(
        AlertCreateForExternalCustomerParams parameters
    )
    {
        HttpRequest<AlertCreateForExternalCustomerParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var alert = await response.Deserialize<Alert>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }

    public async Task<Alert> CreateForSubscription(AlertCreateForSubscriptionParams parameters)
    {
        HttpRequest<AlertCreateForSubscriptionParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var alert = await response.Deserialize<Alert>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }

    public async Task<Alert> Disable(AlertDisableParams parameters)
    {
        HttpRequest<AlertDisableParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var alert = await response.Deserialize<Alert>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }

    public async Task<Alert> Enable(AlertEnableParams parameters)
    {
        HttpRequest<AlertEnableParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var alert = await response.Deserialize<Alert>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            alert.Validate();
        }
        return alert;
    }
}
