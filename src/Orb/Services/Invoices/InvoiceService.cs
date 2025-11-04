using System;
using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models;
using Orb.Models.Invoices;

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

    public async Task<Invoice> Create(InvoiceCreateParams parameters)
    {
        HttpRequest<InvoiceCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var invoice = await response.Deserialize<Invoice>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }

    public async Task<Invoice> Update(InvoiceUpdateParams parameters)
    {
        HttpRequest<InvoiceUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var invoice = await response.Deserialize<Invoice>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }

    public async Task<InvoiceListPageResponse> List(InvoiceListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<InvoiceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var page = await response.Deserialize<InvoiceListPageResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<Invoice> Fetch(InvoiceFetchParams parameters)
    {
        HttpRequest<InvoiceFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var invoice = await response.Deserialize<Invoice>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }

    public async Task<InvoiceFetchUpcomingResponse> FetchUpcoming(
        InvoiceFetchUpcomingParams parameters
    )
    {
        HttpRequest<InvoiceFetchUpcomingParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<InvoiceFetchUpcomingResponse>()
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<Invoice> Issue(InvoiceIssueParams parameters)
    {
        HttpRequest<InvoiceIssueParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var invoice = await response.Deserialize<Invoice>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }

    public async Task<Invoice> MarkPaid(InvoiceMarkPaidParams parameters)
    {
        HttpRequest<InvoiceMarkPaidParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var invoice = await response.Deserialize<Invoice>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }

    public async Task<Invoice> Pay(InvoicePayParams parameters)
    {
        HttpRequest<InvoicePayParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var invoice = await response.Deserialize<Invoice>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }

    public async Task<Invoice> Void(InvoiceVoidParams parameters)
    {
        HttpRequest<InvoiceVoidParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var invoice = await response.Deserialize<Invoice>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }
}
