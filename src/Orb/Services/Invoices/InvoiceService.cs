using System;
using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Invoices = Orb.Models.Invoices;
using Models = Orb.Models;

namespace Orb.Services.Invoices;

public sealed class InvoiceService : IInvoiceService
{
    public IInvoiceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InvoiceService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public InvoiceService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<Models::Invoice> Create(Invoices::InvoiceCreateParams parameters)
    {
        HttpRequest<Invoices::InvoiceCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var invoice = await response.Deserialize<Models::Invoice>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }

    public async Task<Models::Invoice> Update(Invoices::InvoiceUpdateParams parameters)
    {
        HttpRequest<Invoices::InvoiceUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var invoice = await response.Deserialize<Models::Invoice>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }

    public async Task<Invoices::InvoiceListPageResponse> List(
        Invoices::InvoiceListParams? parameters = null
    )
    {
        parameters ??= new();

        HttpRequest<Invoices::InvoiceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var page = await response
            .Deserialize<Invoices::InvoiceListPageResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<Models::Invoice> Fetch(Invoices::InvoiceFetchParams parameters)
    {
        HttpRequest<Invoices::InvoiceFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var invoice = await response.Deserialize<Models::Invoice>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }

    public async Task<Invoices::InvoiceFetchUpcomingResponse> FetchUpcoming(
        Invoices::InvoiceFetchUpcomingParams parameters
    )
    {
        HttpRequest<Invoices::InvoiceFetchUpcomingParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<Invoices::InvoiceFetchUpcomingResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<Models::Invoice> Issue(Invoices::InvoiceIssueParams parameters)
    {
        HttpRequest<Invoices::InvoiceIssueParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var invoice = await response.Deserialize<Models::Invoice>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }

    public async Task<Models::Invoice> MarkPaid(Invoices::InvoiceMarkPaidParams parameters)
    {
        HttpRequest<Invoices::InvoiceMarkPaidParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var invoice = await response.Deserialize<Models::Invoice>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }

    public async Task<Models::Invoice> Pay(Invoices::InvoicePayParams parameters)
    {
        HttpRequest<Invoices::InvoicePayParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var invoice = await response.Deserialize<Models::Invoice>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }

    public async Task<Models::Invoice> Void(Invoices::InvoiceVoidParams parameters)
    {
        HttpRequest<Invoices::InvoiceVoidParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var invoice = await response.Deserialize<Models::Invoice>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }
}
