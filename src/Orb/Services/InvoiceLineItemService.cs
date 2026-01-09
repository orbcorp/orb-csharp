using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.InvoiceLineItems;

namespace Orb.Services;

/// <inheritdoc/>
public sealed class InvoiceLineItemService : IInvoiceLineItemService
{
    readonly Lazy<IInvoiceLineItemServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInvoiceLineItemServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IOrbClient _client;

    /// <inheritdoc/>
    public IInvoiceLineItemService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InvoiceLineItemService(this._client.WithOptions(modifier));
    }

    public InvoiceLineItemService(IOrbClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new InvoiceLineItemServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<InvoiceLineItemCreateResponse> Create(
        InvoiceLineItemCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class InvoiceLineItemServiceWithRawResponse : IInvoiceLineItemServiceWithRawResponse
{
    readonly IOrbClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInvoiceLineItemServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InvoiceLineItemServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InvoiceLineItemServiceWithRawResponse(IOrbClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InvoiceLineItemCreateResponse>> Create(
        InvoiceLineItemCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InvoiceLineItemCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invoiceLineItem = await response
                    .Deserialize<InvoiceLineItemCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invoiceLineItem.Validate();
                }
                return invoiceLineItem;
            }
        );
    }
}
