using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.InvoiceLineItems;

namespace Orb.Services.InvoiceLineItems;

public sealed class InvoiceLineItemService : IInvoiceLineItemService
{
    public IInvoiceLineItemService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InvoiceLineItemService(this._client.WithOptions(modifier));
    }

    readonly IOrbClient _client;

    public InvoiceLineItemService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<InvoiceLineItemCreateResponse> Create(
        InvoiceLineItemCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<InvoiceLineItemCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var invoiceLineItem = await response
            .Deserialize<InvoiceLineItemCreateResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            invoiceLineItem.Validate();
        }
        return invoiceLineItem;
    }
}
