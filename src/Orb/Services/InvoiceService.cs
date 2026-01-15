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
    readonly Lazy<IInvoiceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInvoiceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public IInvoiceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InvoiceService(this._client.WithOptions(modifier));
    }

    public InvoiceService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() => new InvoiceServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Invoice> Create(
        InvoiceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Invoice> Update(
        InvoiceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Invoice> Update(
        string invoiceID,
        InvoiceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InvoiceListPage> List(
        InvoiceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task DeleteLineItem(
        InvoiceDeleteLineItemParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.DeleteLineItem(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task DeleteLineItem(
        string lineItemID,
        InvoiceDeleteLineItemParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.DeleteLineItem(parameters with { LineItemID = lineItemID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Invoice> Fetch(
        InvoiceFetchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Fetch(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Invoice> Fetch(
        string invoiceID,
        InvoiceFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Fetch(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InvoiceFetchUpcomingResponse> FetchUpcoming(
        InvoiceFetchUpcomingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.FetchUpcoming(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Invoice> Issue(
        InvoiceIssueParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Issue(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Invoice> Issue(
        string invoiceID,
        InvoiceIssueParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Issue(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InvoiceListSummaryPage> ListSummary(
        InvoiceListSummaryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListSummary(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Invoice> MarkPaid(
        InvoiceMarkPaidParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.MarkPaid(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Invoice> MarkPaid(
        string invoiceID,
        InvoiceMarkPaidParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.MarkPaid(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Invoice> Pay(
        InvoicePayParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Pay(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Invoice> Pay(
        string invoiceID,
        InvoicePayParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Pay(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Invoice> Void(
        InvoiceVoidParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Void(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Invoice> Void(
        string invoiceID,
        InvoiceVoidParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Void(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class InvoiceServiceWithRawResponse : IInvoiceServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInvoiceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InvoiceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InvoiceServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Invoice>> Create(
        InvoiceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InvoiceCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invoice = await response.Deserialize<Invoice>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invoice.Validate();
                }
                return invoice;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Invoice>> Update(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invoice = await response.Deserialize<Invoice>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invoice.Validate();
                }
                return invoice;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Invoice>> Update(
        string invoiceID,
        InvoiceUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InvoiceListPage>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<InvoiceListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new InvoiceListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> DeleteLineItem(
        InvoiceDeleteLineItemParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.LineItemID == null)
        {
            throw new OrbInvalidDataException("'parameters.LineItemID' cannot be null");
        }

        HttpRequest<InvoiceDeleteLineItemParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> DeleteLineItem(
        string lineItemID,
        InvoiceDeleteLineItemParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.DeleteLineItem(parameters with { LineItemID = lineItemID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Invoice>> Fetch(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invoice = await response.Deserialize<Invoice>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invoice.Validate();
                }
                return invoice;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Invoice>> Fetch(
        string invoiceID,
        InvoiceFetchParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Fetch(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InvoiceFetchUpcomingResponse>> FetchUpcoming(
        InvoiceFetchUpcomingParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InvoiceFetchUpcomingParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<InvoiceFetchUpcomingResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Invoice>> Issue(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invoice = await response.Deserialize<Invoice>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invoice.Validate();
                }
                return invoice;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Invoice>> Issue(
        string invoiceID,
        InvoiceIssueParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Issue(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InvoiceListSummaryPage>> ListSummary(
        InvoiceListSummaryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<InvoiceListSummaryParams> request = new()
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
                    .Deserialize<InvoiceListSummaryPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new InvoiceListSummaryPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Invoice>> MarkPaid(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invoice = await response.Deserialize<Invoice>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invoice.Validate();
                }
                return invoice;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Invoice>> MarkPaid(
        string invoiceID,
        InvoiceMarkPaidParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.MarkPaid(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Invoice>> Pay(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invoice = await response.Deserialize<Invoice>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invoice.Validate();
                }
                return invoice;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Invoice>> Pay(
        string invoiceID,
        InvoicePayParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Pay(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Invoice>> Void(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invoice = await response.Deserialize<Invoice>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invoice.Validate();
                }
                return invoice;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Invoice>> Void(
        string invoiceID,
        InvoiceVoidParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Void(parameters with { InvoiceID = invoiceID }, cancellationToken);
    }
}
