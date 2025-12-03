using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;
using Orb.Models.Invoices;

namespace Orb.Services;

/// <inheritdoc/>
public sealed class InvoiceService : IInvoiceService
{
    /// <inheritdoc/>
    public IInvoiceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InvoiceService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public InvoiceService(IOrbClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<Invoice> Create(
        InvoiceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InvoiceCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var invoice = await response.Deserialize<Invoice>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }

    /// <inheritdoc/>
    public async Task<Invoice> Update(
        InvoiceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InvoiceID == null)
        {
            throw new OrbInvalidDataException("'parameters.InvoiceID' cannot be null");
        }

        HttpRequest<InvoiceUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var invoice = await response.Deserialize<Invoice>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }

    /// <inheritdoc/>
    public async Task<Invoice> Update(
        string invoiceID,
        InvoiceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Update(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InvoiceListPageResponse> List(
        InvoiceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<InvoiceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<InvoiceListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    /// <inheritdoc/>
    public async Task<Invoice> Fetch(
        InvoiceFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InvoiceID == null)
        {
            throw new OrbInvalidDataException("'parameters.InvoiceID' cannot be null");
        }

        HttpRequest<InvoiceFetchParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var invoice = await response.Deserialize<Invoice>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }

    /// <inheritdoc/>
    public async Task<Invoice> Fetch(
        string invoiceID,
        InvoiceFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Fetch(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InvoiceFetchUpcomingResponse> FetchUpcoming(
        InvoiceFetchUpcomingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InvoiceFetchUpcomingParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<InvoiceFetchUpcomingResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<Invoice> Issue(
        InvoiceIssueParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InvoiceID == null)
        {
            throw new OrbInvalidDataException("'parameters.InvoiceID' cannot be null");
        }

        HttpRequest<InvoiceIssueParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var invoice = await response.Deserialize<Invoice>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }

    /// <inheritdoc/>
    public async Task<Invoice> Issue(
        string invoiceID,
        InvoiceIssueParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Issue(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Invoice> MarkPaid(
        InvoiceMarkPaidParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InvoiceID == null)
        {
            throw new OrbInvalidDataException("'parameters.InvoiceID' cannot be null");
        }

        HttpRequest<InvoiceMarkPaidParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var invoice = await response.Deserialize<Invoice>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }

    /// <inheritdoc/>
    public async Task<Invoice> MarkPaid(
        string invoiceID,
        InvoiceMarkPaidParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.MarkPaid(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Invoice> Pay(
        InvoicePayParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InvoiceID == null)
        {
            throw new OrbInvalidDataException("'parameters.InvoiceID' cannot be null");
        }

        HttpRequest<InvoicePayParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var invoice = await response.Deserialize<Invoice>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }

    /// <inheritdoc/>
    public async Task<Invoice> Pay(
        string invoiceID,
        InvoicePayParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Pay(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Invoice> Void(
        InvoiceVoidParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InvoiceID == null)
        {
            throw new OrbInvalidDataException("'parameters.InvoiceID' cannot be null");
        }

        HttpRequest<InvoiceVoidParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var invoice = await response.Deserialize<Invoice>(cancellationToken).ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoice.Validate();
        }
        return invoice;
    }

    /// <inheritdoc/>
    public async Task<Invoice> Void(
        string invoiceID,
        InvoiceVoidParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Void(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }
}
