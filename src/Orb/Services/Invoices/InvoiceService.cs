using System;
using System.Net.Http;
using System.Threading;
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

    public async Task<Models::Invoice> Create(
        Invoices::InvoiceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Invoices::InvoiceCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var invoice = await response
            .Deserialize<Models::Invoice>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }

    public async Task<Models::Invoice> Update(
        Invoices::InvoiceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Invoices::InvoiceUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var invoice = await response
            .Deserialize<Models::Invoice>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }

    public async Task<Invoices::InvoiceListPageResponse> List(
        Invoices::InvoiceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<Invoices::InvoiceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<Invoices::InvoiceListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    public async Task<Models::Invoice> Fetch(
        Invoices::InvoiceFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Invoices::InvoiceFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var invoice = await response
            .Deserialize<Models::Invoice>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }

    public async Task<Invoices::InvoiceFetchUpcomingResponse> FetchUpcoming(
        Invoices::InvoiceFetchUpcomingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Invoices::InvoiceFetchUpcomingParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<Invoices::InvoiceFetchUpcomingResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    public async Task<Models::Invoice> Issue(
        Invoices::InvoiceIssueParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Invoices::InvoiceIssueParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var invoice = await response
            .Deserialize<Models::Invoice>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }

    public async Task<Models::Invoice> MarkPaid(
        Invoices::InvoiceMarkPaidParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Invoices::InvoiceMarkPaidParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var invoice = await response
            .Deserialize<Models::Invoice>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }

    public async Task<Models::Invoice> Pay(
        Invoices::InvoicePayParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Invoices::InvoicePayParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var invoice = await response
            .Deserialize<Models::Invoice>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }

    public async Task<Models::Invoice> Void(
        Invoices::InvoiceVoidParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<Invoices::InvoiceVoidParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var invoice = await response
            .Deserialize<Models::Invoice>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }
}
