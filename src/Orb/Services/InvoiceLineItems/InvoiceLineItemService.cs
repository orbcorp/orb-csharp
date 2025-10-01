using System.Net.Http;
using System.Threading.Tasks;
using Orb.Core;
using Orb.Models.InvoiceLineItems;

namespace Orb.Services.InvoiceLineItems;

public sealed class InvoiceLineItemService : IInvoiceLineItemService
{
    readonly IOrbClient _client;

    public InvoiceLineItemService(IOrbClient client)
    {
        _client = client;
    }

    public async Task<InvoiceLineItemCreateResponse> Create(InvoiceLineItemCreateParams parameters)
    {
        HttpRequest<InvoiceLineItemCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<InvoiceLineItemCreateResponse>().ConfigureAwait(false);
    }
}
